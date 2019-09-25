using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBid.Services.Bidding.Models
{
    public class BiddingProperty
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Asking price is required.")]
        [Range(1, Double.MaxValue, ErrorMessage="Asking price is not valid.")]
        public decimal AskingPrice { get; set; }
        
        public bool IsBiddingActive { get; set; }
    } 
}