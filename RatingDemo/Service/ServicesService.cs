using Model;
using Model.Models;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.ServicesService;

namespace Service
{
    public class ServicesService:Service<Servicecs>,IServicesService
    {
        public interface IServicesService : IService<Servicecs>
        {
            Task<IQueryable<ServicesViewModel>> GetAllServiceAsync();
            Task<IQueryable<ServicesViewModel>> GetServiceByIdAsync(int Id);
            IQueryable<ServicesViewModel> GetAllService();
            IQueryable<ServicesViewModel> GetServiceById(int Id);

        }
        private readonly IRepositoryAsync<Servicecs> _repository;
        public ServicesService(IRepositoryAsync<Servicecs> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<ServicesViewModel>> GetAllServiceAsync()
        {
            return await Task.Run(() => GetAllService());
        }

        public async Task<IQueryable<ServicesViewModel>> GetServiceByIdAsync(int Id)
        {
            return await Task.Run(() => GetServiceById(Id));
        }

        public IQueryable<ServicesViewModel> GetAllService()
        {
            return _repository.Queryable().Select(x => new ServicesViewModel()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public IQueryable<ServicesViewModel> GetServiceById(int Id)
        {
            return _repository.Queryable().Where(x => x.Id == Id)
                .Select(x => new ServicesViewModel()
                {

                    Id = x.Id,
                    Name = x.Name
                });
        }
    }
}
