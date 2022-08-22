using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGITBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterController : ControllerBase
    {

        IEGITService EGITService;
        public ClusterController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("addCluster")]
        [HttpPost]
        public void AddCluster(CreateClusterDto newCluster)
        {
            EGITService.AddCluster(newCluster);
        }

        [Route("getClusterById")]
        [HttpGet]
        public ClusterDto GetClusterByID(int ClusterID)
        {
            return EGITService.GetClusterByID(ClusterID);
        }

        [Route("updateCluster")]
        [HttpPut]
        public void UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            EGITService.UpdateCluster(ClusterID, newCluster);
        }

        [Route("getAllClusters")]
        [HttpGet]
        public IEnumerable<ClusterDto> GetAllClusters()
        {
            return EGITService.GetAllClusters();
        }

        [Route("deleteCluster")]
        [HttpDelete]
        public void DeleteCluster(int ClusterID)
        {
            EGITService.DeleteCluster(ClusterID);
        }
    }
}
