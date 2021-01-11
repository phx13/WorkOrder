using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using DXY.WorkSheet.Controls.GanttChart.GanttModels;

namespace DXY.WorkSheet.Controls.GanttChart
{
    /// <summary>
    /// 甘特图视图
    /// </summary>
    public partial class GanttView : UserControl
    {
        /// <summary>
        /// 视图控制器
        /// </summary>
        public GanttViewModel Controller { get; set; }

        /// <summary>
        /// 所有的横向滚动条
        /// </summary>
        private List<ScrollViewer> m_Horizontals = new List<ScrollViewer>();

        /// <summary>
        /// 构造
        /// </summary>
        public GanttView()
        {
            InitializeComponent();

            this.Controller = new GanttViewModel();
            base.DataContext = this.Controller;
        }

        #region 筛选组件

        /// <summary>
        /// 筛选条件更变回调
        /// </summary>
        public Action<List<string>, List<string>> SelectionChanged { get; set; }

        /// <summary>
        /// 选择项
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
            {
                return;
            }
        }

        /// <summary>
        /// 设置时间
        /// </summary>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var dp = sender as DatePicker;
            if (dp.Name == "StartTime")
            {
                var date = DateTime.Parse(e.OriginalSource.ToString());
                this.Controller.ShowDate = date;
            }

            //if (EndTime.SelectedDate != null && StartTime.SelectedDate != null)
            //{
            //    var daySpan = (EndTime.SelectedDate - StartTime.SelectedDate).Value.Days;
            //    GanttViewModel.MaxDay = daySpan;
            //}
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var types = new List<string>();
            var contents = new List<string>();
            var btn = sender as Button;
            if (btn.Content.ToString() == "重置")
            {
                for (int i = 0; i < ConditionListbox.Items.Count; i++)
                {
                    var listboxitem = ConditionListbox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                    var sp = VisualTreeHelper.GetChild(listboxitem, 0) as StackPanel;
                    var cb = VisualTreeHelper.GetChild(sp, 1) as ComboBox;
                    cb.SelectedIndex = 0;
                    types.Add(cb.ToolTip.ToString());
                    contents.Add(cb.SelectedValue == null ? "" : cb.SelectedValue.ToString());
                }
            }
            else
            {
                for (int i = 0; i < ConditionListbox.Items.Count; i++)
                {
                    var listboxitem = ConditionListbox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                    var sp = VisualTreeHelper.GetChild(listboxitem, 0) as StackPanel;
                    var cb = VisualTreeHelper.GetChild(sp, 1) as ComboBox;
                    types.Add(cb.ToolTip.ToString());
                    contents.Add(cb.SelectedValue == null ? "" : cb.SelectedValue.ToString());
                }
            }

            var beginTime = "";
            var endTime = "";

            if (!string.IsNullOrEmpty(this.StartTime.SelectedDate.ToString()))
            {
                beginTime = Convert.ToDateTime(StartTime.SelectedDate).ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("请选择起始日期", "提示");
                return;
            }
            if (!string.IsNullOrEmpty(this.EndTime.SelectedDate.ToString()))
            {
                endTime = Convert.ToDateTime(EndTime.SelectedDate).ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("请选择结束日期", "提示");
                return;
            }
            if (Convert.ToDateTime(StartTime.SelectedDate) > Convert.ToDateTime(EndTime.SelectedDate))
            {
                MessageBox.Show("起始日期不能大于结束日期", "提示");
                return;
            }
            types.Add("起始日期");
            types.Add("结束日期");
            contents.Add(beginTime);
            contents.Add(endTime);

            Controller.Days.Clear();

            if (EndTime.SelectedDate != null && StartTime.SelectedDate != null)
            {
                var daySpan = (EndTime.SelectedDate - StartTime.SelectedDate).Value.Days;
                GanttViewModel.MaxDay = daySpan;
                GanttViewModel.StartDay = (DateTime) StartTime.SelectedDate;
                if (StartTime.SelectedDate.Value.Month != EndTime.SelectedDate.Value.Month)
                {
                    for (int j = StartTime.SelectedDate.Value.Month; j < EndTime.SelectedDate.Value.Month + 1; j++)
                    {
                        if (j == StartTime.SelectedDate.Value.Month)
                        {
                            for (int i = StartTime.SelectedDate.Value.Day - 1; i < DateTime.DaysInMonth(this.StartTime.SelectedDate.Value.Year, this.StartTime.SelectedDate.Value.Month); i++)
                            {
                                Controller.Days.Add($"{i + 1}日");
                            }
                        }
                        else if (j == EndTime.SelectedDate.Value.Month)
                        {
                            for (int i = 0; i < EndTime.SelectedDate.Value.Day; i++)
                            {
                                Controller.Days.Add($"{i + 1}日");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < DateTime.DaysInMonth(this.StartTime.SelectedDate.Value.Year, j); i++)
                            {
                                Controller.Days.Add($"{i + 1}日");
                            }
                        }
                    }
                }
                else
                {
                    for (int i = StartTime.SelectedDate.Value.Day - 1; i < EndTime.SelectedDate.Value.Day; i++)
                    {
                        Controller.Days.Add($"{i + 1}日");
                    }
                }
            }

            this.Controller.ScrollBarMaximum = (GanttViewModel.MaxDay - 2) * Controller.CellWidth;

            SelectionChanged?.Invoke(types, contents);
        }

        #endregion

        #region 表格UI事件控制相关

        /// <summary>
        /// 获取滚动条
        /// </summary>
        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //获取滚动条
            var listBox = sender as ListBox;
            var bd = VisualTreeHelper.GetChild(listBox, 0);
            var sv = VisualTreeHelper.GetChild(bd, 0);
            m_Horizontals.Add(sv as ScrollViewer);

            this.ListBox_Loaded_1(sender, e);
        }

        /// <summary>
        /// 隐藏边线
        /// </summary>
        private void ListBox_Loaded_1(object sender, RoutedEventArgs e)
        {
            var listBox = sender as ListBox;
            //隐藏边线
            var bd = VisualTreeHelper.GetChild(listBox, 0);
            var border = bd as Border;
            border.Padding = new Thickness(0);
        }

        /// <summary>
        /// 去掉最后一个单元格的边框
        /// </summary>
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            var border = sender as Border;
            var dc = border.DataContext.ToString();
            if (dc == $"{this.Controller.Days.Count}日")
            {
                border.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// 开始滚动
        /// </summary>
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (var item in m_Horizontals)
            {
                item.ScrollToHorizontalOffset(e.NewValue);
            }
        }

        /// <summary>
        /// 修改横向滚动条滑块的宽度
        /// </summary>
        private void HorizontalScrollBar_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = sender as ScrollBar;
            var grid = VisualTreeHelper.GetChild(sb, 0);
            var track = VisualTreeHelper.GetChild(grid, 2) as Track;
            if (track == null)
            {
                track = VisualTreeHelper.GetChild(grid, 1) as Track;
            }
            track.ViewportSize = double.NaN; //必须
            var thumb = VisualTreeHelper.GetChild(track, 2) as Thumb;
            thumb.Width = 100;
        }

        #endregion

        private void img_Checked(object sender, RoutedEventArgs e)
        {
            Screening.Visibility = Visibility.Collapsed;
            //Gantt.Width = 1840;
        }

        private void img_Unchecked(object sender, RoutedEventArgs e)
        {
            Screening.Visibility = Visibility.Visible;

            //if (Screening.datagrid.ItemsSource != null)
            //{
            //    Gantt.Width = 1840 - 30 - (Screening.datagrid.ItemsSource as DataView).Table.Columns.Count * 90;
            //}
            //else
            //{
            //    MessageBox.Show("请先查询数据", "提示");
            //}
        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            var dp = sender as DatePicker;
            DateTime dt = DateTime.Now;
            if (dp != null && dp.Name == "StartTime")
            {
                dp.Text = dt.AddDays(-dt.Day + 1).ToString("yyyy-MM-dd");
            }
            if (dp != null && dp.Name == "EndTime")
            {
                dp.Text = dt.ToString("yyyy-MM-dd");
            }
        }
    }
}
