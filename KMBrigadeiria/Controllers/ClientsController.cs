﻿using KMBrigadeiria.Models.DTOs;
using KMBrigadeiria.Services.Interfaces;
using KMBrigadeiria.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KMBrigadeiria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateClient(CreateClientDTO clientDTO)
        {
            try
            {
                _clientService.Create(clientDTO);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpPost("{clientId}/address")]
        [Authorize(Roles = "admin")]
        public IActionResult AddClientAddress(long clientId, CreateAddressDTO addressDTO)
        {
            try
            {
                _clientService.AddAddress(clientId, addressDTO);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetClientById(long id)
        {
            try
            {
                ReadClientDTO readClientDTO = _clientService.GetById(id);

                return Ok(readClientDTO);
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllClients()
        {
            try
            {
                IEnumerable<ReadClientDTO> clients = _clientService.GetAll();

                return Ok(clients);
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateClient(UpdateClientDTO updateClientDTO)
        {
            try
            {
                _clientService.Update(updateClientDTO);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpPatch("{clientId}/address")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateClientAddress(long clientId, UpdateAddressDTO updateAddressDTO)
        {
            try
            {
                _clientService.UpdateAddress(clientId, updateAddressDTO);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteClient(long id)
        {
            try
            {
                _clientService.Delete(id);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }

        [HttpDelete("{clientId}/address")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteClientAddress(long clientId)
        {
            try
            {
                _clientService.DeleteAddress(clientId);

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }
    }
}
