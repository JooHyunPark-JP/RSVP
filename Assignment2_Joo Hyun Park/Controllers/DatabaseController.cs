using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Assignment2_Joo_Hyun_Park.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2_Joo_Hyun_Park.Controllers
{
    public class DatabaseController : Controller
    {
        
        private string conString ="Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\pjh06\\source\\repos\\Assignment2_Joo Hyun Park\\WebService2\\App_Data\\StudentCompetition.mdf';Integrated Security = True";
        // GET: /<controller>/
        public void DataControl(GuestResponse guest)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
              


                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Student values (@StudentId, @Name, @Email, @Phone, @TechnicalInterest, @SocialNetworkInterest)", conn);
                cmd.Parameters.AddWithValue("@StudentId", guest.StudentId);
                cmd.Parameters.AddWithValue("@Name", guest.Name);
                cmd.Parameters.AddWithValue("@Email", guest.Email);
                cmd.Parameters.AddWithValue("@Phone", long.Parse(guest.Phone));
                cmd.Parameters.AddWithValue("@TechnicalInterest", guest.TechInterest.ToString());
                cmd.Parameters.AddWithValue("@SocialNetworkInterest", guest.SocialNetworkInterest);
                cmd.ExecuteNonQuery();
         
                conn.Close();
            }
            
        }

        public void DataControl2(GuestResponse guest)
        {
            
            using (SqlConnection conn = new SqlConnection(conString))
            {
                
                conn.Open();

                guest.AcceptRegret = "True";
                SqlCommand cmd = new SqlCommand("Insert into Attend values (@StudentId2, @AcceptRegret)", conn);
                cmd.Parameters.AddWithValue("@StudentId2", guest.StudentId);
                cmd.Parameters.AddWithValue("@AcceptRegret", guest.AcceptRegret);
      


                cmd.ExecuteNonQuery();

                conn.Close();
            }

        }

        public void DataControl3(GuestResponse guest)
        {
            GuestResponse Acceptbool = new GuestResponse();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                guest.AcceptRegret = "False";

                SqlCommand cmd = new SqlCommand("Insert into Attend values (@Stud   entId2, @AcceptRegret)", conn);
                cmd.Parameters.AddWithValue("@StudentId2", guest.StudentId);
                cmd.Parameters.AddWithValue("@AcceptRegret", guest.AcceptRegret);



                cmd.ExecuteNonQuery();

                conn.Close();
            }

        }
    }
}
