using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public ActionResult CreatRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatRole(string RoleName)
        {
            IdentityRole role = new IdentityRole();
            role.Name = RoleName;
            ApplicationDbContext context = new ApplicationDbContext();
            RoleStore<IdentityRole> store = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> manager = new RoleManager<IdentityRole>(store);
            manager.Create(role);
            return View();
        }
    }
}