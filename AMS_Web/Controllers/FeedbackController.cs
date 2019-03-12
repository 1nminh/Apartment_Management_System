using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS_Web.Controllers
{
    public class FeedbackController : Controller
    {

        private IRepository<FeedBack> feedbackRepository;

        public FeedbackController()
        {
            this.feedbackRepository = new Repository<FeedBack>();
        }

        public ActionResult Index()
        {
            var result = feedbackRepository.GetAll();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            feedbackRepository.Delete(id);
            return RedirectToAction("Index", "Feedback");
        }
    }
}