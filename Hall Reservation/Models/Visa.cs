using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Visa
    {
        public Visa()
        {
            Payments = new HashSet<Payment>();
        }

        public decimal VisaId { get; set; }
        public string? VisaName { get; set; }
        public long VisaNumber { get; set; }
        public decimal VisaAmount { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? CvcCvv { get; set; }
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
