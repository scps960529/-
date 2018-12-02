namespace SystemFramework.Exceptions
{
    public class OperateError : ErrorBase
    {
        public OperateError(LogType logtype, string msg)
            :base(logtype, "OperateError", msg)
        { }
    }
}
