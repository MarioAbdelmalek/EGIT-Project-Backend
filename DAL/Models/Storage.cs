using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Storage
    {
        public int StorageID { get; set; }
        public string StorageName { get; set; }
        public string StorageType { get; set; }
        public int StorageTotalRAM { get; set; }
        public int StorageRemainingRAM { get; set; }
    }
}
