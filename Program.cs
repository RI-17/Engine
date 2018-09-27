using System;
using System.Collections.Generic;
using System.Text;

namespace LibTest
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var m = new Matrix2(new Vector2(2,3), new Vector2(6,4));
            Console.WriteLine(m);
            Console.WriteLine(m.Determinant);
            m *= 4;
            Console.WriteLine(m);
            Console.WriteLine(m.Determinant);
            m.Transpose();
            Console.WriteLine(m);
            var m2 = new Matrix2(new Vector2(1,2), new Vector2(3,4));
            var m3 = m * m2;
            Console.WriteLine(m3);
            Console.WriteLine(m3.Determinant);
            
            Console.WriteLine();
            Console.WriteLine(m2.Opposite());
            
            var v1 = new Vector2(1,2);
            var v2 = new Vector2(2,4);
            Console.WriteLine(v1 + "\t" + v2);
            Console.WriteLine(v1.Normalize() + "\t" + v2.Normalized());
            Console.WriteLine(v1 + "\t" + v2);
            Console.WriteLine();
            var v3 = new Vector3(1, 2, 3);
            var v4 = new Vector3(2, 3, 4);
            Console.WriteLine(v3 + "\t" + v4);
            Console.WriteLine(v3.Normalize() + "\t" + v4.Normalized());
            Console.WriteLine(v3 + "\t" + v4);
            





        }
    }
    

    public class LRU<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary;
        private readonly Dictionary<TKey, int> lruDict;

        public LRU()
        {
            dictionary = new Dictionary<TKey, TValue>();
            lruDict = new Dictionary<TKey, int>();
        }

        public void Add(TKey key, TValue value)
        {
            dictionary.Add(key, value);
            if (!lruDict.ContainsKey(key))
                lruDict.Add(key, 0);
        }

        public TValue Get(TKey key)
        {
            var keyInDict = dictionary.ContainsKey(key);
            if(keyInDict)
                lruDict[key]++;
            
            return keyInDict ? dictionary[key] : throw new KeyNotFoundException();
        }

        public TValue this[TKey key]
        {
            get => dictionary[key];
            set => dictionary[key] = value;
        }

        public void RemoveLeastRecentlyUsed()
        {
            var min = int.MaxValue;
            var lru = default(TKey);
            foreach (var e in lruDict)
            {
                if (e.Value < min)
                {
                    min = e.Value;
                    lru = e.Key;
                }
            }
            
            lruDict.Remove(lru);
            dictionary.Remove(lru);
        }

        public string Summary()
        {
            var sb = new StringBuilder();
            sb.Append("key\tusages\n");
            foreach (var e in lruDict)
                sb.Append(e.Key + "\t" + e.Value + "\n");
            
            return sb.ToString();
        }
    }
}