using System.Collections.Generic;

namespace BinaryTreeDIct
{
    public interface IReader
    {
        string LoadFile<TKey,TValue>(IDictionary<TKey, TValue> dictionary);
        void ReadFile<TKey, TValue>(string filename, IDictionary<TKey, TValue> dictionary);
    }
}