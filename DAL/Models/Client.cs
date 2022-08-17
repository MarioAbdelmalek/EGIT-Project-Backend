using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientSector { get; set; }
        public int Bandwidth { get; set; }
        public int PublicIps { get; set; }
        public int VPNClients { get; set; }
        public int CurrentVMs { get; set; }
        public int TotalVMs { get; set; }
        public int ISPID { get; set; }
    }
}
