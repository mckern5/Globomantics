using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public interface IStatisticsMemoryRepository
    {
        Task<StatisticsModel> GetStatistics();
    }
}
