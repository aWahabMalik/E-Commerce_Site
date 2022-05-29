using Microsoft.AspNetCore.Mvc;

namespace bsef19a032_LogIn.Controllers
{
    public class ProductsController : Controller
    {
        public string index()
        {
            return "AoA Palistan";
        }

        [HttpGet]
        public ViewResult laptops()
        {
            return View();
        }

        [HttpGet]
        public ViewResult cameras()
        {
            return View();
        }

        [HttpGet]
        public ViewResult accessories()
        {
            return View();
        }


        [HttpGet]
        public ViewResult product()
        {
            return View();
        }
    }
}
