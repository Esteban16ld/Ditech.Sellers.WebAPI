using Ditech.Sellers.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ditech.Sellers.WebAPI.Data.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<SellerModel>
    {
        public void Configure(EntityTypeBuilder<SellerModel> builder)
        {
            builder.HasKey(s => s.CODE);
            builder.Property(s => s.NAME).IsRequired();
            builder.Property(s => s.CITY_ID).IsRequired();
            builder.Property(s => s.LAST_NAME).IsRequired();
        }
    }
}
