Claro! Aqui está o `README.md` com as correções solicitadas:

# BallastLaneBackEnd Project

## Overview

This repository contains the BallastLaneBackEnd project, developed as a response to a technical exercise for a .NET Developer position. The project is built using .NET 6 and follows Domain-Driven Design (DDD) principles. It includes a Web API, authentication using JWT, and unit testing using xUnit, Moq, and the Triple A pattern.

## Project Structure

The project is organized into the following directories:

### BallastLaneBackEnd.Api
Contains the Web API project.
- **Controllers**: Contains the API controllers (`ClassController.cs`, `LoginController.cs`, `StudentController.cs`, `SubjectController.cs`, `TeacherController.cs`).
- **Handler**: Contains the API key handler (`ApiKeyHandler.cs`).
- **Validation**: Contains the API key validation logic (`ApiKeyValidation.cs`).
- **Configuration Files**: `appsettings.json`, `appsettings.Development.json`, `Dockerfile`.
- **Entry Point**: `Program.cs`.

### BallastLaneBackEnd.Application
Contains the application layer logic and services.
- **Authentication**: Contains JWT token generation (`TokenGenerator.cs`).
- **Services**: Contains various service implementations (`ClassesService.cs`, `StudentService.cs`, `SubjectService.cs`, `TeacherService.cs`, `UserService.cs`).
- **Mappings**: Contains mapping configurations (`ClassMapper.cs`, `StudentMapper.cs`, `SubjectMapper.cs`, `TeacherMapper.cs`).

### BallastLaneBackEnd.CrossCutting.IoC
Contains dependency injection configurations and extensions.
- **IoCExtensions.cs**: Contains IoC container extensions.

### BallastLaneBackEnd.Domain
Contains domain entities, interfaces, DTOs, and utility classes.
- **Entities**: Domain models (`Class.cs`, `Student.cs`, `Subject.cs`, `Teacher.cs`, `User.cs`).
- **Interfaces**: Repository and service interfaces.
- **DTOs**: Data Transfer Objects for various entities.
- **Authentication**: Interface for token generation (`ITokenGenerator.cs`).
- **Common**: Common functions (`Functions.cs`).
- **Util**: Utility classes (`Settings.cs`).

### BallastLaneBackEnd.Infra
Contains the infrastructure layer, including data access and initialization logic.
- **Repositories**: Implementation of repositories (`ClassRepository.cs`, `StudentRepository.cs`, `SubjectRepository.cs`, `TeacherRepository.cs`, `UserRepository.cs`).
- **Initializer**: Database initializer (`DbInitializer.cs`).
- **Context**: Database context (`SchoolContext.cs`).

### BallastLaneBackEnd.Test
Contains unit tests for the application.
- **Application**: Unit tests for application services (`ClassServiceTests.cs`).

## Getting Started

### Prerequisites
- .NET 6 SDK
- Docker (optional, for containerization)
- SQL Server (or any other configured database)

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/BallastLaneBackEnd.git
    cd BallastLaneBackEnd
    ```

2. Build the solution:
    ```bash
    dotnet build
    ```

3. Update the connection string in `appsettings.json` as per your database configuration.

4. Apply migrations and initialize the database:
    ```bash
    dotnet ef database update
    ```

### Running the Application
1. Run the API project:
    ```bash
    cd BallastLaneBackEnd.Api
    dotnet run
    ```

2. The API will be available at `https://localhost:5093` or `http://localhost:7168`.

### Running Tests
1. Navigate to the test project and run the tests:
    ```bash
    cd BallastLaneBackEnd.Test
    dotnet test
    ```

## Features
- **Authentication**: JWT-based authentication.
- **CRUD Operations**: CRUD operations for classes, students, subjects, teachers, and users.
- **Unit Testing**: Comprehensive unit tests using xUnit, Moq, and Triple A pattern.

## Technologies Used
- **.NET 6**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **JWT Authentication**
- **xUnit** (for unit testing)
- **Moq** (for mocking in unit tests)
- **Docker** (for containerization)
- **DDD** (Domain-Driven Design)

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Feel free to customize the above `README.md` as per your specific requirements or preferences.