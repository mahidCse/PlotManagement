using System.Threading.Tasks;

namespace RealState.DataSeed
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
    }
}