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
    public class ClientController : ControllerBase
    {
        IEGITService EGITService;
        public ClientController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("addClient")]
        [HttpPost]
        public GenerateErrorDto AddClient(CreateClientDto newClient)
        {
            return EGITService.AddClient(newClient);
        }

        [Route("getClientById")]
        [HttpGet]
        public ClientDto GetClientByID(int ClientID)
        {
            return EGITService.GetClientByID(ClientID);
        }

        [Route("updateClient")]
        [HttpPut]
        public GenerateErrorDto UpdateClient(int ClientID, CreateClientDto newClient)
        {
            return EGITService.UpdateClient(ClientID, newClient);
        }

        [Route("getAllClients")]
        [HttpGet]
        public IEnumerable<ClientDto> GetAllClients()
        {
            return EGITService.GetAllClients();
        }

        [Route("deleteClient")]
        [HttpDelete]
        public GenerateErrorDto DeleteClient(int ClientID)
        {
            return EGITService.DeleteClient(ClientID);
        }
    }
}
