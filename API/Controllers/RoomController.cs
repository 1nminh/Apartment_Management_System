using API.ViewModels;
using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRepository<Room> roomRepository;

        public RoomController()
        {
            this.roomRepository = new Repository<Room>();
        }

        // GET: GetAllRoom
        [HttpGet]
        public IHttpActionResult GetAllRoom()
        {
            var result = roomRepository.GetAll();
            return Ok(result);
        }

        //GET: GetARoom & user
        [HttpGet]
        public IHttpActionResult GetAllApartmentRoomAndUser(int apartmentID)
        {
            var result = roomRepository.GetAll(x => x.ApartmentID == apartmentID, y => y.Periods);
            var viewModelResult = AutoMapper.Mapper.Map<IQueryable<Room>, List<RoomViewModel>>(result);
            return Ok(viewModelResult);
        }

        //GET: GetARoomDetail
        [HttpGet]
        public IHttpActionResult GetRoomDetail(int roomID)
        {
            var result = roomRepository.Get(x => x.ID == roomID, y => y.Periods, z => z.RoomType);
            return Ok(result);
        }
    }
}
