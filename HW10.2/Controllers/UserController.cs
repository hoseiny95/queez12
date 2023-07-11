using HW10._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HW10._2.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = (UserRepository?)userRepository;
        }


        [BindProperty]
        public User user { get; set; }





        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult ShowData(User inputuser)
        {
            user = inputuser;
            return View("ShowData");
        }




        public ActionResult UserLogin(User user)
        {
            var myuser = userRepository.GetUser(user.Ncode);

            if (myuser == null)
            {
                ViewBag.ErrorMessage = "there isnt user with this nationalcode";
                return View("Login");
            }
            user = myuser;
            TempData["usernational"] = user.Ncode;
            return RedirectToAction("ShowData");

        }
        public IActionResult CreateCookie()
        {
            string key = "DemoCookie";
             string value = "masi";
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            cookieOptions.Path = "/";
            Response.Cookies.Append(key, value, cookieOptions);
            return View();
        }
        public IActionResult ReadData()
        {
            string key = "DemoCookie";
            var CookieValue = Request.Cookies[key];
            return View();
        }

        public ActionResult TransferAmt()
        {
              
            return Content(Request.Form["amt"] + " has been transferred to account " + Request.Form["act"]);
        }

        public ActionResult Index()
        {
            return View("TransferAmt");
        }



    }
}
