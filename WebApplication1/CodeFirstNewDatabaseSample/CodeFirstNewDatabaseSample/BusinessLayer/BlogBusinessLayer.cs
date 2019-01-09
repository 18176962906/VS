using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Blogs.Add(blog);
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                //return query.ToList();

                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }
    }
}
