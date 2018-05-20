using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MTSRecorder.View;
using CrashReporterDotNET;
namespace MTSRecorder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.ThreadException += ApplicationThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            SendCrashReport((Exception)unhandledExceptionEventArgs.ExceptionObject);
            Environment.Exit(0);
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            SendCrashReport(e.Exception);
        }




            public static void SendCrashReport(Exception exception, string developerMessage = "")
        {
            var reportCrash = new ReportCrash
            {
                CurrentCulture = new CultureInfo("ru-RU"),
                AnalyzeWithDoctorDump = true,
                DeveloperMessage = developerMessage,
                //ToEmail = "me@zznob.ru",
                DoctorDumpSettings = new DoctorDumpSettings
                {
                    ApplicationID = new Guid("7104a669-9ec8-4bde-bb35-729fb1a9c36f"),
                    OpenReportInBrowser = false
                }
            };

            //reportCrash.Send(exception);

            reportCrash.Send(exception);
        }


    }
}