// NAnt - A .NET build tool
// Copyright (C) 2002-2003 Scott Hernandez
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Ian MacLean (imaclean@gmail.com)

using System;
using System.Collections;

namespace NAnt.Core {
    [Serializable()]
    public sealed class FrameworkInfoDictionary : IDictionary, ICollection, IEnumerable, ICloneable {
        #region Private Instance Fields

        private Hashtable _innerHash;

        #endregion Private Instance Fields
        
        #region Public Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameworkInfoDictionary" /> class.
        /// </summary>
        public FrameworkInfoDictionary() {
            _innerHash = new Hashtable();
        }

        public FrameworkInfoDictionary(FrameworkInfoDictionary original) {
            _innerHash = new Hashtable(original.InnerHash);
        }

        public FrameworkInfoDictionary(IDictionary dictionary) {
            _innerHash = new Hashtable (dictionary);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameworkInfoDictionary" /> class
        /// with the specified capacity.
        /// </summary>
        public FrameworkInfoDictionary(int capacity) {
            _innerHash = new Hashtable(capacity);
        }

        public FrameworkInfoDictionary(IDictionary dictionary, float loadFactor) {
            _innerHash = new Hashtable(dictionary, loadFactor);
        }

        public FrameworkInfoDictionary(IHashCodeProvider codeProvider, IComparer comparer) {
            _innerHash = new Hashtable(codeProvider, comparer);
        }

        public FrameworkInfoDictionary(int capacity, int loadFactor) {
            _innerHash = new Hashtable(capacity, loadFactor);
        }

        public FrameworkInfoDictionary(IDictionary dictionary, IHashCodeProvider codeProvider, IComparer comparer) {
            _innerHash = new Hashtable (dictionary, codeProvider, comparer);
        }
        
        public FrameworkInfoDictionary(int capacity, IHashCodeProvider codeProvider, IComparer comparer) {
            _innerHash = new Hashtable (capacity, codeProvider, comparer);
        }

        public FrameworkInfoDictionary(IDictionary dictionary, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer) {
            _innerHash = new Hashtable (dictionary, loadFactor, codeProvider, comparer);
        }

        public FrameworkInfoDictionary(int capacity, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer) {
            _innerHash = new Hashtable (capacity, loadFactor, codeProvider, comparer);
        }

        #endregion Public Instance Constructors

        #region Internal Instance Properties

        internal Hashtable InnerHash {
            get { return _innerHash; }
            set { _innerHash = value ; }
        }

        #endregion Internal Instance Properties

        #region Implementation of IDictionary

        public FrameworkInfoDictionaryEnumerator GetEnumerator() {
            return new FrameworkInfoDictionaryEnumerator(this);
        }
        
        IDictionaryEnumerator IDictionary.GetEnumerator() {
            return new FrameworkInfoDictionaryEnumerator(this);
        }
        
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Remove(string key) {
            _innerHash.Remove(key);
        }

        void IDictionary.Remove(object key) {
            Remove((string) key);
        }

        public bool Contains(string key) {
            return _innerHash.Contains(key);
        }

        bool IDictionary.Contains(object key) {
            return Contains((string)key);
        }

        public void Clear() {
            _innerHash.Clear();      
        }

        public void Add(string key, FrameworkInfo value) {
            _innerHash.Add (key, value);
        }

        void IDictionary.Add(object key, object value) {
            Add((string) key, (FrameworkInfo) value);
        }

        public bool IsReadOnly {
            get { return _innerHash.IsReadOnly; }
        }

        public FrameworkInfo this[string key] {
            get { return (FrameworkInfo) _innerHash[key]; }
            set { _innerHash[key] = value; }
        }

        object IDictionary.this[object key] {
            get { return this[(string) key]; }
            set { this[(string) key] = (FrameworkInfo) value; }
        }
        
        public ICollection Values {
            get { return _innerHash.Values; }
        }

        public ICollection Keys {
            get { return _innerHash.Keys; }
        }

        public bool IsFixedSize {
            get { return _innerHash.IsFixedSize; }
        }

        #endregion Implementation of IDictionary

        #region Implementation of ICollection

        void ICollection.CopyTo(Array array, int index) {
            _innerHash.CopyTo(array, index);
        }

        public bool IsSynchronized {
            get { return _innerHash.IsSynchronized; }
        }

        public int Count {
            get { return _innerHash.Count; }
        }

        public object SyncRoot {
            get { return _innerHash.SyncRoot; }
        }

        public void CopyTo(FrameworkInfo[] array, int index) {
            _innerHash.CopyTo(array, index);
        }

        #endregion Implementation of ICollection

        #region Implementation of ICloneable

        public FrameworkInfoDictionary Clone() {
            FrameworkInfoDictionary clone = new FrameworkInfoDictionary();
            clone.InnerHash = (Hashtable) _innerHash.Clone();
            return clone;
        }

        object ICloneable.Clone() {
            return Clone();
        }

        #endregion Implementation of ICloneable
        
        #region HashTable Methods

        public bool ContainsKey (string key) {
            return _innerHash.ContainsKey(key);
        }

        public bool ContainsValue(FrameworkInfo value) {
            return _innerHash.ContainsValue(value);
        }

        public static FrameworkInfoDictionary Synchronized(FrameworkInfoDictionary nonSync) {
            FrameworkInfoDictionary sync = new FrameworkInfoDictionary();
            sync.InnerHash = Hashtable.Synchronized(nonSync.InnerHash);
            return sync;
        }

        #endregion HashTable Methods
    }
    
    public class FrameworkInfoDictionaryEnumerator : IDictionaryEnumerator {
        #region Private Instance Fields

        private IDictionaryEnumerator _innerEnumerator;

        #endregion Private Instance Fields

        #region Internal Instance Constructors

        internal FrameworkInfoDictionaryEnumerator(FrameworkInfoDictionary enumerable) {
            _innerEnumerator = enumerable.InnerHash.GetEnumerator();
        }

        #endregion Internal Instance Constructors

        #region Implementation of IDictionaryEnumerator

        public string Key {
            get { return (string) _innerEnumerator.Key; }
        }

        object IDictionaryEnumerator.Key {
            get { return Key; }
        }

        public FrameworkInfo Value {
            get { return (FrameworkInfo) _innerEnumerator.Value; }
        }

        object IDictionaryEnumerator.Value {
            get { return Value; }
        }

        public DictionaryEntry Entry {
            get { return _innerEnumerator.Entry; }
        }

        #endregion Implementation of IDictionaryEnumerator

        #region Implementation of IEnumerator

        public void Reset() {
            _innerEnumerator.Reset();
        }

        public bool MoveNext() {
            return _innerEnumerator.MoveNext();
        }

        object IEnumerator.Current {
            get { return _innerEnumerator.Current; }
        }

        public FrameworkInfo Current {
            get { return (FrameworkInfo)((DictionaryEntry)_innerEnumerator.Current).Value; }
        }

        #endregion Implementation of IEnumerator
    }
}
