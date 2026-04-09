namespace TextLens.Api.Models.Responses;

public record EntitiesResponse(IReadOnlyList<EntityItem> Entities);

public record EntityItem(
    string Text,
    string Category,
    string? SubCategory,
    double ConfidenceScore,
    int Offset,
    int Length
);
