namespace CleanArchitecture.Template.Application.Base.PageList
{
    public class PageListResponse<TListItemResponse> where TListItemResponse : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TListItemResponse> Elements { get; set; } = Enumerable.Empty<TListItemResponse>();
    }
}
