using AutoMapper;
using costs_api.Database.Entities;
using costs_api.Database.Repository.ServiceRepositories;
using costs_api.DTOs.Project;
using costs_api.DTOs.Service;
using Microsoft.AspNetCore.Mvc;

namespace costs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var services = await _repository.GetAll();

            var dtos = _mapper.Map<List<ServiceDTO>>(services);

            return Ok(dtos);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _repository.GetById(id);
            if (service == null) return NotFound();
            var dto = _mapper.Map<ServiceDTO>(service);

            return Ok(dto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ServiceDTO dto)
        {
            if (dto == null) return BadRequest();

            var service = _mapper.Map<Service>(dto);
            await _repository.Add(service);

            return Created();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceDTO dto)
        {
            var service = await _repository.GetById(id);

            if (service == null || dto == null) return BadRequest();

            service.Name = dto.Name;
            service.Cost = dto.Cost;
            service.Description = dto.Description;

            await _repository.Update(service);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _repository.GetById(id);
            if (service == null) return BadRequest();
            await _repository.Delete(service);
            return Ok();
        }
    }
}
