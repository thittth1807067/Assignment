using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Assignment_P3.Models
{
    public class Coin
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter baseasset")]
        public string BaseAsset { get; set; }
        [Required(ErrorMessage = "Please enter quoteasset")]
        public string QuoteAsset { get; set; }
        [Required(ErrorMessage = "Please enter last price")]
        public double LastPrice { get; set; }
        [Required(ErrorMessage = "Please enter volumn24h")]
        public double Volumn24h { get; set; }
        [Required(ErrorMessage = "Please choose market")]
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}