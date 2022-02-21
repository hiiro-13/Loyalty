using Loyalty.Model;
using Microsoft.EntityFrameworkCore;


namespace Loyalty.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
        public DbSet<Category> Categorys{get; set;}

         public DbSet<Product> Products{get; set;}
        public string Description { get; set; }
         public string LastName { get; set; }
        public string FirstName { get; set; }
      
    }
}