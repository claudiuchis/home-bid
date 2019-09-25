using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NUnit.Framework;
using HomeBid.Services.Bidding.Models;
using HomeBid.Services.Bidding.Services;
using HomeBid.Services.Bidding.Controllers;

namespace HomeBid.Services.Bidding.UnitTests
{
    public class PropertiesControllerTests
    {
        private IBiddingService _service;
        private PropertiesController _controller;

        [SetUp]
        public void SetUp()
        {
            _service = new BiddingServiceFake();
            _controller = new PropertiesController(_service);
        }

        [Test]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var biddingProperty = new BiddingProperty()
            {
                AskingPrice = 350000.00M
            };
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var badResult = await _controller.Add(biddingProperty);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(badResult);
        }

        [Test]
        public async Task Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var biddingProperty = new BiddingProperty()
            {
                Title = "50 WoodBrook",
                AskingPrice = 350000.00M
            };

            // Act
            var createdResponse = await _controller.Add(biddingProperty);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(createdResponse);
        }

        [Test]
        public async Task Add_ValidObjectPassed_ReturnedResponseHasCreatedProperty()
        {
            // Arrange
            var biddingProperty = new BiddingProperty()
            {
                Title = "50 WoodBrook",
                AskingPrice = 350000.00M
            };

            // Act
            var createdResponse = await _controller.Add(biddingProperty) as CreatedAtActionResult;
            var property = createdResponse.Value as BiddingProperty;

            // Assert
            Assert.IsInstanceOf<BiddingProperty>(property);
            Assert.AreEqual(property.Title, biddingProperty.Title);
            Assert.AreEqual(property.AskingPrice, biddingProperty.AskingPrice);

        }
    }
}