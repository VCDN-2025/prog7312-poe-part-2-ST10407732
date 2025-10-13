using System;
using System.IO;
using System.Xml.Serialization;

namespace MunicipalServicesApp.Models
{
    // Static class to handle storage and retrieval of issues
    public static class IssueStorage
    {
        // Path to the XML file where issues are saved
        private static readonly string DataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports.xml");

        // Folder where media attachments (photos, videos) are stored
        private static readonly string MediaFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Media");

        /// <summary>
        /// Loads all issues from the XML file into a linked list.
        /// </summary>
        /// <returns>An IssueLinkedList containing all saved issues.</returns>
        public static IssueLinkedList Load()
        {
            var list = new IssueLinkedList();

            // If the file does not exist, return an empty list
            if (!File.Exists(DataFile)) return list;

            XmlSerializer serializer = new XmlSerializer(typeof(Issue[]));

            // Open the XML file and deserialize its contents
            using (FileStream fs = new FileStream(DataFile, FileMode.Open))
            {
                var issues = (Issue[])serializer.Deserialize(fs);

                // Add each issue to the linked list
                foreach (var issue in issues)
                    list.Add(issue);
            }

            return list;
        }

        /// <summary>
        /// Saves all issues from a linked list to the XML file.
        /// </summary>
        /// <param name="issues">The linked list of issues to save.</param>
        public static void Save(IssueLinkedList issues)
        {
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(DataFile));

            XmlSerializer serializer = new XmlSerializer(typeof(Issue[]));

            // Serialize the linked list to the XML file
            using (FileStream fs = new FileStream(DataFile, FileMode.Create))
            {
                serializer.Serialize(fs, issues.ToArray());
            }
        }

        /// <summary>
        /// Copies a media file to the application's media folder and renames it uniquely.
        /// </summary>
        /// <param name="sourcePath">The path of the file to copy.</param>
        /// <returns>The destination path of the copied file.</returns>
        public static string CopyMediaFile(string sourcePath)
        {
            // Ensure the media folder exists
            Directory.CreateDirectory(MediaFolder);

            // Get the original file name
            var fileName = Path.GetFileName(sourcePath);

            // Generate a unique file name using a GUID
            var dest = Path.Combine(MediaFolder, $"{Guid.NewGuid():N}_{fileName}");

            // Copy the file to the media folder
            File.Copy(sourcePath, dest, true);

            // Return the new path
            return dest;
        }
    }
}
