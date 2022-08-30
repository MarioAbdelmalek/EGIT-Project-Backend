using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EGITBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LunController : ControllerBase
    {
        IEGITService EGITService;
        public LunController(IEGITService egitService)
        {
            this.EGITService = egitService;
        }

        [Route("getAll")]
        [HttpGet]
        public List<LunDto> GetAllLuns()
        {
            return EGITService.GetAllLuns();
        }
        [Route("addLun")]
        [HttpPost]
        public GenerateErrorDto AddLun(CreateLunDto lun)
        {
            return EGITService.AddLun(lun);
        }

        [Route("getLun")]
        [HttpGet]
        public LunDto GetLun(int id)
        {
            return EGITService.GetLun(id);
        }

        [Route("deleteLun")]
        [HttpDelete]
        public GenerateErrorDto DeleteLun(int id)
        {
            return EGITService.DeleteLun(id);
        }

        [Route("updateLun")]
        [HttpPut]
        public GenerateErrorDto UpdateLun(CreateLunDto lun, int LunID)
        {
            return EGITService.UpdateLun(lun,LunID);
        }

        [Route("getUpdatedLuns")]
        [HttpGet]
        public IEnumerable<LunDto> GetUpdatedLuns()
        {
            return EGITService.GetUpdatedLuns();
        }


    }
}

