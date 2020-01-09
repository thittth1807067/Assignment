using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_P3.Models
{
    public class Market
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}