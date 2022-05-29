using bsef19a032_LogIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace bsef19a032_LogIn.Controllers
{
    public class UserController : Controller
    {
        public string index()
        {
            return "AoA Palistan";
        }

        [HttpGet]
        public ViewResult login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult login(User u)
        {
            if (UsersRepository.checkUser(u))
                return View("ShowUsers", u);
            else
                return View("login", "User not found");

        }

        public ViewResult UsersList()
        {
            return View(UsersRepository.GetAllUsers());
        }

        [HttpGet]
        public ViewResult signup()
        {
            return View();
        }

        [HttpPost]
        public ViewResult signup(User u)
        {
            UsersRepository.AddUser(u);
            return View("ShowUsers", u);
        }
    }
}
