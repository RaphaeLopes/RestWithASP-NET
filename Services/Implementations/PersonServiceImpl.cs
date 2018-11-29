using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;

namespace RestWithASP_NET.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
           return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
           List<Person> persons = new List<Person>();
           for (int i = 0; i < 8; i++) {
            var person = MokPerson(i);
             persons.Add(person);
           }
           return persons;
        }

        public Person FindById(long id)
        {
            return new Person(){
                Id = IncremetAndGet(),
                firstName = "Raphael",
                lastName = "Lopes",
                address = "teste de endereço",
                gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MokPerson(int i){
             return new Person(){
                Id = IncremetAndGet(),
                firstName = "Person Name " + i,
                lastName = "Person LastName " + i,
                address = "Some Address " + i,
                gender = "Male"
            };
        }

        private long IncremetAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}