namespace Theatre.Interfaces
{
    public interface IOutputWriter
    {
        void Write(string msg);

        void WriteLine(string msg);

        void WriteLine();
    }
}