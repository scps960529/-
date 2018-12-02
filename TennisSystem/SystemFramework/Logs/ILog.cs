namespace SystemFramework.Logs
{
    public interface ILogger
    {
        void Error(string message);

        void Warning(string message);

        void Debug(string message);

        void Infor(string message);
    }
}
