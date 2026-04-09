# TextLens — Learning Log

---

## Step 1 — Azure Setup & Project Scaffold

_What we learned (3 lines):_
> Provisioned an Azure AI Language resource and initialized a .NET solution with Git.
> Learned how to structure a multi-project .NET solution and wire up proper source control from day one.
> Set up `.gitignore` and `.gitattributes` to keep the repo clean across platforms.

**Technical Topics**
- Azure AI Language service
- .NET 10 solution structure
- Git initialization and configuration
- `.gitignore` and `.gitattributes`

---

## Step 2 — Solution Scaffold

_What we learned (3 lines):_
> Created a .NET 10 solution with two projects — an ASP.NET Core Web API and a Blazor Web App — wired together under one `.sln` file.
> Added the `Azure.AI.TextAnalytics` NuGet package to the API project, which is the official SDK for calling Azure AI Language.
> Confirmed the full solution builds cleanly before writing any feature code — a habit that catches structural problems early.

**Technical Topics**
- .NET solution files (`.sln`) and multi-project structure
- `dotnet new webapi` vs `dotnet new blazor` templates
- NuGet package management (`dotnet add package`)
- `Azure.AI.TextAnalytics` SDK
- `Microsoft.AspNetCore.OpenApi` for Swagger/OpenAPI
- Solution-level builds with `dotnet build`

---
