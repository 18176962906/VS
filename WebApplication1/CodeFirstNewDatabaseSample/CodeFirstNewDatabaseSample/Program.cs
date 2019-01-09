using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectPost();
            //A();
        }

        static void A()
        {
            //显示所有博客
            QueryBlog();
            Console.WriteLine(" --1-新增博客   --2-更改博客  --3-删除博客  --4-操作帖子--5-退出");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                CreateBlog();
                QueryBlog();
                Console.Clear();
                A();
            }
            else if (i == 2)
            {
                Update();
                QueryBlog();
                Console.Clear();
                A();
            }
            else if (i == 3)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                A();
            }
            else if (i == 4)
            {
                P();
            }
            else if (i == 5)
            {
                return;
            }
            else
            {
                Console.WriteLine("无效字符");
            }
        }
        static void P()
        {
            
            Console.Clear();
            int blogid = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogid);
            Console.WriteLine(" --1-新增帖子   --2-更改帖子  --3-删除帖子 --4-返回上一层 --5-退出");
            Console.WriteLine("请输入需要操作的指示符");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                CreatePost(blogid);
                Console.Clear();
                DisplayPosts(blogid);
                P();
            }
            else if (i == 2)
            {
                UpdatePost();
                Console.Clear();
                DisplayPosts(blogid);
                P();
            }
            else if (i == 3)
            {
                UpdatePost();
                Console.Clear();
                DisplayPosts(blogid);
                P();
            }
            else if (i == 4)
            {
               A();
            }
            else if (i == 5)
            {
                return;
            }
            else
            {
                Console.WriteLine("无效字符");
            }

            Console.Read();
        }
        //新增帖子
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogid = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogid);
            //根据指定到博客信息创建新帖子    
            CreatePost(blogid);
            //显示指定博客的帖子列表
           
        }
        //获取到博客Id
        static int GetBlogId()
        {
          //提示用户输入博客id
            Console.WriteLine("请输入要操作的博客id");
            //获取用户输入，并存储到变量id
            int id = int.Parse(Console.ReadLine());
            //返回id
            return id;
        }
        //遍历所有的帖子显示帖子标题（博客号 + 帖子标题）
        static void DisplayPosts(int blogid)
        {
             Console.WriteLine(blogid+"的帖子列表");
            List<Post> list = null;
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogid);
                list = blog.Posts.ToList();
            }
            foreach(var item in list)
            {
                Console.WriteLine(item.PostId+ "--" + item.Title);
            }
            
        }

        //新增帖子
        static void CreatePost( int blogid)
        {
            Console.WriteLine("请输入一个帖子名称");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一个帖子内容");
            string content = Console.ReadLine();
            Post post = new Models.Post();
            post.Title = title;
            post.Content = content;
            post.BlogId = blogid;
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            pbl.Add(post);
            
        }
        //修改帖子
        static void UpdatePost()
        {
            QueryBlog();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入想要修改的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postID);
            Console.WriteLine("请入新题目");
            string newtitle = Console.ReadLine();
            post.Title = newtitle;
            Console.WriteLine("请输入新内容");
            string newcontent = Console.ReadLine();
            post.Content = newcontent;
            pbl.UpdatePost(post);
            DisplayPosts(blogID);
        }
        //删除帖子
        static void DeletePost()
        {
            QueryBlog();

            BlogBusinessLayer bbl = new BlogBusinessLayer();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入想要删除的帖子");
            int postID = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postID);
            pbl.DeletePost(post);
            DisplayPosts(blogID);
        }

        //增加博客
        static void CreateBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);

        }
         //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            Console.WriteLine("所有数据库中的博客：");
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);
            }

        }
        //更新博客id
        static void Update()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            Console.Write("请输入新博客名：");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        //删除博客
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个博客id：");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }

        static void SelectPost()
        {
            Console.WriteLine("请输入将要查找到博客名称：");
            string name = Console.ReadLine();
            PostBusinessLayer pbl = new PostBusinessLayer();
            var query = pbl.QueryForTitle(name);
            foreach(var item in query)
            {
                Console.WriteLine(item.Title + "  " + item.Content);
            }
        }



    }
}
