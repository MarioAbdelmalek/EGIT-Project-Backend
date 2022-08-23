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
    public class VpnController : ControllerBase
    {
        IEGITService EGITService;
        public VpnController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("getAllVPNs")]
        [HttpGet]
        public List<VpnDto> GetAllVpns()
        {
            return EGITService.GetAllVpns();
        }

        [Route("getVPNById")]
        [HttpGet]
        public VpnDto GetVpn(int VpnID)
        {
            return EGITService.GetVpn(VpnID);

        }

        [Route("addVPN")]
        [HttpPost]
        public GenerateErrorDto AddVpn(VpnDto vpn)
        {
            return EGITService.AddVpn(vpn);
        }

        [Route("updateVPN")]
        [HttpPut]
        public GenerateErrorDto UpdateVpn(VpnDto vpn, int VpnID)
        {
            return EGITService.UpdateVpn(vpn, VpnID);

        }

        [Route("deleteVPN")]
        [HttpDelete]
        public GenerateErrorDto DeleteVpn(int VpnID)
        {
            return EGITService.DeleteVpn(VpnID);
        }
    }
}
