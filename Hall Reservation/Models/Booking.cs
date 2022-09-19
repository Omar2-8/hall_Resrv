using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Checkeds = new HashSet<Checked>();
            Payments = new HashSet<Payment>();
        }

        public decimal BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? HallId { get; set; }
        public decimal? UserId { get; set; }

        public virtual Hall? Hall { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Checked> Checkeds { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
