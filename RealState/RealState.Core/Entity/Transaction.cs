using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string ImageUrl { get; set; }
        public int Flag { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
