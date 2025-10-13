using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class CustomSortedDictionary<TKey, TValue> where TKey : System.IComparable
    {
        private SortedDictionary<TKey, TValue> _dict = new SortedDictionary<TKey, TValue>();

        public void Add(TKey key, TValue value) => _dict[key] = value;

        public TValue Get(TKey key) => _dict.ContainsKey(key) ? _dict[key] : default(TValue);

        public List<TValue> GetAllValues() => new List<TValue>(_dict.Values);
    }
}
