using TextLens.Api.Models.Responses;

namespace TextLens.Api.Services;

public interface ILanguageService
{
    Task<SentimentResponse> AnalyzeSentimentAsync(string text);
    Task<KeyPhrasesResponse> ExtractKeyPhrasesAsync(string text);
    Task<EntitiesResponse> RecognizeEntitiesAsync(string text);
    Task<EntityLinkingResponse> RecognizeLinkedEntitiesAsync(string text);
    Task<PiiResponse> RecognizePiiEntitiesAsync(string text);
    Task<LanguageResponse> DetectLanguageAsync(string text);
}
