using costs_api.Database.Context;
using costs_api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace costs_api.Database.Repository.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BancoContext _context;
        public ServiceRepository(BancoContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Service service)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Service>> GetAll()
        {
            var services = await _context.Services.ToListAsync();
            return services;
        }

        public async Task<Service> GetById(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            return service;
        }

        public async Task<bool> Update(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
