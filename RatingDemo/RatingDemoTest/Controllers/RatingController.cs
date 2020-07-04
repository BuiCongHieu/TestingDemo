using Model;
using Model.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RatingDemoTest.Controllers
{
    public class RatingController : Controller
    {
        private readonly RatingService _ratingService;
        public RatingController()
        {
            _ratingService = new RatingService(new Repository<Rating>(new dbContext()), new Repository<Servicecs>(new dbContext()), new Repository<Employee>(new dbContext()));
        }
        // GET: Rating
        public ActionResult Cleaning()
        {
            return View();
        }
        public ActionResult Protector()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(int serviceId, int score, string comment)
        {
           var data = (UserViewModel)Session["USERSESSION"];
            RatingViewModel model = new RatingViewModel() {
                Id = Guid.NewGuid(),
                idQuestion = serviceId,
                idService = serviceId,
                Scores = score,
                comment = comment,
                CreateDay = DateTime.Now,
                EmployeeID = data.Id
            };
            if (data != null)
            {
                var res = _ratingService.InsertAsync(model);
            }
            return Json(new
            {
                status = 202
            });

        }
    }
}