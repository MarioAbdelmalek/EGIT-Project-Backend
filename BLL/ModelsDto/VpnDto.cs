using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class VpnDto
    {
        public int VpnID { get; set; }
        public string Username { get; set; }
        public int ClientID { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
}
