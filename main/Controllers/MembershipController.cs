using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject_2018136107.Models;

namespace TermProject_2018136107.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                string userid = "admin";
                string password = "123456";

                if (login.UserId.Equals(userid) && login.Password.Equals(password))
                {
                    TempData["Message"] = "Login Success!";
                    return RedirectToAction("Index", "Membership");
                }
                else
                {
                    message = "Login Failed";
                }
            }
            else
            {
                message = "Wrong information";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }
    }
}
