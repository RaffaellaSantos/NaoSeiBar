namespace NSB_API.data.dtos
{
    public class PaginatedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Items { get; set; } 
    }

    public class PaginationParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int GetSkip()
        {
            return (PageNumber - 1) * PageSize;
        }

        public int GetTake()
        {
            return PageSize;
        }
    }
}
