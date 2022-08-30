using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class UpdateVMDto
    {
        public int CPUCores { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
        public int LunID { get; set; }

    }
}
