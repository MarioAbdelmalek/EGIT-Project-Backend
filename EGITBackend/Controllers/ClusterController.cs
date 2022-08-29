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
        public GenerateErrorDto AddCluster(CreateClusterDto newCluster)
        {
            return EGITService.AddCluster(newCluster);
        }

        [Route("getClusterById")]
        [HttpGet]
        public ClusterDto GetClusterByID(int ClusterID)
        {
            return EGITService.GetClusterByID(ClusterID);
        }

        [Route("updateCluster")]
        [HttpPut]
        public GenerateErrorDto UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            return EGITService.UpdateCluster(ClusterID, newCluster);
        }

        [Route("getAllClusters")]
        [HttpGet]
        public IEnumerable<ClusterDto> GetAllClusters()
        {
            return EGITService.GetAllClusters();
        }

        [Route("getClusterNodes")]
        [HttpGet]
        public IEnumerable<NodeDto> GetClusterNodes(int ClusterID)
        {
            return EGITService.GetClusterNodes(ClusterID);
        }

        [Route("getClustersByType")]
        [HttpGet]
        public IEnumerable<ClusterDto> GetClustersByType(string ClusterType)
        {
            return EGITService.GetClustersByType(ClusterType);
        }

        [Route("deleteCluster")]
        [HttpDelete]
        public GenerateErrorDto DeleteCluster(int ClusterID)
        {
            return EGITService.DeleteCluster(ClusterID);
        }

    }
}
