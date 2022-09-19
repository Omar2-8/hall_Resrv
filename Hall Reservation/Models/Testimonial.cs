using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Testimonial
    {
        public decimal Id { get; set; }
        public int? Rating { get; set; }
        public string? Opinion { get; set; }
        public decimal? UserId { get; set; }
        public decimal? HomeId { get; set; }
        public decimal? Status { get; set; }

        public virtual Home? Home { get; set; }
        public virtual Checklist? StatusNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
