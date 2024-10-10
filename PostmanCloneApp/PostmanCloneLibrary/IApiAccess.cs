namespace PostmanCloneLibrary;

public interface IApiAccess
{
    Task<ApiResponse> CallApiAsync(string url, string content, HttpAction action = HttpAction.GET, Dictionary<string, string>? headers = null, bool formatOutput = true);
    Task<ApiResponse> CallApiAsync(string url, HttpContent? content = null, HttpAction action = HttpAction.GET, Dictionary<string, string>? headers = null, bool formatOutput = true);
    bool IsValidUrl(string url);
}