﻿using System.Text;
using System.Text.Json;

namespace PostmanCloneLibrary;

public class ApiAccess : IApiAccess
{
    private readonly HttpClient client = new();

    public async Task<ApiResponse> CallApiAsync(
        string url, 
        string content, 
        HttpAction action = HttpAction.GET,
        Dictionary<string, string>? headers = null,
        bool formatOutput = true
    )
    {
        StringContent stringContent = new(content, Encoding.UTF8, "application/json");
        return await CallApiAsync(url, stringContent, action, headers, formatOutput);
    }

    public async Task<ApiResponse> CallApiAsync(
        string url, 
        HttpContent? content = null,
        HttpAction action = HttpAction.GET,
        Dictionary<string, string>? headers = null,
        bool formatOutput = true
    )
    {
        HttpResponseMessage? response;

        if (headers != null)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        switch (action)
        {
            case HttpAction.GET:
                response = await client.GetAsync(url);
                break;
            case HttpAction.POST:
                response = await client.PostAsync(url, content);
                break;
            case HttpAction.PUT:
                response = await client.PutAsync(url, content);
                break;
            case HttpAction.PATCH:
                response = await client.PatchAsync(url, content);
                break;
            case HttpAction.DELETE:
                response = await client.DeleteAsync(url);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }

        var apiResponse = new ApiResponse();

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            if (formatOutput)
            {
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                json = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            }

            apiResponse.Body = json;
        }
        else
        {
            apiResponse.Body = $"Error: {response.StatusCode}";
        }

        apiResponse.Headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);

        return apiResponse;
    }


    public bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        bool output = Uri.TryCreate(url, UriKind.Absolute, out Uri uriOutput) && (uriOutput.Scheme == Uri.UriSchemeHttps);

        return output;
    }
}
