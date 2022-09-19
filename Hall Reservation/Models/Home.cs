using System;
using System.Collections.Generic;

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
        public string? Title1 { get; set; }
        public string? Image2 { get; set; }
        public string? Title2 { get; set; }
        public string? Image3 { get; set; }
        public string? Title3 { get; set; }

        public virtual ICollection<ContactU> ContactUs { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
