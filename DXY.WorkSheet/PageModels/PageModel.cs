namespace DXY.WorkSheet.PageModels
{
    public abstract class PageModel : NotifyObject
    {
        private string m_PageName;
        private PageControl m_PageControl;

        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName
        {
            get { return m_PageName; }
            set
            {
                m_PageName = value;
                base.OnPropertyChanged("PageName");
            }
        }

        /// <summary>
        /// 页面控件
        /// </summary>
        public PageControl PageControl
        {
            get { return m_PageControl; }
            set
            {
                m_PageControl = value;
                base.OnPropertyChanged("PageControl");
            }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        public abstract void InitPage(string pageName);
    }
}
