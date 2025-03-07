using Blog.Dal.Repos.Interfaces;
using Blog.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        List<T> GetAll();
        List<T> GetAllActive();
        List<T> GetAllWhere(Expression<Func<T, bool>> expression);
        List<T> GetAllActiveWhere(Expression<Func<T, bool>> expression);
        T GetById(int id);
    }
}
