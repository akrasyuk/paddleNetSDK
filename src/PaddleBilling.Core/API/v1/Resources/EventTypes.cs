namespace PaddleBilling.Core.API.v1.Resources;

public record EventTypes(List<AvailableEventType> Data);

public record AvailableEventType(string Name, string Description, string Group, List<int> AvailableVersions);