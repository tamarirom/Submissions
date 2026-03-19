using Clean.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Clean.Core.Entities.Task;

namespace Clean.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DataContext()
        {
            //Projects = new DbSet<Project>()
            //{
            //    new Project { Id = 1, Name = "Project A", Description = "Housework" },
            //    new Project { Id = 2, Name = "Project B", Description = "Homework" },
            //    new Project { Id = 3, Name = "Project C", Description = "Work" }
            //};

            //Tasks = new DbSet<Task>()
            //{
            //    new Task { Id = 1, ProjectId = 1, Title = "Clean the house", myStatus = Task.Status.ToDo },
            //    new Task { Id = 2, ProjectId = 1, Title = "Wash the dishes", myStatus = Task.Status.InAction },
            //    new Task { Id = 3, ProjectId = 2, Title = "Finish math homework", myStatus = Task.Status.Completed }
            //};
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-L9S4R74;Database=sample_db; Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
