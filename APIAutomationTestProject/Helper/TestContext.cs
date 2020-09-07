using RestSharp;

namespace APIAutomationTestProject.Helper
{
    public class TestContext
    {
        public RestRequest Request { get; set; }
        public IRestResponse Response { get; set; }

        public RestClient Client()
        {
            var client = new RestClient("http://bpdts-test-app-v2.herokuapp.com/");
            client.AddDefaultHeader("Accept", "application/json");
            return client;
        }

        public RestRequest Get(string path)
        {
            return new RestRequest(path, Method.GET);
        }
    }
}
