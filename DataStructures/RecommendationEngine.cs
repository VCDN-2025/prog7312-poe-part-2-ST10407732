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
        private int totalSearchCount = 0;

        private Dictionary<string, int> textSearchCount = new Dictionary<string, int>();


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
        public List<Event> GetRecommendedEvents(List<Event> allEvents, int maxRecommendations = 3)
        {
            List<Event> recommended = new List<Event>();

            // If no searches, return empty list
            if (categorySearchCount.Count == 0 && dateSearchCount.Count == 0)
                return recommended;

            // Combine category + date searches
            var searchedCategories = categorySearchCount.Keys.ToList();
            var searchedDates = dateSearchCount.Keys.ToList();

            // Only events that match both searched categories AND dates
            var matchingEvents = allEvents
                .Where(e => searchedCategories.Contains(e.Category) &&
                            searchedDates.Any(d => e.Date.Date == d.Date))
                .OrderByDescending(e => e.Priority)
                .ThenBy(e => e.Date)
                .Take(maxRecommendations)
                .ToList();

            recommended.AddRange(matchingEvents);

            return recommended;
        }




        // Return search statistics
        public string GetSearchStatistics()
        {
            var stats = "🔍 Search Statistics:\n\n";

            if (categorySearchCount.Count > 0)
            {
                stats += "Top Categories:\n";
                foreach (var kv in categorySearchCount.OrderByDescending(kv => kv.Value))
                    stats += $"• {kv.Key}: {kv.Value} searches\n";
                stats += "\n";
            }

            if (dateSearchCount.Count > 0)
            {
                stats += "Top Dates:\n";
                foreach (var kv in dateSearchCount.OrderByDescending(kv => kv.Value))
                    stats += $"• {kv.Key:dd MMM yyyy}: {kv.Value} searches\n";
                stats += "\n";
            }

            if (categorySearchCount.Count == 0 && dateSearchCount.Count == 0)
            {
                stats = "🔍 No search history yet.\n\n";
                stats += "Showing trending upcoming events based on priority!";
            }
            else
            {
                int totalSearches = categorySearchCount.Values.Sum() + dateSearchCount.Values.Sum();
                stats += $"📊 Total Searches: {totalSearches}";
            }

            return stats;
        }


        // Helper method to check if user has search history
        public int GetTotalSearchCount()
        {
            return categorySearchCount.Values.Sum() + dateSearchCount.Values.Sum();
        }
    }
}

