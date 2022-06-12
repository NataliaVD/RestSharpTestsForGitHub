using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace TestsWithRestSharpForGitHub

{
    public class GitHubTests
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");
            this.client.Authenticator = new HttpBasicAuthenticator("NataliaVD", "********");
        }

        [Test]
        public async Task TestGitHubApiRequest()
        {
            request = new RestRequest("/users/NataliaVD/repos");
            response = await this.client.ExecuteAsync(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]

        public async Task TestGetAllReposTopics()
        {
            request = new RestRequest("/users/NataliaVD/repos");
            response = await this.client.ExecuteAsync(request);
            List<Repo> repos = JsonConvert.DeserializeObject<List<Repo>>(response.Content);
            
            foreach(var repo in repos)
            {
                Assert.IsNotNull(repo.html_url);
            }
        }

    }
}






