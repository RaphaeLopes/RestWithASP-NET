using RestWithASP_NET.Model.Base;

namespace RestWithASP_NET.Model
{
    public class Person: BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
    }
}