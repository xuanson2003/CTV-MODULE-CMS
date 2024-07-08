using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using OcdServiceMono.Lib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcdServiceMono.API.Infrastructure.Middleware
{
    public class FillterTenantMiddleware
    {
        private readonly RequestDelegate _next;

        public FillterTenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {           
            var path = httpContext.Request.Path;
            if(path.HasValue && (path.Value.Contains("Cat") || path.Value.Contains("Fsm")) && path.Value.Contains("get-items"))
            {
                string[] splitPath = path.Value.Split("/");
                if(splitPath.Length == 4)//base action get-items
                {
                    var queryitems = httpContext.Request.Query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
                    List<KeyValuePair<string, string>> queryparameters = new List<KeyValuePair<string, string>>();
                    foreach (var item in queryitems)
                    {
                        var key = item.Key;
                        var value = item.Value;
                        if (key == "searchBy")
                        {
                            string fillterTenant = "TenantCode=\"{TenantCode}\"";
                            value = string.IsNullOrEmpty(value) ? fillterTenant : fillterTenant + " && " + value;
                        }
                        KeyValuePair<string, string> newqueryparameter = new KeyValuePair<string, string>(key, value);
                        queryparameters.Add(newqueryparameter);
                    }
                    httpContext.Request.QueryString = new QueryBuilder(queryparameters).ToQueryString();
                }
            }
            await _next(httpContext);
        }
    }
}
