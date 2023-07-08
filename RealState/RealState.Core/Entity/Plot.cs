using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Entity
{
    public class Plot
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public string PlotNumber { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        
        public virtual IList<PlotBooking> Bookings { get; set; }

    }
}
