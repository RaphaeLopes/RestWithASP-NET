using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;
using RestWithASP_NET.Repository;

namespace RestWithASP_NET.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl (IPersonRepository repository){
            _repository = repository;
        }

        public List<Person> FindAll()
        {
           return _repository.FindAll();
        }

        public Person FindById(long id)
        {
           return _repository.FindById(id);
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
           return _repository.Update(person);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}