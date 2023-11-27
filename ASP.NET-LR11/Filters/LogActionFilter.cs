using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly string filePath;

        public LogActionFilter(string filePath)
        {
            this.filePath = filePath;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string uniqueId = context.HttpContext.Connection.Id.ToString();

            string logMessage = $"Event called by {uniqueId} '{actionName}' at {timestamp}";
            try
            {
                File.AppendAllText(filePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
