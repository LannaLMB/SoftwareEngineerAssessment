using HelloWorldAssessment.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldAssessment.Controllers
{
    public class HomeController : Controller
    {
        // Get List of Users
        public ActionResult GetList()
        {

            HelloWorldEntities HW = new HelloWorldEntities();

            List<User> UserList = HW.Users.ToList();

            ViewBag.UserList = UserList;
            ViewBag.UserFName = HW.Users.Select(x => x.FirstName);
            ViewBag.Names = GetName();

            return View();
        }



        // Get The User Information From DB by First Name
        public List<string> GetName()
        {

            // Reference DB
            HelloWorldEntities HW = new HelloWorldEntities();

            return HW.Users.Select(x => x.FirstName).Distinct().ToList();

        }


        // List User Info
        public ActionResult UserStuff()
        {
            HelloWorldEntities HW = new HelloWorldEntities();

            List<User> UserList = HW.Users.ToList();


            ViewBag.UserList = UserList;
            ViewBag.UserStuff = HW.Users.Select(x => x.FirstName);
            ViewBag.FirstName = GetName();

            return View();

        }


        // Contact Page
        public ActionResult Contact()
        {
            ViewBag.Message = "Lanna Brasure - Computer Software Engineer";

            return View();
        }


        // Registration Form
        public ActionResult RegistrationForm()
        {
            return View();
        }


        // Confirmation Page
        public ActionResult Confirmation(User NewUser)
        {
            return View(NewUser);
        }


        // Add New User
        public ActionResult AddNewUser()
        {
            return View();
        }



        //[HttpPost]
        //public ActionResult SaveNewUser(User NewUser)
        //{
        //    string CurrentUserEmail = User.Identity.GetUserId();
        //    NewUser.UserId = CurrentUserId;
        //    NewUser.Crea = DateTime.Now;

        //    HelloWorldEntities HW = new HelloWorldEntities();

        //    try
        //    {
        //        HW.Users.Add(NewUser);  // Adds New User to Database Using Entity

        //        HW.SaveChanges();     // Saves User to Database 
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Unable to save new user. " + ex.Message.ToString();
        //        return View("Error");
        //    }


        //    ApplicationDbContext UserDB = new ApplicationDbContext();
        //    ApplicationUser CurrentUserInfo = UserDB.Users.Find(CurrentUserId); //here only to find out which user profile to direct back to, using entity

        //    return RedirectToAction("Contact");
        //}






        // Can Only Be Accessed By An Authorized User
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminReport()
        {
            return View();
        }


        // Sends list of the last four pets created to the view
       // List<Pet> NewestPets = PE.Pets.OrderByDescending(x => x.CreationDate).Take(4).ToList();
       // ViewBag.NewestPets = NewestPets;


    }
}