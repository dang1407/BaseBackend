namespace BaseBackend.Domain
{
    public static class SharedResource
    {
        public const int IsNotDeleteInt = 0;
        public const int IsDeletedInt = 1;
        public const bool IsNotDeleteBool = false;
        public const bool IsDeletedBool = true;
        public const int DefaultPageSize = 20;
        public const int FirstVersion = 1;
        public const int GlobalConfig = 9999;
        #region Error Message
        public const string ItemNotFoundMessage = "Không tìm thấy thông tin trong hệ thống";
        public const string ItemHasBeenChanged = "Dữ liệu đã bị thay đổi. Vui lòng tải lại trang!";
        public const string InsertErrorMessage = "Lỗi khi thêm mới bản ghi";
        public const string ExecuteErrorMessage = "Lỗi thi thực hiện thao tác";
        public const string LoginFailed = "Đăng nhập không thành công";
        public const string InputDataInvalid = "Dữ liệu đầu vào không hợp lệ";
        #endregion

        public class Status
        {
            public const int Active = 1;
            public const int UnActive = 2;
        }
    }
}
