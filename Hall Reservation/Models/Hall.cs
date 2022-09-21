using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hall_Reservation.Models
{
    public partial class Hall
    {
        public Hall()
        {
            Bookings = new HashSet<Booking>();
            Checkeds = new HashSet<Checked>();
            PaymentHallNameNavigations = new HashSet<Payment>();
            PaymentPayAmountNavigations = new HashSet<Payment>();
            Reviews = new HashSet<Review>();
        }

        public decimal HallId { get; set; }
        public decimal? CategoryId { get; set; }
        [BindProperty]
        [NotMapped]
        public string CategoryName{ get; set; }

        public string HallName { get; set; } = null!;
        public decimal HallCapacity { get; set; }
        public string? ImagePath { get; set; }
        public string? HallDescription { get; set; }
        public decimal BookingPrice { get; set; }
        public decimal? AddressId { get; set; }
        [BindProperty]
        [NotMapped]
        public string AddressName { get; set; }

        public string? Street { get; set; }
        public decimal? BuildingNumber { get; set; }
        [BindProperty]
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Checked> Checkeds { get; set; }
        public virtual ICollection<Payment> PaymentHallNameNavigations { get; set; }
        public virtual ICollection<Payment> PaymentPayAmountNavigations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
