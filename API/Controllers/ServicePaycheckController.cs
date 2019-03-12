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
    public class ServicePaycheckController : ApiController
    {
        private readonly IRepository<ServicePaycheck> servicePaycheckRepository;

        public ServicePaycheckController()
        {
            this.servicePaycheckRepository = new Repository<ServicePaycheck>();
        }

        // GET: GetListRoomAndUser
        [HttpGet]
        public IHttpActionResult GetAllUserService(string username, bool paid)
        {
            var result = servicePaycheckRepository.GetAll(x => x.Username.Equals(username) && x.Paid == paid, y => y.Service);
            return Ok(result);
        }

        //[HttpPost]
        //public IHttpActionResult EditServicePaycheck(ServicePaycheck servicePaycheck)
        //{
        //    servicePaycheckRepository.Update(servicePaycheck);
        //    return Ok();
        //}

        [HttpPost]
        public IHttpActionResult PayServicePaycheck(ServicePaycheck servicePaycheck)
        {
            servicePaycheck.DateOfPayment = DateTime.Now;
            servicePaycheck.Paid = true;
            servicePaycheckRepository.Update(servicePaycheck);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult PayServicePaychecks(List<ServicePaycheck> servicePaychecks)
        {
            foreach(var item in servicePaychecks)
            {
                item.Paid = true;
                servicePaycheckRepository.Update(item);
            }
            
            return Ok();
        }
    }
}