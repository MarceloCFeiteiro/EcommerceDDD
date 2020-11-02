using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Linq;

namespace Web_ECommerce.Controllers
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            Log("OnActionExecuting", actionExecutingContext.RouteData, actionExecutingContext);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            Log("OnActionExecuted", actionExecutedContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext resultExecutingContext)
        {
            Log("OnResultExecuting", resultExecutingContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext resultExecutedContext)
        {
            Log("OnResultExecuted", resultExecutedContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData, ActionExecutingContext actionExecutingContext = null)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);

            if (actionExecutingContext != null && actionExecutingContext.ActionArguments.Any())
            {
                var teste = JsonConvert.SerializeObject(actionExecutingContext.ActionArguments);
            }
        }
    }
}