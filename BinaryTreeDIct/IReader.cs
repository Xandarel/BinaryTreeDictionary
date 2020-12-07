using System.Collections.Generic;

namespace BinaryTreeDIct
{
    public interface IReader
    {
        string LoadFile<TKey,TValue>(string filename, IDictionary<TKey, TValue> dictionary, char separator);
        string ReadFile(string filename);
    }
}