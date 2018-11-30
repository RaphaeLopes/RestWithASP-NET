using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;

namespace RestWithASP_NET.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImpl (MySqlContext context){
            _context = context;
        }

        public Person Create(Person person)
        {
            try {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            if(!Exist(id)) return;
            var result = _context.Persons.SingleOrDefault(p => p.Id.Value.Equals(id));
            try {
                 _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
           return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
           return _context.Persons.SingleOrDefault(p => p.Id.Value.Equals(id));
        }

        public Person Update(Person person)
        {
            if(!Exist(person.Id.Value)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Value.Equals(person.Id));
            try {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return person;
        }

        private bool Exist(long Id){
            return _context.Persons.Any(p => p.Id.Value.Equals(Id));
        }
    }
}