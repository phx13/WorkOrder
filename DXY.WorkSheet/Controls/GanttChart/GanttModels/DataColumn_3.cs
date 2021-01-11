using System;
using System.Collections.ObjectModel;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class DataColumn_3 : NotifyObject
    {
        private string m_ColumnContent_3;

        /// <summary>
        /// 列3的内容
        /// </summary>
        public string ColumnContent_3
        {
            get { return m_ColumnContent_3; }
            set
            {
                m_ColumnContent_3 = value;
                base.OnPropertyChanged("ColumnContent_3");
            }
        }

        private ObservableCollection<DataColumn_4> m_Rows = new ObservableCollection<DataColumn_4>() { new DataColumn_4() };
        /// <summary>
        /// 列4的内容
        /// </summary>
        public ObservableCollection<DataColumn_4> Rows
        {
            get { return m_Rows; }
            set
            {
                m_Rows = value;
                base.OnPropertyChanged("Rows");
            }
        }

        /// <summary>
        /// 寻找可以添加单元格内容的行
        /// </summary>
        public DataColumn_4 FindCanAddCell(int startTime, int endTime)
        {
            foreach (var row in m_Rows)
            {
                if (row.IsCanAddCell(startTime, endTime))
                {
                    return row;
                }
            }

            return null;
        }

        /// <summary>
        /// 寻找可以添加单元格内容的行
        /// </summary>
        public DataColumn_4 FindCanAddCell(DateTime startTime, DateTime endTime)
        {
            foreach (var row in m_Rows)
            {
                if (row.IsCanAddCell(startTime, endTime))
                {
                    return row;
                }
            }

            return null;
        }
    }
}
