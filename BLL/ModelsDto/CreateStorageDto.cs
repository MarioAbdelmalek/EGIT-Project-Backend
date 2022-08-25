using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateStorageDto
    {
        public string StorageName { get; set; }
        public string StorageType { get; set; }
        public int StorageTotalSpace { get; set; }
    }
}
