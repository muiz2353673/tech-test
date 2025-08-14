# Implementation Notes (Brief)

This document explains at a high level what was added, why, and how it works.

## Features Delivered

-   Filters (Standard)
    -   Implemented Active and Inactive filters in `UsersController` and wired buttons in `Users/List.cshtml`.
-   User Model Extension (Standard)
    -   Added `DateOfBirth` to `User` entity and displayed it on list, add, edit, and view screens.
-   CRUD (Standard)
    -   Add/View/Edit/Delete implemented with server and client validation.
-   Logging (Advanced)
    -   `LogEntry` entity added with `ILogService`/`LogService` to record Create/View/Edit/Delete.
    -   Pages to list logs `/logs`, show details `/logs/{id}`, and per-user `/logs/user/{userId}`.
    -   Recent user activity shown on the user details page via partial `_UserRecentLogs`.
-   Async Support (Expert)
    -   Added async methods in `IDataContext`, `IUserService`, `ILogService`.
    -   Updated controllers to use async where it adds value.

## Architecture

-   Data: EF Core InMemory via `DataContext`. Seed data is provided.
-   Services: `UserService` and `LogService` abstract data access.
-   Web: `UsersController` for CRUD and `LogsController` for logs; Razor views for UI.
-   DI: Service registrations in `UserManagement.Services/Extensions/ServiceCollectionExtensions.cs`.

## How Logging Works

-   When actions occur (create/view/edit/delete), a `LogEntry` is created with action, optional description, optional `UserId`, and UTC timestamp.
-   Logs are fetched via `LogService` for list/detail and user-specific lists.

## Running

-   `cd UserManagement.Web && dotnet run`
-   Users at `/users`. Logs at `/logs`.

## Tests

-   Existing tests adapted to async and pass.

