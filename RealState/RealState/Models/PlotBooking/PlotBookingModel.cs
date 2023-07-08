using RealState.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RealState.Models.PlotBooking
{
    public class PlotBookingModel
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public int PlotId { get; set; }
        public string PlotNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookedOn { get; set; } 
        public DateTime? VacatedOn { get; set; }
    }
}
