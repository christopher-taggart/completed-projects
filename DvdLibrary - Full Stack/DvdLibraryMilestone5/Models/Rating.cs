using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdLibraryMilestone5.Models
{
    public class Rating
    {
        [MaxLength(5)]
        public string RatingId { get; set; }
    }
}