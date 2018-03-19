using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    public class RedirectController: Controller
    {
        public IActionResult MyRedirect(Link link)
        {
            return Redirect("Http://" + link.fullLink);
        }
    }
}