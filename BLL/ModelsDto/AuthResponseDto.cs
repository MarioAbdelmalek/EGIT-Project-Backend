using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Response { get; set; }
        public bool IsValid { get; set; }
    }
}
