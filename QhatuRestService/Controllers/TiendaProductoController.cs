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
    public class TiendaProductoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public TiendaProductoController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllTiendaProductos()
        {
            var tiendaProductos = unitOfWork.TiendaProductoRepository.GetAll();
            return Ok(tiendaProductos);
        }
        [HttpGet("{tiendaId}/{productoId}")]
        public IActionResult GetTiendaProducto( int tiendaId, int productoId)
        {
            var tiendaProducto = unitOfWork.TiendaProductoRepository.GetTiendaProductoByIds(tiendaId, productoId);
            return Ok(tiendaProducto);
        }
        [HttpPost]
        public IActionResult AddTiendaProducto(TiendaProducto tiendaProducto)
        {
            int result = unitOfWork.TiendaProductoRepository.Add(tiendaProducto);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddTiendaProducto), result);
        }
        //[HttpPut]
        //public IActionResult AddVentaTiendaProducto(TiendaProducto tiendaProducto)
        //{
        //    int result = unitOfWork.TiendaProductoRepository.UpdateStock(tiendaProducto);

        //    unitOfWork.Commit();
        //    return CreatedAtAction(nameof(AddVentaTiendaProducto), result);
        //}
        [HttpPut]
        public IActionResult UpdateTiendaProducto(TiendaProducto tiendaProducto)
        {
            int result = unitOfWork.TiendaProductoRepository.Update(tiendaProducto);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateTiendaProducto), result);
        }
        [HttpDelete("{tiendaId}/{productoId}")]
        public IActionResult DeleteTiendaProductoById(int tiendaId, int productoId)
        {
            int result = unitOfWork.TiendaProductoRepository.DeleteTiendaProductoByIds(tiendaId, productoId);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteTiendaProductoById), result);
        }
    }
}
