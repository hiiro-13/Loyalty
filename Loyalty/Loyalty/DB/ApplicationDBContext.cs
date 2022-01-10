using Loyalty.Model;
using Microsoft.EntityFrameworkCore;


namespace Loyalty.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categorys{get; set;}

         public DbSet<Product> Products{get; set;}

      
    }
}