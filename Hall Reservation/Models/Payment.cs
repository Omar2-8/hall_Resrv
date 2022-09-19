using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Payment
    {
        public decimal PayId { get; set; }
        public decimal? Status { get; set; }
        public decimal? PayAmount { get; set; }
        public decimal? HallName { get; set; }
        public DateTime PayDate { get; set; }
        public string? PayDesc { get; set; }
        public decimal? PayUserId { get; set; }
        public decimal? VisaId { get; set; }
        public decimal? BookingId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Hall? HallNameNavigation { get; set; }
        public virtual Hall? PayAmountNavigation { get; set; }
        public virtual User? PayUser { get; set; }
        public virtual Checked? StatusNavigation { get; set; }
        public virtual Visa? Visa { get; set; }
    }
}
