namespace BinaryTreeDIct
{
    public interface IFileWorker
    {
        void ToFile(string filemane, string data);
        string FromFile(string filename);
    }
}
