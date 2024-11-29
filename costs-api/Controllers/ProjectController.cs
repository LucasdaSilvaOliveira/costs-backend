using costs_api.Database.Repository.ProjectRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace costs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        //public async Task<IActionResult> GetAllProjects()
        //{
        //    var projects = await _repository.GetAll();
        //}
    }
}
