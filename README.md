# Employee Tracking System

This project is an employee tracking system developed using **ASP.NET Core MVC**, **SQL Server**, and **Entity Framework**. It allows admins to view, update, and delete employee information. Additionally, new employees can be added, and detailed information about each employee can be accessed.

## Features

- **Employee Listing:** View employee details including name, email, salary, and position.  
- **Update and Delete Employee Information:** Admins can update or delete employee records.  
- **Add New Employee:** Admins can add new employees to the system.  
- **Database Management:** Database operations are handled using Entity Framework, with all operations managed via migrations.  

## Requirements

- .NET Core 5.0 or higher  
- SQL Server  
- Visual Studio or Visual Studio Code 

## Installation

1. **Clone the project from GitHub to your local machine:**  

   ```bash
   git clone https://github.com/username/repository-name.git

2. **Update the database connection in app.config:**   
Replace [ServerName] with your SQL Server connection details:

    ```bash
    "DefaultConnection": "Server=[ServerName];Database=StaffTrack;Trusted_Connection=True;"
    
3. **Apply migrations to create the database:**
Open a terminal or the Package Manager Console and run:

    ```bash
    Update-Database
    
4.  **Run the project in Visual Studio:**
Open the project, start debugging, and access the application via your browser.

## Usage

- List employees.
- Add new employees.
- Update or delete employee records.
- View detailed employee information in the admin panel.

