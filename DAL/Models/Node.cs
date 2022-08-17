using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Node
    {
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string NodeType { get; set; }
        public int TotalRAM { get; set; }
        public int RemainingRAM { get; set; }
        public int TotalCPUCores { get; set; }
        public int RemainingCPUCores { get; set; }

        [ForeignKey("Cluster")]
        public int ClusterID { get; set; }
        public Cluster Cluster { get; set; }
    }
}
