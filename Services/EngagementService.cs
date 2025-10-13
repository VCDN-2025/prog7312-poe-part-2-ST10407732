using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    public static class EngagementService
    {
        // Compute engagement percentage based on number of reports
        public static int ComputePercent(IssueLinkedList issues)
        {
            int count = issues.Count();
            if (count == 0) return 0;

            // Example: scale 1 issue = 10%, max 100%
            return count * 10 > 100 ? 100 : count * 10;
        }

        // Return a professional motivational message
        public static string GetMessage(IssueLinkedList issues)
        {
            int count = issues.Count();

            if (count == 0)
                return "No reports yet. Be the first to report and make a difference!";
            else if (count < 5)
                return $"Good start! {count} reports logged. Keep engaging!";
            else if (count < 10)
                return $"Great! {count} issues have been reported. Community is active!";
            else
                return $"Amazing! Over {count} reports logged. Together we improve the city! 🎉";
        }
    }
}
