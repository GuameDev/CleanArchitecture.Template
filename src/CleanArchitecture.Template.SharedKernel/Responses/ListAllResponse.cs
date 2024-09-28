namespace CleanArchitecture.Template.SharedKernel.Responses
{
    public class ListAllResponse<TListItemResponse> where TListItemResponse : class
    {
        public int TotalCount { get; set; }
        public IEnumerable<TListItemResponse> Elements { get; set; } = Enumerable.Empty<TListItemResponse>();
    }
}
