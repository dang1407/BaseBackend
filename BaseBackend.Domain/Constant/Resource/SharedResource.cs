namespace BaseBackend.Domain
{
    public static class SharedResource
    {
        public readonly static int IsNotDeleteInt = 0;
        public readonly static int IsDeletedInt = 1;
        public readonly static bool IsNotDeleteBool = false;
        public readonly static bool IsDeletedBool = true;
        public readonly static int DefaultPageSize = 20;
        public readonly static int FirstVersion = 1;
        #region Error Message
        public readonly static string ItemNotFoundMessage = "Không tìm thấy thông tin trong hệ thống";
        public readonly static string ItemHasBeenChanged = "Dữ liệu đã bị thay đổi. Vui lòng tải lại trang!";
        public readonly static string InsertErrorMessage = "Lỗi khi thêm mới bản ghi";
        public readonly static string ExecuteErrorMessage = "Lỗi thi thực hiện thao tác";
        public readonly static string LoginFailed = "Đăng nhập không thành công";
        public readonly static string InputDataInvalid = "Dữ liệu đầu vào không hợp lệ";
        #endregion
    }
}
