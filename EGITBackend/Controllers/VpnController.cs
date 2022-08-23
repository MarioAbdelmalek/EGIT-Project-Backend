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

        public List<VpnDto> GetAllVpns()
        {
            return EGITService.GetAllVpns();
        }
        public VpnDto GetVpn(int VpnID)
        {
            return EGITService.GetVpn(VpnID);

        }
        public void AddVpn(VpnDto vpn)
        {
            EGITService.AddVpn(vpn);
        }
        public void UpdateVpn(VpnDto vpn, int VpnID)
        {
            EGITService.UpdateVpn(vpn, VpnID);

        }
        public void DeleteVpn(int VpnID)
        {
            EGITService.DeleteVpn(VpnID);

        }
    }
}
