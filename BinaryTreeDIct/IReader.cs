using System.Collections.Generic;

namespace BinaryTreeDIct
{
    public interface ISerializer
    {
        string ReadDict<TKey,TValue>(IDictionary<TKey, TValue> dictionary);
        void LoadToDict<TKey, TValue>(string filename, IDictionary<TKey, TValue> dictionary);
    }
}