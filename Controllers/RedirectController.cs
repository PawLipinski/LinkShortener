using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    public class RedirectController: Controller
    {
        [Route("shortLink")]
        public IActionResult MyRedirect(Link link)
        {
            return Redirect("http://" + link.fullLink);
        }
    }
}