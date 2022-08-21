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
    public class NodeController : ControllerBase
    {
        IEGITService EGITService;
        public NodeController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("addNode")]
        [HttpPost]
        public void AddNode(CreateNodeDto newNode)
        {
            EGITService.AddNode(newNode);
        }

        [Route("getNodeById")]
        [HttpGet]
        public NodeDto GetNodeByID(int NodeID)
        {
            return EGITService.GetNodeByID(NodeID);
        }

        [Route("updateNode")]
        [HttpPut]
        public void UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            EGITService.UpdateNode(NodeID, newNode);
        }

        [Route("getAllNodes")]
        [HttpGet]
        public IEnumerable<NodeDto> GetAllNodes()
        {
            return EGITService.GetAllNodes();
        }

        [Route("deleteNode")]
        [HttpDelete]
        public void DeleteNode(int NodeID)
        {
            EGITService.DeleteNode(NodeID);
        }
    }
}
