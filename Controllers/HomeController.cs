using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test_Data.Models;

namespace test_Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SearchUser(string searchTerm)
        {
            List<UserModel> users = new List<UserModel>();

            using (var db = new DemoContext())
            {
                users = db.Users.Where(u => u.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            TempData["users"] = users;

            return View("AddUsers");
        }

        public IActionResult UpdateUser()
        {
            using (var db = new DemoContext())
            {
                var user= db.Users.Where(u=> u.Id ==1).FirstOrDefault();

                user.Name = "Kumeren";

                db.SaveChanges();
            }


            return View("AddUsers");
        }

        public IActionResult AddUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (var db = new DemoContext())
            {
                users = db.Users.ToList();
            }

            TempData["users"] = users;

            return View();
        }



        [HttpPost]
        public IActionResult AddUsers(UserModel user)
        {

            if(ModelState.IsValid)
            {
             using (var db = new DemoContext())
             {
                db.Add(user);
                db.SaveChanges();
             }


            }

                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
