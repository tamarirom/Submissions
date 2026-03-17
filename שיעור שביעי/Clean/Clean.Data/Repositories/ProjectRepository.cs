using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Repositories;

namespace Clean.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public List<Project> Get()
        {
            return _context.Projects;
        }

        public Project GetById(int id)
        {
            return _context.Projects.Find(p => p.Id == id);
        }

        public void AddProject(Project newProject)
        {
            _context.Projects.Add(newProject);
        }

        public void UpdateProject(int id, Project updatedProject)
        {
            var project = _context.Projects.Find(p => p.Id == id);

            if (project != null)
            {
                project.Name = updatedProject.Name;
                project.Description = updatedProject.Description;
            }
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.Find(p => p.Id == id);

            if (project != null)
            {
                _context.Projects.Remove(project);
            }
        }
    }
}
