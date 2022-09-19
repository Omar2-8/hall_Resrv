using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Address
    {
        public Address()
        {
            Halls = new HashSet<Hall>();
        }

        public decimal AddressId { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
    }
}
