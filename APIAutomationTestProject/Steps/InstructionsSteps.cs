using APIAutomationTestProject.Helper;
using APIAutomationTestProject.Model;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace APIAutomationTestProject.Steps
{
    [Binding]
    public class InstructionsSteps
    {

        private readonly TestContext _context;
        public InstructionsSteps(TestContext injectedContext)
        {
            _context = injectedContext;
        }

        [Given(@"I have a get instructions request")]
        public void GivenIHaveAGetInstructionRequest()
        {
            _context.Request = _context.Get(RestEndPoints.GetInstructions());
        }

        [Then(@"instructions details should be retrieved")]
        public void ThenInstructionsDetailsShouldBeRetrieved()
        {
            var instruction = DataHelper.Deserialize<Instruction>(_context.Response.Content);
            instruction.Should().NotBeNull();
            instruction.Todo.Should().NotBeNull();
        }
    }
}
