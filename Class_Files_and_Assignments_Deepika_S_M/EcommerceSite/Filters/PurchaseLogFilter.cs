using Microsoft.AspNetCore.Mvc.Filters;

public class PurchaseLogFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var username = context.HttpContext.Session.GetString("Username") ?? "Guest";
        File.AppendAllText("Logs/purchase_log.txt", $"User {username} made a purchase at {DateTime.Now}\n");
    }
}
