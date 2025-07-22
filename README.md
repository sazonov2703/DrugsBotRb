# DrugsBotRb

**DrugsBotRb** is a service implementing the business logic of an online pharmacy aggregator using a pure computing structure and domain-oriented design (DDD). The project is developed on the .NET platform and modern architectural approaches to building extensible modular applications.

---

## Features

- Clean architecture with separation into Domain, Application and Infrastructure layers
- CQRS and MediatR for processing commands and requests
- Event model support (domain events)
- Flexible, easy to test structure
- Integration with Telegram Bot API via infrastructure layer
- Easy launch and scalability

---

## Project structure

The project is built on the principles of Clean Architecture and includes three key layers:

### Domain Layer

- Main business entities and logic
- Value objects, aggregates, repository interfaces
- Domain events
- Complete independence from external technologies

### Application Layer

- Implementation of business cases (use cases)
- Processing commands and requests (CQRS with MediatR)
- DTOs
- Interfaces to external services (bot, database, logging, etc.)

---  

### Infrastructure Layer

- Implementation of data access interfaces
- Integration with Telegram API
- Application configuration
- Repositories, contexts and auxiliary services

---

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (or other compatible DBMS)
- Telegram Bot Token (if launched with integration)

---

## Starting the project

1. Clone the repository:

```bash
git clone https://github.com/sazonov2703/DrugsBotRb.git
```

2. Go to the project directory:

```bash
cd DrugsBotRb
```

3. Update the connection string in `appsettings.json`.

4. Apply migrations:

```bash
dotnet ef database update
```

5. Run the project:

```bash
dotnet run
```

---

## Architecture

- The **Domain** layer does not depend on anything - it defines the essence of business logic.

- The **Application** layer depends only on Domain and implements all business scenarios.

- The **Infrastructure** layer implements external dependencies and provides access to data, Telegram, etc.

- Dependencies are directed strictly inward.

---

## Contribute

1. Fork the repository
2. Create a new branch:

```bash
git checkout -b feature/feature-name
```

3. Make changes and commit:

```bash
git commit -m "Added new feature"
```

4. Submit changes:

```bash
git push origin feature/feature-name
```

5. Create a Pull Request to the original repository

---

🔗 Repository: [github.com/sazonov2703/DrugsBotRb](https://github.com/sazonov2703/DrugsBotRb)
