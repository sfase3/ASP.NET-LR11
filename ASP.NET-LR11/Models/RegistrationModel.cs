using System.ComponentModel.DataAnnotations;

namespace LR11.Models
{
    public class RegistrationModel
    {


        [Required]
        public string Name { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
