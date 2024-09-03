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
        [HttpPost]
        public IActionResult UpdateUser(UserModel user)
        {
            using (var db = new DemoContext())
            {
                var userTemp= db.Users.Where(u=> u.Id == user.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }

        public IActionResult UpdateUserFinal(UserModel user)
        {
            using(var db = new DemoContext())
            {
                var UpdateUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();

                UpdateUser.Name = user.Name;
                UpdateUser.UserName = user.UserName;
                UpdateUser.Password = user.Password; 
                UpdateUser.Email = user.Email;

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
