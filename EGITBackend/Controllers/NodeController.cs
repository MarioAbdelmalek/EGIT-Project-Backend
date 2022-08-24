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
        public GenerateErrorDto AddNode(CreateNodeDto newNode)
        {
            return EGITService.AddNode(newNode);
        }

        [Route("getNodeById")]
        [HttpGet]
        public NodeDto GetNodeByID(int NodeID)
        {
            return EGITService.GetNodeByID(NodeID);
        }

        [Route("updateNode")]
        [HttpPut]
        public GenerateErrorDto UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            return EGITService.UpdateNode(NodeID, newNode);
        }

        [Route("getAllNodes")]
        [HttpGet]
        public IEnumerable<NodeDto> GetAllNodes()
        {
            return EGITService.GetAllNodes();
        }

        [Route("deleteNode")]
        [HttpDelete]
        public GenerateErrorDto DeleteNode(int NodeID)
        {
            return EGITService.DeleteNode(NodeID);
        }

    }
}
