using System;
using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; } = false;
    }
}
