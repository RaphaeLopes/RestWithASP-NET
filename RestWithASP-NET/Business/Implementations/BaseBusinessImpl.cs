using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Generic;

namespace RestWithASP_NET.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;

        public BookBusinessImpl (IRepository<Book> repository){
            _repository = repository;
        }

        public List<Book> FindAll()
        {
           return _repository.FindAll();
        }

        public Book FindById(long id)
        {
           return _repository.FindById(id);
        }
        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public Book Update(Book Book)
        {
           return _repository.Update(Book);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}