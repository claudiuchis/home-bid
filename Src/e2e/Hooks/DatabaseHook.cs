using System.Linq;
using HomeBid.Services.Bidding.Infrastructure;
using HomeBid.Specifications.Setup;

namespace HomeBid.Specifications.Hooks
{
    public class DatabaseHook
    {
        public void EmptyBiddingPropertyTable()
        {
            TestSetup.TestServer.Host
                .UpdateDatabase<BiddingContext>(context =>{
                    var range = context.BiddingProperties
                        .Where( x => 
                            x.Id > 0);
                    context.BiddingProperties.RemoveRange(range);
                    context.SaveChanges();
                });
        }
    }
}

