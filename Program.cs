using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace MetroUITest
{
    static class Program
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //捕获未处理异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var arguments = Environment.GetCommandLineArgs();
            if (arguments.Length > 1)
            {
                Application.Run(new Form1(arguments));
            }
            else
            {
                Application.Run(new Form1());
            }
            
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            log.Error(e.Exception);
            //throw new Exception("线程未知异常", e.Exception);
            MessageBox.Show(e.Exception.Message, "线程异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            log.Error(ex);
            MessageBox.Show(ex.Message, "应用程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
