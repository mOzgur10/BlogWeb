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
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepo _articleRepo;
        public ArticleService(DbContextOptions<AppDbContext> options)
        {
            _articleRepo = new ArticleRepo(options);
        }

        public int Add(Article entity)
        {
            return _articleRepo.Create(entity);
        }

        public int Delete(Article entity)
        {
            return _articleRepo.Delete(entity);
        }

        public List<Article> GetAll()
        {
            return _articleRepo.GetAll();
        }

        public List<Article> GetAllActive()
        {
            return _articleRepo.GetAllActive();
        }

        public Article GetById(int id)
        {
            return _articleRepo.GetById(id);
        }

        public List<Article> GetAllWhere(Expression<Func<Article, bool>> expression)
        {
            return _articleRepo.GetAllWhere(expression);
        }

        public int Update(Article entity)
        {
            return _articleRepo.Update(entity);
        }

        public List<Article> GetAllActiveWhere(Expression<Func<Article, bool>> expression)
        {
            return _articleRepo.GetAllActiveWhere(expression);
        }
    }
}
