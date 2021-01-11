using System.Collections.ObjectModel;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class DataColumn_2_5 : NotifyObject
    {
        private string m_ColumnContent_2;
        /// <summary>
        /// 列2的内容
        /// </summary>
        public string ColumnContent_2
        {
            get { return m_ColumnContent_2; }
            set
            {
                m_ColumnContent_2 = value;
                base.OnPropertyChanged("ColumnContent_2");
            }
        }

        private double m_ColumnContent_5 = 0;
        /// <summary>
        /// 列5的内容
        /// </summary>
        public double ColumnContent_5
        {
            get { return m_ColumnContent_5; }
            set
            {
                m_ColumnContent_5 = value;
                base.OnPropertyChanged("ColumnContent_5");
            }
        }

        private ObservableCollection<DataColumn_3> m_Rows = new ObservableCollection<DataColumn_3>();
        /// <summary>
        /// 列3的内容
        /// </summary>
        public ObservableCollection<DataColumn_3> Rows
        {
            get { return m_Rows; }
            set
            {
                m_Rows = value;
                base.OnPropertyChanged("Rows");
            }
        }
    }
}
