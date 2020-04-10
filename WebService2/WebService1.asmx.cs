using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace WebService2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        List<string> resultPool;

        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        //WebMethod that enable the session to set value true. 
        [WebMethod(EnableSession = true)]

        //Should be return something becuase in clicent, GridView1.DataSource = client.ExtractAllStudents(); <- this wont work if method is void. So i have changed to String
        public String ExtractAllStudents()
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                //Select all student info from database
                SqlCommand cmd = new SqlCommand("Select * From Student", conn);
          
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return "";
        }

        [WebMethod(EnableSession = true)]
        public String ExtractSomeParts()
        {

            using (SqlConnection conn = new SqlConnection(conString))
            {

                conn.Open();

                
                SqlCommand cmd = new SqlCommand("Select StudentId, Name, TechnicalInterest, SocialNetworkInterest, Email From Student", conn);



                cmd.ExecuteNonQuery();

                conn.Close();
            }
            return "";
        }
        [WebMethod(EnableSession = true)]
        public String ExtractDetailInformation()
        {

            using (SqlConnection conn = new SqlConnection(conString))
            {

                conn.Open();


                SqlCommand cmd = new SqlCommand("Select Student, AcceptRegret, From Attend AND Select StudentId, Name, Email From Student ", conn);



                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return "";

        }

        [WebMethod(EnableSession = true)]
        public List<string> ReturnAllResults()
        {
            if (Session["ALLRESULTS"] == null)
            {
                resultPool = new List<string> { "No Result" };
                return resultPool;
            }
            else
            {
                return (List<string>)Session["ALLRESULTS"];
            }
        }
    }
}
