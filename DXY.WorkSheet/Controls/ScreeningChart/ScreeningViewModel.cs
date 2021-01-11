using System.Data;

namespace DXY.WorkSheet.Controls.ScreeningChart
{
    public class FilterViewModel : NotifyObject
    {
        #region 单元格样式

        private string m_Background = "#F2F2F2";
        private string m_Foreground = "#333333";
        private double m_CellHeight = 25;
        private double m_CellWidth = 150;
        private double m_CellLineWidth = 1;
        private string m_CellLineColor = "#D6C79B";
        private string m_FontFamily = "微软雅黑";
        private int m_FontSize = 12;
        private string m_TitleBackground = "#E7E7E7";
        private string m_CellMouseOverColor = "#55555555";

        /// <summary>
        /// 图背景色 - 默认 #F2F2F2
        /// </summary>
        public string Background
        {
            get { return m_Background; }
            set
            {
                m_Background = value;
                base.OnPropertyChanged("Background");
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

        #endregion

        #region 普通列

        private string m_ColumnName_1 = "部门";
        private double m_ColumnWidth_1 = 90;
        private string m_ColumnName_2 = "承接人";
        private double m_ColumnWidth_2 = 90;
        private string m_ColumnName_3 = "项目简称";
        private double m_ColumnWidth_3 = 90;
        private string m_ColumnName_4 = "总计";
        private double m_ColumnWidth_4 = 90;

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
        /// 列4的显示名称
        /// </summary>
        public string ColumnName_4
        {
            get { return m_ColumnName_4; }
            set
            {
                m_ColumnName_4 = value;
                base.OnPropertyChanged("ColumnName_4");
            }
        }

        /// <summary>
        /// 列4的宽度 - 默认90
        /// </summary>
        public double ColumnWidth_4
        {
            get { return m_ColumnWidth_4; }
            set
            {
                m_ColumnWidth_4 = value;
                base.OnPropertyChanged("ColumnWidth_4");
            }
        }

        #endregion

        #region 数据

        private string m_TitleName = "排名";

        /// <summary>
        /// 列1的显示名称
        /// </summary>
        public string TitleName
        {
            get { return m_TitleName; }
            set
            {
                m_TitleName = value;
                base.OnPropertyChanged("TitleName");
            }
        }

        private DataView m_Rows;
        /// <summary>
        /// 数据行
        /// </summary>
        public DataView Rows
        {
            get { return m_Rows; }
            set
            {
                m_Rows = value;
                base.OnPropertyChanged("Rows");
            }
        }


        #endregion
    }
}
