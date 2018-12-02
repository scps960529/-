namespace SystemFramework.Logs
{
    public class LogImpl : ILogger
    {
        private static LogImpl _singleton;

        private static log4net.ILog _kernel;

        private static bool _hasInit = false;

        static LogImpl()
        {
            _kernel = log4net.LogManager.GetLogger("SystemLogger");
        }

        public static LogImpl Instance { get { return _singleton; } }

        public void Error(string msg)
        {
            _kernel.Error(msg);
        }

        public void Warning(string msg)
        {
            _kernel.Warn(msg);
        }

        public void Debug(string msg)
        {
            _kernel.Debug(msg);
        }

        public void Infor(string msg)
        {
            _kernel.Info(msg);
        }
    }
}
