using System.Windows.Controls;

namespace DXY.WorkSheet.Controls.ScreeningChart
{
    /// <summary>
    /// 筛选表视图
    /// </summary>
    public partial class ScreeningView : UserControl
    {
        /// <summary>
        /// 视图控制器
        /// </summary>
        public FilterViewModel Controller { get; set; }

        public ScreeningView()
        {
            InitializeComponent();

            this.Controller = new FilterViewModel();
            base.DataContext = this.Controller;
        }

    }
}
