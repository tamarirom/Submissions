using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Clean.Core.Entities.Task;

namespace Clean.Core.Repositories
{
    public interface ITaskRepository
    {
        Task GetById(int taskId);
        List<Task> GetAll();
        void AddTask(Task newTask);
        void UpdateTask(int id, Task task);
        void DeleteTask(int id);
    }
}
