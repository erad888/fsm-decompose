using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicUtils
{
    /// <summary>
    /// Класс двунаправленного ассоциатора (словаря).
    /// </summary>
    public class BidirectionalDictionary<T, U>:IEnumerable<KeyValuePair<T,U>>
    {

        #region Поля

        private static int DefaultDictionarySize = 10;
        protected Dictionary<T, U> left_dictionary;
        protected Dictionary<U, T> right_dictionary;

        #endregion

        #region Конструкторы

        /// <summary>
        /// дефолтовый конструктор
        /// </summary>
        public BidirectionalDictionary() : this(DefaultDictionarySize) { }

        /// <summary>
        /// конструктор с указанием начального размера словаря
        /// </summary>
        /// <param name="DictionarySize">начальный размер словаря</param>
        public BidirectionalDictionary(int DictionarySize)
        {
            if (DictionarySize <= 0) DictionarySize = DefaultDictionarySize;
            left_dictionary = new Dictionary<T, U>(DictionarySize);
            right_dictionary = new Dictionary<U, T>(DictionarySize);
        }

        #endregion

        #region Свойства

        public IEnumerable<T> First
        {
            get { return left_dictionary.Keys.ToArray(); }
        }
        public IEnumerable<U> Second
        {
            get { return right_dictionary.Keys.ToArray(); }
        }

        /// <summary>
        /// получить прямую закладку словаря
        /// </summary>
        /// <param name="Key">ключ закладки</param>
        /// <returns>данные по закладке</returns>
        //public U this[T Key] { get { return left_dictionary[Key]; } }

        /// <summary>
        /// получить обратную закладку словаря
        /// </summary>
        /// <param name="Key">ключ закладки</param>
        /// <returns>данные по закладке</returns>
        //public T this[U Key] { get { return right_dictionary[Key]; } }

        #endregion

        #region Методы

        public U GetSecond(T key)
        {
            return left_dictionary[key];
        }
        public T GetFirst(U key)
        {
            return right_dictionary[key];
        }

        /// <summary>
        /// очистить словарь
        /// </summary>
        public void Clear()
        {
            left_dictionary.Clear();
            right_dictionary.Clear();
        }

        /// <summary>
        /// проверить существование первого ключа
        /// </summary>
        /// <param name="Key">ключ</param>
        /// <returns>true, если есть</returns>
        public bool ExistsFirst(T Key) { return left_dictionary.ContainsKey(Key); }

        /// <summary>
        /// проверить существование второго ключа
        /// </summary>
        /// <param name="Key">ключ</param>
        /// <returns>true, если есть</returns>
        public bool ExistsSecond(U Key) { return right_dictionary.ContainsKey(Key); }

        /// <summary>
        /// добавить ассоциацию
        /// </summary>
        /// <param name="Key1"></param>
        /// <param name="Key2"></param>
        public void AddAssociation(T Key1, U Key2)
        {
            left_dictionary.Add(Key1, Key2);
            right_dictionary.Add(Key2, Key1);
        }

        /// <summary>
        /// удалить ассоциацию
        /// </summary>
        /// <param name="Key">ключ первого типа</param>
        //public void RemoveAssociation(T Key1)
        //{
        //    if (this[Key1] == null) return;
        //    right_dictionary.Remove(this[Key1]);
        //    left_dictionary.Remove(Key1);
        //}

        public void RemoveAssociationFirst(T Key)
        {
            if (GetSecond(Key) == null) return;
            right_dictionary.Remove(GetSecond(Key));
            left_dictionary.Remove(Key);
        }

        /// <summary>
        /// удалить ассоциацию
        /// </summary>
        /// <param name="Key">ключ второго типа</param>
        //public void RemoveAssociation(U Key2) { if (this[Key2] != null) RemoveAssociation(this[Key2]); }
        public void RemoveAssociationSecond(U Key) { if (GetFirst(Key) != null) RemoveAssociationFirst(GetFirst(Key)); }

        /// <summary>
        /// оставить в ловарях только те ассоциации, ключи которых присутствуют в переданной коллекции
        /// </summary>
        /// <param name="Collection">коллекция "живых" ключей</param>
        public void StayAliveFirst(IEnumerable<T> Collection)
        {
            var v = Collection.Where(ExistsFirst).Select(ii => new KeyValuePair<T, U>(ii, GetSecond(ii))).ToArray();
            Clear();
            foreach (var pair in v) AddAssociation(pair.Key, pair.Value);
        }

        /// <summary>
        /// оставить в ловарях только те ассоциации, ключи которых присутствуют в переданной коллекции
        /// </summary>
        /// <param name="Collection">коллекция "живых" ключей</param>
        public void StayAliveSecond(IEnumerable<U> Collection)
        {
            var v = Collection.Where(ExistsSecond).Select(ii => new KeyValuePair<T, U>(GetFirst(ii), ii)).ToArray();
            Clear();
            foreach (var pair in v) AddAssociation(pair.Key, pair.Value);
        }

        #endregion


        #region IEnumerable<KeyValuePair<T,U>> Members

        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            return left_dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return left_dictionary.GetEnumerator();
        }

        #endregion
    }
}
