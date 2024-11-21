using GLOBAL.Application.Dtos;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GLOBAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceInfoController : ControllerBase
    {
        private readonly IDeviceInfoApplicationService _applicationService;

        public DeviceInfoController(IDeviceInfoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<DeviceInfoEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosDeviceInfos();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<DeviceInfoEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterDeviceInfoPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<DeviceInfoEntity>]
        public IActionResult Post(DeviceInfoDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarDeviceInfo(entity);

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
        [Produces<DeviceInfoEntity>]
        public IActionResult Put(int id, DeviceInfoDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarDeviceInfo(id, entity);

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
        [Produces<DeviceInfoEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverDeviceInfo(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

    }
}
