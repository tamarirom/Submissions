using Clean.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Services;

namespace Clean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projectService.Get();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return _projectService.GetById(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] Project newProject)
        {
            _projectService.AddProject(newProject);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project updatedProject)
        {
            _projectService.UpdateProject(id, updatedProject);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectService.DeleteProject(id);
        }
    }
}
