using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LinkShortener.Interfaces;
using LinkShortener.Models;
using HashidsNet;
using System;
using System.Text.RegularExpressions;

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
            // string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            // Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // if (reg.IsMatch(link.fullLink)){

                link.shortLink = hashids.Encode(Adler32(link.fullLink));
                _repository.AddLink(link);   
            // }
            
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link);
            return Redirect("Index");
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