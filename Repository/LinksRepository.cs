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
            link.ID = _links.Count()+1;
            _links.Add(link);
        }

        public List<Link> GetLinks()
        {
            return _links;
        }

        public void Delete(Link link)
        {
            var linkToDelete = _links
            .FirstOrDefault(element => element.fullLink == link.fullLink && element.shortLink == link.shortLink && element.ID == link.ID);
            _links.Remove(linkToDelete);
            UpdateIDs();
        }

        public void UpdateIDs()
        {
            int number =1;
            foreach(var element in _links)
            {
                element.ID = number;
                number++;
            }
        }

        public static List<Link> GetLinksStatic()
        {
            return _links;
        }

    }
}