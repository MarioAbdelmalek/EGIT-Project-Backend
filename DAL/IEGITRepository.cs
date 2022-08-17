using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IEGITRepository
    {
        //Lun Functions
        public List<Lun> getAllLuns();
        public void addLun(Lun lun);
        public Lun getLun(int id);
        public void deleteLun(int id);
        public void updateLun(Lun lun);
        public int getTSpaceByStockId(int id);

        //Storage functions

        public List<Storage> getAllStorages();
        public Storage getStorage(int id);
        public void addStorage(Storage storage);
        public void deleteStorage(int id);
        public void updateStorage(Storage storage);
    }
}
