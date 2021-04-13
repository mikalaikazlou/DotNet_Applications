using System.Collections.Generic;
using System.Linq;

namespace GrabberSite
{
    public class Searcher
    {
        public static bool IsItAddressSite(string enter)
        {
            List<string> list = new List<string>() {"by", "ru", "com", "ua", "pl", "de","net","uk","web","org","co"};
            return list.Any(item =>  enter.EndsWith("." + item));
        }
    }
}