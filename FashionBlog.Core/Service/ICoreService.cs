using FashionBlog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FashionBlog.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity //coreentity miras almayan model gönderemezsin!
    {
        bool Add(T model);

        bool Add(List<T> models);

        bool Update(T model);

        bool Remove(T model);

        bool Remove(Guid id);

        bool RemoveAl(Expression<Func<T, bool>> expression);

        T GetById(Guid id);

        T GetByDefault(Expression<Func<T, bool>> expression);

        List<T> GetActive(); //status den yakalayabilir

        List<T> GetDefault(Expression<Func<T, bool>> expression);

        List<T> GetAll();

        bool Activate(Guid id);  
        
        bool Any(Expression<Func<T, bool>> expression);

        int Save();
    }
}
