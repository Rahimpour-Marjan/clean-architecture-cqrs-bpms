using Api;
using Application.Services;

namespace Application.Helpers
{
    internal class PaginationHelper
    {
        public static PagedResponse CreatePagedResponse(object pagedData, int? pageNumber, int? pageSize, int totalRecords, IUriService uriService, string route, string[] errors)
        {
            int pagenumber = 1;
            int pagesize = 1;

            if (pageNumber != null)
                pagenumber = pageNumber ?? 1;
            if (pageSize != null)
                pagesize = pageSize ?? 10;
            var respose = new PagedResponse(pagedData, pagenumber, pagesize, errors);
            var totalPages = ((double)totalRecords / (double)pagesize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                pagenumber >= 1 && pagenumber < roundedTotalPages
                ? uriService.GetPageUri(pagenumber + 1, pagesize, route)
                : null;
            respose.PreviousPage =
                pagenumber - 1 >= 1 && pagenumber <= roundedTotalPages
                ? uriService.GetPageUri(pagenumber - 1, pagesize, route)
                : null;
            respose.FirstPage = uriService.GetPageUri(1, pagesize, route);
            respose.LastPage = uriService.GetPageUri(roundedTotalPages, pagesize, route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
