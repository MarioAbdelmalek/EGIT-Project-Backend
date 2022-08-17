using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        //public Array ReservedFlights { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
