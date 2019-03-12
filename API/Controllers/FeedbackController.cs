using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class FeedbackController : ApiController
    {
        private readonly IRepository<FeedBack> feedbackRepository;
        public FeedbackController()
        {
            this.feedbackRepository = new Repository<FeedBack>();
        }

        [HttpPost]
        public IHttpActionResult InsertFeedback(FeedBack feedBack)
        {
            feedBack.Date = DateTime.Now;
            feedbackRepository.Create(feedBack);
            return Ok();
        }
    }
}
