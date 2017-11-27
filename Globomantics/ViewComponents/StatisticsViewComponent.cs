using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.ViewComponents
{
    /// <summary>
    /// The statistics view component as the reusable view component wherever statistics data is needed.
    /// vaguely, a kind of mini StatisticsController for the corresponding partial statistics view.
    /// </summary>
    public class StatisticsViewComponent: ViewComponent
    {
        /// <summary>
        /// The statistics data will be received from the conference service.
        /// </summary>
        private readonly IConferenceService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewComponent"/> class.
        /// </summary>
        /// <param name="service">The conference service which gets the statistics data.</param>
        public StatisticsViewComponent(IConferenceService service)
        {
            this._service = service;
        }

        /// <summary>
        /// The asynchronous invoke method which gets the view component result to be injected as a partial.
        /// </summary>
        /// <param name="caption">The parameters received from the view for the view component</param>
        /// <returns>View component result which will be appended to the main view</returns>
        public async Task<IViewComponentResult> InvokeAsync(string caption)
        {
            ViewBag.Caption = caption;
            return View(await this._service.GetStatistics().ConfigureAwait(false));
        }
    }
}
