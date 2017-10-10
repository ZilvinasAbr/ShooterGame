using System;

namespace Shooter.Classes
{
    public class Logger
    {
        private static volatile Logger _instance;
        private static readonly object SyncRoot = new object();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if(_instance == null)
                            _instance = new Logger();
                    }
                }

                return _instance;
            }
        }

        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.Info, text);
        }

        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.Debug, text);
        }

        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.Error, text);
        }

        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.Info: pretext = "[INFO]"; break;
                case LogLevel.Debug: pretext = "[DEBUG]"; break;
                case LogLevel.Error: pretext = "[ERROR]"; break;
                case LogLevel.Fatal: pretext = "[FATAL]"; break;
                default: pretext = ""; break;
            }

            Console.WriteLine();
            Console.WriteLine($"{DateTime.Now} {pretext}{text}");
        }

        private enum LogLevel
        {
            Info,
            Debug,
            Error,
            Fatal
        }
    }
}
