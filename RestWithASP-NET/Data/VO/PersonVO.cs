using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASP_NET.Data.VO
{
    public class PersonVO: ISupportsHyperMedia
    {
        public long? id {get; set;}
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public List<HyperMediaLink> Links { get; set ; } = new List<HyperMediaLink>();
    }
}