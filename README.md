
# Clean Architecture Template - .NET Core API

## Overview

This project serves as a **template** to implement the **Clean Architecture** pattern in .NET applications. The aim is to provide a scalable, maintainable, and testable foundation for building modern web APIs using industry-standard best practices. 

The design leverages **CQRS**, **MediatR**, and **DDD** patterns to ensure separation of concerns, decoupling of logic, and ease of extensibility. This template also offers pre-configured layers to handle API requests, application logic, domain rules, and infrastructure concerns independently.

---

## Key Design Patterns

### 1. **Clean Architecture**

- Clean Architecture is employed to decouple the core logic (domain and application) from external concerns (infrastructure, UI, or services). This keeps the application flexible for future adaptations such as using different databases or presenting data in various formats.
- It ensures that the domain and business logic are central, with surrounding layers dependent on it, and not vice versa.

### 2. **Command Query Responsibility Segregation (CQRS)**

- **CQRS** is used to separate the responsibilities of reading and writing data. 
- Queries are handled separately from commands, ensuring that the logic is split between handling actions that change state (commands) and actions that retrieve data (queries).

### 3. **Domain-Driven Design (DDD)**

- The core **Domain** layer contains entities, value objects, and aggregates that encapsulate the business rules and logic.
- The template is designed to handle complex business logic using DDD principles, providing structure and clarity.

### 4. **MediatR**

- **MediatR** is used to implement the **CQRS** pattern by decoupling the request from the actual implementation (handler).
- It facilitates handling commands and queries through handlers, promoting separation of concerns and single responsibility.

### 5. **Repository Pattern**

- The **Repository Pattern** is implemented within the **Infrastructure** layer to handle data access. 
- This isolates the database operations from the domain logic, allowing easy substitution of the data source.

---

## Features

- **CQRS with MediatR**: Command-Query separation with MediatR for handling requests.
- **Domain-Driven Design (DDD)**: Core business logic resides in the domain layer.
- **Entity Framework Core**: The ORM is integrated for persistence in the infrastructure layer.
- **Unit of Work Pattern**: Ensure atomicity when interacting with the database.
- **Docker Support**: The project is containerized for easy deployment.
- **Validation**: Uses FluentValidation for request validation.

---

## Project Structure

```bash
├── CleanArchitecture.Template.Api                # API layer (Controllers, Requests, DTOs)
├── CleanArchitecture.Template.Application        # Application layer (Commands, Queries, Handlers, Services)
├── CleanArchitecture.Template.Domain             # Domain layer (Entities, Aggregates, Value Objects, Specifications)
├── CleanArchitecture.Template.Infrastructure     # Infrastructure layer (Persistence, Migrations, Repositories)
├── CleanArchitecture.Template.SharedKernel       # Shared kernel (Common logic, Errors, Results)
├── CleanArchitecture.Template.Tests              # Unit and Integration tests
└── docker-compose.yml                            # Docker configuration
```

---

## Design Choices

### Separation of Concerns

Each layer is responsible for its own task:
- **API Layer**: This layer handles HTTP requests and serves as the gateway to the system. The controllers are lightweight and delegate the business logic to the **Application Layer**.
- **Application Layer**: Contains all business use cases in the form of commands and queries. This layer is isolated from the infrastructure and manages operations through the use of MediatR.
- **Domain Layer**: Implements the core business logic using **Entities**, **Value Objects**, and **Aggregates**. Business rules and policies reside here.
- **Infrastructure Layer**: This layer contains the data persistence logic. By using repositories, it abstracts the database interactions and ensures persistence is decoupled from business logic.

### Result Pattern for Error Handling

The project follows a **Result<T> pattern** to handle success/failure scenarios across all operations. This pattern simplifies error handling, as every operation returns either a success or a failure result. 

```csharp
public class Result<TValue>
{
    public TValue Value { get; }
    public bool IsSuccess { get; }
    public Error Error { get; }

    public static Result<TValue> Success(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure(Error error) => new(default, false, error);
}
```

### FluentValidation for Request Validation

To ensure clean and robust request validation, **FluentValidation** is integrated. This pattern allows for a modular and maintainable approach to validate incoming data.

---

## Setting Up

### Prerequisites

- **.NET SDK 8.0+**
- **Docker**
- **SQL Server** (or use an in-memory database)

### Running the Application

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repo/CleanArchitecture.Template.git
   cd CleanArchitecture.Template
   ```

2. Build and run the Docker containers (ensure Docker is running):

   ```bash
   docker-compose up --build
   ```

3. Access the API:

   - **Swagger UI**: `http://localhost:8080/swagger`
   - **API base URL**: `http://localhost:8080`

---

## Environment Configuration

- Use `appsettings.{Environment}.json` for environment-specific settings (e.g., Development, Production).
- The environment is set via the **ASPNETCORE_ENVIRONMENT** variable.

---

## Testing

Unit tests are written using **xUnit**. Run tests with:

```bash
dotnet test
```

---

## License

This project is licensed under the MIT License.

---

## Contributing

Feel free to submit issues or pull requests. Contributions are welcome to enhance the features and stability of this template.

