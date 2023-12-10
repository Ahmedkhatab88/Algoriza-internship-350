

using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistence.EntitiesConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients").HasKey(p => p.Id);

            builder.HasOne(x => x.DiscountCodeCoupon)
                   .WithOne(x => x.Patient)
                   .HasForeignKey<DiscountCodeCoupon>(x => x.PatientId);
        }
    }

}
