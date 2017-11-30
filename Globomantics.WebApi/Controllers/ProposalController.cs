using Microsoft.AspNetCore.Mvc;

namespace Globomantics.WebApi.Controllers
{
    public class ProposalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}