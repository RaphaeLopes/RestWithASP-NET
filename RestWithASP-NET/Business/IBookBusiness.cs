using System.Collections.Generic;
using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Business
{
    public interface IBookBusiness
    {

        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
         
    }
}