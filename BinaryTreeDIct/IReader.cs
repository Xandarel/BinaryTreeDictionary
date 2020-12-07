using System.Collections.Generic;

namespace BinaryTreeDIct
{
    public interface IReader
    {
        string LoadFile<TKey,TValue>(string filename, IDictionary<TKey, TValue> dictionary);
        string ReadFile(string filename);
    }
}