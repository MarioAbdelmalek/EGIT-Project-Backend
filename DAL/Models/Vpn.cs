using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Vpn
    {
        [Key]
        public int VpnID { get; set; }

        public string Username { get; set; }

        [ForeignKey("ClientID")]
        public int ClientID { get; set; }

        public Client Client { get; set; }
    }
}
