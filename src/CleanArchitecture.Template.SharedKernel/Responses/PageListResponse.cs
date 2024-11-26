namespace CleanArchitecture.Template.SharedKernel.Responses
{
    public class PageListResponse<TListItemResponse> where TListItemResponse : class
    {
        public IEnumerable<TListItemResponse> Elements { get; set; } = Enumerable.Empty<TListItemResponse>();
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageListResponse(IEnumerable<TListItemResponse> elements, int? page, int? pageSize, int totalCount)
        {
            Elements = elements;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
