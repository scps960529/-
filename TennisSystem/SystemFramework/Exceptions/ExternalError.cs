namespace SystemFramework.Exceptions
{
    public class ExternalError : ErrorBase
    {
        public ExternalError(LogType logtype, string msg)
            : base(logtype, "ExternalError", msg)
        { }
    }
}
