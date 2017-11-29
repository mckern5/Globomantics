using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public interface IConferenceRepository
    {
        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetById(int id);

        Task<StatisticsModel> GetStatistics();

        Task Add(ConferenceModel model);
    }
}
