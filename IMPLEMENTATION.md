# Implementation Notes (Brief)

This document explains at a high level what was added, why, and how it works.

## Features Delivered (Standard Only)

-   Filters
    -   Active and Inactive filters in `UsersController`; buttons in `Users/List.cshtml`.
-   User Model Extension
    -   `DateOfBirth` added to `User` and shown across list/add/edit/view.
-   CRUD
    -   Add/View/Edit/Delete with server and client validation.

## Architecture

-   Data: EF Core InMemory via `DataContext`. Seed data is provided.
-   Services: `UserService` abstracts data access.
-   Web: `UsersController` for CRUD; Razor views for UI.
-   DI: Service registrations in `UserManagement.Services/Extensions/ServiceCollectionExtensions.cs`.

Logging and related pages were removed to keep scope to Standard only.

## Running

-   `cd UserManagement.Web && dotnet run`
-   Users at `/users`.

## Tests

-   Existing tests updated accordingly and pass locally.
