using System.Collections.Generic;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Base;

namespace RestWithASP_NET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T model);
        T FindById(long id);
        List<T> FindAll();
        T Update(T model);
        void Delete(long id);
        bool Exists(long id);
    }
}