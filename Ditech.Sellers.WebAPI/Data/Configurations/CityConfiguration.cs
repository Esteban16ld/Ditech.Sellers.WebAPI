using Ditech.Sellers.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ditech.Sellers.WebAPI.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.HasKey(c => c.CODE);
            builder.Property(c => c.DESCRIPTION).IsRequired();
        }
    }
}
