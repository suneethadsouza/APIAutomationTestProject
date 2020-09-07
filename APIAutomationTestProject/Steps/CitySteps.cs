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
    public class CitySteps
    {
        private readonly TestContext _context;
        public CitySteps(TestContext injectedContext)
        {
            _context = injectedContext;
        }

        [Given(@"I have a get user by city request (.*)")]
        public void GivenIHaveAGetUserByCityRequest(string city)
        {
            _context.Request = _context.Get(RestEndPoints.GetUsersByCity(city));
        }

        [Given(@"I have a get user by empty city request")]
        public void GivenIHaveAGetUserByEmptyCityRequest()
        {
            _context.Request = _context.Get(RestEndPoints.GetUsersByCity(string.Empty));
        }


        [Then(@"the API response should have (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ValidateAPIResponseValues(string id, string fname, string lname, string email, string ipAddress, string latitude, string longitude)
        {
            var usersByCity = DataHelper.Deserialize<List<User>>(_context.Response.Content);
            var user = usersByCity.FirstOrDefault(u => u.Email == email);
            user.Should().NotBeNull();
            user.Id.Should().Be(id);
            user.Id.Should().Be(id);
            user.FirstName.Trim().Should().Be(fname.Trim());
            user.LastName.Trim().Should().Be(lname.Trim());
            user.Email.Trim().Should().Be(email.Trim());
            user.IpAddress.Trim().Should().Be(ipAddress.Trim());
            user.Latitude.Trim().Should().Be(latitude.Trim());
            user.Longitude.Trim().Should().Be(longitude.Trim());
        }
    }
}
