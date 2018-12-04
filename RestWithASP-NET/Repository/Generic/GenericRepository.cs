using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASP_NET.Model.Base;
using RestWithASP_NET.Model.Context;

namespace RestWithASP_NET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;

        //Declaração de um dataset generico
        private DbSet<T> dataset;

        public GenericRepository (MySqlContext context){
            _context = context;
            dataset = context.Set<T>();
        }
        public T Create(T model)
        {
            try {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return model;
        }

        public void Delete(long id)
        {
            if(!Exists(id)) return;
            var result = dataset.SingleOrDefault(p => p.id.Equals(id));
            try {
                 dataset.Remove(result);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.id.Equals(id));
        }

        public List<T> FindAll()
        {
             return dataset.ToList();
        }

        public T FindById(long id)
        {
             return dataset.SingleOrDefault(p => p.id.Equals(id));
        }

        public T Update(T model)
        {
            if(!Exists(model.id.Value)) return null;
            
            var result = _context.Books.SingleOrDefault(p => p.id.Equals(model.id));
            try {
                _context.Entry(result).CurrentValues.SetValues(model);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return model;
        }
    }
}