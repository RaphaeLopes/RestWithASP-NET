using System.Collections.Generic;
using RestWithASP_NET.Model;

namespace RestWithASP_NET.Business
{
    public interface IBookBusiness
    {

        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
         
    }
}