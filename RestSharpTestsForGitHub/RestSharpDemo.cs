
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

var client = new RestClient("https://api.github.com");
client.Authenticator = new HttpBasicAuthenticator("NataliaVD", "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");

var request = new RestRequest("users/NataliaVD/repos");
var response = await client.ExecuteAsync(request);

Console.WriteLine(response.StatusCode);
var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

foreach(var repo in repos)
{
    Console.WriteLine(repo.full_name);
    Console.WriteLine(repo.id);
    if(repo.Equals(repos.ElementAt(4)))
    {
        Console.WriteLine(repo.html_url);
    }
}

var postRequest = new RestRequest("/repos/NataliaVD/Postman/issues");
postRequest.AddBody(new { title = "New Issue From RestSharp" });
var postResponse = await client.ExecuteAsync(postRequest, Method.Post);


Console.WriteLine(postResponse.StatusCode);
Console.WriteLine(postResponse.Content);


