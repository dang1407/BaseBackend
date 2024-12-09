using BaseBackend.Application;
using BaseBackend.Controllers.Base;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaseBackend.Controllers
{

    public class BaseController<TDTO, TFilter> : BaseReadOnlyController<TDTO, TFilter> where TFilter : BaseFilter
    {
        protected readonly IBaseService<TDTO, TFilter> BaseService;
        public BaseController(IBaseService<TDTO, TFilter> baseService, int? pageId) : base(baseService, pageId)
        {
            BaseService = baseService;
        }

        /// <summary>
        /// Hàm thêm mới một Entity
        /// </summary>
        /// <param name="createDTO">DTO tạo mới entity</param>
        /// <returns>Thông tin Entity tạo mới nếu thành công</returns>
        /// Created by: nkmdang (21/09/2023)
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody] TDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                // Danh sách thông tin lỗi cho từng trường
                List<ErrorDetail> errorDetails = new List<ErrorDetail>();

                // Lặp qua các lỗi trong ModelState và lấy tên trường và thông báo lỗi
                foreach (var key in ModelState.Keys)
                {
                    if (ModelState[key].ValidationState == ModelValidationState.Invalid)
                    {
                        var error = new ErrorDetail
                        {
                            FieldName = key,
                            ErrorMessage = ModelState[key].Errors[0].ErrorMessage
                        };
                        errorDetails.Add(error);
                    }
                }

                // Trả về danh sách các trường thông tin bị lỗi cùng với thông báo lỗi
                return BadRequest(new { errors = errorDetails });
            }
            CachedUserInfo cachedUserInfo = Utils.GetUserInforFromRequest(HttpContext);
            dtoResponse.dto = await BaseService.InsertAsync(createDTO, cachedUserInfo);
            return StatusCode(201, dtoResponse);
        }

        [HttpPost]
        [Route("many")]
        public async Task<IActionResult> InsertManyAsync([FromBody] List<TDTO> createDTOs)
        {
            CachedUserInfo cachedUserInfo = Utils.GetUserInforFromRequest(HttpContext);
            var result = await BaseService.InsertManyAsync(createDTOs, cachedUserInfo);
            return StatusCode(201, result);
        }

        /// <summary>
        /// Hàm sửa thông tin một TDTO
        /// </summary>
        /// <param name="updateDTO">Instance của TDTO</param>
        /// <returns>Thông tin của TDTO sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        [HttpPut]
        [Route("{id}")]
        public async Task<int> UpdateAsync(int id, [FromBody] TDTO updateDTO)
        {
            CachedUserInfo cachedUserInfo = Utils.GetUserInforFromRequest(HttpContext);
            return await BaseService.UpdateAsync(id, updateDTO, cachedUserInfo);
        }


        /// <summary>
        /// Hàm xóa thông tin một TDTO
        /// </summary>
        /// <param name="id">Định danh TDTO</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            CachedUserInfo cachedUserInfo = Utils.GetUserInforFromRequest(HttpContext);
            var result = await BaseService.DeleteAsync(id, cachedUserInfo);
            return result;
        }


        /// <summary>
        /// Hàm xóa thông tin nhiều TDTO
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh TDTO</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteManyAsync(List<int> ids)
        {
            CachedUserInfo cachedUserInfo = Utils.GetUserInforFromRequest(HttpContext);
            var result = await BaseService.DeleteManyAsync(ids, cachedUserInfo);
            var response = new
            {
                Success = $"Xóa thành công {result} bản ghi!",
                Error = $"Xóa thất bại {ids.Count - result} bản ghi!"
            };
            return StatusCode(200, response);
        }
    }
}
