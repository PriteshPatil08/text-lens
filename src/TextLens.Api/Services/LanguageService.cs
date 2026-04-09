using Azure.AI.TextAnalytics;
using TextLens.Api.Models.Responses;

namespace TextLens.Api.Services;

public class LanguageService : ILanguageService
{
    private readonly TextAnalyticsClient _client;

    public LanguageService(TextAnalyticsClient client)
    {
        _client = client;
    }

    public async Task<SentimentResponse> AnalyzeSentimentAsync(string text)
    {
        var options = new AnalyzeSentimentOptions { IncludeOpinionMining = true };
        var result = await _client.AnalyzeSentimentAsync(text, options: options);
        var doc = result.Value;

        var sentences = doc.Sentences.Select(s =>
        {
            var opinions = s.Opinions.Select(o =>
            {
                var assessments = o.Assessments.Select(a => $"{a.Text} ({a.Sentiment})").ToList();
                return new OpinionTarget(
                    o.Target.Text,
                    o.Target.Sentiment.ToString(),
                    new ConfidenceScores(
                        o.Target.ConfidenceScores.Positive,
                        o.Target.ConfidenceScores.Neutral,
                        o.Target.ConfidenceScores.Negative),
                    assessments);
            }).ToList();

            return new Models.Responses.SentenceSentiment(
                s.Text,
                s.Sentiment.ToString(),
                new ConfidenceScores(
                    s.ConfidenceScores.Positive,
                    s.ConfidenceScores.Neutral,
                    s.ConfidenceScores.Negative),
                opinions);
        }).ToList();

        return new SentimentResponse(
            doc.Sentiment.ToString(),
            new ConfidenceScores(
                doc.ConfidenceScores.Positive,
                doc.ConfidenceScores.Neutral,
                doc.ConfidenceScores.Negative),
            sentences);
    }

    public async Task<KeyPhrasesResponse> ExtractKeyPhrasesAsync(string text)
    {
        var result = await _client.ExtractKeyPhrasesAsync(text);
        return new KeyPhrasesResponse(result.Value.ToList());
    }

    public async Task<EntitiesResponse> RecognizeEntitiesAsync(string text)
    {
        var result = await _client.RecognizeEntitiesAsync(text);
        var entities = result.Value.Select(e => new EntityItem(
            e.Text,
            e.Category.ToString(),
            e.SubCategory,
            e.ConfidenceScore,
            e.Offset,
            e.Length)).ToList();
        return new EntitiesResponse(entities);
    }

    public async Task<EntityLinkingResponse> RecognizeLinkedEntitiesAsync(string text)
    {
        var result = await _client.RecognizeLinkedEntitiesAsync(text);
        var entities = result.Value.Select(e => new LinkedEntityItem(
            e.Name,
            e.Url.ToString(),
            e.DataSource,
            e.Matches.Select(m => new Models.Responses.LinkedEntityMatch(
                m.Text,
                m.ConfidenceScore,
                m.Offset,
                m.Length)).ToList()
        )).ToList();
        return new EntityLinkingResponse(entities);
    }

    public async Task<PiiResponse> RecognizePiiEntitiesAsync(string text)
    {
        var result = await _client.RecognizePiiEntitiesAsync(text);
        var doc = result.Value;
        var entities = doc.Select(e => new PiiEntityItem(
            e.Text,
            e.Category.ToString(),
            e.SubCategory,
            e.ConfidenceScore,
            e.Offset,
            e.Length)).ToList();
        return new PiiResponse(doc.RedactedText, entities);
    }

    public async Task<LanguageResponse> DetectLanguageAsync(string text)
    {
        var result = await _client.DetectLanguageAsync(text);
        var lang = result.Value;
        return new LanguageResponse(lang.Name, lang.Iso6391Name, lang.ConfidenceScore);
    }
}
