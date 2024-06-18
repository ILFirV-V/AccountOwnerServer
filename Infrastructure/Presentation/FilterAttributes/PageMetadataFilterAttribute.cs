using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;

namespace Presentation.FilterAttributes
{
    public class PageMetadataFilterAttribute<T> : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is IPaged<T> pageData)
            {
                var metadata = new
                {
                    pageData.TotalCount,
                    pageData.PageSize,
                    pageData.CurrentPage,
                    pageData.TotalPages,
                    pageData.HasNext,
                    pageData.HasPrevious
                };
                context.HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            }
        }
    }
}
