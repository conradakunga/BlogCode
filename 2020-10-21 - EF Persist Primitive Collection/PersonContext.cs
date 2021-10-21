using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace EFTest
{

    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Animal> Animals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=People;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the value converter for the Animal
            modelBuilder.Entity<Animal>()
                .Property(x => x.Foods)
                .HasConversion(new ValueConverter<List<string>, string>(
                    v => JsonConvert.SerializeObject(v), // Convert to string for persistence
                    v => JsonConvert.DeserializeObject<List<string>>(v))); // Convert to List<String> for use
        }
    }
}