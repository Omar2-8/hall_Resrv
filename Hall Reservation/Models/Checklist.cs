using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Checklist
    {
        public Checklist()
        {
            Checkeds = new HashSet<Checked>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal CheckedId { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Checked> Checkeds { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
