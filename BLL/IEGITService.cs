using System;
using System.Collections.Generic;
using System.Text;
using BLL.ModelsDto;

namespace BLL
{
    public interface IEGITService
    {
        // Lun functions
        public List<LunDto> getAllLuns();
        public void addLun(LunDto lun);
        public LunDto getLun(int id);
        public void deleteLun(int id);
        public void updateLun(LunDto lun);
        public int getTSpaceByStockId(int id);

        // Stock functions
        public List<StorageDto> getAllStorages();
        public StorageDto getStorage(int id);
        public void addStorage(StorageDto storage);
        public void deleteStorage(int id);
        public void updateStorage(StorageDto storage);
]
    }
}
