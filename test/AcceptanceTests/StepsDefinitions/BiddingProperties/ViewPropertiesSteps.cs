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
    public class ViewPropertiesSteps
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

        [Given(@"I have added these properties")]
        public void GivenIHaveAddedTheseProperties(Table table)
        {
            foreach(TableRow row in table.Rows)
            {
                var title = row["Title"];
                var askingPrice = row["AskingPrice"];

                // save the property to compare later
                var property = new BiddingProperty()
                    {
                        Title = title,
                        AskingPrice = Convert.ToDecimal(askingPrice)
                    };
                _propertiesToAdd.Add(property);

                // add the property
                Task task = _propertyDriver.AddBiddingProperty(title, askingPrice);
                task.Wait();
            }
        }

        [When(@"I request all the properties I added")]
        public void WhenIRequestAllThePropertiesIAdded()
        {
            Task<IEnumerable<BiddingProperty>> task =_propertyDriver.GetBiddingProperties();
            task.Wait();
            _propertiesAdded = task.Result;
        }

        [When(@"I change the properties details")]
        public void WhenIChangeThePropertiesDetails()
        {
            
        }

        [Then(@"These properties display")]
        public void ThenThesePropertiesDisplay()
        {
            var diff = _propertiesToAdd.Except(_propertiesAdded, new PropertyComparer());
            Assert.AreEqual(0, diff.Count());
        }

        public class PropertyComparer : IEqualityComparer<BiddingProperty>
        {
            public bool Equals(BiddingProperty p1, BiddingProperty p2)
            {
                return ((p1.Title == p2.Title) && (p1.AskingPrice == p2.AskingPrice));
            }

            public int GetHashCode(BiddingProperty property)
            {
                return (property.Title).GetHashCode();
            }
        }
    }
}