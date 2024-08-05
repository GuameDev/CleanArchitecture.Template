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
        public int? Page { get; set; } = PageListConstants.PageDefault;
        public int? PageSize { get; set; } = PageListConstants.PageSizeDefault;
        public bool IsPaginated { get; set; } = PageListConstants.IsPaginatedDefault;
        public TOrderBy? OrderBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Descending;

    }
}
