namespace CleanArchitecture.Template.Application.Base.PageList
{
    public class PageListRequest<TOrderBy> where TOrderBy : struct
    {
        public required int Page { get; set; }
        public required int PageSize { get; set; }
        public TOrderBy? OrderBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;

    }
}
