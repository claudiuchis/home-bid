using System.Collections.Generic;
using HomeBid.Services.Bidding.Infrastructure;
using HomeBid.Services.Bidding.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HomeBid.Services.Bidding.Services
{
    public class BiddingService : IBiddingService
    {
        private BiddingContext _context;
        public BiddingService(BiddingContext context) 
        {
            _context = context;
        }

        public async Task<BiddingProperty> AddBiddingProperty(BiddingProperty property)
        {
            var biddingProperty = new BiddingProperty()
            {
                Title = property.Title,
                AskingPrice = property.AskingPrice,
                IsBiddingActive = true
            };
            _context.BiddingProperties.Add(biddingProperty);
            await _context.SaveChangesAsync();
            return biddingProperty;
        }

        public async Task<IEnumerable<BiddingProperty>> GetBiddingProperties()
        {
            var properties = await _context.BiddingProperties.ToListAsync();
            return (IEnumerable<BiddingProperty>)properties;
        }
    }
}