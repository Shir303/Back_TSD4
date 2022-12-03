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
    public class VendedorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public VendedorController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllVendedores()
        {
            var vendedores = unitOfWork.VendedorRepository.GetAll();
            return Ok(vendedores);
        }
        [HttpGet("{id}")]
        public IActionResult GetVendedor(int id)
        {
            var vendedor = unitOfWork.VendedorRepository.GetById(id);
            return Ok(vendedor);
        }
        [HttpPost]
        public IActionResult AddVendedor(Vendedor vendedor)
        {
            int result = unitOfWork.VendedorRepository.Add(vendedor);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddVendedor), result);
        }
        [HttpPut]
        public IActionResult UpdateVendedor(Vendedor vendedor)
        {
            int result = unitOfWork.VendedorRepository.Update(vendedor);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateVendedor), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVendedorById(int id)
        {
            int result = unitOfWork.VendedorRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteVendedorById), result);
        }
    }
}
