using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class EGITRepository : IEGITRepository
    {
        private readonly PostgreSqlContext context;

        public EGITRepository(PostgreSqlContext context)
        {
            this.context = context;

        }
        //Lun functions
        public List<Lun> getAllLuns()
        {
            return context.Luns.ToList();
        }

        public Lun getLun(int id)
        {
            return (Lun)context.Luns.Select(l => l.LunID == id);
        }
        public void addLun(Lun lun)
        {
            context.Luns.Add(lun);
            context.SaveChanges();

        }

        public void deleteLun(int id)
        {
            var entity = context.Luns.FirstOrDefault(t => t.LunID == id);
            context.Luns.Remove(entity);
            context.SaveChanges();
        }

        public void updateLun(Lun lun)
        {
            context.Luns.Update(lun);
            context.SaveChanges();
        }

        public int getTSpaceByStockId(int id)
        {
            return context.Luns.Where(t => t.StorageID == id).Sum(i => i.LunTSpace);

        }

        public void updateRSpace(Lun lun)
        {
            var luns = context.Luns.Where(p => p.LunID == lun.LunID).ToList();
            luns.ForEach(p => p.LunRSpace = lun.LunRSpace);
            context.SaveChanges();
        }


        public void updateLunTypes(Lun lun)
        {
            var luns = context.Luns.Where(p => p.StorageID == lun.StorageID).ToList();
            luns.ForEach(p => p.LunType = lun.LunType);
            context.SaveChanges();
        }

        //Storage functions

        public List<Storage> getAllStorages()
        {
            return context.Storages.ToList();
        }
        public Storage getStorage(int id)
        {
            return (Storage)context.Storages.Select(l => l.StorageID == id);
        }

        public void addStorage(Storage storage)
        {
            context.Storages.Add(storage);
            context.SaveChanges();

        }
        public void updateStorage(Storage storage)
        {
            context.Storages.Update(storage);
            context.SaveChanges();
        }

        public void deleteStorage(int id)
        {
            var entity = context.Storages.FirstOrDefault(t => t.StorageID == id);
            context.Storages.Remove(entity);
            context.SaveChanges();
        }
    }
}
