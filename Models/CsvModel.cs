using System.Collections.Generic;
using System.Linq;

namespace DriveHack.Site.Models
{
    public class CsvModel
    {
        public CsvModel(string name, string[] links)
        {
            Name = name;
            Links = links;
            MentionCount = links.Count();

        }

        public string Name;
        public int MentionCount;
        public string[] Links;

        public IEnumerable<string> ToStrings()
        {
            return (new string[] { Name, MentionCount.ToString() }.Concat(Links.AsEnumerable()));
        }
    }
}