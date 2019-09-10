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
        private BiddingDriver biddingDriver;
        private string propertyTitle;
        private string askingPrice;
        public OpenBiddingSteps()
        {
            biddingDriver = new BiddingDriver();
        }

        [Given(@"I chose to create a new property")]
        public void GivenIChoseToCreateANewProperty()
        {
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
            var task = biddingDriver.AddBiddingProperty(propertyTitle, askingPrice);
            task.Wait();
        }

        [Then(@"a property is added with these details")]
        public void ThenAPropertyIsAddedWithTheseDetails()
        {
            var biddingProperty = biddingDriver.GetBiddingPropertyAdded();
            Assert.NotNull(biddingProperty);
            Assert.AreEqual(propertyTitle, biddingProperty.Title);
            Assert.AreEqual(Convert.ToDecimal(askingPrice), biddingProperty.AskingPrice);
        }

        [Then(@"it is available for bidding")]
        public void ThenItIsAvailableForBidding()
        {
            var biddingProperty = biddingDriver.GetBiddingPropertyAdded();
            Assert.AreEqual(true, biddingProperty.IsBiddingActive);
        }

        [Then(@"The message that appears is (.*)")]
        public void ThenTheMessageAppears(string message)
        {
            string[] messages = message.Split(';');
            ArrayList errors = biddingDriver.GetErrorMessages();
            CollectionAssert.AreEqual(messages, errors);
        }

        [Then(@"the property is not added")]
        public void ThenThePropertyIsNotAdded()
        {
            var biddingProperty = biddingDriver.GetBiddingPropertyAdded();
            Assert.IsNull(biddingProperty);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            biddingDriver.Dispose();
        }

    }
}