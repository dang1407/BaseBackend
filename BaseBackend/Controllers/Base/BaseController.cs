using BaseBackend.Application;
using BaseBackend.Controllers.Base;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BaseBackend.Application;
using BaseBackend.Controllers.Base;
using BaseBackend.Domain;

namespace BaseBackend.Controllers
{

    public class BaseController<TDTO, TCreateDTO, TUpdateDTO> : BaseReadOnlyController<TDTO>
    {
        protected readonly IBaseService<TDTO, TCreateDTO, TUpdateDTO> BaseService;
        public BaseController(IBaseService<TDTO, TCreateDTO, TUpdateDTO> baseService) : base(baseService)
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
        public async Task<IActionResult> InsertAsync([FromBody] TCreateDTO createDTO)
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

            var result = await BaseService.InsertAsync(createDTO);
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
        public async Task<TDTO> UpdateAsync(Guid id, [FromBody] TUpdateDTO updateDTO)
        {
            var result = await BaseService.UpdateAsync(id, updateDTO);
            return result;
        }


        /// <summary>
        /// Hàm xóa thông tin một TDTO
        /// </summary>
        /// <param name="id">Định danh TDTO</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await BaseService.DeleteAsync(id);
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
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids)
        {
            var result = await BaseService.DeleteManyAsync(ids);
            var response = new
            {
                Success = $"Xóa thành công {result} bản ghi!",
                Error = $"Xóa thất bại {ids.Count - result} bản ghi!"
            };
            return StatusCode(200, response);
        }
    }
}
