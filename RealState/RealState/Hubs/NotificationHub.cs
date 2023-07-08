using Microsoft.AspNetCore.SignalR;
using RealState.Core.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RealState.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendBookedPlotCount(int bookedPlotCount)
        {
            await Clients.All.SendAsync("BookedPlotCount", bookedPlotCount);
        }
    }
}
