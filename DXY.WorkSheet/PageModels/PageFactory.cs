using System;

namespace DXY.WorkSheet.PageModels
{
    /// <summary>
    /// 创建页面的工厂类
    /// </summary>
    public class PageFactory
    {
        /// <summary>
        /// 依据页面名称创建页面
        /// </summary>
        /// <returns></returns>
        public static PageModel CreatePage(string pageName)
        {
            PageModel model;

            switch (pageName)
            {
                case "项目工单总览":
                    model = new ProjectBriefModel();
                    model.InitPage(pageName);
                    break;
                case "项目工单明细":
                    model = new ProjectDetailedModel();
                    model.InitPage(pageName);
                    break;
                case "人员工单总览":
                    model = new UndertakesBriefModel();
                    model.InitPage(pageName);
                    break;
                case "人员工单明细":
                    model = new UndertakesDetailedModel();
                    model.InitPage(pageName);
                    break;
                default:
                    throw new ArgumentException($"页面名称参数错误，没有“{pageName}”选项");
            }

            return model;
        }
    }
}
