using Clean.Core.Entities;
using Clean.Core.Repositories;
using Task = Clean.Core.Entities.Task;
using Clean.Core.Services;

namespace Clean.Service
{
    public class TaskService : ITaskService
    {
        public readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task GetById(int taskId)
        {
            //TODO business logic

            return _taskRepository.GetById(taskId);
        }

        public List<Task> GetAll()
        {
            //TODO business logic

            return _taskRepository.GetAll();
        }

        public void AddTask(Task newTask)
        {
            //TODO business logic

            _taskRepository.AddTask(newTask);
        }

        public void UpdateTask(int id, Task task)
        {
            //TODO business logic

            _taskRepository.UpdateTask(id, task);
        }

        public void DeleteTask(int id)
        {
            //TODO business logic

            Task deletedTask = _taskRepository.GetById(id);

            if (deletedTask != null)
            {
                _taskRepository.DeleteTask(id);
            }
        }
    }
}
