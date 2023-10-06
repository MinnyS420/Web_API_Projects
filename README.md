# Web-API Project Showcase

Welcome to my collection of **Web API Projects** that demonstrate the power and versatility of building modern APIs. Each project is carefully crafted to deliver practical solutions while showcasing the principles of robust API design.

In the fast-paced world of software development, creating efficient and reliable Web APIs is essential for building scalable and interconnected applications. Whether you are a seasoned developer or just starting your journey, these projects will provide valuable insights into building and managing Web APIs effectively.

---


# SEDC NoteApp

**Version: 1.1.0 Stable**

SEDC NoteApp is a simple application for taking notes. It allows users to register, log in, and manage their notes. The application is built on ASP.NET Core using Entity Framework Core for data management.

## Features

### User Management

- Users can register with their first name, last name, username, age, and password.
- Passwords are securely hashed before being stored in the database.
- Users can log in using their username and password.

### Note Management

- Authenticated users can create, view, update, and delete their notes.
- Each note has a text content, priority level, and a tag.

### Priorities and Tags

- Notes can be assigned priority levels (Low, Medium, High).
- Notes can be tagged with categories (Work, Health, Social Life).

### Token-Based Authentication

- User authentication is managed through JSON Web Tokens (JWT).
- Tokens are generated upon successful login and used for subsequent requests.

### Error Handling

- The application handles common errors such as invalid input, missing data, and unauthorized access gracefully.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (Database)
- JWT for Authentication
- Serilog for Logging

## Getting Started

1. **Prerequisites**

    - [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

2. **Database Setup**

    - Ensure that a SQL Server instance is available.
    - Update the connection string in the `appsettings.json` file.

3. **Running the Application**

    - Use the following command in the terminal:

    ```
    dotnet run --project SEDC.NoteApp.Api
    ```

4. **Accessing the Application**

    - Open a web browser and go to `http://localhost:5000` (or the appropriate port).

5. **API Documentation**

    - The API is documented using Swagger UI. Navigate to `http://localhost:5000/swagger` for detailed API documentation.

## Contributing

If you'd like to contribute, please fork the repository and make changes as you see fit. Pull requests are warmly welcome.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments

This project was created as a part of the Software Engineering Daily Community (SEDC) courses. Special thanks to the instructors and contributors.

---

For any further questions or assistance, please don't hesitate to contact us. Happy Note Taking!


