using Clean.Core.Entities;

namespace Clean.Core.Services
{
    public interface IProjectService
    {
        List<Project> Get();
        Project GetById(int id);
        void AddProject(Project newProject);
        void UpdateProject(int id, Project updatedProject);
        void DeleteProject(int id);
    }
}