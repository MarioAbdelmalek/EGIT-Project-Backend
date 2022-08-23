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

        [Route("getVM")]
        [HttpGet]
        public VMDto GetVM(int VMID)
        {
            return EGITService.GetVM(VMID);
        }

        [Route("addVM")]
        [HttpPost]
        public GenerateErrorDto AddVM(VMDto VM)
        {
             GenerateErrorDto Response=EGITService.AddVM(VM);
            return Response;
        }

        [Route("updateVM")]
        [HttpPut]
        public void UpdateVM(VMDto VM, int VMID)
        {
            EGITService.UpdateVM(VM, VMID);
        }
        [Route("deleteVM")]
        [HttpDelete]
        public void DeleteVM(int VMID)
        {
            EGITService.DeleteVM(VMID);
        }
    }
}
