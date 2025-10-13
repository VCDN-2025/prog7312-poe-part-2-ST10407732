using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    public class RecommendationEngine
    {
        private Dictionary<string, int> categorySearchCount = new Dictionary<string, int>();
        private Dictionary<DateTime, int> dateSearchCount = new Dictionary<DateTime, int>();

        // Track category searches
        public void TrackCategorySearch(string category)
        {
            if (string.IsNullOrEmpty(category)) return;

            if (!categorySearchCount.ContainsKey(category))
                categorySearchCount[category] = 0;
            categorySearchCount[category]++;
        }

        // Track date searches
        public void TrackDateSearch(DateTime date)
        {
            if (!dateSearchCount.ContainsKey(date))
                dateSearchCount[date] = 0;
            dateSearchCount[date]++;
        }

        // Recommend events based on search history
        public List<Event> GetRecommendedEvents(List<Event> allEvents, int maxRecommendations = 5)
        {
            List<Event> recommended = new List<Event>();

            // Top searched categories
            var topCategories = categorySearchCount
                .OrderByDescending(kv => kv.Value)
                .Select(kv => kv.Key)
                .ToList();

            // Top searched dates
            var topDates = dateSearchCount
                .OrderByDescending(kv => kv.Value)
                .Select(kv => kv.Key)
                .ToList();

            // Recommend events from top categories first
            foreach (var cat in topCategories)
            {
                recommended.AddRange(allEvents.Where(e => e.Category == cat && !recommended.Contains(e)));
            }

            // Then recommend events on top dates
            foreach (var date in topDates)
            {
                recommended.AddRange(allEvents.Where(e => e.Date.Date == date.Date && !recommended.Contains(e)));
            }

            // Fill remaining slots randomly if needed
            foreach (var evt in allEvents)
            {
                if (recommended.Count >= maxRecommendations) break;
                if (!recommended.Contains(evt))
                    recommended.Add(evt);
            }

            return recommended.Take(maxRecommendations).ToList();
        }

        // Return search statistics
        public string GetSearchStatistics()
        {
            var stats = "🔍 Search Statistics:\n";

            if (categorySearchCount.Count > 0)
            {
                stats += "Top Categories:\n";
                foreach (var kv in categorySearchCount.OrderByDescending(kv => kv.Value))
                    stats += $"• {kv.Key}: {kv.Value} searches\n";
            }

            if (dateSearchCount.Count > 0)
            {
                stats += "Top Dates:\n";
                foreach (var kv in dateSearchCount.OrderByDescending(kv => kv.Value))
                    stats += $"• {kv.Key:dd MMM yyyy}: {kv.Value} searches\n";
            }

            if (categorySearchCount.Count == 0 && dateSearchCount.Count == 0)
                stats += "No searches performed yet.";

            return stats;
        }
    }
}
