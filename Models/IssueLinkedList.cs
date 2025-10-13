using System;

namespace MunicipalServicesApp.Models
{
    // Represents a simple linked list to manage Issue objects
    public class IssueLinkedList
    {
        // Reference to the first node in the list
        private IssueNode head;

        /// <summary>
        /// Adds a new Issue to the end of the linked list.
        /// </summary>
        /// <param name="issue">The Issue object to add.</param>
        public void Add(Issue issue)
        {
            var newNode = new IssueNode(issue); // Create a new node containing the issue

            if (head == null) // If the list is empty, set head to new node
            {
                head = newNode;
            }
            else
            {
                // Traverse to the end of the list
                IssueNode current = head;
                while (current.Next != null)
                    current = current.Next;

                // Append the new node at the end
                current.Next = newNode;
            }
        }

        /// <summary>
        /// Finds an Issue by its unique identifier.
        /// </summary>
        /// <param name="id">The Guid of the Issue to find.</param>
        /// <returns>The Issue if found; otherwise, null.</returns>
        public Issue Find(Guid id)
        {
            IssueNode current = head;
            while (current != null)
            {
                if (current.Data.Id == id) // Check if current node matches the id
                    return current.Data;

                current = current.Next; // Move to next node
            }
            return null; // Not found
        }

        /// <summary>
        /// Removes an Issue from the list by its unique identifier.
        /// </summary>
        /// <param name="id">The Guid of the Issue to remove.</param>
        /// <returns>True if removed; false if not found.</returns>
        public bool Remove(Guid id)
        {
            if (head == null) return false; // Empty list, nothing to remove

            // If the head node is the one to remove
            if (head.Data.Id == id)
            {
                head = head.Next; // Move head to the next node
                return true;
            }

            IssueNode current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Id == id) // Check next node
                {
                    current.Next = current.Next.Next; // Skip over the node to remove
                    return true;
                }
                current = current.Next; // Move to next node
            }

            return false; // Issue not found
        }

        /// <summary>
        /// Converts the linked list into an array of Issue objects.
        /// </summary>
        /// <returns>An array containing all Issue objects in the list.</returns>
        public Issue[] ToArray()
        {
            IssueNode current = head;
            int count = 0;

            // Count the number of nodes
            while (current != null)
            {
                count++;
                current = current.Next;
            }

            Issue[] result = new Issue[count];
            current = head;
            int i = 0;

            // Copy nodes into array
            while (current != null)
            {
                result[i++] = current.Data;
                current = current.Next;
            }

            return result;
        }

        /// <summary>
        /// Counts the number of Issue objects in the list.
        /// </summary>
        /// <returns>The total number of issues.</returns>
        public int Count()
        {
            int count = 0;
            IssueNode current = head;

            while (current != null)
            {
                count++;           // Increment for each node
                current = current.Next; // Move to next node
            }

            return count;
        }
    }
}
