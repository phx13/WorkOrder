using System;
using System.Windows;
using System.Windows.Threading;

namespace DXY.WorkSheet
{
    /// <summary>
    /// 主程序
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>
        /// UI未捕获异常
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"未捕获异常 - {e.Exception.Message}");
        }

        /// <summary>
        /// 程序域未捕获异常
        /// </summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"未捕获异常 - {(e.ExceptionObject as Exception).Message}");
        }
    }
}
