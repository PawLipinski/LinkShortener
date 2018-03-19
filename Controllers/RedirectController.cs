using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Repository;

namespace LinkShortener.Controllers
{
    public class RedirectController: Controller
    {
        [Route("shortLink")]
        public IActionResult MyRedirectShort(Link link)
        {
            return Redirect("http://" + link.fullLink);
        }

        [Route("fullLink")]
        public IActionResult MyRedirectFull(Link link)
        {
            return Redirect("http://" + link.fullLink);
        }

        public IActionResult RedirectByAddress(string shortLink)
        {
            var myList = LinksRepository.GetLinksStatic();
            string properLink= "";
            foreach(var element in myList){
                if(element.shortLink == shortLink) properLink = element.fullLink;
            }
            return Redirect("http://" + properLink);
        }
    }
}