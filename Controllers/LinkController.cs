using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Interfaces;
using LinkShortener.Models;
using HashidsNet;

namespace LinkShortener.Controllers
{
    public class LinkController : Controller
    {
        private ILinksRepository _repository;

        public LinkController(ILinksRepository linkRepository)
        {
            _repository = linkRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _repository.GetLinks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            var hashids = new Hashids();
            link.shortLink = hashids.Encode(Adler32(link.fullLink));
            _repository.AddLink(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult MyRedirect(Link link)
        {
            return new RedirectController().MyRedirect(link);
        }

        private static int Adler32(string str)
        {
            const int mod = 65521;
            int a = 1, b = 0;
            foreach (char c in str) {
                a = (a + c) % mod;
                b = (b + a) % mod;
            }
            return (b << 16) | a;
        }
    }
}