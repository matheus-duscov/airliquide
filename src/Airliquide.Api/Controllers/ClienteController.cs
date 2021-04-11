using Airliquide.Contracts.Contracts;
using Airliquide.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airliquide.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAsync(Guid? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.ListAsync(id);

            if (result != null && result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostAsync(ClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);

            return Created("api/[controller]", "201 Created");
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAsync(ClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(dto);

            return Ok("200 OK");
        }

        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([Required] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.RemoveAsync(id);

            return Ok("200 OK");
        }
    }
}
