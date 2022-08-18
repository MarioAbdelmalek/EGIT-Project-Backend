using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsPowerUser { get; set; }
    }
}
