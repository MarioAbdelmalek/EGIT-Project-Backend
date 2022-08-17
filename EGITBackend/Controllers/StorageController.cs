using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;

namespace EGITBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        EGITService egitService;
        public StorageController(EGITService egitService)
        {
            this.egitService = egitService;
        }
        public List<StorageDto> getAllStorages()
        {

            return egitService.getAllStorages();
        }
        public StorageDto getStorage(int id)
        {
            return egitService.getStorage(id);
        }
        public void addStorage(StorageDto storage)
        {
            egitService.addStorage(storage);
        }
        public void deleteStorage(int id)
        {
            egitService.deleteStorage(id);
        }
        public void updateStorage(StorageDto storage)
        {
            egitService.updateStorage(storage);
        }

    }
}
