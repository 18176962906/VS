using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NumController : Controller
    {
        // GET: Num
        public ActionResult Index()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;
            if (hour < 11)
            {
                greeting = "早上好！";
            }
            else if (hour < 13)
            {
                greeting = "中午好！";
            }
            else
            {
                greeting = "下午好！";
            }
            ViewData["greeting"] = greeting;


            Customer cus = new Models.Customer();
            Employee emp = new Models.Employee();
            cus.CustomerName = "小明";
            cus.Address = "作家";
            ViewData["Employee"] = emp;
            ViewBag.Customer = cus;

            emp.Name = "天天";
            emp.Salary = 2000;
            ViewData["Customer"] = cus;
            ViewBag.Employee = emp;
            return View("Index",emp);



        }
    }
}