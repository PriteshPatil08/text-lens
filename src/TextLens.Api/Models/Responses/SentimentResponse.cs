namespace TextLens.Api.Models.Responses;

public record ConfidenceScores(double Positive, double Neutral, double Negative);

public record OpinionTarget(
    string Text,
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<string> Assessments
);

public record SentenceSentiment(
    string Text,
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<OpinionTarget> Opinions
);

public record SentimentResponse(
    string Sentiment,
    ConfidenceScores Scores,
    IReadOnlyList<SentenceSentiment> Sentences
);
