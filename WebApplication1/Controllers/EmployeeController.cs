using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.EmployeeViewList = getEmpVmList();
            employeeListViewModel.Greeting = getGreeting();
            employeeListViewModel.UserName = getUserName();


            return View(employeeListViewModel);


        }
        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务chen
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            var listEmp = empBal.GetEmployees();
            var listEmpVm= new List<EmployeeViewModel>();
            foreach (Employee emp in listEmp)
            {
                EmployeeViewModel empViewModel = new ViewModels.EmployeeViewModel();
                empViewModel.EmployeeName = emp.Name;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 10000)
                {
                    empViewModel.SalaryGrade = "土豪";
                }
                else
                {
                    empViewModel.SalaryGrade = "屌丝";
                }
                listEmpVm.Add(empViewModel);
            }
            return listEmpVm;
        }
        [NonAction]

        string getGreeting()
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
            return greeting;
        }

        [NonAction]

        string getUserName()
        {
            return "Admin";

        }

        
    }
}