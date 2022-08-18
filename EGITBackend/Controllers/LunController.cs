using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EGITBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LunController : ControllerBase
    {
        IEGITService EGITService;
        public LunController(IEGITService egitService)
        {
            this.EGITService = egitService;
        }
        public List<LunDto> GetAllLuns()
        {
            return EGITService.GetAllLuns();
        }
        public void AddLun(LunDto lun)
        {
            EGITService.AddLun(lun);
        }
        public LunDto GetLun(int id)
        {
            return EGITService.GetLun(id);
        }
        public void DeleteLun(int id)
        {
            EGITService.DeleteLun(id);
        }
        public void UpdateLun(LunDto lun)
        {
            EGITService.UpdateLun(lun);
        }
        public int getTSpaceByStockId(int id)
        {
            return EGITService.getTSpaceByStockId(id);
        }

    }
}

