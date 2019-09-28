using System;
using System.Collections;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Mvc.Testing;
using HomeBid.Services.Bidding.Models;
using HomeBid.Services.Bidding;
using HomeBid.Specifications.Drivers;

namespace HomeBid.Specifications.StepsDefinitions
{
    [Binding]
    public class OpenBiddingSteps
    {
        private PropertyDriver _propertyDriver;
        private BiddingProperty _biddingProperty;
        private string propertyTitle;
        private string askingPrice;

        [Given(@"I chose to create a new property")]
        public void GivenIChoseToCreateANewProperty()
        {
            _propertyDriver = new PropertyDriver();            
        }

        [Given(@"I entered title (.*)")]
        public void GivenIEnteredTitle(string title)
        {
            propertyTitle = title;
        }

        [Given(@"I entered asking price (.*)")]
        public void GivenIEnteredAskingPrice(string askingPrice)
        {
            this.askingPrice = askingPrice;
        }

        [When(@"I send the data")]
        public void WhenISendTheData()
        {
            var task = _propertyDriver.AddBiddingProperty(propertyTitle, askingPrice);
            task.Wait();
            _biddingProperty = task.Result;
        }

        [Then(@"a property is added with these details")]
        public void ThenAPropertyIsAddedWithTheseDetails()
        {
            Assert.NotNull(_biddingProperty);
            Assert.AreEqual(propertyTitle, _biddingProperty.Title);
            Assert.AreEqual(Convert.ToDecimal(askingPrice), _biddingProperty.AskingPrice);
        }

        [Then(@"it is available for bidding")]
        public void ThenItIsAvailableForBidding()
        {
            Assert.AreEqual(true, _biddingProperty.IsBiddingActive);
        }

        [Then(@"The message that appears is (.*)")]
        public void ThenTheMessageAppears(string message)
        {
            string[] messages = message.Split(';');
            var errors = _propertyDriver.Errors;
            CollectionAssert.AreEqual(messages, errors);
        }

        [Then(@"the property is not added")]
        public void ThenThePropertyIsNotAdded()
        {
            Assert.IsNull(_biddingProperty);
        }
    }
}