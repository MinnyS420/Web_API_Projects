# Movie Application

Welcome to the Movie Application, a .NET Web API designed for users to manage their favorite movie genres and create a personalized movie list.

## Overview

The Movie Application provides a secure environment for users to log in, select their preferred movie genres, and list their favorite movies.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (Database)
- JWT for Authentication
- Serilog for Logging

## Application Structure

### 1. CryptoService

Responsible for password hashing using ASCII encoding for enhanced security.

### 2. CustoExceptions

Custom exceptions, including UserDataException, UserNotFoundException, and MoviesCustomException, for better error handling.

### 3. MoviesApp.DataAccess

Manages the database context and repositories, providing abstractions for data access.

### 4. MoviesApp.Domain

Defines modules such as BaseEntity, Movie, and User, along with the Genre enumeration.

### 5. MoviesApp.Helpers

Contains settings for the connection string and dependency injection configuration.

### 6. MoviesApp.Mappers

Manually maps code for improved readability and ease of implementation.

### 7. MoviesApp.Services

Core logic implementation for user and movie functionality.

### 8. MoviesApp.DTOs

Data Transfer Objects (DTOs) for efficient communication between different parts of the application.

### 9. MoviesApp

Houses controllers, database settings, and the main program file (Program.cs). Set this folder as the startup project for execution.

## Password Security

The application employs the CryptoService to hash passwords using ASCII encoding, ensuring an added layer of security.

## How to Run the Application

1. Right-click on the MoviesApp folder.
2. Select "Set as start-up project."
3. Run the program.

## Note on DTOs

DTOs (Data Transfer Objects) facilitate seamless communication between different components of the application, enhancing overall efficiency.
