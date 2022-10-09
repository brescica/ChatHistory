# ChatHistory
A .NET 6 Web API for retrieving chat records and chat statistics

# Technologies and patterns
- Clean architecture
- .NET 6
- Entity Framework Core 6
- MediatR
- XUnit for Unit & integration tests, Moq
- AutoMapper
- Swagger 
----
# Instructions
- Install the latest .NET 6 SDK

----
# Overview
## ChatHistory.Domain
This will contain all entities, enums, constants, helpers, types and logic specific to the domain layer.

## ChatHistory.Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example IChatHistoryProvider, and an implementation would be created within infrastructure.

## ChatHistory.Infrastructure
This layer contains classes related to data persistance (db_context, dbset configurations, providers). These classes should be based on interfaces defined within the application layer.

## ChatHistory.API
This layer provides REST API endpoints. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Program.cs should reference Infrastructure.

## ChatHistory.Tests
This layer provides unit and integrations tests.
