namespace GameSphere.Models;

public record ErrorViewModel(string RequestId, int? ErrorCode)
{
    public readonly bool ShowRequestId = !string.IsNullOrEmpty(RequestId);
}

