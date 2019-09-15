using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using HomeBid.Specifications.Drivers;
using HomeBid.Specifications.Hooks;
using HomeBid.Services.Bidding.Models;

namespace HomeBid.Specifications.StepsDefinitions
{
    [Binding]
    public class EditPropertiesSteps
    {
        private PropertyDriver _propertyDriver;         
        private DatabaseHook _databaseHook;
        private List<BiddingProperty> _propertiesToAdd;
        private IEnumerable<BiddingProperty> _propertiesAdded;

        [BeforeScenario]
        public void Setup()
        {
            _propertyDriver = new PropertyDriver();
            _databaseHook = new DatabaseHook();
            _propertiesToAdd = new List<BiddingProperty>();
            _databaseHook.EmptyBiddingPropertyTable();
        }

        // [Given(@"I have added these properties")]
        // public void GivenIHaveAddedTheseProperties(Table table)
        // {
        //     foreach(TableRow row in table.Rows)
        //     {
        //         var title = row["Title"];
        //         var askingPrice = row["AskingPrice"];

        //         // save the property to compare later
        //         var property = new BiddingProperty()
        //             {
        //                 Title = title,
        //                 AskingPrice = Convert.ToDecimal(askingPrice)
        //             };
        //         _propertiesToAdd.Add(property);

        //         // add the property
        //         Task task = _propertyDriver.AddBiddingProperty(title, askingPrice);
        //         task.Wait();
        //     }
        // }

        [When(@"I change the properties details")]
        public void WhenIChangeThePropertiesDetails(Table table)
        {
            
        }
    }
}