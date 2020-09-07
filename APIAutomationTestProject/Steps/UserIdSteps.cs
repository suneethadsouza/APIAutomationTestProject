using APIAutomationTestProject.Helper;
using APIAutomationTestProject.Model;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace APIAutomationTestProject.Steps
{
    [Binding]
    public class UserIdSteps
    {
        private readonly TestContext _context;
        public UserIdSteps(TestContext injectedContext)
        {
            _context = injectedContext;
        }

        [Given(@"I have a get user by Id request (.*)")]
        public void GivenIHaveAGetUserByIdRequest(string userId)
        {
            _context.Request = _context.Get(RestEndPoints.GetUsersById(userId));
        }

        [Given(@"I have a get user by empty Id request")]
        public void GivenIHaveAGetUserByEmptyIdRequest()
        {
            _context.Request = _context.Get(RestEndPoints.GetUsersById(string.Empty));
        }


        [Then(@"validate API response (.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenValidateAPIResponseUserById(string id, string fname, string lname, string email, string ipAddress, string latitude, string longitude, string city)
        {
            var userById = DataHelper.Deserialize<User>(_context.Response.Content);
            userById.Should().NotBeNull();
            userById.Id.Should().Be(id);
            userById.FirstName.Trim().Should().Be(fname.Trim());
            userById.LastName.Trim().Should().Be(lname.Trim());
            userById.Email.Trim().Should().Be(email.Trim());
            userById.IpAddress.Trim().Should().Be(ipAddress.Trim());
            userById.Latitude.Trim().Should().Be(latitude.Trim());
            userById.Longitude.Trim().Should().Be(longitude.Trim());
        }

        [Then(@"Validate Id (.*) doesn't exist in API response body")]
        public void ThenValidateIdDoesnTExistInAPIResponseBody(string errorMessage)
        {
            var response = _context.Response;
            var result = JObject.Parse(response.Content);
            var errMessage = result["message"].ToString();
            errMessage.Should().Contain(errorMessage);
        }
    }
}
