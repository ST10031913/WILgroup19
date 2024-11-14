using System;
using System.ComponentModel.DataAnnotations;

namespace ShadowOfHisWings.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Media Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Media Type")]
        public string Type { get; set; } // "Image" or "Video"

        [Display(Name = "URL (for Videos)")]
        public string? Url { get; set; } // Only for video links

        [Display(Name = "Image Path")]
        public string? ImagePath { get; set; } // Stores the path of uploaded images

        [Display(Name = "Date Uploaded")]
        public DateTime DateUploaded { get; set; } = DateTime.Now;
    }
}
