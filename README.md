# Clean Architecture Template

This repository contains a template for building ASP.NET Core applications following the principles of Clean Architecture. The project is structured with separate layers for Domain, Application, Infrastructure, and API, ensuring separation of concerns and maintainability. The template also incorporates modern development practices like DDD (Domain-Driven Design), SOLID principles, and the use of the Specification Pattern.

## Project Structure

The solution is organized into the following projects:

- **CleanArchitecture.Template.Domain**: Contains the core business logic and domain entities. This layer is independent of other layers and represents the heart of the application.
- **CleanArchitecture.Template.Application**: Implements the use cases of the system. This layer coordinates between the domain and infrastructure layers, handling application-specific logic.
- **CleanArchitecture.Template.Infrastructure**: Contains the implementation of external services, database access (EF Core), and repositories. This layer depends on both the Application and Domain layers.
- **CleanArchitecture.Template.Api**: Exposes the application via HTTP APIs. This layer depends on the Application layer and handles incoming HTTP requests.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (for database and containerized development)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (or any other supported relational database)

### Installation

1. **Clone the repository:**

   ```bash``````
   git clone https://github.com/your-username/CleanArchitecture.Template.git
   cd CleanArchitecture.Template

2. **Configure the Database:**

If you're using Docker, you can run the SQL Server container:

bash```
docker-compose up -d```

Alternatively, update the connection string in the appsettings.Development.json file under the CleanArchitecture.Template.Api project to match your local SQL Server setup.

**Apply Migrations:**

Run the following command to apply the database migrations:

bash```
dotnet ef database update --project CleanArchitecture.Template.Infrastructure --startup-project CleanArchitecture.Template.Api```

Run the Application:

Start the application by running the following command:

bash```
dotnet run --project CleanArchitecture.Template.Api```

The API will be available at https://localhost:7058

## Features

- Clean Architecture: Follows the principles of Clean Architecture with clear separation of concerns between layers.
DDD and SOLID Principles: Applies Domain-Driven Design and SOLID principles for maintainable and testable code.

- Specification Pattern: Implements the Specification Pattern for flexible and reusable query logic.
- Result Pattern: A robust pattern for handling success and failure across the application.
- Entity Framework Core: Integrated with EF Core for database access, using repository and unit of work patterns.
- Dependency Injection: Fully configured dependency injection using ASP.NET Core's built-in DI container.
- Docker Support: Pre-configured Docker support for running SQL Server in a containerized environment.

## Usage

- **API Endpoints**
The project exposes several API endpoints for managing WeatherForecast entities. You can use tools like Postman or Swagger to interact with the API.

- GET /weatherforecast/{id}: Get a WeatherForecast by ID.
- GET /weatherforecast: Get a paginated, filtered, and sorted list of WeatherForecasts.
- GET /weatherforecast/all: Get all WeatherForecasts.
- POST /weatherforecast: Create a new WeatherForecast.

- **Logging**
The project uses ASP.NET Core's built-in logging system, with a future plan to integrate a more robust logging solution like Serilog.

- **Testing**
Unit tests are implemented using xUnit. To run the tests, use the following command:

bash```dotnet test```

- **Future Enhancements**
Integration of MediatR for command and query handling.
Serilog integration for enhanced logging and structured log output.
Improved error handling and validation.
Contributing
Contributions are welcome! Please follow these steps:

Fork the repository.
Create a new branch (git checkout -b feature/my-feature).
Commit your changes (git commit -am 'Add my feature').
Push to the branch (git push origin feature/my-feature).
Open a Pull Request.
License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
If you have any questions or suggestions, feel free to reach out to the repository owner.