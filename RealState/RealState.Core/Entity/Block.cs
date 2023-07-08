using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Entity
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Thana { get; set; }
        public int NumPlots { get; set; }
        public int NumAvailablePlots { get; set; }
        public int NumSoldPlots { get; set; }
        public IList<Plot> Plots { get; set; } = null;

    }
}
