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
        public List<VMDto> GetAllVMs()
        {
            return EGITService.GetAllVMs();
        }
        public VMDto GetVM(int VMID)
        {
            return EGITService.GetVM(VMID);
        }
        public void AddVM(VMDto VM)
        {
             EGITService.AddVM(VM);
        }
        public void UpdateVM(VMDto VM, int VMID)
        {
            EGITService.UpdateVM(VM, VMID);
        }
        public void DeleteVM(int VMID)
        {
            EGITService.DeleteVM(VMID);
        }
    }
}
