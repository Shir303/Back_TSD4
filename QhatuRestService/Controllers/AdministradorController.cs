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
    public class AdministradorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public AdministradorController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllAdministradores()
        {
            var administradores = unitOfWork.AdministradorRepository.GetAll();
            return Ok(administradores);
        }
        [HttpGet("{id}")]
        public IActionResult GetAdministrador(int id)
        {
            var administrador = unitOfWork.AdministradorRepository.GetById(id);
            return Ok(administrador);
        }
        [HttpPost]
        public IActionResult AddAdministrador(Administrador administrador)
        {
            int result = unitOfWork.AdministradorRepository.Add(administrador);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddAdministrador),result);
        }
        [HttpPut]
        public IActionResult UpdateAdministrador(Administrador administrador)
        {
            int result = unitOfWork.AdministradorRepository.Update(administrador);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddAdministrador), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAdministradorById(int id)
        {
            int result = unitOfWork.AdministradorRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddAdministrador), result);
        }
    }
}
