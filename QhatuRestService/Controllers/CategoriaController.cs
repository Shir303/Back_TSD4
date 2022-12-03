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
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductoController> logger;
        public CategoriaController(IUnitOfWork unitOfWork, ILogger<ProductoController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult AllCategorias()
        {
            var categorias = unitOfWork.CategoriaRepository.GetAll();
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoria(int id)
        {
            var categoria = unitOfWork.CategoriaRepository.GetById(id);
            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult AddCategoria(Categoria categoria)
        {
            int result = unitOfWork.CategoriaRepository.Add(categoria);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(AddCategoria), result);
        }
        [HttpPut]
        public IActionResult UpdateCategoria(Categoria categoria)
        {
            int result = unitOfWork.CategoriaRepository.Update(categoria);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(UpdateCategoria), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoriaById(int id)
        {
            int result = unitOfWork.CategoriaRepository.DeleteById(id);
            unitOfWork.Commit();
            return CreatedAtAction(nameof(DeleteCategoriaById), result);
        }
    }
}
