using Blog.Dal.Repos.Interfaces;
using Blog.Data.Abstracts;
using Blog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllActiveWhere(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllWhere(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

      

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
