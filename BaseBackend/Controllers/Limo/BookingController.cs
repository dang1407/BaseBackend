using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Limo
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public BookingDTO Post(BookingDTO request)
        {
            BookingDTO dtoResponse = new BookingDTO();
            switch (this.ActionCode)
            {
                case "":
                    break;
                default: 
                    throw new NotImplementedException(this.ActionCode);
            }
            return dtoResponse;
        }

        public class BookingDTO : BaseDTO
        {

        }
    }
}
