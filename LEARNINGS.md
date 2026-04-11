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

## Step 3 — Core API

_What we learned (3 lines):_
> Built a thin ASP.NET Core Minimal API layer with 6 endpoints, each wrapping one Azure AI Language feature via the official SDK.
> Designed clean DTOs as C# records to represent every response shape — sentiment, key phrases, NER, entity linking, PII, and language detection.
> Learned how to register a typed Azure SDK client in DI and expose it through a service interface for testability.

**Technical Topics**
- ASP.NET Core Minimal API (`MapGroup`, `MapPost`, `WithName`, `WithSummary`)
- C# records as immutable DTOs
- `ILanguageService` / `LanguageService` pattern (interface + implementation)
- `TextAnalyticsClient` SDK — `AnalyzeSentimentAsync`, `ExtractKeyPhrasesAsync`, `RecognizeEntitiesAsync`, `RecognizeLinkedEntitiesAsync`, `RecognizePiiEntitiesAsync`, `DetectLanguageAsync`
- `AnalyzeSentimentOptions.IncludeOpinionMining` for aspect-level sentiment
- Dependency Injection (`AddSingleton`, `AddScoped`)
- CORS policy configuration for cross-origin Blazor calls
- `appsettings.json` + `IConfiguration` for secrets-free config

---

## Step 3 — Core API (Rebuilt piece by piece)

_What we learned (3 lines):_
> Built the full API layer from scratch unit by unit — DTOs, service interface, service implementation, endpoints, and composition root — understanding the purpose of each piece before writing it.
> Learned how the Anti-Corruption Layer pattern shields the domain from SDK changes, and why DI lifetimes (Singleton vs Scoped) match the lifecycle of the objects they manage.
> Understood that `Program.cs` is the Composition Root — the one place where all dependencies meet — and that middleware pipeline ordering is architecture, not ceremony.

**Technical Topics**
- C# `record` types as immutable DTOs
- Anti-Corruption Layer pattern
- `ILanguageService` interface — testability and access control
- `LanguageService` — Azure SDK mapping, `Response<T>`, `.Value`
- DI lifetimes — `AddSingleton`, `AddScoped`
- ASP.NET Core Minimal API — `MapGroup`, `MapPost`, `WithName`, `WithSummary`
- Lambda functions and async endpoint handlers
- CORS — preflight requests, cross-origin policy
- Middleware pipeline ordering
- Fail Fast — startup config validation with `??` throw
- Configuration hierarchy — environment variables override appsettings

---
