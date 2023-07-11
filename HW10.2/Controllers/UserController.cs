using HW10._2.Models;
using Microsoft.AspNetCore.Mvc;
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
        [BindProperty]
        public Account account { get; set; }


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

        
   
    }
}
