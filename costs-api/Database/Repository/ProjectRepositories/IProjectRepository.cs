using costs_api.Database.Entities;

namespace costs_api.Database.Repository.ProjectRepositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<bool> Update(Project project);
        Task<bool> Delete(Project project);
        Task<bool> Add(Project project);
    }
}
