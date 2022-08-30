using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class NodeDto
    {
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public int NodeTotalRAM { get; set; }
        public int NodeRemainingRAM { get; set; }
        public int NodeTotalCPUCores { get; set; }
        public int NodeRemainingCPUCores { get; set; }
        public int ClusterID { get; set; }
        public ClusterDto Cluster { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
