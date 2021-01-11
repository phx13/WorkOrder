using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DXY.WorkSheet.Controls.GanttChart.GanttModels;

namespace DXY.WorkSheet.Controls.GanttChart
{
    public class GanttViewModel : NotifyObject
    {
        public GanttViewModel()
        {
            this.PropertyChanged += GanttViewModel_PropertyChanged;
        }

        private bool m_Loading;
        /// <summary>
        /// 加载框显隐
        /// </summary>
        public bool Loading
        {
            get { return m_Loading; }
            set
            {
                m_Loading = value;
                OnPropertyChanged("Loading");
            }
        }

        #region 图例属性
        private string m_ShowContentType1 = "显示内容：承接人数/平均计划人日/平均实际人日";
        public string ShowContentType1
        {
            get { return m_ShowContentType1; }
            set
            {
                m_ShowContentType1 = value;
                base.OnPropertyChanged("ShowContentType1");
            }
        }

        private string m_ShowContentType2 = "浮窗内容：承接人/事项";
        public string ShowContentType2
        {
            get { return m_ShowContentType2; }
            set
            {
                m_ShowContentType2 = value;
                base.OnPropertyChanged("ShowContentType2");
            }
        }
        #endregion

        #region 筛选控件属性

        private ObservableCollection<ComboBoxItemContent> m_ComboBoxItems = new ObservableCollection<ComboBoxItemContent>();
        private int m_ComboBoxWidth = 120;

        /// <summary>
        /// 所有的下拉框
        /// </summary>
        public ObservableCollection<ComboBoxItemContent> ComboBoxItems
        {
            get { return m_ComboBoxItems; }
            set
            {
                m_ComboBoxItems = value;
                base.OnPropertyChanged("ComboBoxItems");
            }
        }

        /// <summary>
        /// 下拉框的宽度  默认150
        /// </summary>
        public int ComboBoxWidth
        {
            get { return m_ComboBoxWidth; }
            set
            {
                m_ComboBoxWidth = value;
                base.OnPropertyChanged("ComboBoxWidth");
            }
        }


        #endregion

        #region 表格属性

        /// <summary>
        /// 当前月份的最大天数
        /// </summary>
        public static int MaxDay { get; set; } = 0;

        /// <summary>
        /// 选定的开始日期
        /// </summary>
        public static DateTime StartDay { get; set; } = DateTime.Now;

        #region 单元格样式

        private string m_GanttBackground = "#F2F2F2";
        private string m_Foreground = "#333333";
        private double m_CellHeight = 25;
        private double m_CellWidth = 150;
        private double m_CellLineWidth = 1;
        private string m_CellLineColor = "#D6C79B";
        private string m_FontFamily = "微软雅黑";
        private int m_FontSize = 12;
        private string m_TitleBackground = "#E7E7E7";
        private string m_CellMouseOverColor = "#55555555";
        private double m_ScrollBarMaximum = 1;
        private DateTime m_ShowDate = DateTime.Now;

        /// <summary>
        /// 甘特图背景色 - 默认 #F2F2F2
        /// </summary>
        public string GanttBackground
        {
            get { return m_GanttBackground; }
            set
            {
                m_GanttBackground = value;
                base.OnPropertyChanged("GanttBackground");
            }
        }

        /// <summary>
        /// 前景色 - 默认 #333333
        /// </summary>
        public string Foreground
        {
            get { return m_Foreground; }
            set
            {
                m_Foreground = value;
                base.OnPropertyChanged("Foreground");
            }
        }

        /// <summary>
        /// 单元格高度 - 默认25像素
        /// </summary>
        public double CellHeight
        {
            get { return m_CellHeight; }
            set
            {
                m_CellHeight = value;
                base.OnPropertyChanged("CellHeight");
            }
        }

        /// <summary>
        /// 单元格宽度 - 默认80像素
        /// </summary>
        public double CellWidth
        {
            get { return m_CellWidth; }
            set
            {
                m_CellWidth = value;
                base.OnPropertyChanged("CellWidth");
            }
        }

        /// <summary>
        /// 单元格线宽 - 默认1像素
        /// </summary>
        public double CellLineWidth
        {
            get { return m_CellLineWidth; }
            set
            {
                m_CellLineWidth = value;
                base.OnPropertyChanged("CellLineWidth");
            }
        }

        /// <summary>
        /// 单元格边线颜色 - 默认 #D6C79B
        /// </summary>
        public string CellLineColor
        {
            get { return m_CellLineColor; }
            set
            {
                m_CellLineColor = value;
                base.OnPropertyChanged("CellLineColor");
            }
        }

        /// <summary>
        /// 单元格鼠标滑过颜色 - 默认 #55555555
        /// </summary>
        public string CellMouseOverColor
        {
            get { return m_CellMouseOverColor; }
            set
            {
                m_CellMouseOverColor = value;
                base.OnPropertyChanged("CellMouseOverColor");
            }
        }

        /// <summary>
        /// 字体 - 默认 微软雅黑
        /// </summary>
        public string FontFamily
        {
            get { return m_FontFamily; }
            set
            {
                m_FontFamily = value;
                base.OnPropertyChanged("FontFamily");
            }
        }

        /// <summary>
        /// 字号 - 默认 12
        /// </summary>
        public int FontSize
        {
            get { return m_FontSize; }
            set
            {
                m_FontSize = value;
                base.OnPropertyChanged("FontSize");
            }
        }

        /// <summary>
        /// 表头背景色 - 默认 #E7E7E7
        /// </summary>
        public string TitleBackground
        {
            get { return m_TitleBackground; }
            set
            {
                m_TitleBackground = value;
                base.OnPropertyChanged("TitleBackground");
            }
        }

        /// <summary>
        /// 横向滑块的最大值 - 默认0 自动计算无需修改
        /// </summary>
        public double ScrollBarMaximum
        {
            get { return m_ScrollBarMaximum; }
            set
            {
                m_ScrollBarMaximum = value;
                base.OnPropertyChanged("ScrollBarMaximum");
            }
        }

        /// <summary>
        /// 显示日期
        /// </summary>
        public DateTime ShowDate
        {
            get { return m_ShowDate; }
            set
            {
                m_ShowDate = value;
                base.OnPropertyChanged("ShowDate");
            }
        }

        #endregion

        #region 普通列

        private string m_ColumnName_1 = "部门";
        private double m_ColumnWidth_1 = 150;
        private string m_ColumnName_2 = "承接人";
        private double m_ColumnWidth_2 = 150;
        private string m_ColumnName_3 = "项目简称";
        private double m_ColumnWidth_3 = 150;
        private string m_ColumnName_5 = "总计";
        private double m_ColumnWidth_5 = 150;

        /// <summary>
        /// 列1的显示名称
        /// </summary>
        public string ColumnName_1
        {
            get { return m_ColumnName_1; }
            set
            {
                m_ColumnName_1 = value;
                base.OnPropertyChanged("ColumnName_1");
            }
        }

        /// <summary>
        /// 列1的宽度 - 默认90
        /// </summary>
        public double ColumnWidth_1
        {
            get { return m_ColumnWidth_1; }
            set
            {
                m_ColumnWidth_1 = value;
                base.OnPropertyChanged("ColumnWidth_1");
            }
        }

        /// <summary>
        /// 列2的显示名称
        /// </summary>
        public string ColumnName_2
        {
            get { return m_ColumnName_2; }
            set
            {
                m_ColumnName_2 = value;
                base.OnPropertyChanged("ColumnName_2");
            }
        }

        /// <summary>
        /// 列2的宽度 - 默认90
        /// </summary>
        public double ColumnWidth_2
        {
            get { return m_ColumnWidth_2; }
            set
            {
                m_ColumnWidth_2 = value;
                base.OnPropertyChanged("ColumnWidth_2");
            }
        }

        /// <summary>
        /// 列3的显示名称
        /// </summary>
        public string ColumnName_3
        {
            get { return m_ColumnName_3; }
            set
            {
                m_ColumnName_3 = value;
                base.OnPropertyChanged("ColumnName_3");
            }
        }

        /// <summary>
        /// 列3的宽度 - 默认90
        /// </summary>
        public double ColumnWidth_3
        {
            get { return m_ColumnWidth_3; }
            set
            {
                m_ColumnWidth_3 = value;
                base.OnPropertyChanged("ColumnWidth_3");
            }
        }

        /// <summary>
        /// 列5的显示名称
        /// </summary>
        public string ColumnName_5
        {
            get { return m_ColumnName_5; }
            set
            {
                m_ColumnName_5 = value;
                base.OnPropertyChanged("ColumnName_5");
            }
        }

        /// <summary>
        /// 列5的宽度 - 默认90
        /// </summary>
        public double ColumnWidth_5
        {
            get { return m_ColumnWidth_5; }
            set
            {
                m_ColumnWidth_5 = value;
                base.OnPropertyChanged("ColumnWidth_5");
            }
        }

        #endregion

        #region 数据

        public ObservableCollection<string> Days { get; set; } = new ObservableCollection<string>();

        private ObservableCollection<DataColumn_1> m_Rows;
        /// <summary>
        /// 数据行
        /// </summary>
        public ObservableCollection<DataColumn_1> Rows
        {
            get { return m_Rows; }
            set
            {
                m_Rows = value;
                base.OnPropertyChanged("Rows");
            }
        }

        #endregion

        /// <summary>
        /// 当日起属性改变时发生
        /// </summary>
        private void GanttViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ShowDate")
            {
                //Days.Clear();
                //MaxDay = DateTime.DaysInMonth(this.ShowDate.Year, this.ShowDate.Month);
                //for (int i = 0; i < MaxDay; i++)
                //{
                //    Days.Add($"{i + 1}日");
                //}

                //this.ScrollBarMaximum = MaxDay * (CellWidth - 2);
            }
        }

        #endregion
    }
}
