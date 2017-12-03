using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient _client;

        public ConferenceApiService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<ConferenceModel> Add(ConferenceModel model)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.PostAsJsonAsync("v1/Conference", model);
                return await message.Content.ReadAsAsync<ConferenceModel>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.GetAsync(new Uri("v1/Conference", UriKind.Relative)).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<IEnumerable<ConferenceModel>>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.GetAsync(new Uri($"v1/Conference/{id}")).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<ConferenceModel>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.GetAsync(new Uri($"v1/Statistics")).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<StatisticsModel>();
            }).ConfigureAwait(false);
        }
    }
}
