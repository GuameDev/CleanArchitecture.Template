namespace CleanArchitecture.Template.SharedKernel.Responses.PageList
{
    public class ListAllResponse<TListItemResponse> where TListItemResponse : class
    {
        public IEnumerable<TListItemResponse> Elements { get; set; } = Enumerable.Empty<TListItemResponse>();
        public int TotalCount { get; set; }
    }
}
