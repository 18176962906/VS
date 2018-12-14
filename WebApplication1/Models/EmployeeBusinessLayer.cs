using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDL salesDal = new SalesERPDL();
            return salesDal.Employees.ToList();
            //var list = new List<Employee>();
            //Employee emp = new Models.Employee();
            //emp.Name = "zhangsan";
            //emp.Salary = 12333;
            //list.Add(emp);



        }
    }
}