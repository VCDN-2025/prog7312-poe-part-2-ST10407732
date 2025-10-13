using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // Simple priority queue using a List and sorting by Event.Priority
    public class CustomPriorityQueue<T> where T : MunicipalServicesApp.Models.Event
    {
        private List<T> _items;

        public CustomPriorityQueue()
        {
            _items = new List<T>();
        }

        public void Enqueue(T item)
        {
            _items.Add(item);
            // Sort descending so highest priority comes first
            _items.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        public T Dequeue()
        {
            if (_items.Count == 0) throw new InvalidOperationException("Queue is empty");
            T item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0) throw new InvalidOperationException("Queue is empty");
            return _items[0];
        }

        public int Count => _items.Count;

        public List<T> GetAllItems()
        {
            return new List<T>(_items);
        }
    }
}
