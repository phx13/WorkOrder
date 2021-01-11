using System;
using System.Collections.ObjectModel;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class DataColumn_4 : NotifyObject
    {
        public DataColumn_4()
        {
            this.m_Cells = new ObservableCollection<Cell>();
            for (int i = 0; i < GanttViewModel.MaxDay + 1; i++)
            {
                this.m_Cells.Add(new Cell
                {
                    Date = GanttViewModel.StartDay.AddDays(i)
                });
            }
        }

        private ObservableCollection<Cell> m_Cells;
        /// <summary>
        /// 列4的内容
        /// </summary>
        public ObservableCollection<Cell> Cells
        {
            get { return m_Cells; }
            set
            {
                m_Cells = value;
                base.OnPropertyChanged("Cells");
            }
        }

        /// <summary>
        /// 是否可以添加单元格内容
        /// </summary>
        public bool IsCanAddCell(int startCell, int endCell)
        {
            for (int i = startCell - 1; i < endCell; i++)
            {
                if (m_Cells[i].Color != "Transparent")
                {
                    return false;
                }
            }

            //从开始位置到结束位置没有单元格的背景色为非透明
            return true;
        }

        /// <summary>
        /// 是否可以添加单元格内容
        /// </summary>
        public bool IsCanAddCell(DateTime startCell, DateTime endCell)
        {
            //var index = (startCell - GanttViewModel.StartDay).Days;

            for (int i = (startCell - GanttViewModel.StartDay).Days; i < (endCell - GanttViewModel.StartDay).Days+1; i++)
            {
                if (m_Cells[i].Color != "Transparent")
                {
                    return false;
                }
            }

            //从开始位置到结束位置没有单元格的背景色为非透明
            return true;
        }
    }
}
