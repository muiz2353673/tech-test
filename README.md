# User Management Technical Exercise

A simple ASP.NET Core MVC application for managing users (CRUD) and recording actions as log entries. The app uses EF Core InMemory for frictionless local runs and unit tests.

## Requirements

- .NET SDK 9.0 (recommended) — `dotnet --version`
- macOS/Windows/Linux
- IDE: Visual Studio or VS Code (recommended)

## Quick Start

```bash
# Restore, build, test
dotnet restore
dotnet build
dotnet test

# Run web app on a fixed port (avoids dev-cert prompts)
dotnet run --project UserManagement.Web/UserManagement.Web.csproj --urls http://localhost:5010
# Then open http://localhost:5010/
```

Tips:

- Use `dotnet watch run` during development for hot-reload.
- To change the port: `--urls http://localhost:5050` (or add `https://localhost:7050` if using a dev cert).

## Project Structure

- `UserManagement.Data`
  - Entities: `User` (Id, Forename, Surname, Email, IsActive, DateOfBirth), `LogEntry` (Id, UserId?, Action, Description?, CreatedAtUtc)
  - `DataContext`: EF Core InMemory DbContext, seeds 11 demo users; simple CRUD helpers via `IDataContext`
  - DI: `AddDataAccess()` registers `IDataContext` as scoped `DataContext`
- `UserManagement.Services`
  - Interfaces: `IUserService`, `ILogService` (sync + async APIs)
  - Implementations: `UserService`, `LogService` using the shared `IDataContext`
  - DI: `AddDomainServices()` registers services as scoped
- `UserManagement.Web`
  - `Program.cs`: adds data access, domain services, MVC; middleware (HSTS, HTTPS redirection, static files, routing, authorization)
  - Controllers: `HomeController`, `UsersController` (CRUD + filters), `LogsController` (listing, details, per-user)
  - Views: Razor pages for Users and Logs; simple Bootstrap UI
- Tests
  - `UserManagement.Data.Tests`, `UserManagement.Services.Tests`, `UserManagement.Web.Tests` (xUnit + FluentAssertions)

## Features Implemented

- Filters: Active / Inactive on the Users list
- User model: Added `DateOfBirth` and displayed across list/forms
- Actions: Add / View / Edit / Delete with validation and success messages
- Logging: `LogEntry` entity and `ILogService/LogService`; Logs pages (`/logs`, `/logs/{id}`, `/logs/user/{userId}`)
- Async support: async methods across data layer and services; controllers updated to use async where relevant

## Endpoints

- `GET /` — Home
- `GET /users` — List all users
- `GET /users/active` — Active users
- `GET /users/inactive` — Inactive users
- `GET /users/add` — Create form
- `POST /users/add` — Create
- `GET /users/{id}/view` — Details
- `GET /users/{id}/edit` — Edit form
- `POST /users/{id}/edit` — Update
- `GET /users/{id}/delete` — Delete confirmation
- `POST /users/{id}/delete` — Delete
- `GET /logs` — Logs list (supports `page`, `pageSize`)
- `GET /logs/{id}` — Log details
- `GET /logs/user/{userId}` — Logs for a specific user

## Testing

```bash
dotnet test
```

- All tests currently pass.
- You may see a FluentAssertions license reminder during test runs.

## Exercise Brief

Complete as many tasks as you like. They are grouped by difficulty:

- **Standard**
  - Filters: Implement Active Only (`IsActive == true`) and Non Active (`IsActive == false`)
  - User Model: Add `DateOfBirth` and show it throughout the app
  - Actions: Add/View/Edit/Delete with validation
- **Advanced**
  - Data Logging: Capture log information for primary actions
  - View screen: Show recent actions for a user
  - Logs page: List all logs, details page, and consider UX for large volumes
- **Expert**
  - Significant architectural improvement (examples):
    - Client-side UI (e.g., Blazor or your preferred framework) backed by an API
    - Full async data access
    - Authentication and login
    - Bundling of static assets
    - Real database with migrations
- **Platform**
  - CI/CD pipelines, cloud deployment, IaC, message bus/worker for long-running tasks

## Design Decisions & Trade-offs

- EF Core InMemory for simplicity and speed (not persistent; resets each run)
- Scoped lifetimes for DbContext/services to align with web request scope
- Both sync and async methods to ease future switch to a real database provider
- HTTPS redirection and HSTS enabled by default

## Limitations / Next Steps

- No persistence/migrations; data resets on restart
- Minimal validation and error handling; no authentication/authorization
- Logging stored in the same in-memory store

Suggested improvements:

- Replace InMemory with SQL provider + EF migrations
- Add server-side paging/sorting/search for users
- Introduce DTOs and mapping (e.g., AutoMapper)
- Add authn/authz and roles
- Expand test coverage, add API endpoints if needed

## Assessment Docs

- `ASSESSMENT_SUMMARY.txt` — high-level project overview
- `ASSESSMENT_QA.txt` — common assessment questions and answers

## Troubleshooting

- Port in use: stop previous instances or change `--urls`
- HTTPS locally: install dev certificate and include an `https://` URL in `--urls`
- Build artifacts tracked: consider adding `bin/` and `obj/` to `.gitignore` and untracking them

## Publishing to GitHub (optional)

```bash
git init
git add .
git commit -m "Initial solution"
git branch -M main
git remote add origin https://github.com/muiz2353673/tech-test.git
git push -u origin main
```
