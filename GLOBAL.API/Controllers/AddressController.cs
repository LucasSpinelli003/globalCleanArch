using GLOBAL.Application.Dtos;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GLOBAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressApplicationService _applicationService;

        public AddressController(IAddressApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<AddressEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosAddresss();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<AddressEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterAddressPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<AddressEntity>]
        public IActionResult Post(AddressDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarAddress(entity);

                if (categorias is not null)
                    return Ok(categorias);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [Produces<AddressEntity>]
        public IActionResult Put(int id, AddressDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarAddress(id, entity);

                if (categorias is not null)
                    return Ok(categorias);

                return BadRequest("Não foi possivel editar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("{id}")]
        [Produces<AddressEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverAddress(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

    }
}
