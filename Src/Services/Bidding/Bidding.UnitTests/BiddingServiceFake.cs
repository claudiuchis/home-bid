using System.Threading.Tasks;
using HomeBid.Services.Bidding.Services;
using HomeBid.Services.Bidding.Models;

namespace HomeBid.Services.Bidding.UnitTests
{
    public class BiddingServiceFake: IBiddingService
    {
        public Task<BiddingProperty> AddBiddingProperty(BiddingProperty property)
        {
            property.Id = 1;
            return Task.FromResult(property);
        }

    }
}