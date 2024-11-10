
# Login Use Case Documentation

## Overview
The **Login** use case allows users to authenticate via their username or email and password. On successful authentication, an access token and refresh token are generated, enabling session management and ensuring secure access to resources.

---

## Components Involved

### 1. **Controller**: `AuthenticationController`
- **Endpoint**: `POST /auth/login`
- **Handler**: `LoginUserHandler`

### 2. **Data Transfer Object (DTO)**: `LoginUserRequest`
- **Fields**:
  - `UsernameOrEmail` (string): User's email or username.
  - `Password` (string): User's password.

### 3. **Handler**: `LoginUserHandler`
- **Responsibilities**:
  - Validate user credentials.
  - Generate and return access and refresh tokens on successful login.
  - Revoke previous refresh tokens to ensure secure session handling.

---

## Login Workflow

### Endpoint
```http
POST /auth/login
```

### Request Payload
```json
{
    "UsernameOrEmail": "user@example.com",
    "Password": "YourPassword123"
}
```

### Response Example
- **On Success** (200 OK):
  ```json
  {
      "accessToken": {
          "token": "access_token_string",
          "expirationDate": "2024-11-10T15:16:31.531Z"
      }
  }
  ```
  - **Cookie**: `RefreshToken` containing the refresh token with expiration date.

- **On Failure**:
  ```json
  {
      "type": "https://httpstatuses.com/401",
      "title": "Unauthorized",
      "status": 401,
      "detail": "Invalid username or password"
  }
  ```

---

## Implementation Details

### AuthenticationController.cs

This controller manages authentication-related endpoints, including login, registration, and token refreshing.

```csharp
[HttpPost("login")]
[AllowAnonymous]
public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
{
    var result = await _sender.Send(new LoginUserCommand(request.UsernameOrEmail, request.Password));

    return result.Match(
        onSuccess: loginResponse =>
        {
            CookieHelper.SetCookie(
                Response,
                nameof(RefreshToken),
                loginResponse.RefreshToken.Token,
                loginResponse.RefreshToken.ExpirationDate);

            return Ok(loginResponse.AccessToken);
        },
        onFailure: ApiResults.Problem);
}
```

### LoginUserHandler.cs

The `LoginUserHandler` performs the primary responsibilities for handling login requests:
- **Retrieves** the user based on their email/username.
- **Validates** the password.
- **Generates** a new access token and refresh token.
- **Revokes** any existing active refresh tokens to prevent multiple active sessions.

```csharp
public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
{
    // Retrieve and validate user
    var userByEmailOrUsernameSpecification = new UserByEmailOrUsernameSpecification(request.EmailOrUsername);
    var user = await _unitOfWork.UserRepository.GetBySpecificationAsync(userByEmailOrUsernameSpecification);
    if (user is null)
        return Result.Failure<LoginUserResponse>(UserErrors.UserNotFound);

    if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
        return Result.Failure<LoginUserResponse>(UserErrors.UserInvalidCredentials);

    // Generate access token and refresh token
    var accessTokenResponse = _authTokenService.GenerateAccessToken(user);
    var refreshTokenResponse = _authTokenService.GenerateRefreshToken();

    // Revoke old tokens
    var activeRefreshTokenSpecification = new ActiveRefreshTokensByUserIdSpecification(user.Id);
    var oldRefreshTokens = await _unitOfWork.RefreshTokenRepository.GetListBySpecificationAsync(activeRefreshTokenSpecification);
    foreach (var token in oldRefreshTokens)
    {
        token.Revoke();
        _unitOfWork.RefreshTokenRepository.Update(token);
    }

    // Create new refresh token
    var newRefreshToken = RefreshToken.Create(refreshTokenResponse.Token, refreshTokenResponse.ExpirationDate, user);
    if (newRefreshToken.IsFailure)
        return Result.Failure<LoginUserResponse>(newRefreshToken.Error);

    await _unitOfWork.RefreshTokenRepository.AddAsync(newRefreshToken.Value);
    await _unitOfWork.CommitAsync(cancellationToken);

    return Result.Success(new LoginUserResponse(accessTokenResponse, refreshTokenResponse));
}
```

---

## Error Handling

- **User Not Found**: If the username/email is invalid, the handler returns a `401 Unauthorized` response with the error `UserErrors.UserNotFound`.
- **Invalid Password**: If the password is incorrect, a `401 Unauthorized` response is returned with `UserErrors.UserInvalidCredentials`.
- **Token Errors**: Issues with token generation or storage are captured and returned as error results.

---

## Related Endpoints

- **Register User**: `POST /auth/register`
- **Get Current User**: `GET /auth/me`
- **Refresh Token**: `POST /auth/refresh-token`

## Notes

- **Security**: Both access and refresh tokens should be stored securely. The access token is returned in the response body, while the refresh token is set in a `HttpOnly` cookie.
- **Token Expiration**: The access token has a shorter lifespan and should be refreshed regularly using the `Refresh Token` endpoint.

---

## Summary

The login feature provides a comprehensive approach to secure user authentication, utilizing:

1. Access and refresh tokens for session management.
2. `LoginUserHandler` for validating credentials and handling token generation.
3. Revoking old refresh tokens to enforce single-session security.

Refer to the [Authentication Overview](./AuthenticationOverview.md) for additional information on security and token handling.
