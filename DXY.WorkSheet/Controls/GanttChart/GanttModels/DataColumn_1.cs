using System.Collections.ObjectModel;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class DataColumn_1 : NotifyObject
    {
        private string m_ColumnContent_1;
        /// <summary>
        /// 列1的内容
        /// </summary>
        public string ColumnContent_1
        {
            get { return m_ColumnContent_1; }
            set
            {
                m_ColumnContent_1 = value;
                base.OnPropertyChanged("ColumnContent_1");
            }
        }

        private ObservableCollection<DataColumn_2_5> m_Rows = new ObservableCollection<DataColumn_2_5>();
        /// <summary>
        /// 列2和列5的内容
        /// </summary>
        public ObservableCollection<DataColumn_2_5> Rows
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
