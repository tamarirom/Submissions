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
        public static List<Task> tasks = new List<Task>
        {
            new Task { Id = 1, ProjectId = 1, Title = "Clean the house", myStatus = Task.Status.ToDo },
            new Task { Id = 2, ProjectId = 1, Title = "Wash the dishes", myStatus = Task.Status.InAction },
            new Task { Id = 3, ProjectId = 2, Title = "Finish math homework", myStatus = Task.Status.Completed }
        };

        // GET api/<TaskController>/5
        [HttpGet("{taskId}")]
        public Task GetById(int taskId)
        {
            return tasks.Find(t => t.ProjectId == taskId);
        }

        // GET api/<TaskController>/project/1
        [HttpGet("project/{projectId}")]
        public IEnumerable<Task> GetByProject(int projectId)
        {
            return tasks.FindAll(t => t.ProjectId == projectId);
        }

        // POST api/<TaskController>
        [HttpPost("{projectId}")]
        public void Post(int projectId, [FromBody] Task newTask)
        {
            newTask.ProjectId = projectId;

            // בדיקה: האם הרשימה ריקה?
            if (tasks.Count == 0)
                newTask.Id = 1;
            
            else
                newTask.Id= tasks.Max(t => t.Id) + 1;

            newTask.myStatus = Task.Status.ToDo;

            tasks.Add(newTask);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Task t)
        {
            Task newTask=tasks.Find(t => t.Id == id);

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
            Task taskToDelete = tasks.Find(t => t.Id == id);
            if (taskToDelete != null)
            {
                tasks.Remove(taskToDelete);
            }
        }
    }
}