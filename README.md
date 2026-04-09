# TextLens

> Point it at text. See what's inside.

TextLens is a .NET 10 full-stack application that surfaces every non-generative insight Azure AI Language can extract from raw text — sentiment, entities, key phrases, PII detection, and more — through a clean Blazor UI backed by an ASP.NET Core Web API.

---

## Features

| Feature | What it returns |
|---|---|
| Sentiment Analysis | Positive / Negative / Neutral / Mixed + confidence scores |
| Opinion Mining | Aspect-level sentiment ("battery life is great") |
| Key Phrase Extraction | The most important topics and phrases |
| Named Entity Recognition | People, orgs, locations, dates, quantities |
| Entity Linking | Entities mapped to Wikipedia with confidence scores |
| PII Detection | Phone numbers, emails, SSNs — with redaction |
| Language Detection | Detected language + confidence |

---

## Architecture

```
Browser
  └─ Blazor Web App (.NET 10)       ← interactive UI
       └─ ASP.NET Core Web API       ← one endpoint per feature
            └─ Azure.AI.TextAnalytics SDK
                 └─ Azure AI Language (cloud)
```

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Azure AI Language resource ([create one free](https://portal.azure.com))

### Configuration

Set your Azure credentials via environment variables or `appsettings.Development.json`:

```bash
export AzureLanguage__Endpoint="https://<your-resource>.cognitiveservices.azure.com/"
export AzureLanguage__Key="<your-key>"
```

### Run

```bash
# API
cd src/TextLens.Api
dotnet run

# Blazor UI (separate terminal)
cd src/TextLens.Web
dotnet run
```

Open `https://localhost:5001` in your browser.

---

## Project Structure

```
TextLens/
├── src/
│   ├── TextLens.Api/          # ASP.NET Core Web API
│   └── TextLens.Web/          # Blazor Web App
├── tests/
│   └── TextLens.Api.Tests/    # Unit + integration tests
├── .github/
│   └── workflows/ci.yml       # GitHub Actions CI
└── README.md
```

---

## CI/CD

GitHub Actions runs on every push: build, test, and publish.

---

## License

MIT
