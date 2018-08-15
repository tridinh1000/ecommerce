using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class EcommerceContext: DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options){}
        public DbSet<Product> products {get; set;}
        public DbSet<Customer> customers {get; set;}
        public DbSet<Order> orders {get; set;}
    }
}