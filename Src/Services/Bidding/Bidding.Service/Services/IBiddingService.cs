using System.Collections.Generic;
using System.Threading.Tasks;
using HomeBid.Services.Bidding.Models;

namespace HomeBid.Services.Bidding.Services
{
    public interface IBiddingService
    {
        Task<BiddingProperty> AddBiddingProperty(BiddingProperty property);
        Task<IEnumerable<BiddingProperty>> GetBiddingProperties();
    }
}