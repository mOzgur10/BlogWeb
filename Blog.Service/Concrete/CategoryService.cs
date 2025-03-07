using Blog.Dal.Context;
using Blog.Dal.Repos.Concrete;
using Blog.Dal.Repos.Interfaces;
using Blog.Data.Concrete;
using Blog.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(DbContextOptions<AppDbContext> options)
        {
            _categoryRepo = new CategoryRepo(options);
        }

        public int Add(Category entity)
        {
            return _categoryRepo.Create(entity);
        }

        public int Delete(Category entity)
        {
            return _categoryRepo.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }

        public List<Category> GetAllActive()
        {
            return _categoryRepo.GetAllActive();
        }

        public Category GetById(int id)
        {
            return _categoryRepo.GetById(id);
        }

        public List<Category> GetAllWhere(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepo.GetAllWhere(expression);
        }

        public int Update(Category entity)
        {
            return _categoryRepo.Update(entity);
        }

        public List<Category> GetAllActiveWhere(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepo.GetAllActiveWhere(expression);
        }
    }
}
