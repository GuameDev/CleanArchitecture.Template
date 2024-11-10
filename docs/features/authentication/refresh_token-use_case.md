
# Refresh Token Use Case

## Overview

The **Refresh Token** use case is responsible for generating a new Access Token and Refresh Token upon request. This process involves verifying the provided Refresh Token, revoking it if valid, and issuing a new set of tokens. This flow supports single device login by ensuring that only one active refresh token is linked to a user at any time.

---

## Implementation

The **RefreshTokenHandler** is the main class that implements this use case.

### Code Structure

```csharp
public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthTokenService _authTokenService;

    public RefreshTokenHandler(IUnitOfWork unitOfWork, IAuthTokenService authTokenService)
    {
        _unitOfWork = unitOfWork;
        _authTokenService = authTokenService;
    }

    public async Task<Result<RefreshTokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the refresh token
        var refreshToken = await _unitOfWork.RefreshTokenRepository.GetBySpecificationAsync(
            new RefreshTokenByTokenSpecification(request.Token));

        if (refreshToken == null || refreshToken.IsRevoked || refreshToken.ExpirationDate < DateTime.UtcNow)
            return Result.Failure<RefreshTokenResponse>(RefreshTokenErrors.TokenInvalidOrExpired);

        // Revoke the old token
        refreshToken.Revoke();
        _unitOfWork.RefreshTokenRepository.Update(refreshToken);

        // Generate new tokens
        var user = refreshToken.User;
        var newAccessTokenResponse = _authTokenService.GenerateAccessToken(user);
        var newRefreshTokenResponse = _authTokenService.GenerateRefreshToken();

        // Create and save the new refresh token
        var newRefreshToken = RefreshToken.Create(
            newRefreshTokenResponse.Token,
            newRefreshTokenResponse.ExpirationDate,
            user);

        if (newRefreshToken.IsFailure)
            return Result.Failure<RefreshTokenResponse>(newRefreshToken.Error);

        await _unitOfWork.RefreshTokenRepository.AddAsync(newRefreshToken.Value);
        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success(new RefreshTokenResponse(
            new(newAccessTokenResponse.Token, newAccessTokenResponse.ExpirationDate),
            new(newRefreshTokenResponse.Token, newRefreshTokenResponse.ExpirationDate)));
    }
}
```

### Steps

1. **Retrieve the Refresh Token**: The handler uses `RefreshTokenByTokenSpecification` to fetch the token from the database.
2. **Validation**: If the token is null, revoked, or expired, a failure response is returned.
3. **Revoke Token**: The existing refresh token is revoked to ensure a single active token per user.
4. **Generate New Tokens**: 
   - A new Access Token is generated with user details.
   - A new Refresh Token is generated for future requests.
5. **Save the New Token**: 
   - The new refresh token is saved to the repository.
   - Changes are committed to the database.

---

## API Endpoint

The `POST /auth/refresh-token` endpoint triggers this flow.

### Request

No request body is required, as the **Refresh Token** is provided via cookies.

### Response

- **On Success**: A new Access Token is returned in the response body, and a new Refresh Token is set as an HTTP-only cookie.
- **On Failure**: Returns a problem response indicating an invalid or expired Refresh Token.

---

## Example Usage

```http
POST /auth/refresh-token HTTP/1.1
Host: yourapi.com
Cookie: RefreshToken=<your_refresh_token>

Response:
Status: 200 OK
{
    "token": "new_access_token_here",
    "expirationDate": "2024-11-10T15:16:31.5315458Z"
}
```

---

## Remarks

- **Security**: Ensure HTTPS is used to protect Refresh Tokens in transit.
- **Scalability**: This design supports a scalable, stateless session management approach by limiting active refresh tokens per user.

