using ExampleProject.Models;
using Microsoft.EntityFrameworkCore;
namespace ExampleProject.DAO
{
    // DB context for example application
    public class ExampleDbContext : DbContext
    {
        // extends base DbContext class
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
        }
        // DbSet for Samples
        /*
            A db set was not created from the ItemModel because `Items` only exist in relation to Samples. An  `Item` table will automatically be generated but you will not be able to directly reference `Items` using this current structure unless you go through Samples. 
        */
        public DbSet<SampleModel> Samples {get;set;}
        // DbSet for Buckets
        public DbSet<BucketModel> Buckets {get;set;}
    }
}