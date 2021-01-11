using System;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class Cell : NotifyObject
    {
        private string m_Color = "Transparent";
        /// <summary>
        /// 颜色 - 默认 "Transparent"
        /// </summary>
        public string Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
                base.OnPropertyChanged("Color");
            }
        }

        private double m_LeftThickness = 0;
        /// <summary>
        /// 左边线
        /// </summary>
        public double LeftThickness
        {
            get { return m_LeftThickness; }
            set
            {
                m_LeftThickness = value;
                base.OnPropertyChanged("Thickness");
            }
        }

        private double m_RightThickness = 0;
        /// <summary>
        /// 右边线
        /// </summary>
        public double RightThickness
        {
            get { return m_RightThickness; }
            set
            {
                m_RightThickness = value;
                base.OnPropertyChanged("Thickness");
            }
        }

        public string Thickness
        {
            get
            {
                return $"{m_LeftThickness},0,{m_RightThickness},0";
            }
        }

        private string m_ShowContent;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string ShowContent
        {
            get { return m_ShowContent; }
            set
            {
                m_ShowContent = value;
                base.OnPropertyChanged("ShowContent");
            }
        }

        private string m_TipContent;
        /// <summary>
        /// 提示内容
        /// </summary>
        public string TipContent
        {
            get { return m_TipContent; }
            set
            {
                m_TipContent = value;
                base.OnPropertyChanged("TipContent");
            }
        }

        private double m_ActualTime;
        /// <summary>
        /// 实际工时
        /// </summary>
        public double ActualTime
        {
            get { return m_ActualTime; }
            set
            {
                m_ActualTime = value;
                base.OnPropertyChanged("ActualTime");
            }
        }

        private double m_PlanTime;
        /// <summary>
        /// 计划工时
        /// </summary>
        public double PlanTime
        {
            get { return m_PlanTime; }
            set
            {
                m_PlanTime = value;
                base.OnPropertyChanged("PlanTime");
            }
        }

        private int m_PrjCount;
        /// <summary>
        /// 项目数
        /// </summary>
        public int PrjCount
        {
            get { return m_PrjCount; }
            set
            {
                m_PrjCount = value;
                base.OnPropertyChanged("PrjCount");
            }
        }

        private DateTime m_Date;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date
        {
            get { return m_Date; }
            set
            {
                m_Date = value;
                base.OnPropertyChanged("Date");
            }
        }
    }
}
