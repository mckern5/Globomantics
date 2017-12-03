using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _repository;

        public ConferenceController(IConferenceRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IActionResult> GetAll()
        {
            return await Task.Run(async () =>
            {
                IEnumerable<ConferenceModel> conferences = await this._repository.GetAll().ConfigureAwait(false);
                return conferences.Count() > 0 ? await Task.FromResult<IActionResult>(new ObjectResult(conferences)).ConfigureAwait(false) :
                await Task.FromResult<IActionResult>(new NoContentResult()).ConfigureAwait(false);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ConferenceModel conference)
        {
            return await Task.Run(async () =>
            {
                ConferenceModel model = await this._repository.Add(conference).ConfigureAwait(false);
                return model != null ? await Task.FromResult<IActionResult>(new ObjectResult(model)) : NotFound(conference);
            });
        }

        [HttpGet]
        public async Task<StatisticsModel> GetStatistics()
        {
            return await Task.Run(async () =>
            {
                return await this._repository.GetStatistics().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}