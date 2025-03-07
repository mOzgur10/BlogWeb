using Blog.Dal.Context;
using Blog.Dal.Repos.Interfaces;
using Blog.Data.Abstracts;
using Blog.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repos.Concrete
{
    public class BaseREPO<T> : IBaseREPO<T> where T : BaseEntity
    {
        private readonly AppDbContext db;
        public BaseREPO(DbContextOptions<AppDbContext> options)
        {
            db = new AppDbContext(options);
        }

        public int Create(T entity)
        {
            db.Add(entity);
            entity.isActive = true;
            return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.isActive = false;
            return db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetAllActive()
        {
            return db.Set<T>().Where(x=>x.isActive==true).ToList();
        }

        public List<T> GetAllActiveWhere(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(x => x.isActive == true).Where(expression).ToList();
        }

        public List<T> GetAllWhere(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            db.Update(entity);
            
            return db.SaveChanges();
        }
    }
}
