using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDIct
{
    public class FileReaderLoader : IReader
    {
        char separator;
        public FileReaderLoader(char separator)
        {
            this.separator = separator;
        }
        public string LoadFile<TKey, TValue>(string filename, IDictionary<TKey, TValue> dictionary)
        {
            var result = "";
            using (StreamWriter w = new StreamWriter(filename, false, Encoding.GetEncoding(1251)))
            {
                foreach (var k in dictionary.Keys)
                {
                    w.WriteLine($"{k}{separator}{dictionary[k]} ");
                    result += $"{k}{separator}{dictionary[k]} ";
                }
            }
            return result;
        }

        public string ReadFile<TKey, TValue>(string filename, IDictionary<TKey, TValue> dictionary)
        {
            var result = "";
            using (var fstream = new StreamReader(filename, Encoding.GetEncoding(1251)))
            {
                string s;
                while ((s = fstream.ReadLine()) != null)
                    result += $"{s} ";
            }
            foreach (var keyValue in result.Split())
            {
                var Key = (TKey)Convert.ChangeType(keyValue.Split(separator)[0], typeof(TKey));
                var Value = Convert.ChangeType(keyValue.Split(separator)[1], typeof(TValue));
                dictionary[Key] = (TValue)Value;
            }
            return result;
        }
    }
}
