using System.ComponentModel.DataAnnotations;

namespace EFTest
{
    public class Animal
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<string> Foods { get; set; } = new();
    }
}