using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Lun
    {
        [Key]
        public int LunID { get; set; }
        public string LunName { get; set; }
        public string LunType { get; set; }

        public int LunTSpace { get; set; }
        public int LunRSpace { get; set; }

        [ForeignKey("Storage")]
        public int StorageID { get; set; }
        public Storage Storage { get; set; }
    }
}
