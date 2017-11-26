using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.Controllers
{
    /// <summary>
    /// Controller for a actions for a conference.
    /// </summary>
    public class ConferenceController : Controller
    {
        #region Private Fields

        private readonly IConferenceService _service;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceController"/> class.
        /// </summary>
        /// <param name="service">The conference service.</param>
        public ConferenceController(IConferenceService service)
        {
            this._service = service;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Gets the details of all the conferences.
        /// </summary>
        /// <returns>The collection of all the conferences.</returns>
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            return View(await this._service.GetAll().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets the add view of a conference.
        /// </summary>
        /// <returns>Add view of a conference.</returns>
        public async Task<IActionResult> Add()
        {
            ViewBag.Title = "Add Conference";
            return await Task.Run(() =>
            {
                return View(new ConferenceModel());
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Posts the conference model from a view to this action.
        /// </summary>
        /// <param name="model">The conference model.</param>
        /// <returns>The result of addition of the conference model.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this._service.Add(model).ConfigureAwait(false);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}