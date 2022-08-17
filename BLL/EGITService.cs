using System;
using System.Collections.Generic;
using AutoMapper;
using DAL;
using DAL.Models;
using BLL.ModelsDto;

namespace BLL
{
    public class EGITService : IEGITService
    {

        IEGITRepository EGITRepository;
        private readonly IMapper _mapper;

        public EGITService(IEGITRepository repository, IMapper mapper)
        {
            this.EGITRepository = repository;
            this._mapper = mapper;
        }

        //Lun functions
        public List<LunDto> getAllLuns()
        {
            List<Lun> luns= EGITRepository.getAllLuns();
            return _mapper.Map<List<Lun>, List<LunDto>>(luns);
        }
        public void addLun(LunDto lun)
        {
            EGITRepository.addLun(_mapper.Map<Lun>(lun));
        }
        public LunDto getLun(int id)
        {
            Lun lun = EGITRepository.getLun(id);
            return _mapper.Map<LunDto>(lun);
        }
        public void deleteLun(int id)
        {
            EGITRepository.deleteLun(id);
        }
        public void updateLun(LunDto lun) {
            LunDto newlun = new LunDto
            {
                LunName = lun.LunName,
                LunType = lun.LunType,
                LunRSpace = lun.LunRSpace,
                LunTSpace = lun.LunTSpace,
                StorageID = lun.StorageID
            };
            EGITRepository.updateLun(_mapper.Map<Lun>(newlun));
        }
        public int getTSpaceByStockId(int id)
        {
            return EGITRepository.getTSpaceByStockId(id);
        }

        //Storage functions

        public List<StorageDto> getAllStorages()
        {
            List<Storage> storages = EGITRepository.getAllStorages();
            return _mapper.Map<List<Storage>, List<StorageDto>>(storages);
        }
        public StorageDto getStorage(int id)
        {
            Storage storage = EGITRepository.getStorage(id);
            return _mapper.Map<StorageDto>(storage);
        }
        public void addStorage(StorageDto storage)
        {
            EGITRepository.addStorage(_mapper.Map<Storage>(storage));

        }
        public void deleteStorage(int id)
        {
            EGITRepository.deleteStorage(id);

        }
        public void updateStorage(StorageDto storage)
        {
            StorageDto newStorage = new StorageDto
            {
                StorageName = storage.StorageName,
                StorageType = storage.StorageType,
                StorageRSpace = storage.StorageRSpace,
                StorageTSpace = storage.StorageTSpace

            };

            EGITRepository.updateStorage(_mapper.Map<Storage>(newStorage));
        }

    }
}
