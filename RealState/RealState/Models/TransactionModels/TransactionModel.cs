using Microsoft.AspNetCore.Http;
using RealState.Core.Entity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealState.Models.TransactionModels
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public IFormFile ImageFile { get; set; }

        [Display(Name ="Transaction Slip")]
        public string ImageUrl { get; set; }
        public int Flag { get; set; }
        public int AccountId { get; set; }
        [DisplayName("Account")]
        public string AccountName { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
