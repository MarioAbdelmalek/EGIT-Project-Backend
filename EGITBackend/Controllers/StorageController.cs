using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;

namespace EGITBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        EGITService EGITService;
        public StorageController(EGITService egitService)
        {
            this.EGITService = egitService;
        }

        [Route("getAll")]
        [HttpGet]
        public List<StorageDto> GetAllStorages()
        {

            return EGITService.GetAllStorages();
        }

        [Route("getById")]
        [HttpGet]
        public StorageDto GetStorage(int id)
        {
            return EGITService.GetStorage(id);
        }

        [Route("addStorage")]
        [HttpPost]
        public void AddStorage(StorageDto storage)
        {
            EGITService.AddStorage(storage);
        }

        [Route("deleteById")]
        [HttpDelete]
        public void DeleteStorage(int id)
        {
            EGITService.DeleteStorage(id);
        }

        [HttpPost("updatestorage")]
        public void UpdateStorage(StorageDto storage)
        {
            EGITService.UpdateStorage(storage);
        }

    }
}
