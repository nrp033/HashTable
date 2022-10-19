using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MyMapNode<K, V>
    { // const and readonly
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);  // |-5| =5 |3|=3 |-3|=3
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }


        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        // 5-4345 7-8765456 8-8745
        protected int GetArrayPosition(K key)// 5->-7654323456     5->  7654323456 //78-87654568745 
        { // 100 ->876543456787654  -> 100->876543456787654
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }


        //to get frequency of values using getfrequency method

        public void GetFrequency(V Values)
        {
            //initially our frequency is zero

            int frequency = 0;

            //using foreach loop to get the value in linked list

            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;

                foreach (KeyValue<K, V> check in list)
                {
                    if (check.Equals(null))
                    {
                        continue;

                    }
                    if (check.Value.Equals(Values))
                    {
                        frequency++;

                    }
                }

            }
            Console.WriteLine("Frequency of \"{0}\" is : {1}", Values, frequency);
        }
    }
  
}
