using DecisiveApp.Data.Base;
using DecisiveApp.Models;

namespace DecisiveApp.Data.Services
{
    public interface IServiceService : IEntityBaseRepository<Service>
    {
        public Task<Service> GetServicesByidAsync(int id);

        //Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewServiceAsync(Service data);

        Task UpdateServiceAsync(Service data);
    }
}
