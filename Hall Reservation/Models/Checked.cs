using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Checked
    {
        public Checked()
        {
            Payments = new HashSet<Payment>();
        }

        public decimal CheckId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? HallId { get; set; }
        public decimal? BookingId { get; set; }
        public DateTime? CheckedDate { get; set; }
        public decimal? Status { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Hall? Hall { get; set; }
        public virtual Checklist? StatusNavigation { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
