using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Constant
{
    public static class SharedResource
    {
        public readonly static int IsNotDelete = 0;
        public readonly static int IsDeleted = 1;
        public readonly static int DefaultPageSize = 20;

        public readonly static string ItemNotFoundMessage = "Không tìm thấy tài nguyên";
        public readonly static string ItemHasBeenChanged = "Dữ liệu đã bị thay đổi. Vui lòng tải lại trang!";
    }
}
