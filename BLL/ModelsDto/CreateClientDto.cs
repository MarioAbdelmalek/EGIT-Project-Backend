using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateClientDto
    {
        public string ClientName { get; set; }
        public string ClientSector { get; set; }
        public int ISPID { get; set; }
    }
}
