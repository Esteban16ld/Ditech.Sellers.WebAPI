using Ditech.Sellers.WebAPI.Data.Configurations;
using Ditech.Sellers.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ditech.Sellers.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Models
        public DbSet<CityModel> City { get; set; }
        public DbSet<SellerModel> Seller { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new SellerConfiguration());
        }
    }
}
