using System.Linq.Dynamic.Core;
using Domain;
using Domain.Enums;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;

namespace Infrastructure.Persistance.Extensions
{
    public static class IQueryableExtensions
    {
        //Search and filter for all tbls
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, QueryFilter? queryFilter)
        {
            try
            {
                if (queryFilter != null)
                {
                    if (queryFilter.QueryFilterItem != null && queryFilter.QueryFilterItem.Any())
                    {
                        var expression = "x=>";
                        var args = new Dictionary<string, object>();
                        int i = 0;

                        foreach (var item in queryFilter.QueryFilterItem)
                        {
                            i += 1;
                            if (item.ColumnName != null)
                            {
                                var columnName = "";
                                var columnType = "";
                                var searchText = "";

                                var propertyWithId = typeof(T).GetProperty(item.ColumnName + "Id");
                                var propertyWithoutId = typeof(T).GetProperty(item.ColumnName);

                                // Search by Column Text
                                if (item.SearchText != null)
                                {
                                    if (item.ColumnName == "Posts" && query.ElementType.Name == nameof(Person))
                                    {
                                        expression = expression + "x.PersonJuncPosts.Any(p=>p.Post.Title.Contains(\"" + item.SearchText + "\"))";
                                    }
                                    else if (item.ColumnName == "Post" && query.ElementType.Name == nameof(UserGroup))
                                    {
                                        expression = expression + "x.PostJuncUserGroups.Any(p=>p.Post.Title.Contains(\"" + item.SearchText + "\"))";
                                    }
                                    else
                                    {
                                        if (propertyWithId != null && propertyWithoutId != null)
                                        {
                                            columnName = propertyWithoutId.Name + ".Title";
                                            columnType = propertyWithoutId.PropertyType.ToString();
                                        }
                                        else if (propertyWithId == null && propertyWithoutId != null)
                                        {
                                            columnName = propertyWithoutId.Name;
                                            columnType = propertyWithoutId.PropertyType.ToString();
                                        }
                                        searchText = item.SearchText;
                                        if (columnType.Contains("Int") || columnType.Contains("Decimal") || columnType.Contains("System.Single"))
                                            expression = expression + "x." + columnName + ".ToString().Contains(\"" + searchText + "\") ";
                                        else
                                            expression = expression + "x." + columnName + ".Contains(\"" + searchText + "\") ";
                                    }

                                    if (i != queryFilter.QueryFilterItem.Count || (item.Filter != null && item.Filter.Any()))
                                        expression = expression + " && ";
                                }

                                // Search by Column Filter
                                if (item.Filter != null && item.Filter.Any())
                                {
                                    var arrayName = "";

                                    if (item.ColumnName == "Posts" && query.ElementType.Name == nameof(Person))
                                    {
                                        arrayName = item.ColumnName + "array";
                                        expression = expression + "x.PersonJuncPosts.Any(p=> " + arrayName + ".Contains(p.PostId))";
                                    }
                                    else if (item.ColumnName == nameof(Post) && query.ElementType.Name == nameof(UserGroup))
                                    {
                                        arrayName = item.ColumnName + "array";
                                        expression = expression + "x.PostJuncUserGroups.Any(p=> " + arrayName + ".Contains(p.Post.Id))";
                                    }
                                    else
                                    {
                                        if (propertyWithId != null && propertyWithoutId != null)
                                        {
                                            columnName = propertyWithId.Name;
                                            columnType = propertyWithId.PropertyType.ToString();
                                        }
                                        else if (propertyWithId == null && propertyWithoutId != null)
                                        {
                                            columnName = propertyWithoutId.Name;
                                            columnType = propertyWithoutId.PropertyType.ToString();
                                        }

                                        arrayName = columnName + "array";

                                        if (columnType.Contains("System.Nullable"))
                                        {
                                            if (columnType.Contains("Enum"))
                                                expression = expression + arrayName + ".Contains(x." + columnName + ".Value) ";
                                            else if (columnType.Contains("System.Boolean"))
                                                expression = expression + arrayName + ".Contains(x." + columnName + "?? false) ";
                                            else
                                                expression = expression + arrayName + ".Contains(x." + columnName + " ?? 0 ) ";
                                        }
                                        else
                                            expression = expression + arrayName + ".Contains(x." + columnName + ") ";
                                    }

                                    if (i != queryFilter.QueryFilterItem.Count)
                                        expression = expression + " && ";
                                    if (columnType.Contains("System.Boolean"))
                                    {
                                        var boolArray = new List<bool>();
                                        foreach (var fItem in item.Filter)
                                        {
                                            if (fItem == 1)
                                                boolArray.Add(true);
                                            if (fItem == 0)
                                                boolArray.Add(false);
                                        }
                                        args.Add(arrayName, boolArray);
                                    }
                                    else if (item.ColumnName == nameof(Gender) && query.ElementType.Name == nameof(Person))
                                    {
                                        var enumArray = item.Filter.Cast<Gender>().ToArray();
                                        args.Add(arrayName, enumArray);
                                    }
                                    else if (item.ColumnName == "Status" && query.ElementType.Name == nameof(Ticket))
                                    {
                                        var enumArray = item.Filter.Cast<TicketStatus>().ToArray();
                                        args.Add(arrayName, enumArray);
                                    }
                                    else
                                    {
                                        args.Add(arrayName, item.Filter);
                                    }


                                }

                                // Search by Column blank value
                                if (item.Blank != null && item.Blank == true)
                                {
                                    if (propertyWithId != null && propertyWithoutId != null)
                                    {
                                        columnName = propertyWithoutId.Name + ".Title";
                                    }
                                    else if (propertyWithId == null && propertyWithoutId != null)
                                    {
                                        columnName = propertyWithoutId.Name;
                                    }

                                    if ((item.Filter != null && item.Filter.Any()) || item.SearchText != null)
                                        expression = expression + " || ";
                                    else if (item.ColumnName == "Posts" && query.ElementType.Name == nameof(Person))
                                        expression = expression + "!x.PersonJuncPosts.Any()";
                                    else
                                        expression = expression + "x." + columnName + " == null";


                                    if (i != queryFilter.QueryFilterItem.Count)
                                        expression = expression + " && ";
                                }

                                if (item.FromDate != null || item.ToDate != null)
                                {
                                    if (item.FromDate != null && item.ToDate != null)
                                    {
                                        expression = expression + "(x." + item.ColumnName + " >= " + item.ColumnName + "From && " + "x." + item.ColumnName + " <= " + item.ColumnName + "To)";
                                        args.Add(item.ColumnName + "From", (item.FromDate ?? DateTime.Now).Date);
                                        args.Add(item.ColumnName + "To", (item.ToDate ?? DateTime.Now).Date.AddDays(1));
                                    }
                                    else if (item.FromDate != null)
                                    {
                                        expression = expression + "(x." + item.ColumnName + " >= " + item.ColumnName + "From)";
                                        args.Add(item.ColumnName + "From", (item.FromDate ?? DateTime.Now).Date);
                                    }
                                    else if (item.ToDate != null)
                                    {
                                        expression = expression + "(x." + item.ColumnName + " <= " + item.ColumnName + "To)";
                                        args.Add(item.ColumnName + "To", (item.ToDate ?? DateTime.Now).Date.AddDays(1));
                                    }
                                    if (i != queryFilter.QueryFilterItem.Count)
                                        expression = expression + " && ";
                                }
                            }

                        }

                        var exp = DynamicExpressionParser.ParseLambda<T, bool>(ParsingConfig.Default, false, expression, new object[] { args });
                        query = query.Where(exp);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, QueryFilter? queryFilter, string type)
        {
            var expression = "x=>";
            var columnName = "";
            if (queryFilter != null)
            {
                if (!string.IsNullOrEmpty(queryFilter.SortBy))
                {
                    if (type == "Query")
                    {
                        var property = typeof(T).GetProperty(queryFilter.SortBy);

                        var propertyWithId = typeof(T).GetProperty(queryFilter.SortBy + "Id");
                        var propertyWithoutId = typeof(T).GetProperty(queryFilter.SortBy + "Title");
                        var propertyColumn = typeof(T).GetProperty(queryFilter.SortBy);

                        if (property != null)
                        {
                            columnName = property.Name;
                        }
                        else if (propertyWithId != null && propertyWithoutId != null)
                        {
                            columnName = propertyWithoutId.Name;
                        }
                        else if (propertyColumn != null)
                        {

                            columnName = propertyColumn.Name;
                        }
                    }
                    else if (type == "Entity")
                    {
                        var propertyWithId = typeof(T).GetProperty(queryFilter.SortBy + "Id");
                        var propertyWithoutId = typeof(T).GetProperty(queryFilter.SortBy);

                        if (propertyWithId != null && propertyWithoutId != null)
                        {
                            columnName = propertyWithoutId.Name + ".Title";
                        }
                        else if (propertyWithId == null && propertyWithoutId != null)
                        {
                            columnName = propertyWithoutId.Name;
                        }
                    }

                    expression = expression + "x." + columnName;

                    var exp = DynamicExpressionParser.ParseLambda<T, object>(ParsingConfig.Default, false, expression, new object[0]);
                    //var func = exp.Compile();

                    if (queryFilter.IsSortAscending)
                        return query.OrderBy(exp);
                    else
                        return query.OrderByDescending(exp);
                }
            }
            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, QueryFilter? queryFilter)
        {
            if (queryFilter != null)
            {
                if (queryFilter.PageSize != null && queryFilter.PageNumber != null)
                {
                    if (queryFilter.PageSize <= 0)
                        queryFilter.PageSize = 10;

                    if (queryFilter.PageNumber <= 0)
                        queryFilter.PageNumber = 1;

                    return query.Skip(((queryFilter.PageNumber ?? 1) - 1) * (queryFilter.PageSize ?? 10)).Take(queryFilter.PageSize ?? 10);
                }
            }

            return query;
        }

        public static DateTime From(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day);
        }

        public static DateTime To(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }

    }
}