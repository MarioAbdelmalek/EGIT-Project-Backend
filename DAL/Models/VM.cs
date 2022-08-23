using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class VM
    {
        [Key]
        public int VMID { get; set; }

        public int CpuCores { get; set; }

        public int Ram { get; set; }

        public string? IP { get; set; }

        public int Bandwidth { get; set; }

        [ForeignKey("ClientID")]

        public int ClientID { get; set; }

        [ForeignKey("NodeID")]

        public int NodeID { get; set; }

        [ForeignKey("LunID")]

        public int LunID { get; set; }


        public Client Client { get; set; }

        public Node Node { get; set; }

        public Lun Lun { get; set; }


    }
}
