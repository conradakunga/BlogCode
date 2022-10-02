using Microsoft.EntityFrameworkCore;

namespace FunWithDatesAndTimes.Core
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=test;Password=test");
    }
}