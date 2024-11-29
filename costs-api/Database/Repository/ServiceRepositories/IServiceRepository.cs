using costs_api.Database.Entities;

namespace costs_api.Database.Repository.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
        Task<Service> GetById(int id);
        Task<bool> Update(Service project);
        Task<bool> Delete(Service project);
        Task<bool> Add(Service project);
    }
}
