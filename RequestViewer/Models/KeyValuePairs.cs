using RequestResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestViewer.Models
{
    public class KeyValuePairs
    {
        public IList<KeyValuePair<string, string>> Data {get;set;}
        public string IP { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}