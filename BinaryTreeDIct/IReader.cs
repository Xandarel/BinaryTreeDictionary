using System.Collections.Generic;

namespace BinaryTreeDIct
{
    public interface ISerializer
    {
        string ReadDict<TKey,TValue>(IDictionary<TKey, TValue> dictionary, char separator);
        void LoadToDict<TKey, TValue>(string result, IDictionary<TKey, TValue> dictionary, char separator);
    }
}