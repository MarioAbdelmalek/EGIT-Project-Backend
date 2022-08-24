using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateLunDto
    {
        public string LunName { get; set; }
        public int LunTotalRAM { get; set; }
        public int StorageID { get; set; }
    }
}
