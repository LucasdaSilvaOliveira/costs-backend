using costs_api.Database.Context;
using costs_api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace costs_api.Database.Repository.ProjectRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BancoContext _context;
        public ProjectRepository(BancoContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Project>> GetAll()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project> GetById(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return project;
        }

        public async Task<bool> Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
