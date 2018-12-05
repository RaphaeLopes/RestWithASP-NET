using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASP_NET.Data.VO
{
    public class BookVO: ISupportsHyperMedia
    {
        //[DataMember(Order = 1, Name ="codigo")]
        public long? id {get; set;}
        //[DataMember(Order = 2)]
        public string title { get; set; }
        //[DataMember(Order = 3)]
        public string author { get; set; }
        //[DataMember(Order = 5)]
        public decimal price { get; set; }
        //[DataMember(Order = 4)]
        public DateTime launchDate { get; set; }
         public List<HyperMediaLink> Links { get; set ; } = new List<HyperMediaLink>();
    }
}