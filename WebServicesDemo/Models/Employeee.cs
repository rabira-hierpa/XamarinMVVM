using System.ComponentModel.DataAnnotations;

namespace WebServicesDemo.Models
{
    public class Employeee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

    }
}
