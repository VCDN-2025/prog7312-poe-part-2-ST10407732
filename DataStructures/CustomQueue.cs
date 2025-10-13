using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class CustomQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();

        public void Enqueue(T item) => _queue.Enqueue(item);

        public T Dequeue() => _queue.Dequeue();

        public int Count => _queue.Count;

        public List<T> GetAllItems() => new List<T>(_queue);
    }
}
