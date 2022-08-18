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
        public List<StorageDto> GetAllStorages()
        {

            return egitService.GetAllStorages();
        }
        public StorageDto GetStorage(int id)
        {
            return egitService.GetStorage(id);
        }
        public void addStorage(StorageDto storage)
        {
            egitService.AddStorage(storage);
        }
        public void deleteStorage(int id)
        {
            egitService.DeleteStorage(id);
        }
        public void updateStorage(StorageDto storage)
        {
            egitService.UpdateStorage(storage);
        }

    }
}
