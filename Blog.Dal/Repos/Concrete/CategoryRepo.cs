using Blog.Dal.Context;
using Blog.Dal.Repos.Interfaces;
using Blog.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Repos.Concrete
{
    public class CategoryRepo : BaseREPO<Category>, ICategoryRepo
    {
        private readonly AppDbContext db;
        public CategoryRepo(DbContextOptions<AppDbContext> options): base(options)
        {
            db = new AppDbContext(options);
        }
        
    }
}
