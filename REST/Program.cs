/*
 This app calls the GitHub API Foundation to get information about 
 the projects under the .NET umbrella.
*/

using System.Net.Http.Headers;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")); // accept json responses
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRespositoryAsync(client);

static async Task ProcessRespositoryAsync(HttpClient client)
{
    /*
       1. await the result returned from calling HttpClient.GetStringAsync(string)
       2. The body is returned as a string, when the task completes.
    */ 
    var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
    Console.WriteLine(json);
}

