using APIAutomationTestProject.Helper;
using APIAutomationTestProject.Model;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace APIAutomationTestProject.Steps
{
    [Binding]
    public class UserSteps
    {
        private readonly TestContext _context;
        public UserSteps(TestContext injectedContext)
        {
            _context = injectedContext;
        }

        [Given(@"I have a get all users request")]
        public void GivenIHaveAGetAllUserRequest()
        {
            _context.Request = _context.Get(RestEndPoints.GetAllUsers());
        }

        [Then(@"user details should be retrieved")]
        public void ThenInstructionsDetailsShouldBeRetrieved()
        {
            var users = DataHelper.Deserialize<List<User>>(_context.Response.Content);
            users.Count.Should().Be(1000);
            var user = users.First();
            user.Id.Should().NotBeNull();
        }
    }
}

