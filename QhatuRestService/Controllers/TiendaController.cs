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
    public class TiendaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public TiendaController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllTiendas()
        {
            var tiendas = unitOfWork.TiendaRepository.GetAll();
            return Ok(tiendas);
        }
        [HttpGet("{id}")]
        public IActionResult GetTienda(int id)
        {
            var tienda = unitOfWork.TiendaRepository.GetById(id);
            return Ok(tienda);
        }
        [HttpPost]
        public IActionResult AddTienda(Tienda tienda)
        {
            int result = unitOfWork.TiendaRepository.Add(tienda);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddTienda), result);
        }
        [HttpPut]
        public IActionResult UpdateTienda(Tienda tienda)
        {
            int result = unitOfWork.TiendaRepository.Update(tienda);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateTienda), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTiendaById(int id)
        {
            int result = unitOfWork.TiendaRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteTiendaById), result);
        }
    }
}
