

using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistence.EntitiesConfigurations
{
    public class DiscountCodeCouponConfiguration : IEntityTypeConfiguration<DiscountCodeCoupon>
    {
        public void Configure(EntityTypeBuilder<DiscountCodeCoupon> builder)
        {
            builder.ToTable("DiscountCodeCoupon").HasKey(x => x.Id);

            builder.Property(x => x.Value).HasPrecision(10, 2);
        }
    }

}
