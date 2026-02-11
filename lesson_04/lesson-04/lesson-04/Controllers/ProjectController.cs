using lesson_04.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private static List<Project> projects = new List<Project>
        {
            new Project { Id = 1, Name = "Project A", Description = "Housework" },
            new Project { Id = 2, Name = "Project B", Description = "Homework" },
            new Project { Id = 3, Name = "Project C", Description = "Work" }
        };

        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return projects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return projects.Find(p => p.Id == id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] Project project)
        {
            Project newProject = new Project
            {
                Id = projects.Max(p => p.Id) + 1,
                Name = project.Name,
                Description = project.Description
            };

            projects.Add(newProject);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project project)
        {
            Project newProject = projects.Find(p => p.Id == id);

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
            Project project = projects.Find(p => p.Id == id);

            if (project != null)
            {
                TaskController.tasks.RemoveAll(t => t.ProjectId == id);
                projects.Remove(project);
            }
        }
    }
}
