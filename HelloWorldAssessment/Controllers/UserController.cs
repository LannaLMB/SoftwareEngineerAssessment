using HelloWorldAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldAssessment.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ListofItems()
        {
            HelloWorldEntities HW = new HelloWorldEntities();


            List<User> UserList = HW.Users.ToList();

            ViewBag.UserList = UserList;

            ViewBag.Names = GetName();

            return View();
        }
    }


    public List<string> GetAllUsers()
    {

        // To Return a List of All Users First Names
        HelloWorldEntities HW = new HelloWorldEntities();


        //Lambda Expression
        return HW.Users.Select(x => x.FirstName).Distinct().ToList();
    }


    //// Add A User To List
    //public ActionResult AddUser()
    //{
    //    return View();
    //}



    //Save The New User Added
        public ActionResult SaveNewUser(User NewUser)
    {
        HelloWorldEntities HW = new HelloWorldEntities();

        HW.Users.Add(NewUser);
        HW.SaveChanges();

        return RedirectToAction("AdminReport", "Home");
    }



    // Delete Users
    public ActionResult DeleteUser(string Email)
    {
        try
        {
            if (Email == null)
            {

                ViewBag.ErrorMessage = "Nice Try!";
                return View("ErrorMessages");
            }


            HelloWorldEntities HW = new HelloWorldEntities();

            // 1. Find the User that I need to delete

            User ToDelete = HW.Users.Find(Email);

            if (ToDelete == null)
            {
                ViewBag.ErrorMessage = "Hahahaha";
                return View("ErrorMessages");
            }


            // 2. Remove the object from the list of Items
            HW.Users.Remove(ToDelete);


            // 3. Perform the changes onto the DB
            HW.SaveChanges(); // save changes to DB


            // Execute the ListofItems Action
            return RedirectToAction("AdminReport", "Home");
        }

        catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
        {
            ViewBag.ErrorMessage = "You Cannot Delete an Email With an ID!";

            return View("ErrorMessages");
        }

        catch (Exception ex)
        {

            ViewBag.ErrorMessage = "Something Horrible Happened";

            return View("ErrorMessages");
        }
    }


    // Update Items
    public ActionResult UpdateUser(string Email)
    {
        HelloWorldEntities HW = new HelloWorldEntities();

        User ToFind = HW.Users.Find(Email);

        return View("AdminReport", ToFind);
    }


    // Save Updated Items
    public ActionResult SaveUpdates(User ToBeUpdated)
    {
        HelloWorldEntities HW = new HelloWorldEntities();

        // Find the Original Customer Record
        User ToFind = HW.Users.Find(ToBeUpdated.Email);

        ToFind.Email = ToBeUpdated.Email;

        ToFind.FirstName = ToBeUpdated.FirstName;

        ToFind.LastName = ToBeUpdated.LastName;

        ToFind.Address1 = ToBeUpdated.Address1;

        ToFind.Address2 = ToBeUpdated.Address2;

        ToFind.City = ToBeUpdated.City;

        ToFind.State = ToBeUpdated.State;

        ToFind.Zipcode = ToBeUpdated.Zipcode;

        ToFind.Country = ToBeUpdated.Country;

        ToFind.Password = ToBeUpdated.Password;

        HW.SaveChanges();

        return RedirectToAction("../Home/AdminReport");
    }



    // Search for the Name of a Coffee in the Drop Down Box
    public ActionResult SearchUser(string FirstName)
    {
        HelloWorldEntities HW = new HelloWorldEntities();

        List<User> UserList = HW.Users.Where(x => x.FirstName != null && x.FirstName.ToUpper().
        Contains(FirstName.ToUpper())).ToList();


        ViewBag.FirstNames = GetName();

        ViewBag.ItemList = UserList;
        ViewBag.UserNames = HW.Users.Select(x => x.FirstName);
        return View("../Home/AdminReport");

    }

    // Get Name From DB
    public List<string> GetName()
    {
        // To return a list of all cities
        HelloWorldEntities HW = new HelloWorldEntities();


        //Lambda Expression
        return HW.Users.Select(x => x.FirstName).Distinct().ToList();

    }
}
