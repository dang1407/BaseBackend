using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Limo
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarTripController : BaseController
    {
        private readonly ICarTripService _carTripService;

        public CarTripController(ICarTripService car_tripService)
        {
            _carTripService = car_tripService;
        }
        [HttpPost]
        public async Task<CarTripDTO> Post(CarTripDTO request)
        {
            CarTripDTO dtoResponse = new CarTripDTO();
            switch (this.ActionCode)
            {
                case ApiActionCode.SearchData:
                    dtoResponse.CarTrips = await _carTripService.GetPagingAsync(request.Filter, request.PagingInfo);
                    dtoResponse.PagingInfo = request.PagingInfo;
                    break;
                case ApiActionCode.AddNewItem:
                    dtoResponse.CarTrip = await _carTripService.InsertItemAsync(request.CarTrip);
                    break;
                case ApiActionCode.UpdateItem:
                    await _carTripService.UpdateItemAsync(request.CarTrip);
                    break;
                case ApiActionCode.DeleteItem:
                    await _carTripService.DeleteItemAsync(request.CarTripID.Value);
                    break;
                default:
                    throw new NotImplementedException(this.ActionCode);
            }
            return dtoResponse;
        }

        public class ApiActionCode : BaseApiActionCode
        {

        }

        public class CarTripDTO : BaseDTO
        {
            public CarTripFilter? Filter { get; set; }
            public List<CarTrip>? CarTrips { get; set; }
            public CarTrip? CarTrip { get; set; }
            public int? CarTripID { get; set; }
        }
    }
}
