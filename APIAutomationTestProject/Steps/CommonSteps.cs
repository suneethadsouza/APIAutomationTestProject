using APIAutomationTestProject.Helper;
using APIAutomationTestProject.Model;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace APIAutomationTestProject.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly TestContext _context;

        public CommonSteps(TestContext injectedContext)
        {
            _context = injectedContext;
        }

        [When(@"I call the endpoint")]
        public void WhenICallTheEndpoint()
        {
            _context.Response = _context.Client().Execute(_context.Request);
        }

        [Then(@"the response should have the status (.*) and success status (.*)")]
        public void ThenTheResponseShouldHaveTheStatusAndSuccessStatus(HttpStatusCode httpStatusCode, bool isSuccess)
        {
            _context.Response.StatusCode.Should().Be(httpStatusCode);
            _context.Response.IsSuccessful.Should().Be(isSuccess);
        }

        [Then(@"the response should be empty")]
        public void ThenTheResponseShouldBeEmpty()
        {
            var usersByCity = DataHelper.Deserialize<List<User>>(_context.Response.Content);
            usersByCity.Should().NotBeNull();
            usersByCity.Count.Should().Be(0);
        }
    }
}
