using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class MusicController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Save(Music m)
        {
            MusicBusiness mb = new MusicBusiness();
            mb.Addm(m);
            return new RedirectResult("index");
        }
        public ActionResult Select(string name)
        {
            MusicViewModel mv = new MusicViewModel();
            mv.UserName = name;
            return View("Index",name);
        }
    }
}