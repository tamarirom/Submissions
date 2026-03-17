using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface IProjectRepository
    {
        List<Project> Get();
        Project GetById(int id);
        void AddProject(Project newProject);
        void UpdateProject(int id, Project updatedProject);
        void DeleteProject(int id);
    }
}
