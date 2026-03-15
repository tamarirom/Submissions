using lesson_04.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _context.Projects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return _context.Projects.Find(p => p.Id == id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] Project project)
        {
            Project newProject = new Project
            {
                Id = _context.Projects.Max(p => p.Id) + 1,
                Name = project.Name,
                Description = project.Description
            };

            _context.Projects.Add(newProject);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project project)
        {
            Project newProject = _context.Projects.Find(p => p.Id == id);

            if (newProject != null)
            {
                newProject.Name = project.Name;
                newProject.Description = project.Description;
            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Project project = _context.Projects.Find(p => p.Id == id);

            if (project != null)
            {
                TaskController.tasks.RemoveAll(t => t.ProjectId == id);
                _context.Projects.Remove(project);
            }
        }
    }
}
