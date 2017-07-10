using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exercises.Models.Data
{
    public class Major
    {
        public int MajorId { get; set; }
                                   
        public string MajorName { get; set; }
    }
}