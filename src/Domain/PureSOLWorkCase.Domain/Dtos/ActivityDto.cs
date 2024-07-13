namespace PureSOLWorkCase.Domain;

public record ActivityDto(
        int UserId,
        string ActivityType,
        DateTime ActivityDate,
        string Description
    );