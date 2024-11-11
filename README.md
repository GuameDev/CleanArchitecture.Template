
# Clean Architecture Template

![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/YourUsername/CleanArchitecture.Template/.github/workflows/dotnet.yml?branch=develop)
![License](https://img.shields.io/badge/License-MIT-green)

> A .NET project template implementing Clean Architecture, focusing on DDD principles, unit testing, and RESTful API design. This template uses 5 layers to ensure modularity and separation of concerns, and it supports token-based authentication.

---

## 🗂 Project Structure

- **src/**
  - `Api` - Controllers and API configuration (e.g., Swagger, API responses)
  - `Application` - Application layer with CQRS, MediatR handlers, DTOs, and commands/queries.
  - `Domain` - Domain models, entities, and core business logic.
  - `Infrastructure` - Database configuration, data access, and external services.
  - `SharedKernel` - Common types, constants, and cross-cutting concerns.
  - `Host` - Application setup and main entry point (Program.cs and configuration).
- **tests/**
  - Separate unit tests for each layer to ensure isolation and robustness.
  
---

## 🚀 Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/YourUsername/CleanArchitecture.Template.git
   ```

2. **Navigate to the source directory**:
   ```bash
   cd src
   ```

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Build the solution**:
   ```bash
   dotnet build
   ```

5. **Run the project**:
   ```bash
   dotnet run --project CleanArchitecture.Template.Host
   ```

---

## 🔧 Configuration

- **Environment Variables**: Set up necessary environment variables, like database connections and JWT keys.
- **Docker Support**: Optionally, run the project using Docker.

---

## 📜 Documentation

### 📁 `docs/` Folder

Comprehensive documentation is located in the `docs/` folder, structured as follows:
- `features/authentication` - Detailed markdown documentation for authentication, login, and token refresh flows.
- `postman` - Pre-configured Postman collection for testing endpoints.
- `setup` - Guide to run migrations using Entity Framework Core, ensuring seamless database setup.

---

## 🧪 Testing

1. **Run Unit Tests**:
   ```bash
   dotnet test
   ```

2. **Continuous Integration**:
   GitHub Actions are set up to automatically run tests on each push to `main` and `develop` branches, ensuring that new changes don’t break existing functionality.

---

## 🛠 Tooling

- **Swagger**: API documentation available at `/swagger` when running the project.
- **Postman Collection**: [Available in `docs/postman`](docs/postman) to test API endpoints for authentication, user management, and health checks.

---

## 💻 CI/CD Pipeline

The project uses GitHub Actions for CI/CD, with the following workflow:
- **.NET Build & Test**: Runs on each push to `main` and `develop`, performing `restore`, `build`, and `test` operations.

---

## 🛠 Key Features

- **Modular Architecture**: Divides responsibilities across API, Application, Domain, Infrastructure, SharedKernel, and Host layers.
- **Authentication & Authorization**: JWT-based token authentication with refresh token mechanism.
- **Documentation**: Detailed feature documentation and Postman collection to ease testing and integration.
- **Docker Support**: Optionally run the project in Docker for a standardized environment.

---

## 📜 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for details.

---

Happy coding! 🎉
