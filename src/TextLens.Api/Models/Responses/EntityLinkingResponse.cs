namespace TextLens.Api.Models.Responses;

public record EntityLinkingResponse(IReadOnlyList<LinkedEntityItem> Entities);

public record LinkedEntityItem(
    string Name,
    string Url,
    string DataSource,
    IReadOnlyList<LinkedEntityMatch> Matches
);

public record LinkedEntityMatch(
    string Text,
    double ConfidenceScore,
    int Offset,
    int Length
);
