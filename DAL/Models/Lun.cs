using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Lun
    {
        public int LunID { get; set; }
        public string LunName { get; set; }
        public int LunTotalRAM { get; set; }
        public int LunRemainingRAM { get; set; }

        [ForeignKey("Storage")]
        public int StorageID { get; set; }
        public Storage Storage { get; set; }
    }
}
