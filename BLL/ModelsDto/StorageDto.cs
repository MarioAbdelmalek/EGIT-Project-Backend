﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class StorageDto
    {
        public int StorageID { get; set; }
        public string StorageName { get; set; }
        public string StorageType { get; set; }
        public int StorageTSpace { get; set; }
        public int StorageRSpace { get; set; }
    }
}