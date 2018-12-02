namespace SystemFramework.Exceptions
{
    public class StartupError : ErrorBase
    {
        public StartupError(LogType logtype, string msg)
            : base(logtype, "StartupError", msg)
        { }
    }
}
