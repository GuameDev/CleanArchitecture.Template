namespace CleanArchitecture.Template.SharedKernel.Responses
{
    public class PageListResponse<TListItemResponse> where TListItemResponse : class
    {
        public IEnumerable<TListItemResponse> Elements { get; set; } = Enumerable.Empty<TListItemResponse>();
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
