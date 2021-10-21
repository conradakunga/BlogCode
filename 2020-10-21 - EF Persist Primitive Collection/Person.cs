using System.ComponentModel.DataAnnotations;

namespace EFTest
{
    public class Person
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Hobby> Hobbies { get; set; } = new();
    }
}