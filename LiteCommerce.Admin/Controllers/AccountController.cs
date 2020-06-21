using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LiteCommerce.Admin.Controllers
{/// <summary>
/// 
/// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
       
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string pw="",string pwn="",string confirmpw="")
        {
            WebUserData userData = User.GetUserData();
            Employee employee = CataLogBLL.GetEmployee(Convert.ToInt32(userData.UserID));
            if (employee.Password.Equals(MaHoaMD5Hepler.EncodeMD5(pw)))
            {
                if (pwn.Equals(confirmpw))
                {
                    UserAccountBLL.ChangePassword(MaHoaMD5Hepler.EncodeMD5(pwn),employee.Email);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("MatKhau", "Mật khẩu không khớp!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("MatKhauMoi", "Mật Khẩu không đúng!");
                return View();
            }
           
        }
        public ActionResult Index()
        {
            WebUserData userData = User.GetUserData();
            Employee employee = CataLogBLL.GetEmployee(Convert.ToInt32(userData.UserID));
            return View(employee);
        }
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Dashboard");
            return View();
            
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string email = "" , string password = "")
        {
            //TODO: Kiem tra tai khoan thong qua co so du lieu
            UserAccount user = UserAccountBLL.Authorize(email,MaHoaMD5Hepler.EncodeMD5(password), UserAccountTypes.Employee);
            if(user != null)
            {
                // Ghi nhan cooke dang nhap
                WebUserData userData = new WebUserData()
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    GroupName = user.Roles, // TODO: can thay doi cho dung
                    SessionID = Session.SessionID,
                    ClientIP = Request.UserHostAddress,
                    Photo = user.Photo,
                    LoginTime = DateTime.Now,
                    Title = user.Title
                    

                };
                FormsAuthentication.SetAuthCookie(userData.ToCookieString(), false);
                return RedirectToAction("Index", "Dashboard");
            }
            else// Dang nhap thanh cong
            {
                ModelState.AddModelError("LoginError", "Login Fail");
                    ViewBag.Email = email;
                    return View();
            }
            //if(email=="thanhdo121998@gmail.com" && password == "123") {
            //     //Ghi nhan phien dang nhap tai khoan
            //     System.Web.Security.FormsAuthentication.SetAuthCookie(email,false);
            //     // Chuyen trang ve Dashboard 
            //     return RedirectToAction("Index","Dashboard");
            // } else {
            //     ModelState.AddModelError("LoginError", "Login Fail");
            //     ViewBag.Email = email;
            //     return View();
            // }
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(string email="",string pwn="", string confirmpw="")
        {
            ViewBag.Email = email;
            if (pwn.Equals(confirmpw))
            {
                if (CataLogBLL.CheckEmail(email) != 0)
                {
                    UserAccountBLL.ChangePassword(MaHoaMD5Hepler.EncodeMD5(pwn),email);
                    return RedirectToAction("SignIn", "Account");
                }
                else
                {
                    ModelState.AddModelError("Messege", "Email không tồn tại!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Messege", "Mật Khẩu không khớp!");
                return View();
            }
            
        }

    }
}