using System;

namespace MunicipalServicesApp.Models
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateReported { get; set; } = DateTime.Now;
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        // Store attachments as an array (no List<T>)
        public string[] AttachedFiles { get; set; } = new string[0];

        // Track the user who submitted the issue
        public string UserId { get; set; } = "defaultUser"; // Default since we have no login
    }
}
