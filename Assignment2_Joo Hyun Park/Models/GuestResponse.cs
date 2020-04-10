using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//This for using validations. 
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;



namespace Assignment2_Joo_Hyun_Park.Models
{
    public enum TechnicalInterest { lot, MotionSensors, DataAnalytics, Programming }
    //Save the guests information. GuestResponse is a domain class. 
    public class GuestResponse
    {
        //Required validation. If Name is empty, this vailidation will be active. 
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("^[a-zA-Z''-']{1,40}$", ErrorMessage = "Only String is avaliable for your name")]
        public string Name { get; set; }
        
        //RegularExpression for user need to put email address 
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public int StudentId { get; set; }

       public string AcceptRegret { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        //Regular expression for numbers only
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Please enter a number only! ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Choose your technical interest")]
        public TechnicalInterest? TechInterest { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your SocialNetworkInterest")]
        public string SocialNetworkInterest { get; set; }


    }
}
