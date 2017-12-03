using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.Services
{
    public class ProposalApiService
    {
        private readonly HttpClient _client;

        public ProposalApiService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<IActionResult> Add(ProposalModel model)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.PostAsJsonAsync("v1/Proposal", model).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<IActionResult>();
            }).ConfigureAwait(false);
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage message = await this._client.PutAsJsonAsync("v1/Proposal", proposalId).ConfigureAwait(false);
                return await message.Content.ReadAsAsync<IActionResult>().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
