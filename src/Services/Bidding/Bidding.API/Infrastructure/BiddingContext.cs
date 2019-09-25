using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using HomeBid.Services.Bidding.Models;
using HomeBid.Services.Bidding.Infrastructure.EntityConfigurations;

namespace HomeBid.Services.Bidding.Infrastructure
{
    public class BiddingContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "bidding";
        public DbSet<BiddingProperty> BiddingProperties { get; set;}

        public BiddingContext(DbContextOptions<BiddingContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BiddingPropertyTypeConfiguration());
        }
    }
}
