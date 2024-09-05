
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.IO.Enumeration;
using test_Data.Helper.QRCodeGeneratorHelper;
using test_Data.Models;
using static System.Net.Mime.MediaTypeNames;


namespace test_Data.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRCodeGeneratorHelper qRCodeGeneratorHelper;

        public HomeController(ILogger<HomeController> logger, IQRCodeGeneratorHelper qRCodeGeneratorHelper)
        {
            _logger = logger;
            this.qRCodeGeneratorHelper = qRCodeGeneratorHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest();
            byte[] QRCodeAsBytes = qRCodeGeneratorHelper.GenerateQRCode(text);
            string QRCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}";

            GenerateQRCodeViewModel model = new GenerateQRCodeViewModel();
            model.QRCodeImageUrl = QRCodeAsImageBase64;


            return View(model);
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

        public IActionResult DeleteUser(UserModel user)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
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

        public IActionResult RouteAddUsers()
        {
            return View("AddUsers");
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

        public IActionResult Parent()
        {
            List<ParentModel> parent = new List<ParentModel>();

            using (var db = new DemoContext())
            {
                parent = db.Parents.ToList();
            }

            ViewBag.users = parent;

            return View();
        }

        [HttpPost]
        public IActionResult Parent(ParentModel parent)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(parent);
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
