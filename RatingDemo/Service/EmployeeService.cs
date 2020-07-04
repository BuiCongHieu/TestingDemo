using Model;
using Model.Models;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.EmployeeService;

namespace Service
{
   public class EmployeeService:Service<Employee>, IEmployeeService
    {
        public interface IEmployeeService: IService<Employee>
        {
            //Task<IQueryable<EmployeeViewModel>> GetAllEmployeeAsync();
            //Task<IQueryable<EmployeeViewModel>> GetEmployeeByIdAsync(string pass);
            IQueryable<EmployeeViewModel> GetAllEmployee();
            EmployeeViewModel GetEmployeeById(string pass);
        }
        private readonly IRepositoryAsync<Employee> _repository;
        public EmployeeService(IRepositoryAsync<Employee> repository) : base(repository)
        {
            _repository = repository;
        }

        //public async Task<IQueryable<EmployeeViewModel>> GetAllEmployeeAsync()
        //{
        //    return await Task.Run(() => GetAllEmployee());
        //}

        //public async Task<IQueryable<EmployeeViewModel>> GetEmployeeByIdAsync(string pass)
        //{
        //    return await Task.Run(() => GetEmployeeById(pass));
        //}

        public IQueryable<EmployeeViewModel> GetAllEmployee()
        {
            return _repository.Queryable().Select(x => new EmployeeViewModel()
            {
                Id = x.Id,
                passCode = x.passCode
            });
        }
        public EmployeeViewModel GetEmployeeById(string pass)
        {
            return _repository.Queryable().Where(x => x.passCode == pass)
                .Select(x => new EmployeeViewModel()
                {
                    Id = x.Id,
                    passCode = x.passCode
                }).SingleOrDefault();
        }
    }
}
