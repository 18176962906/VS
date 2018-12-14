using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;



namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "hello world! MVC!";
        }
        public Customer GetCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "def";
            return ct;
        }
        public ActionResult GetView()
        {





            Employee emp = new Employee();
            emp.Name = "小明";
            emp.Salary = 2000;

            EmployeeViewModel vmEmp = new ViewModels.EmployeeViewModel();

            vmEmp.EmployeeName = emp.Name;
            vmEmp.Salary = emp.Salary.ToString("C");
            if (emp.Salary > 1000)
            {
                vmEmp.SalaryGrade = "土豪";
            }
            else
            {
                vmEmp.SalaryGrade = "屌丝";
            }
            vmEmp.EmployeeName = "Admin";

            return View("MyView", vmEmp);








            //string greeting;
            //DateTime dt = DateTime.Now;
            //int hour = dt.Hour;
            //if (hour < 11)
            //{
            //    greeting = "早上好！";
            //}
            //else if( hour <13)
            //{
            //    greeting = "中午好！";
            //}
            //else
            //{
            //    greeting = "下午好！";
            //}
            //ViewData["greeting"] = greeting;


            //Employee emp = new Models.Employee();
            //emp.Name = "小明";
            //emp.Salary = 2000;
            ////ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;
            //return View("MyView",emp);

        }

    }
}