using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class StorageDto
    {
        public int StorageID { get; set; }
        public string StorageName { get; set; }
        public int StorageTotalRAM { get; set; }
        public int StorageRemainingRAM { get; set; }
    }
}
