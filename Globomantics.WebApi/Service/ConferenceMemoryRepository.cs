using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.WebApi.Service
{
    public class ConferenceMemoryRepository : IConferenceRepository
    {
        private readonly List<ConferenceModel> _conferences;

        public ConferenceMemoryRepository()
        {
            this._conferences = new List<ConferenceModel>()
            {
                new ConferenceModel()
                {
                    Id = 1,
                    Name = "NDC",
                    Location = "Oslo",
                    Start = new DateTime(2017, 12, 12),
                    AttendeeTotal = 2132
                },
                new ConferenceModel()
                {
                    Id = 2,
                    Name = "IT/DevConnections",
                    Location = "San Fransisco",
                    Start = new DateTime(2017, 12, 20),
                    AttendeeTotal = 3210
                }
            };
        }

        public async Task Add(ConferenceModel model)
        {
            if (model == null)
            {
                return;
            }

            model.Id = this._conferences.Count + 1;
            this._conferences.Add(model);
            await Task.FromResult<Task>(null).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return await Task.FromResult<IEnumerable<ConferenceModel>>
                (this._conferences).ConfigureAwait(false);
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            if (id <= 0)
            {
                return await Task.FromResult<ConferenceModel>(null).ConfigureAwait(false);
            }

            return await Task.FromResult<ConferenceModel>
                (this._conferences.Find(conference => conference.Id.Equals(id))).ConfigureAwait(false);
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            return await Task.Run(() =>
            {
                return new StatisticsModel()
                {
                    NumberOfAttendees = this._conferences.Sum(conference => conference.AttendeeTotal),
                    AverageConferenceAttendees = Convert.ToInt32(this._conferences.Average(conference => conference.AttendeeTotal))
                };
            }).ConfigureAwait(false);
        }
    }
}
