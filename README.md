
**Ecom** is a powerful, enterprise-grade e-commerce solution crafted with **ASP.NET Core** for the backend and **Angular 9+** for the frontend. It features a modular, scalable, and maintainable layered architecture separating API, business logic, and infrastructure. This project embodies industry best practices, advanced design patterns, and secure architecture — perfect as a reference or boilerplate for professional online stores.

## 🚀 Key Highlights

- Production-ready, clean architecture fostering scalability and reusability  
- Robust API with JWT authentication via ASP.NET Identity  
- Angular frontend with lazy loading, reactive multi-step forms, and reusable components  
- Integration of Stripe payment gateway compliant with EU 3D Secure standards  
- Advanced backend patterns: Repository, Unit of Work, Specification patterns  
- Multi-DbContext setup for identity and domain separation  
- Caching strategies using Azure Redis Cache for enhanced performance  
- Responsive UI powered by Angular Material & Bootstrap  
- Comprehensive error handling, HTTP interceptors, and async validation  
- Deployment-ready for Azure cloud platform  

## 🗂 Project Structure

| Folder               | Description                                                         |
|----------------------|---------------------------------------------------------------------|
| `Ecom.API`           | RESTful API layer exposing core e-commerce services                 |
| `Ecom.Core`          | Domain models, business logic, service interfaces                   |
| `Ecom.infratruct`    | Infrastructure services — database access, repositories, caching   |

## 📚 Technologies & Concepts Covered

### Frontend (Angular)

- Angular Routing and Lazy Loading for optimized performance  
- Reactive Forms including multi-step wizard forms  
- Reusable form components with synchronous and asynchronous validations  
- State management with RxJS observables and Input/Output bindings  
- Angular Material & Bootstrap integration for elegant UI  
- HTTP Interceptors and global error handling mechanisms  
- Pagination, sorting, filtering, and searching functionalities  
- Client-side caching to reduce server calls  

### Backend (.NET Core)

- C# Generics, Dependency Injection, and SOLID principles  
- Repository Pattern, Unit of Work & Specification Pattern for clean data access  
- Multi-DbContext setup for Identity and Domain separation  
- JWT token-based secure authentication and authorization with ASP.NET Identity  
- AutoMapper for DTO/entity mapping  
- Custom Middleware and Application Service Extensions  
- Server-side caching including Azure Redis Cache integrations  
- Consistent and generic API error responses  

## 💡 Additional Features

- Fully integrated **Stripe Payment Gateway** with support for the new EU 3D Secure protocol  
- Complete multi-step checkout flow: cart, shipping info, payment, confirmation  
- Email notifications for account activation and order confirmation  
- Customized themes with Bootstrap and Angular Material  
- Publish and host your app seamlessly on **Microsoft Azure**  

## ⚙️ Getting Started

### Prerequisites

- [.NET 6+ SDK or latest LTS](https://dotnet.microsoft.com/download)  
- [Node.js & npm](https://nodejs.org/)  
- IDE: [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)  

### Setup Instructions

```bash
git clone https://github.com/3bdao3/Ecom.git
cd Ecom
```

- Open `Ecom.sln` in Visual Studio or VS Code  
- Set `Ecom.API` as startup project for backend API  

#### Run Backend API

```bash
dotnet run --project Ecom.API/Ecom.API.csproj
```

#### Run Frontend Angular App

Navigate to your Angular project folder (if separate), then:

```bash
npm install
ng serve
```

Application will be available usually at `http://localhost:4200`

## 🌿 Branches

| Branch       | Purpose                                          |
|--------------|--------------------------------------------------|
| `master`     | Active development with latest features          |
| `production` | Stable, production-ready release                  |

## 🤝 Contributing & License

Contributions and feature requests are welcome! Please fork and submit pull requests, or open issues for bug reports.

⚠️ **Note:** This project currently does **not** specify an official open-source license. Please contact the repository owner before using or deploying it commercially.

## 📖 Summary

Ecom provides a modern, robust implementation of a full-stack e-commerce platform, balancing advanced technical concepts with practical usability. Whether you want to learn enterprise-grade Angular and ASP.NET Core patterns or bootstrap your own scalable e-commerce app, this project offers a rich and real-world example.


