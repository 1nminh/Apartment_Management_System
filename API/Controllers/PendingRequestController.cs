using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PendingRequestController : ApiController
    {
        private readonly IRepository<PendingRequest> pendingRequestRepository;

        public PendingRequestController()
        {
            this.pendingRequestRepository = new Repository<PendingRequest>();
        }

        [HttpPost]
        public IHttpActionResult InsertRequest(PendingRequest pendingRequest)
        {
            pendingRequest.Date = DateTime.Now;
            pendingRequest.Pending = true;

            pendingRequestRepository.Create(pendingRequest);
            return Ok();
        }

    }
}
