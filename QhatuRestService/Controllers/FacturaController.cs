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
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public FacturaController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllFacturas()
        {
            var facturas = unitOfWork.FacturaRepository.GetAll();
            return Ok(facturas);
        }
        [HttpGet("{id}")]
        public IActionResult GetFacturaUsuario(int id)
        {
            var categoria = unitOfWork.FacturaRepository.GetFacturasById(id);
            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult AddFactura(Factura factura)
        {
            int result = unitOfWork.FacturaRepository.Add(factura);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddFactura), result);
        }
        [HttpPut]
        public IActionResult UpdateFactura(Factura factura)
        {
            int result = unitOfWork.FacturaRepository.Update(factura);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateFactura), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFacturaById(int id)
        {
            int result = unitOfWork.FacturaRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteFacturaById), result);
        }
    }
}
