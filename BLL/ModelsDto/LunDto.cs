using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class LunDto
    {
        public int LunID { get; set; }
        public string LunName { get; set; }
        public int LunTSpace { get; set; }
        public int LunRSpace { get; set; }
        public int StorageID { get; set; }
    }
}
