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
        public int NodeTotalRAM { get; set; }
        public int NodeRemainingRAM { get; set; }
        public int NodeTotalCPUCores { get; set; }
        public int NodeRemainingCPUCores { get; set; }

        [ForeignKey("Cluster")]
        public int ClusterID { get; set; }
        public Cluster Cluster { get; set; }
    }
}
