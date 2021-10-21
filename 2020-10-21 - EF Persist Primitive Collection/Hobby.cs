using System.ComponentModel.DataAnnotations;

namespace EFTest
{
    public class Hobby
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}