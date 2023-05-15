using DecisiveApp.Data.Base;
using DecisiveApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DecisiveApp.Data.Services
{
    public class ServiceService : EntityBaseRepository<Service>, IServiceService
    {
        private readonly AppDBContext _context;
        public ServiceService(AppDBContext context) : base(context)
        {
            _context = context;
        }
        public Task AddNewServiceAsync(Service data)
        {
            throw new NotImplementedException();
        }

        public async Task<Service> GetServicesByidAsync(int id)
        {
            var ServiceDetails = await _context.Services
                 .FirstOrDefaultAsync(n => n.id == id);
            return ServiceDetails;
        }

        public Task UpdateServiceAsync(Service data)
        {
            throw new NotImplementedException();
        }
    }
}
