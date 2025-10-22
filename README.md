# VB.HotChocoBoard

A .NET 9 API built with Domain-Driven Design (DDD) and Command Query Responsibility Segregation (CQRS) principles, using GraphQL as the communication protocol.

## 🏗️ Architecture Overview

This project follows a clean architecture approach with strict adherence to DDD and CQRS patterns:

- **Domain Layer**: Contains entities, repositories interfaces, specifications, and business logic
- **Application Layer**: Houses commands, queries, and handlers using MediatR
- **Infrastructure Layer**: Implements data persistence with Entity Framework Core
- **API Layer**: Exposes GraphQL endpoints using HotChocolate

## 🛠️ Technology Stack

- **.NET 9**: Latest .NET framework
- **HotChocolate**: GraphQL server implementation
- **MediatR**: Command/Query orchestration
- **Entity Framework Core**: Data persistence
- **Domain-Driven Design (DDD)**: Business logic organization
- **CQRS**: Command Query Responsibility Segregation

### Estrutura do Projeto

```text
VB.HotChocoBoard/
├── VB.HotChocoBoard.API/
├── VB.HotChocoBoard.Application/
├── VB.HotChocoBoard.Infrastructure/
└── VB.HotChocoBoard.Domain/
    ├── Entities/
    │   └── [EntityName]s/
    ├── Enums/
    ├── Repositories/
    ├── Specifications/
    └── ...
```

    
## 🎯 Key Principles

### Consistency First
All new code must follow existing patterns and conventions established in the project.

### English Code, Native Documentation
- All code (classes, methods, variables) must be written in English
- Comments and documentation can be in the native language

### Entity Design Pattern
Each entity follows a canonical blueprint:

1. **Directory Structure**: Create a plural directory for each entity (e.g., `Invoices/`)
2. **Subdirectories**: 
   - `Entities/`: Domain entities
   - `Repositories/`: Repository interfaces
   - `Specifications/`: Query filtering logic
   - `Enums/`: Related enumerations

3. **Entity Implementation**:
   - Private setters for encapsulation
   - Parameterless constructor for EF Core
   - Business logic validation in constructors
   - Methods for state manipulation

### Domain Aggregation
- Root entities manage child entities
- Direct manipulation only through aggregate roots
- Collections initialized in constructors (HotChocolate compatibility)

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- Compatible IDE (JetBrains Rider recommended)

### Installation

1. Clone the repository
2. Run the docker compose with:
```bash
docker compose build
docker compose up
```

🔗 Related Technologies
HotChocolate Documentation
MediatR GitHub
Entity Framework Core Documentation
Domain-Driven Design


Built with ❤️ using .NET 9 and HotChocolate GraphQL
    
