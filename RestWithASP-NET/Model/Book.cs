using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASP_NET.Model.Base;

namespace RestWithASP_NET.Model
{
    public class Book: BaseEntity
    {
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public DateTime launchDate { get; set; }
    }
}