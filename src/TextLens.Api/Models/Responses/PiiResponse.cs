namespace TextLens.Api.Models.Responses;

public record PiiResponse(
    string RedactedText,
    IReadOnlyList<PiiEntityItem> Entities
);

public record PiiEntityItem(
    string Text,
    string Category,
    string? SubCategory,
    double ConfidenceScore,
    int Offset,
    int Length
);
