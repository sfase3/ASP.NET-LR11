using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11.Filters
{
    public class UniqueUsersFilter : IAuthorizationFilter
    {
        private readonly string filePath;
        private HashSet<string> uniqueIds = new HashSet<string>();

        public UniqueUsersFilter(string filePath)
        {
            this.filePath = filePath;

            try
            {
                if (File.Exists(this.filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        uniqueIds.Add(line.Replace("userId: ", ""));
                    }
                }
                else
                {
                    File.Create(this.filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string uniqueId = context.HttpContext.Connection.Id.ToString();

            if (!uniqueIds.Contains(uniqueId))
            {
                uniqueIds.Add(uniqueId);
                File.AppendAllText(filePath, $"Unique Id: {uniqueId}" + Environment.NewLine);
            }
        }
    }
}
