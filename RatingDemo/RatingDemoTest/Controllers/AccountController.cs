using Model;
using Model.Models;
using Model.Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Service.EmployeeService;
using static Service.ServicesService;

namespace RatingDemoTest.Controllers
{
    public class AccountController : Controller
    {
        private const string USERSESSION = "USERSESSION";
        private readonly EmployeeService _employeeService;

        public AccountController(/*IEmployeeService employeeService, IServicesService servicesService*/)
        {
            _employeeService = new EmployeeService(new Repository<Employee>(new dbContext()));
        }

        // GET: Protector
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult accountlogin(string passcode, int idService)
        {
            if (passcode != null && passcode != "NaN")
            {
                EmployeeViewModel model = _employeeService.GetEmployeeById(passcode);
               
                //model = _employeeService.GetEmployeeById(passcode);
                if (model != null)
                {
                    UserViewModel m = new UserViewModel()
                    {
                        Id = model.Id,
                        passCode = model.passCode,
                        idService = idService
                    };
                    Session[USERSESSION] = m;
                    return Json(new
                    {
                        status = 202
                    });

                }
                else
                {
                    return Json(new
                    {
                        status = 404
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = 403
                });
            }
        }
        public ActionResult logout(string passcode)
        {
            EmployeeViewModel model = _employeeService.GetEmployeeById(passcode);
            if (model!=null){
                Session[USERSESSION] = null;
                return Json(new
                {
                    status = 202
                });
            }
            else
            {
                return Json(new
                {
                    status = 403
                });
            }
           
        }
    }
}