using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.Serialization;
using ICollection=System.Collections.ICollection;
using IDictionary=System.Collections.IDictionary;

namespace LogicUtils
{
    public class EventableDictionary<TKey, TValue>
        :
        ISerializable,
        IDeserializationCallback,
        IEnumerable<KeyValuePair<TKey, TValue>>
        //IDictionary<TKey, TValue>
        //ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, 
        //IDictionary, ICollection, IEnumerable, ISerializable, IDeserializationCallback
        where TKey : class
    {
        #region Constructors

        public EventableDictionary()
        {
            items = new Dictionary<TKey, TValue>();
        }

        public EventableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            items = new Dictionary<TKey, TValue>(dictionary);
        }

        public EventableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            items = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        public EventableDictionary(IEqualityComparer<TKey> comparer)
        {
            items = new Dictionary<TKey, TValue>(comparer);
        }

        public EventableDictionary(int capacity)
        {
            items = new Dictionary<TKey, TValue>(capacity);
        }

        public EventableDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            items = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        #endregion

        #region Properties
        public System.Collections.Generic.IEqualityComparer<TKey> Comparer
        {
            get { return items.Comparer; }
        }
        public int Count
        {
            get { return items.Count; }
        }
        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get { return items.Keys; }
        }
        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get { return items.Values; }
        }

        public TValue this[TKey key]
        {
            get { return items[key]; }
            set { items[key] = value; }
        }
        #endregion

        #region Fields
        Dictionary<TKey, TValue> items = null;
        #endregion

        #region Events

        public EventHandler<ItemEventArgs<KeyValuePair<TKey, TValue>>> ItemAdded;
        private void InvokeItemAdded(KeyValuePair<TKey, TValue> item)
        {
            if (ItemAdded != null)
                ItemAdded(this, new ItemEventArgs<KeyValuePair<TKey, TValue>>(item));
        }

        public EventHandler<ItemEventArgs<KeyValuePair<TKey, TValue>>> ItemRemoved;
        private void InvokeItemRemoved(KeyValuePair<TKey, TValue> item)
        {
            if (ItemRemoved != null)
                ItemRemoved(this, new ItemEventArgs<KeyValuePair<TKey, TValue>>(item));
        }

        #endregion

        #region Methods
        private KeyValuePair<TKey, TValue> GetPair(TKey key)
        {
            return items.FirstOrDefault(p => p.Key == key);
        }

        public bool TryAdd(TKey key, ref TValue value)
        {
            if (ContainsKey(key))
            {
                value = items[key];
                return false;
            }
            Add(key, value);
            return true;
        }

        public void Add(TKey key, TValue value)
        {
            items.Add(key, value);
            InvokeItemAdded(GetPair(key));
        }
        public bool Remove(TKey key)
        {
            var pair = GetPair(key);
            return Remove(pair);
        }
        private bool Remove(KeyValuePair<TKey, TValue> pair)
        {
            bool result = items.Remove(pair.Key);
            if (result)
                InvokeItemAdded(pair);
            return result;
        }

        public void Clear()
        {
            while (items.Count != 0)
            {
                Remove(items.First());
            }
        }

        public bool ContainsKey(TKey key)
        {
            return items.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return items.ContainsValue(value);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        //public IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return items.GetEnumerator();
        //}

        public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            items.GetObjectData(info, context);
        }

        public virtual void OnDeserialization(object sender)
        {
            OnDeserialization(sender);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return items.TryGetValue(key, out value);
        }

        #endregion
    }

    public class ItemEventArgs<TItem> : EventArgs
    {
        public ItemEventArgs(TItem item)
        {
            Item = item;
        }
        public TItem Item { get; private set; }
    }
}