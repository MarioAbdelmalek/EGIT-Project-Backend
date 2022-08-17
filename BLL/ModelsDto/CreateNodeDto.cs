using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateNodeDto
    {
        public string NodeName { get; set; }
        public string NodeType { get; set; }
        public int TotalRAM { get; set; }
        public int RemainingRAM { get; set; }
        public int TotalCPUCores { get; set; }
        public int RemainingCPUCores { get; set; }
        public int ClusterID { get; set; }
    }
}
