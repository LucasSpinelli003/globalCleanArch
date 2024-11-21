using GLOBAL.Application.Dtos;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GLOBAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceApplicationService _applicationService;

        public DeviceController(IDeviceApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<DeviceEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosDevices();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<DeviceEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterDevicePorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<DeviceEntity>]
        public IActionResult Post(DeviceDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarDevice(entity);

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
        [Produces<DeviceEntity>]
        public IActionResult Put(int id, DeviceDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarDevice(id, entity);

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
        [Produces<DeviceEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverDevice(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

    }
}
