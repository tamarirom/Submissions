using lesson_04.Entities;
using Microsoft.AspNetCore.Mvc;
using Task = lesson_04.Entities.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        // GET api/<TaskController>/5
        [HttpGet("{taskId}")]
        public Task GetById(int taskId)
        {
            return _context.Tasks.Find(t => t.ProjectId == taskId);
        }

        // GET api/<TaskController>/project/1
        [HttpGet("project/{projectId}")]
        public IEnumerable<Task> GetByProject(int projectId)
        {
            return _context.Tasks.FindAll(t => t.ProjectId == projectId);
        }

        // POST api/<TaskController>
        [HttpPost("{projectId}")]
        public void Post(int projectId, [FromBody] Task newTask)
        {
            newTask.ProjectId = projectId;

            // בדיקה: האם הרשימה ריקה?
            if (_context.Tasks.Count == 0)
                newTask.Id = 1;
            
            else
                newTask.Id= _context.Tasks.Max(t => t.Id) + 1;

            newTask.myStatus = Task.Status.ToDo;

            _context.Tasks.Add(newTask);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Task t)
        {
            Task newTask= _context.Tasks.Find(t => t.Id == id);

            if (newTask != null)
            {
                newTask.ProjectId = t.ProjectId;
                newTask.Title = t.Title;
                newTask.myStatus = t.myStatus;
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Task taskToDelete = _context.Tasks.Find(t => t.Id == id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
            }
        }
    }
}