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
    public class ServiceController : ApiController
    {
        private readonly IRepository<Service> serviceRepository;

        public ServiceController()
        {
            this.serviceRepository = new Repository<Service>();
        }

        // GET: GetListRoomAndUser
        [HttpGet]
        public IHttpActionResult GetAllServiceList()
        {
            var result = serviceRepository.GetAll();
            return Ok(result);
        }
    }
}
