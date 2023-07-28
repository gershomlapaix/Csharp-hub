/* This class will be used to represent JSON object returned from the API */
using System.Text.Json.Serialization;

public record class Repository(
    [property: JsonPropertyName("name")] string Name, // change the name of 'name' prop to "Name"
    [property: JsonPropertyName("description")] string Description,
[property: JsonPropertyName("html_url")] Uri GitHubHomeUrl,
[property: JsonPropertyName("homepage")] Uri Homepage,
[property: JsonPropertyName("watchers")] int Watchers);