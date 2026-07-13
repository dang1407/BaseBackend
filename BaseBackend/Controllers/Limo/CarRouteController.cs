using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Limo
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarRouteController : BaseController
    {
        private readonly ICarRouteService _carRouteService;
        public CarRouteController(ICarRouteService carRouteService)
        {
            _carRouteService = carRouteService;
        }
        [HttpPost]
        public async Task<CarRouteDTO> Post(CarRouteDTO request)
        {
            CarRouteDTO dtoResponse = new CarRouteDTO();
            switch (this.ActionCode)
            {
                case ApiActionCode.SearchData:
                    dtoResponse.CarRoutes = await _carRouteService.GetPagingAsync(request.Filter, request.PagingInfo);
                    dtoResponse.PagingInfo = request.PagingInfo;
                    break;
                case ApiActionCode.AddNewItem:
                    dtoResponse.CarRoute = await _carRouteService.InsertItemAsync(request.CarRoute);
                    break;
                case ApiActionCode.UpdateItem:
                    await _carRouteService.UpdateItemAsync(request.CarRoute);
                    break;
                case ApiActionCode.DeleteItem:
                    await _carRouteService.DeleteItemAsync(request.CarRouteID.Value);
                    break;
                default:
                    throw new NotImplementedException(this.ActionCode);
            }
            return dtoResponse;
        }
        public class ApiActionCode : BaseApiActionCode
        {
        }
        public class CarRouteDTO : BaseDTO
        {
            public List<CarRoute>? CarRoutes { get; set; }
            public CarRoute? CarRoute { get; set; }
            public int? CarRouteID { get; set; }
            public CarRouteFilter? Filter { get; set; }
        }
    }


}
