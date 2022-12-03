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
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public DetalleFacturaController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllDetalleFactura()
        {
            var detalleFacturas = unitOfWork.DetalleFacturaRepository.GetAll();
            return Ok(detalleFacturas);
        }
        [HttpGet("{facturaId}")]
        public IActionResult GetDetalleFactura(int facturaId)
        {
            var detalleFacturas = unitOfWork.DetalleFacturaRepository.GetDetalleFactura(facturaId);
            return Ok(detalleFacturas);
        }
        [HttpGet("{facturaId}/{tiendaId}")]
        public IActionResult GetDetalleFacturaTienda(int facturaId, int tiendaId)
        {
            var detalleFacturas = unitOfWork.DetalleFacturaRepository.GetDetalleFacturaTienda(facturaId, tiendaId);
            return Ok(detalleFacturas);
        }
        [HttpGet("{facturaId}/{tiendaId}/{productoId}")]
        public IActionResult GetDetalleFacturaTiendaProducto(int facturaId,int tiendaId,int productoId)
        {
            var detalleFacturas = unitOfWork.DetalleFacturaRepository.GetDetalleFacturaByIds(facturaId,tiendaId,productoId);
            return Ok(detalleFacturas);
        }
        [HttpPost]
        public IActionResult AddDetalleFactura(DetalleFactura detalleFactura)
        {
            int result = unitOfWork.DetalleFacturaRepository.Add(detalleFactura);
            var tiendaProducto = unitOfWork.TiendaProductoRepository.GetTiendaProductoByIds(detalleFactura.TiendaId,detalleFactura.ProductoId);
            tiendaProducto.Stock -= detalleFactura.Cantidad;
            int resultStock = unitOfWork.TiendaProductoRepository.UpdateStock(tiendaProducto);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddDetalleFactura), result);
        }
        [HttpPut]
        public IActionResult UpdateDetalleFactura(DetalleFactura detalleFactura)
        {
            int result = unitOfWork.DetalleFacturaRepository.Update(detalleFactura);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateDetalleFactura), result);
        }
        [HttpDelete("{facturaId}/{tiendaId}/{productoId}")]
        public IActionResult DeleteDetalleFacturaById(int facturaId, int tiendaId, int productoId)
        {
            int result = unitOfWork.DetalleFacturaRepository.DeleteDetalleFacturaByIds(facturaId, tiendaId, productoId);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteDetalleFacturaById), result);
        }
    }
}
