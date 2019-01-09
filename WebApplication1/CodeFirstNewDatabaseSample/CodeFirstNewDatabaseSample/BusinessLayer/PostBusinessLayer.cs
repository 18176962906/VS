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
    public class PostBusinessLayer
    {
        public void Add(Post post)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Posts.Add(post);
                //保存状态改变
                db.SaveChanges();
            }
        }
        public Post QueryPost(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }


        public void UpdatePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(post).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }
        public void DeletePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }
        public List<Post> QueryForTitle(string title)
        {
            using (var db = new BloggingContext())
            {
                // 查询所有包含字符串name的博客
                var query = from b in db.Posts
                            where b.Title == title
                            select b;
                return query.ToList();
            }
        }



    }
}
