using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;

namespace RestWithASP_NET.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImpl (MySqlContext context){
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
            if(!Exists(id)) return;
            var result = _context.Persons.SingleOrDefault(p => p.id.Value.Equals(id));
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
           return _context.Persons.SingleOrDefault(p => p.id.Value.Equals(id));
        }

        public Person Update(Person person)
        {
            if(!Exists(person.id.Value)) return null;
            
            var result = _context.Persons.SingleOrDefault(p => p.id.Value.Equals(person.id));
            try {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return person;
        }

        public bool Exists(long Id){
            return _context.Persons.Any(p => p.id.Value.Equals(Id));
        }
    }
}