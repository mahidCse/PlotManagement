using RealState.Core.Entity;

namespace RealState.Models.PlotModels
{
    public class PlotModel
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public string PlotNumber { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
    }
}
