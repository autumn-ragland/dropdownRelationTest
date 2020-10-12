using ExampleProject.Models;
using Microsoft.EntityFrameworkCore;
namespace ExampleProject.DAO
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
        }
        public DbSet<SampleModel> Samples {get;set;}
        public DbSet<BucketModel> Buckets {get;set;}
    }
}