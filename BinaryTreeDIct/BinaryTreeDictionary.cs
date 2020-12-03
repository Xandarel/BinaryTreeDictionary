using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryTreeDIct
{
    public class BinaryTreeDictionary<Tkey, Tvalue> : IDictionary<Tkey,Tvalue>
        where Tkey : IComparable<Tkey>
    {
        private BinaryTreeDictionary<Tkey, Tvalue> left, rigth;
        Tkey key;
        Tvalue value;
        bool Head;
        
        public BinaryTreeDictionary()
        {
            left = null;
            rigth = null;
            Head = true;
        }

        public Tvalue this[Tkey key] 
        {
            get
            {
                if (!Keys.Contains(key))
                    throw new KeyNotFoundException();

                if (key.Equals(this.key))
                    return value;
                else if (this.key.CompareTo(key) < 0) //Левая ветка
                {
                    return left[key];
                }
                else return rigth[key];
            }
            set 
            {
                if (Head)
                {
                    this.key = key;
                    this.value = value;
                    Head = false;
                }
                else if (this.key.CompareTo(key) < 0)
                    if (left != null)
                        left[key] = value;
                    else
                    {
                        left = new BinaryTreeDictionary<Tkey, Tvalue>();
                        left[key] = value;
                    }
                else
                {
                    if (rigth != null)
                        rigth[key] = value;
                    else
                    {
                        rigth = new BinaryTreeDictionary<Tkey, Tvalue>();
                        rigth[key] = value;
                    }
                }
            } 
        }

        public ICollection<Tkey> Keys
        {
            get 
            {
                var result = new List<Tkey>();
                result.Add(key);
                if (left != null) result.AddRange(left.Keys);
                if (rigth != null) result.AddRange(rigth.Keys);
                return result;
            }
        }

        public ICollection<Tvalue> Values
        {
            get
            {
                var result = new List<Tvalue>();
                result.Add(value);
                if (left != null) result.AddRange(left.Values);
                if (rigth != null) result.AddRange(rigth.Values);
                return result;
            }
        }

        public int Count => Keys.Count;

        public bool IsReadOnly => false;

        public void Add(Tkey key, Tvalue value) => this[key] = value;

        public void Add(KeyValuePair<Tkey, Tvalue> item) => this[item.Key] = item.Value;

        public void Clear()
        {
            left = null;
            rigth = null;
            Head = true;
            key = default;
            value = default;
        }

        public bool Contains(KeyValuePair<Tkey, Tvalue> item)
        {
            if (!Keys.Contains(item.Key))
                return false;
            else
            {
                var data = this[item.Key];
                return data.Equals(item.Value);
            }
        }

        public bool ContainsKey(Tkey key) => Keys.Contains(key);

        public void CopyTo(KeyValuePair<Tkey, Tvalue>[] array, int arrayIndex)
        {
            array[arrayIndex] = new KeyValuePair<Tkey, Tvalue>(key, value);
            if (left != null)
                left.CopyTo(array, arrayIndex + 1);
            if (rigth != null)
                rigth.CopyTo(array, arrayIndex + 2);
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            var res = new Dictionary<Tkey, Tvalue>();
            foreach (var k in Keys)
                res[k] = this[k];
            return res.GetEnumerator();
            
        }

        //TODO: Спросить на паре
        public bool Remove(Tkey key)
        {
            if (!Keys.Contains(key))
                return false;

            return true;
        }
        //TODO: Спросить на паре
        public bool Remove(KeyValuePair<Tkey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            if (!Keys.Contains(key))
            {
                value = default;
                return false;
            }
            else
            {
                value = this[key];
                return true;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Чтение из файла. Данные в файле должны иметь следующий формат:
        /// ключ: значение
        /// </summary>
        /// <param name="filename">имя файла</param>
        public void ReadFile(string filename)
        {
            using (var fstream = new StreamReader(filename, Encoding.GetEncoding(1251)))
            {
                string s;
                while ((s = fstream.ReadLine()) != null)
                {
                    var sKey = (object)s.Split(':')[0];
                    var sValue = (object)s.Split(':')[1];
                    this[(Tkey)sKey] = (Tvalue)sValue;
                }
            }
        }
        /// <summary>
        /// Запись в файл.Данные в файле будут иметь следующий формат:
        /// ключ: значение
        /// </summary>
        /// <param name="filename">имя файла</param>
        public void LoadFile(string filename)
        {
            using (StreamWriter w = new StreamWriter(filename, false, Encoding.GetEncoding(1251)))
            {
                foreach (var k in Keys)
                    w.WriteLine($"{k}: {this[k]}");
            }
        }
    }
}
