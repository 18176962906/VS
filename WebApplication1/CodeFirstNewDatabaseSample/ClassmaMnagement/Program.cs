using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassmaMnagement.BusinessClass;
using ClassmaMnagement.Models;

namespace ClassmaMnagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个新博客
            CreateClass();
            QueryBlog();
            Update();
            Delete();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        //增加--交互

        static void CreateClass()
        {
            Console.WriteLine("请输入一个班级名称");
            string name = Console.ReadLine();
            ClassName classname = new ClassName();
            classname.Name = name;

            ClassBusiness cb = new ClassBusiness();
            cb.Add(classname);

        }

        //显示全部博客
        static void QueryBlog()
        {
            ClassBusiness cb = new ClassBusiness();
            var blogs = cb.Query();
            Console.WriteLine("所有数据库中的博客：");
            foreach (var item in blogs)
            {
                Console.WriteLine(item.ClassNameId  + "" + item.Name);
            }

        }
        //更新博客id
        static void Update()
        {
            ClassBusiness cb = new ClassBusiness();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            ClassName blog = cb.Query(id);
            Console.Write("请输入新博客名：");
            string name = Console.ReadLine();
            blog.Name = name;
            cb.Update(blog);
        }

        static void Delete()
        {
            ClassBusiness cb = new ClassBusiness();
            Console.Write("请输入一个博客id：");
            int id = int.Parse(Console.ReadLine());
            ClassName blog = cb.Query(id);
            cb.Delete(blog);
        }


    }
}
