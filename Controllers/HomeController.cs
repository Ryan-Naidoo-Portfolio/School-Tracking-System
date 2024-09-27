
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.IO.Enumeration;
using test_Data.Helper.QRCodeGeneratorHelper;
using test_Data.Models;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;



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
        public IActionResult PreForgot()
        {
            return View();
        }
        public IActionResult ForgotPassword(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var userTemp = db.Account.Where(u => u.acUsername == account.acUsername).FirstOrDefault();
                //ViewBag.username = userTemp.acUsername;
            }
            //USES A TEXT FILE ALSO IN LOGIN CALLED currentuser
            string fileContent = string.Empty;
            string filePath = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\currentuser.txt";
            fileContent = System.IO.File.ReadAllText(filePath);
            ViewBag.FileContent = fileContent;
            
            return View();
        }

        public IActionResult ForgotPasswordFinal(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var UpdatePassword = db.Account.Where(u => u.acUsername == account.acUsername).FirstOrDefault();

                UpdatePassword.acPassword = account.acPassword;

                db.SaveChanges();
            }
            return View("Authenticate");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Login Page
        public IActionResult Authenticate()
        {
            return View();
        }

        //searchuser
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

        //search user in teacher
        public IActionResult SearchAttendance(string searchattendance)
        {
            List<AttendanceModel> attendance = new List<AttendanceModel>();

            using (var db = new DemoContext())
            {
                attendance = db.Attendance.Where(u => u.atTimeIn.ToLower().Contains(searchattendance.ToLower())).ToList();
            }

            TempData["attendance"] = attendance;

            return View("TeacherView");
        }

        //Login
        public IActionResult Login(string username, string password, string position, AccountModel account)
        {
            List<AccountModel> users = new List<AccountModel>();
            
            using (var db = new DemoContext())
            {
                users = db.Account.Where(u => u.acUsername.Contains(username) && u.acPassword.Contains(password) && u.acPosition.Contains(position)).ToList();
                ViewBag.currentuser = username;
                var userId = db.Account.Where(u => u.acUsername == username).Select(u => u.acID).FirstOrDefault();
                ViewBag.userid = userId;

                TextWriter txt = null;
                string filePath = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\currentuser.txt";
                txt = new StreamWriter(filePath);
                txt.WriteLine(ViewBag.currentuser);
                txt.Close();
                
                TextWriter txt2 = null;
                string filePath2 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\userid.txt";
                txt2 = new StreamWriter(filePath2);
                txt2.WriteLine(ViewBag.userid);
                txt2.Close();

                string fileContent3 = string.Empty;
                string filePath3 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\userid.txt";
                fileContent3 = System.IO.File.ReadAllText(filePath3);
                ViewBag.FileContent3 = fileContent3;

                List<ParentModel> parents = new List<ParentModel>();  
                var parent2 = db.Parents.Where(u => u.acID == userId.ToString()).Select(u => u.sID).FirstOrDefault();
                ViewBag.childID = parent2;
                //writing to child
			    TextWriter txt4 = null;
			    string filePath4 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\childID.txt";
			    txt4 = new StreamWriter(filePath4);
			    txt4.WriteLine(parent2);
			    txt4.Close();
			    //reading form child
			    string fileContent5 = string.Empty;
			    string filePath5 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\childID.txt";
			    fileContent5 = System.IO.File.ReadAllText(filePath5);
			    ViewBag.FileContent5 = fileContent5;
			}
			

			if (users.Count == 0)
            {
                return View("Authenticate");
            }
            else 
            {
                if (position == "Teacher")
                {
                    return RedirectToAction("TeacherView");
                }
                else if (position == "Admin")
                {
                    return RedirectToAction("Admin");
                    //return View("Admin");
                }
                else if (position=="Parent")
                {
                    List<ParentModel> parent = new List<ParentModel>();

                    using (var db = new DemoContext())
                    {
                        parent = db.Parents.ToList();
                    }
                    ViewBag.parent1 = parent;

                    return View("ParentView");
                }
                else
                {
                    return View("Index");
                }
                
            }

            
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
                var userTemp = db.Teacher.Where(u => u.tID == teacher.tID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Teacher 2
        public IActionResult UpdateTeacherFinal(TeacherModel teacher)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Teacher.Where(u => u.tID == teacher.tID).FirstOrDefault();

                UpdateTeacher.tName = teacher.tName;
                UpdateTeacher.tSurname = teacher.tSurname;
                UpdateTeacher.tFormClass = teacher.tFormClass;

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
                var userTemp = db.Parents.Where(u => u.pID == parent.pID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Parent 2
        public IActionResult UpdateParentFinal(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Parents.Where(u => u.pID == parent.pID).FirstOrDefault();

                UpdateTeacher.pName = parent.pName;
                UpdateTeacher.pSurname = parent.pSurname;
                UpdateTeacher.pPhoneNumber = parent.pPhoneNumber;
                UpdateTeacher.pSpouseName = parent.pSpouseName;
                UpdateTeacher.pSpousePhoneNumber = parent.pSpousePhoneNumber;
                UpdateTeacher.pEmergencyContactName = parent.pEmergencyContactName;
                UpdateTeacher.pEmergencyPhoneNumber = parent.pEmergencyPhoneNumber;
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
                var userTemp = db.Child.Where(u => u.sID == child.sID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Child 2
        public IActionResult UpdateChildFinal(ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Child.Where(u => u.sID == child.sID).FirstOrDefault();

                UpdateTeacher.sName = child.sName;
                UpdateTeacher.sSurname = child.sSurname;
                UpdateTeacher.sFormClass = child.sFormClass;

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
                var userTemp = db.Account.Where(u => u.acID == account.acID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Account 2
        public IActionResult UpdateAccountFinal(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Account.Where(u => u.acID == account.acID).FirstOrDefault();

                UpdateTeacher.acUsername = account.acUsername;
                UpdateTeacher.acPassword = account.acPassword;
                UpdateTeacher.acPosition = account.acPosition;

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
                var userTemp = db.Attendance.Where(u => u.atID == attendance.atID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Attendance 2
        public IActionResult UpdateAttendanceFinal(AttendanceModel attendance)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Attendance.Where(u => u.atID == attendance.atID).FirstOrDefault();

                UpdateTeacher.atTimeIn = attendance.atTimeIn;
                UpdateTeacher.atTimeOut = attendance.atTimeOut;
                UpdateTeacher.atDate = attendance.atDate;
                UpdateTeacher.atPresent = attendance.atPresent;

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
                var userTemp = db.Admin.Where(u => u.aID == admin.aID).FirstOrDefault();
                TempData["userTemp"] = userTemp;
            }


            return View();
        }


        //Update Admin 2
        public IActionResult UpdateAdminFinal(AdminModel admin)
        {
            using (var db = new DemoContext())
            {
                var UpdateTeacher = db.Admin.Where(u => u.aID == admin.aID).FirstOrDefault();

                UpdateTeacher.aName = admin.aName;
                UpdateTeacher.aSurname = admin.aSurname;


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
            return RedirectToAction("User");
        }

        //Account Delete
        public IActionResult DeleteAccount(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Account.Where(u => u.acID == account.acID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Account");
        }

        //Admin Delete
        public IActionResult DeleteAdmin(AdminModel admin)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Admin.Where(u => u.aID == admin.aID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Admin");
        }

        //Child Delete
        public IActionResult DeleteChild(ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Child.Where(u => u.sID == child.sID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Child");
        }

        //Teacher Delete
        public IActionResult DeleteTeacher(TeacherModel teacher)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Teacher.Where(u => u.tID == teacher.tID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Teacher");
        }

        //Parent Delete
        public IActionResult DeleteParent(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Parents.Where(u => u.pID == parent.pID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Parent");
        }

        //Attendance Delete
        public IActionResult DeleteAttendance(AttendanceModel attendance)
        {
            using (var db = new DemoContext())
            {
                var DeleteUser = db.Attendance.Where(u => u.atID == attendance.atID).FirstOrDefault();
                db.Attach(DeleteUser);
                db.Remove(DeleteUser);
                db.SaveChanges();
            }
            return RedirectToAction("Attendance");
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

            return RedirectToAction("AddUsers");
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
        public IActionResult AddParentsDetails(AccountModel account, ChildModel child)
        {
            using (var db = new DemoContext())
            {
                var lastRecord3 = db.Account.OrderByDescending(x => x.acID).FirstOrDefault();
                int numParent = lastRecord3.acID;
                int numParent2 = numParent + 1;

                ViewBag.file4 = numParent2.ToString();
               
            }
            using (var db = new DemoContext())
            {
                var lastRecord4 = db.Child.OrderByDescending(x => x.sID).FirstOrDefault();
                int numChild = lastRecord4.sID;
                int numChild2 = numChild + 1;

                ViewBag.file5 = numChild2.ToString();
            }

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
            return RedirectToAction("AddChildDetails");
            }
            else
            {
                return View("AddParentsDetails");
            }

            
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
        public IActionResult AddChildDetails(ParentModel parent)
        {
            using (var db = new DemoContext())
            {
                var lastRecord = db.Parents.OrderByDescending(x => x.pID).FirstOrDefault();
                int num = lastRecord.pID;

                ViewBag.file5 = num.ToString();
            }

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
                string parent2 = "Parent";
                ViewBag.position=parent2;
            return View("AddAccountDetails");
            }
            else
            {
                return View("AddChildDetails");
            }

            
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

            return RedirectToAction("Attendance");
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
        
        public IActionResult TeachersAddDetails(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var lastRecord = db.Account.OrderByDescending(x => x.acID).FirstOrDefault();
                int num = lastRecord.acID;
                int num2 = num + 1;
                
                ViewBag.file2 = num2.ToString();
                
            }

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
                string teacher2 = "Teacher";
                ViewBag.position = teacher2;
                return View("AddAccountDetails");
            }
            else
            {
                return View("TeachersAddDetails");
            }
            
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
        public IActionResult AddAccountDetails()
        {   
            
            
            

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
            return RedirectToAction("Account");
            }
            else
            {
                return View("AddAccountDetails");
            }
 
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
        public IActionResult AdminsAddDetails(AccountModel account)
        {
            using (var db = new DemoContext())
            {
                var lastRecord2 = db.Account.OrderByDescending(x => x.acID).FirstOrDefault();
                int numAdmin = lastRecord2.acID;
                int numAdmin2 = numAdmin + 1;

                ViewBag.file3 = numAdmin2.ToString();
                
            }

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
                string admin2 = "Admin";
                ViewBag.position = admin2;
                return View("AddAccountDetails");
            }
            else
            {
                return View("AdminsAddDetails");
            }

            
        }
        public IActionResult ViewChildDetails() 
        { 
            return View(); 
        }
        public IActionResult ParentView()
        {
            string fileContent3 = string.Empty;
            string filePath3 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\userid.txt";
            fileContent3 = System.IO.File.ReadAllText(filePath3);
            ViewBag.FileContent3 = fileContent3;

            string fileContent5 = string.Empty;
            string filePath5 = "C:\\Users\\Caldon\\Desktop\\NewNewFile\\childID.txt";
            fileContent5 = System.IO.File.ReadAllText(filePath5);
            ViewBag.FileContent5 = fileContent5;
            return View();
        }
        public IActionResult ParentView2(string id)
        {

            List<ParentModel> parent4 = new List<ParentModel>();
            using (var db = new DemoContext())
            {
                parent4 = db.Parents.Where(u => u.acID.Contains(id)).ToList();
                ViewBag.parentid=parent4;
            }
            
            return View("ViewParentDetails");
        }
        public IActionResult ParentView3(string sid) 
        {
            List<ChildModel> child1 = new List<ChildModel>();
            int child2 = Int32.Parse(sid);
            using (var db = new DemoContext())
            {
                child1 = db.Child.Where(u => u.sID==child2).ToList();
                ViewBag.childID = child1;
            }
            return View("ViewChildDetails");
        }
        public IActionResult ViewParentDetails() 
        { 
            return View(); 
        }

        public IActionResult TeacherView()
        {
            List<AttendanceModel> attendance = new List<AttendanceModel>();

            using (var db = new DemoContext())
            {
                attendance = db.Attendance.ToList();
            }

            ViewBag.users = attendance;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
