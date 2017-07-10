using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdLibraryMilestone5.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(5)]
        public string RatingId { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        [MaxLength(4)]
        public string ReleaseYear { get; set; }
        public string Notes { get; set; }



        public virtual Rating Rating { get; set; }
    }
}