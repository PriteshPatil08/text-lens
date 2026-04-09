using TextLens.Api.Models.Requests;
using TextLens.Api.Services;

namespace TextLens.Api.Endpoints;

public static class LanguageEndpoints
{
    public static void MapLanguageEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/language")
            .WithTags("Language Analysis");

        group.MapPost("/sentiment", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.AnalyzeSentimentAsync(req.Text)))
            .WithName("AnalyzeSentiment")
            .WithSummary("Analyze sentiment with opinion mining");

        group.MapPost("/keyphrases", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.ExtractKeyPhrasesAsync(req.Text)))
            .WithName("ExtractKeyPhrases")
            .WithSummary("Extract key phrases");

        group.MapPost("/entities", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.RecognizeEntitiesAsync(req.Text)))
            .WithName("RecognizeEntities")
            .WithSummary("Named entity recognition");

        group.MapPost("/entity-linking", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.RecognizeLinkedEntitiesAsync(req.Text)))
            .WithName("RecognizeLinkedEntities")
            .WithSummary("Entity linking to Wikipedia");

        group.MapPost("/pii", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.RecognizePiiEntitiesAsync(req.Text)))
            .WithName("RecognizePii")
            .WithSummary("PII detection and redaction");

        group.MapPost("/language", async (AnalyzeRequest req, ILanguageService svc) =>
            Results.Ok(await svc.DetectLanguageAsync(req.Text)))
            .WithName("DetectLanguage")
            .WithSummary("Language detection");
    }
}
