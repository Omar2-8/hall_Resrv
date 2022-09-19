using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Review
    {
        public decimal ReviewsId { get; set; }
        public int? Rating { get; set; }
        public string? Opinion { get; set; }
        public decimal? UserId { get; set; }
        public decimal? HallId { get; set; }

        public virtual Hall? Hall { get; set; }
        public virtual User? User { get; set; }
    }
}
