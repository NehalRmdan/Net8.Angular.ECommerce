# 🛒 Net8 Angular E-Commerce

A full-stack **E-Commerce application** built with **ASP.NET Core (.NET
8)** for the backend and **Angular** for the frontend.\
This project follows a clean, layered architecture and is suitable as a
foundation for real-world enterprise applications.

------------------------------------------------------------------------

## 📌 Overview

This repository contains a sample eCommerce solution that clearly
separates responsibilities between backend APIs, domain logic,
infrastructure, and frontend UI.

It is designed to be **extensible**, allowing future enhancements such
as authentication, payment gateways, and advanced order processing.

------------------------------------------------------------------------

## 🧱 Project Structure

/ ├── API/\
│ └── ASP.NET Core (.NET 8) Web API\
├── Infrastructure/\
│ └── Data access, EF Core, configurations\
├── core/\
│ └── Domain models and business logic\
├── client/\
│ └── Angular frontend application\
├── .gitignore\
└── SportsECommerce.sln

------------------------------------------------------------------------

## 🧩 Architecture Overview

-   **core**\
    Contains domain entities, interfaces, and business rules.

-   **Infrastructure**\
    Responsible for persistence, database access, and external
    integrations.

-   **API**\
    Exposes RESTful endpoints and handles HTTP requests.

-   **client**\
    Angular Single Page Application responsible for UI and API
    consumption.

------------------------------------------------------------------------

## 🚀 Technologies Used

### Backend

-   ASP.NET Core **.NET 8**
-   Entity Framework Core
-   RESTful APIs
-   Clean / Layered Architecture

### Frontend

-   Angular
-   TypeScript
-   HTML
-   SCSS

------------------------------------------------------------------------

## ⚙️ Getting Started

### Prerequisites

-   .NET 8 SDK
-   Node.js (18+ recommended)
-   Angular CLI
-   npm
-   SQL Server or another configured database

------------------------------------------------------------------------

## ▶️ Running the Backend (API)

cd API\
dotnet restore\
dotnet run

------------------------------------------------------------------------

## ▶️ Running the Frontend (Angular)

cd client\
npm install\
ng serve

Open: http://localhost:4200

------------------------------------------------------------------------

## 🔐 Authentication & Payments

-   ❌ No payment gateway integration is included
-   ❌ No external payment providers
-   🔧 Can be extended when needed

------------------------------------------------------------------------

## 🤝 Contributing

1.  Fork the repository\
2.  Create a feature branch\
3.  Commit your changes\
4.  Open a Pull Request

------------------------------------------------------------------------

## 📄 License

No license defined yet.

------------------------------------------------------------------------

## ⭐ Support

If you find this project useful, please give it a ⭐.
