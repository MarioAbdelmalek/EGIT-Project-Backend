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
        public List<LunDto> getAllLuns()
        {
            return EGITService.getAllLuns();
        }
        public void addLun(LunDto lun)
        {
            EGITService.addLun(lun);
        }
        public LunDto getLun(int id)
        {
            return EGITService.getLun(id);
        }
        public void deleteLun(int id)
        {
            EGITService.deleteLun(id);
        }
        public void updateLun(LunDto lun)
        {
            EGITService.updateLun(lun);
        }
        public int getTSpaceByStockId(int id)
        {
            return EGITService.getTSpaceByStockId(id);
        }

    }
}

