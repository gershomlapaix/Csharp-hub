/*
 This app calls the GitHub API Foundation to get information about 
 the projects under the .NET umbrella.
*/

using System.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")); // accept json responses
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var repositories = await ProcessRespositoryAsync(client);
foreach (var repo in repositories)
{
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
    Console.WriteLine($"Last push: {repo.LastPush}");
    Console.WriteLine();
}

static async Task<List<Repository>> ProcessRespositoryAsync(HttpClient client)
{
    /*
       1. await the result returned from calling HttpClient.GetStreamAsync(string)
       2. The body is returned as a string, when the task completes.
    */
    await using Stream stream = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

    var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    return repositories ?? new();
    // foreach (var repo in repositories ?? Enumerable.Empty<Repository>())
    // {
    //     Console.WriteLine(repo.Name);
    // }
}

