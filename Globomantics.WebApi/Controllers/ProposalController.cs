using System.Threading.Tasks;
using Globomantics.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class ProposalController : Controller
    {
        private readonly IProposalRepository _repository;

        public ProposalController(IProposalRepository service)
        {
            this._repository = service;
        }

        [HttpGet("{conferenceId}")]
        public async Task<IActionResult> GetAll(int conferenceId)
        {
            return await Task.FromResult<IActionResult>(new ObjectResult(this._repository.GetAll(conferenceId))).ConfigureAwait(false);
        }

        /// <summary>
        /// Posts the added proposal from the view to this action.
        /// </summary>
        /// <param name="model">The incoming proposal model from the view.</param>
        /// <returns>The result of adding the proposal to the application.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel model)
        {
            ProposalModel addedModel = null;
            addedModel = await this._repository.Add(model).ConfigureAwait(false);
            return addedModel != null ? await Task.FromResult<IActionResult>(CreatedAtRoute("GetById", new { id = addedModel.Id }))
                : await Task.FromResult<IActionResult>(NoContent());
        }

        /// <summary>
        /// Approves a particular proposal.
        /// </summary>
        /// <param name="proposalId">The proposal to be approved.</param>
        /// <returns>Redirected index action result.</returns>
        [HttpPut("{proposalId}")]
        public async Task<IActionResult> Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(await this._repository.Approve(proposalId).ConfigureAwait(false));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}