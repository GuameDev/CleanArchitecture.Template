using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;

namespace CleanArchitecture.Template.SharedKernel.Requests
{
    public class PageListRequest<TOrderBy> where TOrderBy : struct
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public bool IsPaginated { get; set; }
        public TOrderBy? OrderBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Descending;

    }
}
