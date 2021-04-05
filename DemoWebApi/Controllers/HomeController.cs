using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoWebApi.Models;
namespace DemoWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DeptClient client = new DeptClient();
            var data = client.ShowAllDept();
            ViewBag.Dept= data;
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DeptClient client = new DeptClient();
            var data = client.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Dept dept)
        {
            DeptClient client = new DeptClient();
            bool yesno = client.Edit(dept);
            return Redirect("index");
        }
    }
}
