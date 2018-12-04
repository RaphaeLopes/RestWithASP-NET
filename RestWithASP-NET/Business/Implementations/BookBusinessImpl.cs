using System.Collections.Generic;
using System.Threading;
using RestWithASP_NET.Model.Context;
using System;
using System.Linq;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Generic;
using RestWithASP_NET.Data.Converters;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;

namespace RestWithASP_NET.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImpl (IRepository<Book> repository){
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
           return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
           return _converter.Parse(_repository.FindById(id));
        }
        public BookVO Create(BookVO Book)
        {
            var bookEntity = _converter.Parse(Book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO Book)
        {
           var bookEntity = _converter.Parse(Book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}