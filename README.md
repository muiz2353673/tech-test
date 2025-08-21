# User Management Technical Exercise

The exercise is an ASP.NET Core web application backed by Entity Framework Core, which faciliates management of some fictional users.
We recommend that you use [Visual Studio (Community Edition)](https://visualstudio.microsoft.com/downloads) or [Visual Studio Code](https://code.visualstudio.com/Download) to run and modify the application.

**The application uses an in-memory database, so changes will not be persisted between executions.**

## The Exercise (Standard Only)

This solution focuses solely on the Standard tasks.

### 1. Filters Section (Standard)

The users page contains 3 buttons below the user listing - **Show All**, **Active Only** and **Non Active**. Show All has already been implemented. Implement the remaining buttons using the following logic:

-   Active Only – This should show only users where their `IsActive` property is set to `true`
-   Non Active – This should show only users where their `IsActive` property is set to `false`

### 2. User Model Properties (Standard)

Add a new property to the `User` class in the system called `DateOfBirth` which is to be used and displayed in relevant sections of the app.

### 3. Actions Section (Standard)

Create the code and UI flows for the following actions

-   **Add** – A screen that allows you to create a new user and return to the list
-   **View** - A screen that displays the information about a user
-   **Edit** – A screen that allows you to edit a selected user from the list
-   **Delete** – A screen that allows you to delete a selected user from the list

Each of these screens should contain appropriate data validation, which is communicated to the end user.

Note: Advanced, Expert, and Platform tasks and related code have been removed.

## Additional Notes

-   Please feel free to change or refactor any code that has been supplied within the solution and think about clean maintainable code and architecture when extending the project.
-   If any additional packages, tools or setup are required to run your completed version, please document these thoroughly.

## What Is Implemented (Standard)

-   Filters: Active/Inactive filters on the Users list
-   User model: `DateOfBirth` displayed on list and forms
-   Actions: Add/View/Edit/Delete with validation and success messages

## How It Works (Brief)

-   Data layer uses EF Core InMemory so the app runs without setup. `DataContext` seeds users.
-   `UserService` provides user operations.
-   `UsersController` renders list and CRUD pages.
-   Views are Razor with Bootstrap; client-side validation via jQuery validation.

## Run

```
cd UserManagement.Web
dotnet run
```

-   Users: https://localhost:7084/users (or http://localhost:5084/users)
 

If you see a port in use error, close previous instances or change `applicationUrl` in `Properties/launchSettings.json`.

## GitHub

To publish this repo under your GitHub account:

```
git init
git add .
git commit -m "Initial solution with CRUD, filters, DOB, logging, and async support"
git branch -M main
git remote add origin https://github.com/<your-username>/<your-repo>.git
git push -u origin main
```
