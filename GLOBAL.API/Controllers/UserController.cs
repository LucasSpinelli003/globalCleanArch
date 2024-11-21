using GLOBAL.Application.Dtos;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GLOBAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _applicationService;

        public UserController(IUserApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<UserEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosUsers();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<UserEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterUserPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<UserEntity>]
        public IActionResult Post(UserDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarUser(entity);

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
        [Produces<UserEntity>]
        public IActionResult Put(int id, UserDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarUser(id, entity);

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
        [Produces<UserEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverUser(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

    }
}
