using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddorEdit(int id = 0)
        {
            Table user = new Table(); 
            return View(user);
        }
        [HttpPost]
        public ActionResult AddorEdit(Table user)
        {
            using (DBModels db = new DBModels())
            {
                if (db.Tables.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "UserName Already Exits";
                    return View("AddorEdit", user);
                }
                else
                {
                    db.Tables.Add(user);
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registartion Successful";
            return View("AddorEdit", new Table());
        }
    }
}