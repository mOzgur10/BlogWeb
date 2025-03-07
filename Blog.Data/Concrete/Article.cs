using Blog.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ReadingTİme { get; set; }
        public int ViewCount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
