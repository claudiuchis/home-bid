using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeBid.Services.Bidding.Models;

namespace HomeBid.Services.Bidding.Infrastructure.EntityConfigurations
{
    public class BiddingPropertyTypeConfiguration : IEntityTypeConfiguration<BiddingProperty>
    {
        public void Configure(EntityTypeBuilder<BiddingProperty> config)
        {
            config.ToTable("BiddingProperty", BiddingContext.DEFAULT_SCHEMA);

            config.HasKey(p => p.Id);

            config.Property(p => p.Id)
                .ForNpgsqlUseSequenceHiLo("propertyseq", BiddingContext.DEFAULT_SCHEMA);

            config.Property<bool>("IsBiddingActive")
                .HasDefaultValue(false);

            config.Property<string>("Title")
                .IsRequired();

            config.Property<decimal>("AskingPrice")
                .IsRequired();

        }
    }
}