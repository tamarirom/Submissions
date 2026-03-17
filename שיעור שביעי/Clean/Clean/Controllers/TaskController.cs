using Microsoft.AspNetCore.Mvc;
using Clean.Service;
using Clean.Core.Entities;
using Task = Clean.Core.Entities.Task;
using Clean.Core.Services;

namespace Clean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _taskService.GetAll();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return _taskService.GetById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post(int projectId, [FromBody] Task newTask)
        {
            newTask.ProjectId = projectId;

            _taskService.AddTask(newTask);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Task task)
        {
            task.Id = id;

            _taskService.UpdateTask(id, task); 
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taskService.DeleteTask(id);
        }
    }
}
