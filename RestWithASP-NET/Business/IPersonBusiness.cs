using System.Collections.Generic;
using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Business
{
    public interface IPersonBusiness
    {

        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
         
    }
}