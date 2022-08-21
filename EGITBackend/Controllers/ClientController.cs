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
        public void AddClient(CreateClientDto newClient)
        {
            EGITService.AddClient(newClient);
        }

        [Route("getClientById")]
        [HttpGet]
        public ClientDto GetClientByID(int ClientID)
        {
            return EGITService.GetClientByID(ClientID);
        }

        [Route("updateClient")]
        [HttpPut]
        public void UpdateClient(int ClientID, CreateClientDto newClient)
        {
            EGITService.UpdateClient(ClientID, newClient);
        }

        [Route("getAllClients")]
        [HttpGet]
        public IEnumerable<ClientDto> GetAllClients()
        {
            return EGITService.GetAllClients();
        }

        [Route("deleteClient")]
        [HttpDelete]
        public void DeleteClient(int ClientID)
        {
            EGITService.DeleteClient(ClientID);
        }
    }
}
