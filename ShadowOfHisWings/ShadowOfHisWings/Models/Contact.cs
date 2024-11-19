using System;
using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [StringLength(150, ErrorMessage = "Subject cannot exceed 150 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
    }
}
