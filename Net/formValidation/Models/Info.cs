using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace formValidation.Models
{
    public class Info
    {
        [Required]
        public String uname { get; set; }
        [Required]
        public String id { get; set; }
        [Required]
        public String gender { get; set; }
        [Required]
        public String profession { get; set; }
        [Required]
        public String[] Hobbies { get; set; }
        [Required]
        public DateTime dob { get; set; }

    }
}