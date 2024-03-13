using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentController = context.RouteData.Values["controller"];
            var currentAction = context.RouteData.Values["action"];

            // parametre olarak Command gönderilmişmi Kontrol edelim ? 
            var param = context.ActionArguments.SingleOrDefault(p => p.Value.ToString().Contains("Command")).Value;
            if(param is null)
            {
                // Parametre olarak gönderilen Command Objesi null ise;
                context.Result = new BadRequestObjectResult($"Object is null." + $"Controller : {currentController} " + $"Action :  {currentAction}");
                return;  // StatusCode 400 BadRequest 
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState); //StatusCode 422 Desteklenmeyen İçerik


        }
    }
}
