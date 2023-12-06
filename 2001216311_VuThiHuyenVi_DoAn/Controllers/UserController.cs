using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001216311_VuThiHuyenVi_DoAn.Models;
using Microsoft.AspNet.Identity;

namespace _2001216311_VuThiHuyenVi_DoAn.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user) 
        { 
            if(user != null)
            {
                CompanyDBContext db = new CompanyDBContext();
                User myUser = db.User.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if(myUser != null)
                {
                    if(myUser.Password == user.Password)
                    {
                        HttpCookie authCookie = new HttpCookie("auth", myUser.UserName);
                        HttpCookie roleCookie = new HttpCookie("role", myUser.Role);
                        Response.Cookies.Add(authCookie);
                        Response.Cookies.Add(roleCookie);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("Password", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View();
        }
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("auth");
            authCookie.Expires = DateTime.Now.AddDays(-1);
            HttpCookie roleCookie = new HttpCookie("role");
            roleCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);
            Response.Cookies.Add(roleCookie);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user, string retypePassword)
        {
            if(ModelState.IsValid)
            {
                if (user.Password != retypePassword)
                {
                    ModelState.AddModelError("retypePassword", "Password không trùng khớp");
                    return View();
                }
                CompanyDBContext db = new CompanyDBContext();
                User myUser = db.User.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (myUser != null)
                {
                    ModelState.AddModelError("UserName", "UserName đã tồn tại");
                    return View();
                }
                myUser = db.User.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefault();
                if (myUser != null)
                {
                    ModelState.AddModelError("EmailAddress", "EmailAddress đã tồn tại");
                    return View();
                }

                myUser = new User();
                myUser.UserName = user.UserName;
                myUser.Password = user.Password;
                myUser.EmailAddress = user.EmailAddress;
                myUser.Role = "user";
                db.User.Add(myUser);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            else
            {
                return View();
            }
        }
    }
}