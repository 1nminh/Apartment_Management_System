using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System.Web.Http;

namespace API.Controllers
{
    public class ApartmentController : ApiController
    {
        private readonly IRepository<Apartment> apartmentRepository;

        public ApartmentController()
        {
            this.apartmentRepository = new Repository<Apartment>();
        }

        // GET: GetAllApartment
        [HttpGet]
        public IHttpActionResult GetAllAparmentList()
        {
            var result = apartmentRepository.GetAll();
            return Ok(result);
        }
    }
}
