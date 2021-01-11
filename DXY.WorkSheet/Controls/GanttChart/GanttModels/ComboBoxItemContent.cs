using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DXY.WorkSheet.Controls.GanttChart.GanttModels
{
    public class ComboBoxItemContent : NotifyObject
    {
        private string m_TipContent;
        private ObservableCollection<string> m_ItemContent;

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

        public ObservableCollection<string> ItemContent
        {
            get { return m_ItemContent; }
            set
            {
                m_ItemContent = value;
                base.OnPropertyChanged("ItemContent");
            }
        }

        public static ComboBoxItemContent CreateItem(string type, IEnumerable<string> items)
        {
            var item = new ComboBoxItemContent();
            item.TipContent = type;
            item.ItemContent = new ObservableCollection<string>(items.Prepend("全部").Cast<string>());

            return item;
        }
    }
}
