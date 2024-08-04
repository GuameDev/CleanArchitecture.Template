namespace CleanArchitecture.Template.Application.Base.PageList
{
    public class PageListRequest<TOrderBy> where TOrderBy : struct
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public bool IsPaginated { get => this.Page is not null && this.PageSize is not null; }
        public TOrderBy? OrderBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Descending;

    }
}
