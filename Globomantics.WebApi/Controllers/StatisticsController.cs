using System.Threading.Tasks;
using Globomantics.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsMemoryRepository _repository;

        public StatisticsController(IStatisticsMemoryRepository repository)
        {
            this._repository = repository;
        }

        public async Task<StatisticsModel> Get()
        {
            return await this._repository.GetStatistics().ConfigureAwait(false);
        }
    }
}