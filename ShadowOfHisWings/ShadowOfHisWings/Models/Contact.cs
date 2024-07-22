using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}

