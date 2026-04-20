using System;
using System.IO;

namespace WinFormsTemplate.Core
{
    public static class Logger
    {
        private static readonly string sLogFile = "App.log";

        public static void Log(string sMessage, Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(sLogFile, true))
                {
                    sw.WriteLine("-----");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(sMessage);

                    if (ex != null)
                    {
                        sw.WriteLine(ex.Message);
                        sw.WriteLine(ex.StackTrace);
                    }
                }
            }
            catch
            {
                // Do not throw exception from logger
            }
        }
    }
}
