using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassmaMnagement.Models;
using System.Data.Entity;
using ClassmaMnagement.DataAccessClass;

namespace ClassmaMnagement.BusinessClass
{
    public class ClassBusiness
    {
        public void Add(ClassName classname)
        {
            //设置上下文生存期
            using (var db = new ClassContext())
            {

                //向上下文Class数据集添加一个实体（改变实体状态为添加）
                db.ClassNames.Add(classname);


                //或者将实体状态为添加
                //db.Entry(classname).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }

        }
        public List<ClassName> Query()
        {
            using (var db = new ClassContext())
            {
                return db.ClassNames.ToList();
            }
        }
        public ClassName Query(int id)
        {
            using (var db = new ClassContext())
            {
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                //return query.ToList();

                return db.ClassNames.Find(id);
            }
        }

        public void Update(ClassName blog)
        {
            using (var db = new ClassContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }

        public void Delete(ClassName blog)
        {
            using (var db = new ClassContext())
            {
                db.Entry(blog).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }

    }
}
