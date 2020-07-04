using Model;
using Model.Repository;
using Service;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using static Service.EmployeeService;
using static Service.RatingService;
using static Service.ServicesService;
using System.Web.Http;
namespace RatingDemoTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType(typeof(IRepository<>), typeof(Repository<>))
                .RegisterType(typeof(IRepositoryAsync<>), typeof(Repository<>))
                .RegisterType<DbContext, dbContext>(new HierarchicalLifetimeManager())

                .RegisterType<IRatingService, RatingService>()
                .RegisterType<IEmployeeService, EmployeeService>()
                .RegisterType<IServicesService, ServicesService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}