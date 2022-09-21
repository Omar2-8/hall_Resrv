using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hall_Reservation.Models
{
    public partial class Home
    {
        public Home()
        {
            ContactUs = new HashSet<ContactU>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Id { get; set; }
        public string? Image1 { get; set; }
        [NotMapped]
        [BindProperty]
        public virtual IFormFile ImageFile1 { get; set; }
        public string? Title1 { get; set; }
        public string? Image2 { get; set; }
        [NotMapped]
        [BindProperty]
        public virtual IFormFile ImageFile2 { get; set; }
        public string? Title2 { get; set; }
        public string? Image3 { get; set; }
        [NotMapped]
        [BindProperty]
        public virtual IFormFile ImageFile3 { get; set; }
        public string? Title3 { get; set; }

        public virtual ICollection<ContactU> ContactUs { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
