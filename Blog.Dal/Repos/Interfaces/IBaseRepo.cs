using Blog.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repos.Interfaces
{
    public interface IBaseREPO<T> where T : BaseEntity
    {
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);

        List<T> GetAll();
        List<T> GetAllActive();
        T GetById(int id);

        List<T> GetAllWhere(Expression<Func<T, bool>> expression);
        List<T> GetAllActiveWhere(Expression<Func<T, bool>> expression);
    }
}
