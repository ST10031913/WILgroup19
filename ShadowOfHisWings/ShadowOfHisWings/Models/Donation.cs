using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Donation
    {
        [Required]
        public string DonorName { get; set; }

        [Required, EmailAddress]
        public string DonorEmail { get; set; }

        [Required, Range(1, double.MaxValue, ErrorMessage = "Please enter a valid donation amount")]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
