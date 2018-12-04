using System.Collections.Generic;
using System.Linq;
using RestWithASP_NET.Data.Converter;
using RestWithASP_NET.Model;
using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();

            return new PersonVO
            {
                id = origin.id,
                firstName = origin.firstName,
                lastName = origin.lastName,
                address = origin.address,
                gender = origin.gender
            };
        }

        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();
            return new Person
            {
                id = origin.id,
                firstName = origin.firstName,
                lastName = origin.lastName,
                address = origin.address,
                gender = origin.gender
            };
        }

        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}