# 🚀 Invoice Management System API

A robust Backend Web API designed for handling complex invoice workflows, built with **.NET 8** and **SQL Server**. This project demonstrates the implementation of a comprehensive database schema using **Entity Framework Core (Code First)** approach.

## 📌 Project Overview
The goal of this project is to provide a scalable and well-structured API for managing business transactions, ranging from geographic master data and customer management to detailed invoicing and order tracking.

## 🛠 Tech Stack
- **Framework:** .NET 8 (ASP.NET Core Web API)
- **Database:** SQL Server (Express Edition)
- **ORM:** Entity Framework Core (EF Core)
- **API Documentation:** Swagger / OpenAPI
- **Version Control:** Git & GitHub

## 📊 Database Architecture
The system is architected into several logical modules:
- **Location Module:** Regions, Provinces, Cities
- **Business CRM:** Companies, Suppliers, Customers
- **Catalog Module:** Categories, Products
- **Sales Engine:** Orders, OrderItems, OrderStatuses
- **Billing Module:** Invoices, InvoiceStatuses

## 🚀 Getting Started

### 1. Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

### 2. Database Configuration
Update the connection string in `appsettings.json` to match your local SQL Server instance:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=InvoiceManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

### 3. SP Configuration
- Sript is exits on `Script > StoredProcedures` folder, you must run all script to create stored procedure in your database.

### 4. View Configuration
- Sript is exits on `Script > View` folder, you must run the script in file '1_viewSql' to create stored procedure in your database.

Hope it's useful for you, if you have any question please let me know.

glhf :)