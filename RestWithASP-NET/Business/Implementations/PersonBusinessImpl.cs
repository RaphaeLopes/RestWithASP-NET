using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Generic;
using RestWithASP_NET.Data.Converters;
using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImpl (IRepository<Person> repository){
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
           return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
           return _converter.Parse(_repository.FindById(id));
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}