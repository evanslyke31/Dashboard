using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Dashboard.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/?name=x&numTimes=y 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            //Use the ViewData dict to pass values to view (Not prefered over View Model method)
            //Other options ViewBag, TempData
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}