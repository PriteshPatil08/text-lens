namespace TextLens.Api.Models.Responses;

public record LanguageResponse(
    string Name,
    string Iso6391Name,
    double ConfidenceScore
);
