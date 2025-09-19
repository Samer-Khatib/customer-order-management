# Customer Order Management

A C# .NET 8 console application for managing products, customers, and orders.  
Implements a **layered architecture** with support for **JSON data storage**, **logging**, and comprehensive **unit testing**.

## Features
- Manage customers, products, and orders
- Data storage with JSON serialization (Newtonsoft.Json)
- Structured logging with Microsoft.Extensions.Logging
- Layered architecture (Models, Services, Repositories)
- Unit tests using NUnit and Moq

## Tech Stack
- C# / .NET 8
- Newtonsoft.Json
- Microsoft.Extensions.Logging
- NUnit & Moq
- Visual Studio 2022

## Run locally
1. Clone the repository
2. Open the solution in Visual Studio 2022
3. Run the application from `Program.cs`

## Tests
Run tests from Visual Studio Test Explorer or with:
```bash
dotnet test
