using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class ProjectService : IProjectService
    {
        public readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> Get()
        {
            // TODO: business logic

            return _projectRepository.Get();
        }

        public Project GetById(int id)
        {
            // TODO: business logic

            return _projectRepository.GetById(id);
        }

        public void AddProject (Project project)
        {
            _projectRepository.AddProject(project);
        }

        public void UpdateProject(int id, Project updatedProject)
        {
            _projectRepository.UpdateProject(id, updatedProject);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }
    }
}