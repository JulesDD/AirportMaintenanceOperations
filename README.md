# ✈️ Airport Maintenance Operations API

A modern **ASP.NET Core (.NET 8)** backend application built using **Clean Architecture**, **CQRS**, and **Domain-Driven Design (DDD)** principles to manage aircraft, pilots, and maintenance operations.

This project is being developed incrementally using agile sprints to simulate real-world enterprise software development practices.

---

## 🚀 Project Status

| Module | Status |
|---------|:------:|
| Pilot Management | ✅ Complete |
| Aircraft Management | ✅ Complete |
| Maintenance Requests | ✅ Complete  |
| Work Orders | 🚧 In Progress |
| Technician Management | 📅 Planned |
| Inventory Management | 📅 Planned |
| Maintenance Scheduling | 📅 Planned |
| Authentication & Authorization | 📅 Planned |
| Unit Testing | 📅 Planned |
| Docker Deployment | 📅 Planned |

---

# 📚 Features

## 👨‍✈️ Pilot Management

- ✅ Create Pilot
- ✅ Retrieve All Pilots
- ✅ Retrieve Pilot by ID
- ✅ Update Pilot
- ✅ Archive Pilot

### Business Rules

- Only active pilots may be assigned to an aircraft.
- Archived pilots cannot be assigned.

---

## ✈️ Aircraft Management

- ✅ Create Aircraft
- ✅ Retrieve All Aircraft
- ✅ Retrieve Aircraft by ID
- ✅ Update Aircraft
- ✅ Archive Aircraft
- ✅ Assign Pilot

### Business Rules

- Aircraft may only have one assigned pilot.
- Archived aircraft cannot receive pilot assignments.
- Out-of-service aircraft cannot receive pilot assignments.
- Flight hours cannot decrease.
- Flight hours cannot be negative.
- New aircraft begin with:
  - Grounded status
  - Zero flight hours

---

# 🏗 Architecture

The solution follows **Clean Architecture** principles.

```
AirportMaintenanceOperations
│
├── API
│   ├── Carter Minimal APIs
│   ├── Dependency Injection
│   └── Swagger
│
├── Application
│   ├── Commands
│   ├── Queries
│   ├── Handlers
│   ├── Validators
│   └── DTOs
│
├── Domain
│   ├── Entities
│   ├── Enums
│   ├── Value Objects
│   ├── Domain Results
│   └── Business Rules
│
└── Infrastructure
    ├── Entity Framework Core
    ├── SQL Server
    └── Persistence
```

---

# 🛠 Technologies

- ASP.NET Core (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- MediatR
- Carter
- FluentValidation
- Mapster
- Swagger / OpenAPI
- Minimal APIs

---

# 🧩 Design Patterns

This project demonstrates several enterprise development patterns:

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Domain-Driven Design (DDD)
- Repository Pattern
- Dependency Injection
- Factory Methods
- Domain Result Pattern
- Validation Pipeline Behaviour

---

# ⚙️ CQRS

Commands are responsible for modifying application state.

Examples include:

- CreateAircraftCommand
- UpdateAircraftCommand
- ArchiveAircraftCommand
- AssignPilotCommand
- CreatePilotCommand
- UpdatePilotCommand

Queries are responsible for retrieving data.

Examples include:

- GetAircraftQuery
- GetAircraftByIdQuery
- GetPilotsQuery
- GetPilotByIdQuery

MediatR coordinates communication between API endpoints and application handlers.

---

# ✅ Validation Strategy

Validation is intentionally split into two layers.

### FluentValidation

Used for:

- Required fields
- Length validation
- Date validation
- Input formatting

### Domain Layer

Responsible for business rules such as:

- Aircraft assignment rules
- Flight hour validation
- Operational status changes
- Aggregate behaviour

This separation keeps business logic inside the domain where it belongs.

---

# 📖 Learning Objectives

This project has strengthened my understanding of:

- Clean Architecture
- CQRS
- Domain-Driven Design
- MediatR
- Entity Framework Core
- RESTful API Design
- Minimal APIs
- FluentValidation
- Separation of Concerns

---

# 📅 Sprint Progress

## ✅ Sprint 5 Complete

Completed during this sprint:

- Pilot Management module
- Aircraft Management module
- Domain business rules
- CQRS implementation
- FluentValidation
- Carter Minimal APIs
- Entity Framework Core persistence
- Swagger endpoint testing
- Flight hour business validation
- Pilot assignment workflow

---

# 🚀 Upcoming Work

Planned features include:

- Maintenance Requests
- Maintenance Scheduling
- Maintenance History
- JWT Authentication
- Role-Based Authorization
- Unit Testing
- Integration Testing
- Docker Improvements
- Azure Deployment
- CI/CD Pipeline

---

# 📷 API Documentation

Swagger is included for interactive API testing.

Current endpoints include:

### Pilot

- POST /api/pilot
- GET /api/pilot
- GET /api/pilot/{id}
- PATCH /api/pilot/{id}
- PATCH /api/pilot/{id}/archive

### Aircraft

- POST /api/aircraft
- GET /api/aircraft
- GET /api/aircraft/{id}
- PATCH /api/aircraft/{id}
- PATCH /api/aircraft/{id}/archive
- PATCH /api/aircraft/{id}/assign-pilot

---

# 👨‍💻 Author

**Jules Douglas**

Backend Software Developer

This repository documents my journey developing enterprise-style backend applications while applying Clean Architecture, CQRS, and Domain-Driven Design principles through sprint-based development.
