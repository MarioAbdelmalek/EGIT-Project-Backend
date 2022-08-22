using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateClusterDto
    {
        public string ClusterType { get; set; }
        public int NumberOfNodes { get; set; }
        public int ClusterTotalRAM { get; set; }
        public int ClusterRemainingRAM { get; set; }
        public int ClusterTotalCPUCores { get; set; }
        public int ClusterRemainingCPUCores { get; set; }
    }
}
