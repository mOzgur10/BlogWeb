﻿using Blog.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
