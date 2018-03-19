using System.Collections.Generic;
using System.Linq;
using LinkShortener.Models;
using LinkShortener.Interfaces;

namespace LinkShortener.Repository
{
    public class LinksRepository : ILinksRepository
    {
        public static List<Link> _links = new List<Link>();

        public void AddLink(Link link)
        {
            _links.Add(link);
        }

        public List<Link> GetLinks()
        {
            return _links;
        }

        public void Delete(Link link)
        {
            var linkToDelete = _links
            .SingleOrDefault(element => element.fullLink == link.fullLink && element.shortLink == link.shortLink);
            _links.Remove(linkToDelete);
        }

        public static List<Link> GetLinksStatic()
        {
            return _links;
        }

    }
}