using Domain.Enums;
using Domain.Resources;
using Newtonsoft.Json;

namespace Application.Common
{
    public class QueryFilterResponse
    {
        public static QueryFilter Response(string? queryFilter)
        {
            var newQueryFilter = new QueryFilter();
            if (queryFilter != null)
            {
                if (queryFilter.Contains("true"))
                    queryFilter = queryFilter.Replace("true", "1");
                if (queryFilter.Contains("false"))
                    queryFilter = queryFilter.Replace("false", "0");
                var result=JsonConvert.DeserializeObject<QueryFilter>(queryFilter);
                if (result != null)
                    return result;
            }

            return newQueryFilter;
        }
    }
}
