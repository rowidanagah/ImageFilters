namespace ImageFilters.Services.Utilities
{
    public class BaseResponseModel
    {
        public BaseResponseModel()
        {
            ErrorList = new List<ErrorListModel>();
            Message = String.Empty;
        }

        public string Message { get; set; }

        public List<ErrorListModel> ErrorList { get; set; }
    }


    public class ErrorListModel
    {
        public int Id { get; set; }
        public string Message { get; set; }

    }
}