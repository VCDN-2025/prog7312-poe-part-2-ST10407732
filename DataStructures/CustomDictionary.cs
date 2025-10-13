using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class CustomDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value) => _dict[key] = value;

        public TValue Get(TKey key) => _dict.ContainsKey(key) ? _dict[key] : default(TValue);

        public List<TValue> GetAllValues() => new List<TValue>(_dict.Values);
    }
}
