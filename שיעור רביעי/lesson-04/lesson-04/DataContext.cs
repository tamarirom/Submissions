using lesson_04.Entities;
using Task = lesson_04.Entities.Task;

namespace lesson_04
{
    public class DataContext
    {
        public List<Project> Projects { get; set; }
        public List<Task> Tasks { get; set; }

        public DataContext()
        {
            Projects = new List<Project>()
            {
                new Project { Id = 1, Name = "Project A", Description = "Housework" },
                new Project { Id = 2, Name = "Project B", Description = "Homework" },
                new Project { Id = 3, Name = "Project C", Description = "Work" }
            };

            Tasks = new List<Task>()
            {
                new Task { Id = 1, ProjectId = 1, Title = "Clean the house", myStatus = Task.Status.ToDo },
                new Task { Id = 2, ProjectId = 1, Title = "Wash the dishes", myStatus = Task.Status.InAction },
                new Task { Id = 3, ProjectId = 2, Title = "Finish math homework", myStatus = Task.Status.Completed }
            };
        }
    }
}
