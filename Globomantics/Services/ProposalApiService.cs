using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ProposalApiService : IProposalService
    {
        private readonly HttpClient _client;

        public ProposalApiService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<ProposalModel> Add(ProposalModel model)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.PostAsJsonAsync("v1/Proposal", model).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<ProposalModel>();
            }).ConfigureAwait(false);
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.PutAsJsonAsync("v1/Proposal", proposalId).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<ProposalModel>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.GetAsync(new Uri($"v1/Proposal/{conferenceId}")).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<IEnumerable<ProposalModel>>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
