using FashionBlog.Core.Entity;
using FashionBlog.Core.Entity.Enums;
using FashionBlog.Core.Service;
using FashionBlog.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace FashionBlog.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly FashionBlogContext _context;
        public BaseService(FashionBlogContext context)
        {
            _context = context;
        }

        public bool Activate(Guid id)
        {
            T active = GetById(id);
            active.Status = Status.Active;
            
            return Update(active);
        }

        public bool Add(T model)
        {
            try
            {
                _context.Set<T>().Add(model);
                return Save() > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(List<T> models)
        {
            try
            {
                ///çalışma bitince ram den at diyorum
                using (TransactionScope ts = new TransactionScope()) 
                {
                    _context.Set<T>().AddRange(models);
                    ts.Complete();
                    return Save() > 0;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);
      

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public bool Remove(T model)
        {
            try
            {
                _context.Set<T>().Remove(model);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T remove_item = GetById(id);
                    ts.Complete();
                    _context.Set<T>().Remove(remove_item);

                    return Save() > 0;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveAl(Expression<Func<T, bool>> expression)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var removeall = GetDefault(expression);
                    int count = 0;
                    foreach (var model in removeall)
                    {
                        bool result = Remove(model);
                        if (result)
                        {
                            count++;
                        }
                    }
                    if (removeall.Count == count )
                    {
                        ts.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T model)
        {
            try
            {
                _context.Set<T>().Update(model);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
