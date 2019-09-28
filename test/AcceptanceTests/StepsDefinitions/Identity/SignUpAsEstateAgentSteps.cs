using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using HomeBid.Specifications.Drivers;

namespace HomeBid.Specifications.StepsDefinitions
{
    [Binding]
    public class SignUpAsEstateAgentSteps
    {
        private IdentityDriver _identityDriver;
        private Account _accountToBeCreated;
        private Account _accountCreated;
        public SignUpAsEstateAgentSteps(IdentityDriver driver)
        {
            _identityDriver = driver;
        }

        [Given(@"I chose to sign up as an estate agent")]
        public void GivenIChoseToSignUpAsAnEstateAgent()
        {

        }

        [Given(@"I entered my new account details")]
        public void GivenIEnteredMyNewAccountDetails(Table table)
        {
            _accountToBeCreated = table.CreateInstance<Account>();
        }

        [When(@"I submit my account details")]
        public void WhenISubmitMyAccountDetails()
        {
            Task<Account> task =_identityDriver.SignUpAsEstateAgent(_accountToBeCreated);
            task.Wait();
            _accountCreated = task.Result;
        }

        [Then(@"My estate agent account is created")]
        public void ThenMyEstateAgentAccountIsCreated()
        {
            Assert.NotNull(_accountCreated);
            Assert.AreEqual(_accountCreated.FirstName, _accountToBeCreated.FirstName);
            Assert.AreEqual(_accountCreated.LastName, _accountToBeCreated.LastName);
            Assert.AreEqual(_accountCreated.Email, _accountToBeCreated.Email);
        }
    }
}