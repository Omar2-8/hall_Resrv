using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Checkeds = new HashSet<Checked>();
            Logins = new HashSet<Login>();
            Payments = new HashSet<Payment>();
            Reviews = new HashSet<Review>();
            Testimonials = new HashSet<Testimonial>();
            Visas = new HashSet<Visa>();
        }

        public decimal UserId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long? Phonenumber { get; set; }
        public string? Email { get; set; }
        public string? UserImage { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Checked> Checkeds { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Visa> Visas { get; set; }
    }
}
