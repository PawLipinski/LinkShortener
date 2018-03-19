using System.Collections.Generic;
using LinkShortener.Models;

namespace LinkShortener.Interfaces
{
    public interface ILinksRepository
    {
         List<Link> GetLinks();
         void AddLink(Link link);
         void Delete(Link link);
    }
}