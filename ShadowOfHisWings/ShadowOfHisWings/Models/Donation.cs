using System;
using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Donor Name")]
        public string DonorName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Donor Email")]
        public string DonorEmail { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
