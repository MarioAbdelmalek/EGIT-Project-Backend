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
    public class VMController : ControllerBase
    {
        IEGITService EGITService;
        public VMController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("getAllVMs")]
        [HttpGet]
        public List<VMDto> GetAllVMs()
        {
            return EGITService.GetAllVMs();
        }

        [Route("getVMById")]
        [HttpGet]
        public VMDto GetVM(int VMID)
        {
            return EGITService.GetVM(VMID);
        }

        [Route("addVM")]
        [HttpPost]
        public GenerateErrorDto AddVM(VMDto VM)
        {
             return EGITService.AddVM(VM);
        }

        [Route("updateVM")]
        [HttpPut]
        public GenerateErrorDto UpdateVM(VMDto VM, int VMID)
        {
            return EGITService.UpdateVM(VM, VMID);
        }

        [Route("deleteVM")]
        [HttpDelete]
        public GenerateErrorDto DeleteVM(int VMID)
        {
            return EGITService.DeleteVM(VMID);
        }
    }
}
