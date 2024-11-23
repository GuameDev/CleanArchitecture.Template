
# Criteria-Specification Pattern

## Summary

The Criteria-Specification pattern is a design approach used to encapsulate query logic in a reusable and maintainable way. It enables developers to separate the logic for filtering, sorting, and including related entities from the underlying data access layer, ensuring cleaner and more testable code.

This pattern is particularly useful in Domain-Driven Design (DDD) and Clean Architecture, where clear separation of concerns is critical.

## Explanation of the Pattern

### **Criteria**

- Represents a reusable, atomic predicate (i.e., filtering logic) that can be applied to a query.
- Encapsulates domain logic in a single, well-defined expression (e.g., "find a user by email").
- Operates exclusively within the **Domain Layer**.

### **Specification**

- Combines multiple criterias and additional application-specific logic, such as pagination and sorting.
- Defines the behavior of a query tailored to a specific use case or application requirement.
- Operates within the **Application Layer** because it often depends on external inputs, such as DTOs or query objects.

## Your Current Implementation

In your project, you've implemented the Criteria-Specification pattern as follows:

### **Domain Layer**

- Houses all `Criteria` classes, which define reusable predicates encapsulating domain logic.
- Example:

    ```csharp
    public class UserByEmailCriteria : Criteria<User>
    {
        private readonly string _email;

        public UserByEmailCriteria(string email)
        {
            _email = email;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Email.Value == _email;
        }
    }
    ```

### **Application Layer**

- Houses `Specification` classes, which use domain-level criterias to build queries specific to use cases.
- Specifications also handle application-specific details, such as sorting and pagination.
- Example:

    ```csharp
    public class UserByEmailOrUsernameSpecification : Specification<User>
    {
        public UserByEmailOrUsernameSpecification(string email, string username)
        {
            AddCriteria(new UserByEmailCriteria(email));
            Or(new UserByUsernameCriteria(username));

            AddInclude(user => user.Roles);
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
    }
    ```

## Why Keep Criterias and Specifications in Separate Layers?

### **Separation of Concerns**

- **Criterias** represent pure domain logic, encapsulating reusable predicates for querying entities. They belong in the domain layer to maintain a clean boundary between domain logic and application-specific requirements.
- **Specifications** represent use-case-specific logic. They combine criterias with application details (e.g., DTOs, sorting, pagination), making them more suitable for the application layer.

### **Reusability**

- **Domain Criterias** can be reused across different specifications and services, ensuring consistency and maintainability.
- **Application Specifications** are tailored to specific use cases, leveraging criterias for clean composition.

### **Cleaner Code**

- Separating criterias and specifications avoids coupling domain logic to application details (e.g., DTOs or query objects).
- The domain layer remains focused on business logic, while the application layer manages use-case-specific query orchestration.

### **Future Proofing**

- By isolating criterias in the domain, you ensure that domain logic remains unchanged if new application layers (e.g., GraphQL or gRPC) are introduced.
- Specifications can evolve independently to support new use cases or query requirements.

## Final Structure

### Domain Layer

- `Domain/Users/Criterias`
    - `UserByEmailCriteria.cs`
    - `UserByUsernameCriteria.cs`
    - `UserByIdCriteria.cs`

### Application Layer

- `Application/Users/Specifications/UserSpecifications`
    - `UserByEmailOrUsernameSpecification.cs`

- `Application/WeatherForecasts/Specifications`
    - `WeatherForecastSpecification.cs`

This structure ensures a clean separation of concerns, making your code more maintainable, reusable, and aligned with the principles of Clean Architecture.

---

## Conclusion

The Criteria-Specification pattern is a powerful way to organize query logic in your application. By separating criterias and specifications across the domain and application layers, respectively, you achieve:

- Clear boundaries between domain and application logic.
- Better reusability of domain predicates.
- Easier maintainability and future-proofing of your codebase.
