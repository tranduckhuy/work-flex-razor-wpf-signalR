namespace WorkFlex.Domain
{
    public class Pageable<T> where T : class
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int TotalPages { get; private set; }
        public T? SearchCriteria { get; set; }

        public Pageable()
        {
        }

        public Pageable(int totalItems, int page, int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);

            if (page > TotalPages)
            {
                CurrentPage = TotalPages > 0 ? TotalPages : 1;
            }
            else
            {
                CurrentPage = page;
            }

            StartPage = CurrentPage > 3 ? CurrentPage - 3 : 1;
            EndPage = TotalPages - 3 > CurrentPage ? CurrentPage + 3 : TotalPages;
        }
    }
}