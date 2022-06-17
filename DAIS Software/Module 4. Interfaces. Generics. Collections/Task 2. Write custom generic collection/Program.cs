namespace Task_2._Write_custom_generic_collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> myCollection = new MyCollection<int>();

            myCollection.Add(1);
            myCollection.Add(2);
            myCollection.Add(2);
            myCollection.Add(2);
            myCollection.RemoveAt(2);
            myCollection.Add(2);

            Console.WriteLine(myCollection[2]);
        }

        public class MyCollection<T>
        {

            private T[] array = new T[4];
            public int Count = 0;

            public void Add(T item)
            {
                if (Count >= Capacity)
                {
                    CopyTo(array, 0);
                }
                array[Count] = item;
                Count++;
            }

            public T this[int index]
            {
                get => array[index];
                set => array[index] = value;
            }

            int Capacity => array.Length;

            //void Clear();

            public bool Contains(T item)
            {
                if (array.Contains(item))
                {
                    return true;
                }

                return false;
            }

            void CopyTo(T[] arr, int arrayIndex)
            {
                var newArray = new T[Capacity * 2];

                for (int i = 0; i < arr.Length; i++)
                {
                    newArray[i] = arr[i];
                }
                array = newArray;
            }

            public bool Remove(T item)
            {
                int idx = IndexOf(item);

                if (idx == -1)
                {
                    return false;
                }

                var newArr = new T[Capacity];

                for (int i = 0; i < idx; i++)
                {
                    newArr[i] = array[i];
                }
                for (int i = idx; i < array.Length - 1; i++)
                {
                    newArr[i] = array[i + 1];
                }

                array = newArr;
                Count--;
                return true;
            }

            IEnumerator<T> GetEnumerator()
            {
                foreach (var item in array)
                {
                    yield return item;
                }
            }

            int IndexOf(T item)
            {
                int idx = -1;

                EqualityComparer<T> comparer = EqualityComparer<T>.Default;


                for (int i = 0; i < array.Length; i++)
                {
                    if (comparer.Equals(array[i], item))
                    {
                        idx = i;
                    }
                }

                return idx;
            }

            delegate int Comparison<in T>(T x, T y);

            public interface IComparer<in T>

            {

                int Compare(T x, T y);

            }

            public void Insert(int index, T item)
            {
                if (Count >= Capacity)
                {
                    CopyTo(array, 0);
                }

                var newArr = new T[Capacity];

                for (int i = 0; i < index; i++)
                {
                    newArr[i] = array[i];
                }

                for (int i = index; i < array.Length - 1; i++)
                {
                    newArr[i + 1] = array[i];
                }

                array = newArr;
                array[index] = item;
                Count++;
            }

            public void RemoveAt(int index)
            {
                var newArr = new T[Capacity];

                for (int i = 0; i < index; i++)
                {
                    newArr[i] = array[i];
                }

                for (int i = index; i < array.Length - 1; i++)
                {
                    newArr[i] = array[i + 1];
                }

                array = newArr;
                Count--;
            }

            //public void Sort()
            //{
            //    for (int i = 0; i < array.Length; i++)
            //    {
            //        for (int j = 0; j < array.Length - i; j++)
            //        {
            //            if (array[i] > array[j])
            //            {

            //            }
            //        }
            //    }
            //}

            //void Sort(Comparison<T> comparison);

            //void Sort(IComparer<T> comparer);



            //void AddRange(IEnumerable<T> collection);

            //void ForEach(Action<T> action);

            //void Reverse();
        }
    }
}