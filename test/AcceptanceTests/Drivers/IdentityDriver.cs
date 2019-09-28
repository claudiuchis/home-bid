using System.Threading.Tasks;
using HomeBid.Specifications.StepsDefinitions;

// https://medium.com/@amaya30/specflow-selenium-beginner-tutorial-for-functional-automated-web-testing-part-1-bf5c8fe53c3f
// https://medium.com/@amaya30/specflow-selenium-beginner-tutorial-for-functional-automated-web-testing-part-2-d3a2ba3d7c2

namespace HomeBid.Specifications.Drivers
{
    public class IdentityDriver
    {
        public Task<Account> SignUpAsEstateAgent(Account account)
        {
            return Task.FromResult(account);
        }
    }
}