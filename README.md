# Aircraft Maintenance Operations Platform

An enterprise-style Aircraft Maintenance Operations Platform built with **ASP.NET Core**, **Clean Architecture**, **CQRS**, and **Domain-Driven Design** principles.

The project focuses on modeling real-world aviation maintenance workflows rather than simple CRUD operations.

---

## Technology Stack

### Backend

- ASP.NET Core Web API (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation

### Architecture

- Clean Architecture
- CQRS
- Domain-Driven Design
- Vertical Slice Architecture

---

## Features

### ✅ Completed

- Create Aircraft
- Get Aircraft
- Get Aircraft by ID
- Archive Aircraft
- Aircraft Factory (`Aircraft.Create()`)
- Domain Behaviors
  - Archive
  - Ground
  - Return to Service
  - Assign Pilot
  - Unassign Pilot
- Business Rule Enforcement
- Domain Result Pattern

### 🚧 In Progress

- Assign Pilot Vertical Slice
- Unit Testing
- API Endpoints

### 📋 Planned

- Maintenance Requests
- Work Orders
- Technician Assignment
- Return to Service Workflow
- Authentication & Authorization
- Reporting Dashboard

---

## Business Rules

- Aircraft are never deleted; they are archived.
- New aircraft are created in the **Grounded** state.
- Flight hours start at **0**.
- Archived aircraft cannot receive a pilot.
- Out-of-service aircraft cannot receive a pilot.
- An aircraft can only have one assigned pilot at a time.

Business rules are enforced within the domain model rather than application handlers.

---

## Current Sprint

**Sprint 5 – Pilot Assignment**

Current work includes:

- DomainResult implementation
- Aircraft aggregate improvements
- Assign Pilot command and handler
- Business rule validation

---

## Project Goals

This project is designed to demonstrate:

- Enterprise application architecture
- Clean code principles
- Rich domain modeling
- REST API design
- CQRS with MediatR
- Business-driven software development

---

## Project Status

🚀 Active Development

Current Progress: **Sprint 5 (Approximately 50% MVP Complete)**
