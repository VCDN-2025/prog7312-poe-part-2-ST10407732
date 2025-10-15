using System;

namespace MunicipalServicesApp.Models
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateReported { get; set; } = DateTime.Now;

        // Location broken into fields
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }

        // Category and description
        public string Category { get; set; }
        public string Description { get; set; }

        // Attachments as array
        public string[] AttachedFiles { get; set; } = new string[0];

        // User info
        public string UserId { get; set; } = "defaultUser";

        // Convenience property to get full location
        public string FullLocation => $"{Province}, {City}, {Area}";
    }
}
