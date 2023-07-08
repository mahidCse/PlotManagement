using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Entity
{
    public class PlotBooking
    {
        public int Id { get; set; }
        public int PlotId { get; set; }
        public Plot Plot { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookedOn { get; set; }
        public DateTime? VacatedOn { get; set; }
    }
}
