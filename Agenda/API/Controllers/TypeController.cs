using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Types;
using Application.DTOs.TypesDTOs;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/types")] 
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _typeService.GetAllAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var type = await _typeService.GetByIdAsync(id);
            return type is null ? NotFound() : Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TypeRequestDTO dto)
        {
            var type = await _typeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = type.Id }, type);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TypeRequestDTO dto)
        {
            var updated = await _typeService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _typeService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}