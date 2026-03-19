using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Clean.Core.Entities.Task;
using Clean.Core.Repositories;

namespace Clean.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public Task GetById(int taskId)
        {
            return _context.Tasks.ToList().Find(t => t.ProjectId == taskId);
        }

        public List<Task> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public void AddTask(Task newTask)
        {
            _context.Tasks.Add(newTask);
        }

        public void UpdateTask(int id, Task UpdateTask)
        {
            Task newTask = _context.Tasks.ToList().Find(t => t.Id == id);

            if (newTask != null)
            {
                newTask.ProjectId = UpdateTask.ProjectId;
                newTask.Title = UpdateTask.Title;
                newTask.myStatus = UpdateTask.myStatus;
            }
        }

        public void DeleteTask(int id)
        {
            Task task = _context.Tasks.ToList().Find(t => t.Id == id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }
    }
}
