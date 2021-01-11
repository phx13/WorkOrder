using System.Windows;
using System.Collections.ObjectModel;
using DXY.WorkSheet.PageModels;
using System;
using System.Windows.Controls;

namespace DXY.WorkSheet
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// 所有的页面
        /// </summary>
        public ObservableCollection<PageModel> Pages { get; set; } = new ObservableCollection<PageModel>();

        /// <summary>
        /// 构造
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;

            this.DataContext = Pages;
        }

        public (string, int) GetInfo()
        {
            return ("1", 1);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Pages.Add(PageFactory.CreatePage("项目工单总览"));
            this.Pages.Add(PageFactory.CreatePage("项目工单明细"));
            this.Pages.Add(PageFactory.CreatePage("人员工单总览"));
            this.Pages.Add(PageFactory.CreatePage("人员工单明细"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton==System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key==System.Windows.Input.Key.Escape)
            {
                WindowState = WindowState.Normal;
            }
            if (e.Key == System.Windows.Input.Key.F11)
            {
                WindowState = WindowState.Maximized;
            }
            if (e.Key == System.Windows.Input.Key.F12)
            {
                WindowState = WindowState.Minimized;
            }
        }
    }
}
