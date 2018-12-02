namespace SystemFramework.Exceptions
{
    public class InternalError : ErrorBase
    {
        public InternalError(LogType logtype, string msg)
            : base(logtype, "InternalError", msg)
        { }
    }
}
