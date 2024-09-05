
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

        //Update user 1
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

        //Update User2
        public IActionResult UpdateUserFinal(UserModel user)
        {
            using (var db = new DemoContext())
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

        //Update Teacher 1
        [HttpPost]
        public IActionResult UpdateTeacher(TeacherModel teacher)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Teacher.Where(u => u.Id == teacher.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Teacher 2
        public IActionResult UpdateTeacherFinal(TeacherModel teacher)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Teacher.Where(u => u.Id == teacher.Id).FirstOrDefault();

                UpdateTeacher.Name = teacher.Name;
                UpdateTeacher.Surname = teacher.Surname;
                UpdateTeacher.FormClass = teacher.FormClass;

                db.SaveChanges();
            }
            return View("Teacher");
        }

        //Update Parent 1
        [HttpPost]
        public IActionResult UpdateParent(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Parents.Where(u => u.Id == parent.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Parent 2
        public IActionResult UpdateParentFinal(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Parents.Where(u => u.Id == parent.Id).FirstOrDefault();

                UpdateTeacher.Name = parent.Name;
                UpdateTeacher.Surname = parent.Surname;
                UpdateTeacher.PhoneNumber = parent.PhoneNumber;
                UpdateTeacher.SpouseName = parent.SpouseName;
                UpdateTeacher.SpousePhoneNumber = parent.SpousePhoneNumber;
                UpdateTeacher.EmergencyContactName = parent.EmergencyContactName;
                UpdateTeacher.EmergencyContactPhoneNumber = parent.EmergencyContactPhoneNumber;
                db.SaveChanges();
            }
            return View("Parent");
        }


        //Update Child 1
        [HttpPost]
        public IActionResult UpdateChild(ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Child.Where(u => u.Id == child.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Child 2
        public IActionResult UpdateChildFinal(ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Child.Where(u => u.Id == child.Id).FirstOrDefault();

                UpdateTeacher.Name = child.Name;
                UpdateTeacher.Surname = child.Surname;
                UpdateTeacher.FormClass = child.FormClass;

                db.SaveChanges();
            }
            return View("Child");
        }


        //Update Account 1
        [HttpPost]
        public IActionResult UpdateAccount(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Account.Where(u => u.Id == account.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Account 2
        public IActionResult UpdateAccountFinal(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Account.Where(u => u.Id == account.Id).FirstOrDefault();

                UpdateTeacher.Username = account.Username;
                UpdateTeacher.Password = account.Password;
                UpdateTeacher.Position = account.Position;

                db.SaveChanges();
            }
            return View("Account");
        }

        //Update Attendance 1
        [HttpPost]
        public IActionResult UpdateAttendance(AttendanceModel attendance)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Attendance.Where(u => u.Id == attendance.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Attendance 2
        public IActionResult UpdateAttendanceFinal(AttendanceModel attendance)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Attendance.Where(u => u.Id == attendance.Id).FirstOrDefault();

                UpdateTeacher.TimeIn = attendance.TimeIn;
                UpdateTeacher.TimeOut = attendance.TimeOut;
                UpdateTeacher.Date = attendance.Date;
                UpdateTeacher.Present = attendance.Present;

                db.SaveChanges();
            }
            return View("Attendance");
        }


        //Update Admin 1
        [HttpPost]
        public IActionResult UpdateAdmin(AdminModel admin)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Admin.Where(u => u.Id == admin.Id).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Admin 2
        public IActionResult UpdateAdminFinal(AdminModel admin)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Admin.Where(u => u.Id == admin.Id).FirstOrDefault();

                UpdateTeacher.Name = admin.Name;
                UpdateTeacher.Surname = admin.Surname;


                db.SaveChanges();
            }
            return View("Admin");
        }

        //Delete User
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

        //Account Delete
        public IActionResult DeleteAccount(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Account.Where(u => u.Id == account.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
        }

        //Admin Delete
        public IActionResult DeleteAdmin(AdminModel admin)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Admin.Where(u => u.Id == admin.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
        }

        //Child Delete
        public IActionResult DeleteChild(ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Child.Where(u => u.Id == child.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
        }

        //Teacher Delete
        public IActionResult DeleteTeacher(TeacherModel teacher)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Teacher.Where(u => u.Id == teacher.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
        }

        //Parent Delete
        public IActionResult DeleteParent(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Parents.Where(u => u.Id == parent.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
        }

        //Attendance Delete
        public IActionResult DeleteAttendance(AttendanceModel attendance)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Attendance.Where(u => u.Id == attendance.Id).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return View("Index");
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


        public IActionResult Child()
        {
            List<ChildModel> child = new List<ChildModel>();

            using (var db = new DemoContext())
            {
                child = db.Child.ToList();
            }

            ViewBag.users = child;

            return View();
        }

        [HttpPost]
        public IActionResult Child(ChildModel child)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(child);
                    db.SaveChanges();
                }


            }

            return View();
        }

        public IActionResult Attendance()
        {
            List<AttendanceModel> attendance = new List<AttendanceModel>();

            using (var db = new DemoContext())
            {
                attendance = db.Attendance.ToList();
            }

            ViewBag.users = attendance;

            return View();
        }

        [HttpPost]
        public IActionResult Attendance(AttendanceModel attendance)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(attendance);
                    db.SaveChanges();
                }


            }

            return View();
        }
        public IActionResult Teacher()
        {
            List<TeacherModel> teacher = new List<TeacherModel>();

            using (var db = new DemoContext())
            {
                teacher = db.Teacher.ToList();
            }

            ViewBag.users = teacher;

            return View();
        }

        [HttpPost]
        public IActionResult Teacher(TeacherModel teacher)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(teacher);
                    db.SaveChanges();
                }


            }

            return View();
        }

        public IActionResult Account()
        {
            List<AccountModel> account = new List<AccountModel>();

            using (var db = new DemoContext())
            {
                account = db.Account.ToList();
            }

            ViewBag.users = account;

            return View();
        }

        [HttpPost]
        public IActionResult Account(AccountModel account)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(account);
                    db.SaveChanges();
                }


            }

            return View();
        }

        public IActionResult Admin()
        {
            List<AdminModel> admin = new List<AdminModel>();

            using (var db = new DemoContext())
            {
                admin = db.Admin.ToList();
            }

            ViewBag.users = admin;

            return View();
        }

        [HttpPost]
        public IActionResult Admin(AdminModel admin)
        {



            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(admin);
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
