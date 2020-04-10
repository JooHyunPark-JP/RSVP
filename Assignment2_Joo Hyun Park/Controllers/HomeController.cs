using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//can refer to the GuestResponse model type without needing to qualify the class name.
using Assignment2_Joo_Hyun_Park.Models;
using System.Net.Mail;
using System.Data.SqlClient;





namespace Assignment2_Joo_Hyun_Park.Controllers
{
    public class HomeController : Controller
    {
      

        // When return a ViewResult object from an action method, It is instructing MVC to render a view
        public ViewResult Index()
        {
            //Save real time on "hour" variable
            int hour = DateTime.Now.Hour;

            ViewBag.Hour = DateTime.Now.Hour;
            ViewBag.Minute = DateTime.Now.Minute;
            ViewBag.Second = DateTime.Now.Second;
        
            
            //If hour is less than 12, print "good morning" else "good afternoon"
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            // ViewResult by calling the View method, specifying the name of the view,  which is "MyView" 
            return View("MyView");
        }

        // This tells MVC that this method should be used only for GET requests
                [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        // This tells MVC that this method should be used only for POST requests
        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse, string answer)
        {

            //Controller base class provides a property called ModelState that provides information about the
            //  conversion of HTTP request data into C# objects
            if (ModelState.IsValid && !String.IsNullOrWhiteSpace(answer))
            {
                DatabaseController controlling = new DatabaseController();
                
                switch (answer)
                {
                    //if button value is "Accept"
                    case "Accept":

                        
                        controlling.DataControl(guestResponse);
                        controlling.DataControl2(guestResponse);
                        Repository.AddResponse(guestResponse);
                        return View("Thanks", guestResponse);



                    //if button value is "Regret"
                    case "Regret":
                        controlling.DataControl3(guestResponse);
                        Repository.AddResponse(guestResponse);
                        guestResponse.TechInterest = null;
                        guestResponse.Phone = null;
                        guestResponse.Email = null;
                        guestResponse.SocialNetworkInterest = null;
                        guestResponse.Address = null;
                        return View("Thanks", guestResponse);
                }
            }
            return View();
        }

        //Make user to display the list of guests who is coming to the party.
        // ListResponses , and it calls the View method, using the Repository   
        public ViewResult ListResponses()
        {

            return View(Repository.Responses.Where(r => r.TechInterest.HasValue));
        }

        
    }
}
