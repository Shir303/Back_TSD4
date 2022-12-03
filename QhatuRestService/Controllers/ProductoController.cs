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
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public ProductoController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllProductos()
        {
            var productos = unitOfWork.ProductoRepository.GetAll();
            return Ok(productos);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            var producto = unitOfWork.ProductoRepository.GetById(id);
            return Ok(producto);
        }
        [HttpPost]
        public IActionResult AddProducto(Producto producto)
        {
            //logger.LogInformation("haciendo seguimiento al producto");
            int result = unitOfWork.ProductoRepository.Add(producto);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddProducto), result);
        }
        [HttpPut]
        public IActionResult UpdateProducto(Producto producto)
        {
            int result = unitOfWork.ProductoRepository.Update(producto);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateProducto), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            int result = unitOfWork.ProductoRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteProducto), result);
        }
    }
}
