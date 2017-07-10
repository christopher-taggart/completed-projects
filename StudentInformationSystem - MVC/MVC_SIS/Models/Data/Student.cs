using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "A first name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "A last name is required.")]
        public string LastName { get; set; }
        [Range(0,4)]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
       [Required(ErrorMessage = "A major must be selected.")]
        public Major Major { get; set; }
       
        public List<Course> Courses { get; set; }
    }
}