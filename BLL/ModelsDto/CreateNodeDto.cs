using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateNodeDto
    {
        public int NodeTotalRAM { get; set; }
        public int NodeTotalCPUCores { get; set; }
        public int ClusterID { get; set; }
    }
}
