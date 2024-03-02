# Product Management System
## Description
Product Management System is a comprehensive solution designed for managing groups and products. It offers a robust set of features including group creation, editing, deletion, and hierarchical structuring, as well as product management with support for various attributes and associations.

## Technology Stack
- Backend: ASP.NET Core Web API
- Database: Entity Framework Core (Code-First Approach)
- ORM: Entity Framework Core
- Validation: FluentValidation
- Object Mapping: AutoMapper
- Logging: (Optional - You can specify if you're using any logging library like NLog, Serilog, etc.)
- Authentication/Authorization: (Optional - Specify if used, e.g., JWT, OAuth)

## Getting Started
### Prerequisites
- .NET 6.0 SDK or later
- SQL Server (or any other EF Core supported database)
- Visual Studio (recommended) or another .NET-compatible IDE

## Installation
1. Clone the repository:

`git clone https://github.com/TarielTopuria/ProductManagementService.git`

4. Navigate to the project directory and restore the dependencies:

`cd [project directory]`

`dotnet restore`

7. Update the database connection string in appsettings.json.
8. Apply migrations to your database:

`dotnet ef database update`

Running the Application
1. Run the application using:

`dotnet run`

3. Access the API through the specified port, for example, http://localhost:5000.

## Usage
API Endpoints

### Groups
- GET /api/groups: Retrieves all groups.
- POST /api/groups/createGroup: Creates a new group.
- PUT /api/groups/{id}: Updates an existing group.
- DELETE /api/groups/{id}: Deletes a group.

### Products
- GET /api/products: Retrieves all products.
- POST /api/products/createProduct: Creates a new product.
- PUT /api/products/{id}: Updates an existing product.
- DELETE /api/products/{id}: Deletes a product.

### Validations
Group and product data are validated using FluentValidation.

### Testing
(Provide instructions on how to run any tests that you have written for your project.)

## Contact
- tatotophuria@gmail.com
- Project Link: https://github.com/TarielTopuria/ProductManagementService
