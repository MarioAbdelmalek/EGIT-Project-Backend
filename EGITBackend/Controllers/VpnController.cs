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
    public class VpnController : ControllerBase
    {
        IEGITService EGITService;
        public VpnController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("getAllVpns")]
        [HttpGet]
        public List<VpnDto> GetAllVpns()
        {
            return EGITService.GetAllVpns();
        }

        [Route("getVpn")]
        [HttpGet]
        public VpnDto GetVpn(int VpnID)
        {
            return EGITService.GetVpn(VpnID);

        }

        [Route("addVpn")]
        [HttpPost]
        public void AddVpn(VpnDto vpn)
        {
            EGITService.AddVpn(vpn);
        }

        [Route("updateVpn")]
        [HttpPut]
        public void UpdateVpn(VpnDto vpn, int VpnID)
        {
            EGITService.UpdateVpn(vpn, VpnID);

        }

        [Route("deleteVpn")]
        [HttpDelete]
        public void DeleteVpn(int VpnID)
        {
            EGITService.DeleteVpn(VpnID);

        }
    }
}
