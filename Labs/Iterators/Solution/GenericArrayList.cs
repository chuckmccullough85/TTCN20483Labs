
using System.Collections;

namespace GenericsLab
{
	public class GenericArrayList<T> : IEnumerable<T>
	{
		private T[] items;
		int count;

		public GenericArrayList()
		{
			items = new T[15];
			count = 0;
		}

		public GenericArrayList<T> Add(T item)
		{
			if (count == items.Length)
			{
				Array.Resize(ref items, items.Length + ((int)items.Length / 2));
			}
			items[count++] = item;
			return this;
		}

		public void Remove(int idx)
		{
			if (idx >= 0 && idx >= count)
				throw new ArgumentOutOfRangeException("idx");
			for (int i = idx; i < count; i++)
			{
				if (i < count - 1)
					items[i] = items[i + 1];
			}
			count--;
		}
		public int Size { get { return count; } }

		public int IndexOf(T o)
		{
			return Array.IndexOf(items, o);
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
				yield return items[i];
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// This is the class indexer.  Use it like an array.
        /// </summary>
        /// <param name="idx">The index of the item</param>
        /// <returns></returns>
        public T this[int idx]
		{
			get
			{
				if (idx >= 0 && idx < count)
					return items[idx];
				else
					throw new ArgumentOutOfRangeException("idx");
			}
			set
			{
				if (idx >= 0 && idx < count)
					items[idx] = value;
				else
					throw new ArgumentOutOfRangeException("idx");

			}
		}


	}
}
