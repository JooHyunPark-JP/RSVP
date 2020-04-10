using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Joo_Hyun_Park.Models
{
    public static class Repository
    {
        // The Repository class and its members are static , which will make it easy to store and retrieve
        // data from different places in the application
        private static List<GuestResponse> responses = new List<GuestResponse>();

        //Expose the Enumerator. 
        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }

        }

        //Add guests to the list "responses"  
        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}



