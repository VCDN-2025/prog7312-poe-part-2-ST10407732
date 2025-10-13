namespace MunicipalServicesApp.Models
{
    // Represents a single node in the linked list of issues
    public class IssueNode
    {
        // The actual issue data stored in this node
        public Issue Data { get; set; }

        // Reference to the next node in the linked list
        public IssueNode Next { get; set; }

        /// <summary>
        /// Constructor to create a new IssueNode with the given Issue.
        /// </summary>
        /// <param name="data">The Issue object to store in this node.</param>
        public IssueNode(Issue data)
        {
            Data = data;    // Assign the issue data
            Next = null;    // Initially, the next node is null
        }
    }
}
