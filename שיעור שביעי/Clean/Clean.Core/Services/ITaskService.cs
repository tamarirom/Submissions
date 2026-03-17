using Clean.Core.Entities;
using Task = Clean.Core.Entities.Task;
using System.Collections.Generic;

namespace Clean.Core.Services
{
    public interface ITaskService
    {
        List<Task> GetAll();
        Task GetById(int id);
        void AddTask(Task newTask);
        void UpdateTask(int id, Task task);
        void DeleteTask(int id);
    }
}