using System;

namespace MunicipalServicesApp.Models
{
    public class Event
    {
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Priority { get; set; } // For priority queue

        public Event(string eventId, string title, string category, DateTime date,
                     string location, string description, string imagePath = "", int priority = 0)
        {
            EventId = eventId;
            Title = title;
            Category = category;
            Date = date;
            Location = location;
            Description = description;
            ImagePath = imagePath;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Title} - {Category} - {Date.ToShortDateString()}";
        }
    }
}
