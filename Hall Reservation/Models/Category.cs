using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hall_Reservation.Models
{
    public partial class Category
    {
        public Category()
        {
            Halls = new HashSet<Hall>();
        }

        public decimal CatId { get; set; }
        public string? CatName { get; set; }
        public string? CatImagePath { get; set; }
        [NotMapped]
        [BindProperty]
        public virtual IFormFile ImageFile { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
