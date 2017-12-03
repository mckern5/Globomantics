using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public class StatisticsMemoryRepository: IStatisticsMemoryRepository
    {
        private readonly IConferenceRepository _conferenceRepo;

        public StatisticsMemoryRepository(IConferenceRepository conferenceRepo)
        {
            this._conferenceRepo = conferenceRepo;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            return await Task.Run(async () =>
            {
                var conferences = await _conferenceRepo.GetAll().ConfigureAwait(false);
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
                };
            }).ConfigureAwait(false);
        }
    }
}
