using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;

namespace CleanArchitecture.Template.SharedKernel.Requests
{
    /// <summary>
    /// By default IsPaginated is true
    /// </summary>
    /// <typeparam name="TOrderBy"></typeparam>
    public class PageListRequest<TOrderBy> where TOrderBy : struct
    {
        public int? Page { get; set; } = PageListConstants.DefaultPage;
        public int? PageSize { get; set; } = PageListConstants.DefaultPageSize;
        public bool IsPaginated { get; set; } = PageListConstants.DefaultIsPaginated;
        public SortDirection SortDirection { get; set; } = PageListConstants.DefaultSortDirection;
        public TOrderBy? OrderBy { get; set; }

    }
}
