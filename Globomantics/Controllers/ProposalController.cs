using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.Controllers
{
    /// <summary>
    /// Controller for handling proposals for a conference.
    /// </summary>
    public class ProposalController : Controller
    {
        #region Private Fields

        private readonly IProposalService _service;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProposalController"/> class.
        /// </summary>
        /// <param name="service">The proposal service</param>
        public ProposalController(IProposalService service)
        {
            this._service = service;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Gets the details of all the proposals
        /// </summary>
        /// <param name="conferenceId">The conference id for which the proposals are required.</param>
        /// <returns>Proposal details of a conference</returns>
        public async Task<IActionResult> Index(int conferenceId)
        {
            ViewBag.Title = "Proposals for the selected conference";
            ViewBag.ConferenceId = conferenceId;
            return View(await this._service.GetAll(conferenceId).ConfigureAwait(false));
        }

        /// <summary>
        /// Gets the add view of a proposal.
        /// </summary>
        /// <returns>Add view of a proposal</returns>
        public async Task<IActionResult> Add(int conferenceId)
        {
            ViewBag.Title = "Add a Proposal";
            return await Task.Run(() =>
            {
                return View(new ProposalModel() { ConferenceId = conferenceId });
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Posts the added proposal from the view to this action.
        /// </summary>
        /// <param name="model">The incoming proposal model from the view.</param>
        /// <returns>The result of adding the proposal to the application.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this._service.Add(model).ConfigureAwait(false);
            }

            return RedirectToAction("Index", new { conferenceId = model.ConferenceId });
        }

        /// <summary>
        /// Approves a particular proposal.
        /// </summary>
        /// <param name="proposalId">The proposal to be approved.</param>
        /// <returns>Redirected index action result.</returns>
        public async Task<IActionResult> Approve(int proposalId)
        {
            ProposalModel model = null;

            if (this.ModelState.IsValid)
            {
                model = await this._service.Approve(proposalId).ConfigureAwait(false);
            }

            return RedirectToAction("Index", new { conferenceId = model.ConferenceId });
        }

        #endregion
    }
}