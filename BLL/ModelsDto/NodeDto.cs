using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class NodeDto
    {
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string NodeType { get; set; }
        public int ClusterID { get; set; }
    }
}
