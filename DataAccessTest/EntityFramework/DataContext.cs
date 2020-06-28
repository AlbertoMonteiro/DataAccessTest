using Microsoft.EntityFrameworkCore;

namespace DataAccessTest.EntityFramework
{
    public class DataContext : DbContext
    {
        private readonly string connectionString;

        public DataContext(string connectionString)
        => this.connectionString = connectionString;

        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseNpgsql(connectionString);
            //=> builder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
            => modelBuilder.ApplyConfiguration(new CustomerMap());
    }
}
