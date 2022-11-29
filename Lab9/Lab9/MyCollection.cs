using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class MyCollection<T> : ISet<T> where T : Computer
    {
        readonly ISet<T>? _comps = new HashSet<T>();

        public int Count => _comps.Count;

        public bool IsReadOnly => _comps.IsReadOnly;
        
        public bool Add(T item)
        {
            return _comps.Add(item);
        }

        public void Clear()
        {
            _comps.Clear();
        }

        public bool Contains(T item)
        {
            return _comps.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _comps.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            _comps.ExceptWith(other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _comps.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            _comps.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return _comps.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return _comps.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return _comps.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return _comps.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return _comps.Overlaps(other);
        }

        public bool Remove(T item)
        {
            return _comps.Remove(item);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return _comps.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            _comps.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            _comps.UnionWith(other);
        }

        void ICollection<T>.Add(T item)
        {
            ((ICollection<T>)_comps).Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_comps).GetEnumerator();
        }
        public void Print()
        {
            foreach (T item in _comps)
            {
                Console.WriteLine($"{item.ToString()}");
            }

        }

    }
}
