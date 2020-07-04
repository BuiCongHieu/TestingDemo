using Model;
using Model.Models;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.RatingService;
using static Service.ServicesService;

namespace Service
{
   public class RatingService:Service<Rating>, IRatingService
    {
        public interface IRatingService : IService<Rating>
        {
            Rating insert(RatingViewModel model);
            Task<Rating> InsertAsync(RatingViewModel model);
        }
        private readonly IRepositoryAsync<Rating> _repository;
        private readonly IRepositoryAsync<Servicecs> _servicesService;
        private readonly IRepositoryAsync<Employee> _employeeService;
        public RatingService(IRepositoryAsync<Rating> repository, IRepositoryAsync<Servicecs> servicesService, IRepositoryAsync<Employee> employeeService) :base(repository)
        {
            _repository = repository;
            _servicesService = servicesService;
            _employeeService = employeeService;
        }
        public Rating insert(RatingViewModel model)
        {
            var data = new Rating();

              // data.Employee = _employeeService.Find(model.EmployeeID);
               data.Id = model.Id;
               data.idQuestion = model.idQuestion;
               data.Scores = model.Scores;
               data.comment = model.comment;
               data.CreateDay = model.CreateDay;
               data.idService = model.idService;

            base.Insert(data);
            return data;
        }

        public async Task<Rating> InsertAsync(RatingViewModel model)
        {
            return await Task.Run(() => insert(model));
        }
    }
}
