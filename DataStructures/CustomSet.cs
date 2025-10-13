using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class CustomSet<T>
    {
        private HashSet<T> _set = new HashSet<T>();

        public void Add(T item) => _set.Add(item);

        public bool Contains(T item) => _set.Contains(item);

        public List<T> ToList() => new List<T>(_set);
    }
}
