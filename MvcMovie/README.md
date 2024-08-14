# MvcMovie

**MvcMovie** is an ASP.NET Core Web App (Model-View-Controller) designed to manage movie information. Users can Add, Delete, Update, and Read movie data from a database, using the website as the front-end interface. The application is built using ASP.NET Core MVC and employs Entity Framework for data access, adhering to the Code First approach. Raw SQL queries are not allowed, and the application utilizes SQL Server as the database.

## Features
- **CRUD Operations**: Add, Delete, Update, and Read movie information.
- **Search Functionality**: Search movies by name.
- **Entity Framework**: Code First approach for database management.
- **SQL Server**: Uses SQL Server as the database, not SQLite.

## Technologies
- ASP.NET Core MVC (Model-View-Controller)
- Entity Framework Core (Code First)
- SQL Server

## Getting Started
1. Clone the repository.
2. Restore dependencies with `dotnet restore`.
3. Apply migrations with `dotnet ef database update`.
4. Run the application using `dotnet run`.

