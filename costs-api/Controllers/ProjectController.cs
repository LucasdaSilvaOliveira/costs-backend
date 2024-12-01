using AutoMapper;
using costs_api.Database.Entities;
using costs_api.Database.Repository.ProjectRepositories;
using costs_api.DTOs.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace costs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        public ProjectController(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repository.GetAll();

            var dtos = _mapper.Map<List<ProjectDTO>>(projects);

            return Ok(dtos);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _repository.GetById(id);
            if (project == null) return NotFound();
            var dto = _mapper.Map<ProjectDTO>(project);

            return Ok(dto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProjectDTO dto)
        {
            if (dto == null) return BadRequest();

            var project = _mapper.Map<Project>(dto);
            await _repository.Add(project);

            return Created();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectDTO dto)
        {
            var project = await _repository.GetById(id);

            if (project == null || dto == null) return BadRequest();

            project.Name = dto.Name;
            project.Budget = dto.Budget;
            project.Category = dto.Category;

            await _repository.Update(project);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _repository.GetById(id);
            if (project == null) return BadRequest();
            await _repository.Delete(project);
            return Ok();
        }
    }
}
