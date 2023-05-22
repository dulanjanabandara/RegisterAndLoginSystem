using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterAndLoginSystem.Models;

namespace RegisterAndLoginSystem.Controllers
{
    public class AccountV2Controller : Controller
    {
        private ApplicationDbContext _context;

        public AccountV2Controller ()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose ( bool disposing )
        {
            _context.Dispose();
        }

        // GET: AccountV2
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            else
            {
                if ( user.Id == 0 )
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Login", "AccountV2");
                }
            }
            
            return RedirectToAction("Login", "AccountV2");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            if ( !ModelState.IsValid )
            {
                return View("Login");
            }
            else
            {
                var isValidUser = IsValidUser(user);

                if ( isValidUser != null )
                {
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        public User IsValidUser(LoginUser loginUser)
        {
            var user = _context.Users.Single(u => u.Id == loginUser.Id);
            
            if (user == null)
            {
                return null;
            }

            if (user.Email == loginUser.Email && user.Password == loginUser.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}