namespace WMS.Data.RequestFeatures
{
    public abstract class RequestParameters
    {
        // for pagination
        const int maxPageSize = 50;

        public int PageNumber { get; set; } = 1;


        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        // for sorting
        public string OrderBy { get; set; } = null!;

        // for data shaping
        public string Fields { get; set; } = null!;
    }
}
