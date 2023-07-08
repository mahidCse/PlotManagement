using RealState.Core.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealState.Models.BlockModels
{
    public class BlockModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Total number of Plots is required")]
        public int NumPlots { get; set; }
        public int NumAvailablePlots { get; set; }
        public int NumSoldPlots { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plot price is required")]
        public decimal PlotPrice { get; set; }



    }
}
