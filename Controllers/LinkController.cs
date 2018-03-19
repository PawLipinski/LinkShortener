using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Interfaces;
using LinkShortener.Models;

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
            _repository.AddLink(link);
            return Redirect("Index");
        }
    }
}