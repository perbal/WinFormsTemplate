using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;
using WinFormsTemplate.UI;
using WinFormsTemplate.Core;

namespace WinFormsTemplate
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure WinForms catches exceptions
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // *** Global Error Management
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            Application.Run(new MainForm());
        }

        // *** Global Error Management
        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Logger.Log("UI Thread Exception", e.Exception);
            }
            catch
            {
                // Prevent secondary crash during logging
            }

            MessageBox.Show(
                "An unexpected error occurred.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;

                if (ex != null)
                {
                    Logger.Log("Unhandled Exception (IsTerminating=" + e.IsTerminating.ToString() + ")", ex);
                }
            }
            catch
            {
                // Prevent secondary crash during logging
            }
        }
    }
}
