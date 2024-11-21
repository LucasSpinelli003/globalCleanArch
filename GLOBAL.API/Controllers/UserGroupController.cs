using GLOBAL.Application.Dtos;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GLOBAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupApplicationService _applicationService;

        public UserGroupController(IUserGroupApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<UserGroupEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosUserGroups();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<UserGroupEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterUserGroupPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<UserGroupEntity>]
        public IActionResult Post(UserGroupDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarUserGroup(entity);

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
        [Produces<UserGroupEntity>]
        public IActionResult Put(int id, UserGroupDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarUserGroup(id, entity);

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
        [Produces<UserGroupEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverUserGroup(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

    }
}
