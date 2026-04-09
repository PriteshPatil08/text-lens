namespace TextLens.Api.Models.Responses;

public record SentimentResponse(
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<SentenceSentiment> Sentences
);

public record ConfidenceScores(double Positive, double Neutral, double Negative);

public record SentenceSentiment(
    string Text,
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<OpinionTarget> Opinions
);

public record OpinionTarget(
    string Text,
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<string> Assessments
);
