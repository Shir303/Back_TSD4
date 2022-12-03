using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Qhatu.Domain.Models;
using Qhatu.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QhatuRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public ClienteController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllCliente()
        {
            var clientes = unitOfWork.ClienteRepository.GetAll();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = unitOfWork.ClienteRepository.GetById(id);
            return Ok(cliente);
        }
        [HttpPost]
        public IActionResult AddCliente(Cliente cliente)
        {
            int result = unitOfWork.ClienteRepository.Add(cliente);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddCliente), result);
        }
        [HttpPut]
        public IActionResult UpdateCliente(Cliente cliente)
        {
            int result = unitOfWork.ClienteRepository.Update(cliente);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateCliente), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClienteById(int id)
        {
            int result = unitOfWork.ClienteRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteClienteById), result);
        }
    }
}
