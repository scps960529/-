using SystemFramework.Logs;

namespace SystemFramework.Exceptions
{
    public abstract class ErrorBase
    {
        protected ILogger Log { get { return LogImpl.Instance; } }

        public LogType Type { get; private set; }

        public string Message { get; private set; }

        public ErrorBase(LogType logtype, object errorType, string msg)
        {
            Type = logtype;
            Message = msg;

            switch (Type)
            {
                case LogType.Info:
                    Log.Infor(string.Format("[OperateError]\t{1}", msg));
                    break;
                case LogType.Debug:
                    Log.Infor(string.Format("[OperateError]\t{1}", msg));
                    break;
                case LogType.Warn:
                    Log.Infor(string.Format("[OperateError]\t{1}", msg));
                    break;
                case LogType.Error:
                    Log.Infor(string.Format("[OperateError]\t{1}", msg));
                    break;
                default:
                    Log.Infor(string.Format("[OperateError]\t{0}", msg));
                    break;
            }
        }
    }
}
