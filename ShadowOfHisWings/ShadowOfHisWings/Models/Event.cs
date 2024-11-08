using System;
using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Event Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
