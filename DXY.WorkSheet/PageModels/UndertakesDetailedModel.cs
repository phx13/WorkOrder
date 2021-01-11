using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DXY.WorkSheet.Controls.GanttChart.GanttModels;
using System.ComponentModel;
using DXY.WorkSheet.Controls.GanttChart;

namespace DXY.WorkSheet.PageModels
{
    /// <summary>
    /// 承接人统计- 详细
    /// </summary>
    public class UndertakesDetailedModel : PageModel
    {
        /// <summary>
        /// 当前所有数据
        /// </summary>
        private DataTable m_CurrentData;

        /// <summary>
        /// 当前所有的筛选条件
        /// </summary>
        private List<ValueTuple<string, string>> m_CurrentCondition = new List<ValueTuple<string, string>>();

        /// <summary>
        /// 初始化页面
        /// </summary>
        public override void InitPage(string pageName)
        {
            base.PageName = pageName;
            base.PageControl = new PageControl();
            base.PageControl.Gantt.SelectionChanged = ConditionChanged;
            base.PageControl.Gantt.Controller.ColumnWidth_3 = 150;
            base.PageControl.Gantt.Controller.ShowContentType1 = "显示内容：事项";
            base.PageControl.Gantt.Controller.ShowContentType2 = "浮窗内容：事项备注";

            this.m_CurrentData = Hepler.GetData(@".\项目工单台账（全部）.xlsx", "项目工单台账（全部）").DefaultView.ToTable(false, new[]
            {
                "所属部门",
                //"项目总监",
                //"客户经理",
                //"支撑总监",
                //"方案专家",
                "工单类型",
                "承接人",
                "项目",
                "事项",
                "事项备注",
                "工单状态",
                "开始时间",
                "结束时间",
                "地点",
                //"实际工时",
                "工时"
            });
            m_CurrentData.Columns.Add("项目总监", typeof(string));
            m_CurrentData.Columns.Add("客户经理", typeof(string));
            m_CurrentData.Columns.Add("支撑总监", typeof(string));
            m_CurrentData.Columns.Add("方案专家", typeof(string));
            m_CurrentData.Columns.Add("实际工时", typeof(string));
            var dicData = Hepler.GetData(@".\项目台账（全部）.xlsx", "项目台账（全部）").DefaultView.ToTable(false, new[]
            {
                "项目简称",
                "项目总监",
                "客户经理",
                "支撑总监",
                "方案专家",
            });

            var datas = m_CurrentData.Select();

            foreach (DataRow dataRow in datas)
            {
                var dicDataRows = dicData.Select().Where(t => t["项目简称"].ToString() == dataRow["项目"].ToString());
                if (dicDataRows.Count() > 0)
                {
                    var dicDataRow = dicDataRows.First();
                    if (dicDataRow != null)
                    {
                        dataRow["项目总监"] = dicDataRow["项目总监"];
                        dataRow["客户经理"] = dicDataRow["客户经理"];
                        dataRow["支撑总监"] = dicDataRow["支撑总监"];
                        dataRow["方案专家"] = dicDataRow["方案专家"];
                        dataRow["实际工时"] = 0;
                    }
                }
                else
                {
                    dataRow["项目总监"] = "";
                    dataRow["客户经理"] = "";
                    dataRow["支撑总监"] = "";
                    dataRow["方案专家"] = "";
                    dataRow["实际工时"] = 0;
                }
            }
            InitCondition();
        }

        /// <summary>
        /// 初始化条件
        /// </summary>
        private void InitCondition()
        {
            //添加部门筛选条件
            var unit = this.m_CurrentData.DefaultView.ToTable(true, "所属部门"); //去重
            var condition = ComboBoxItemContent.CreateItem("所属部门", unit.Rows.ForeachToStrings("所属部门"));
            base.PageControl.Gantt.Controller.ComboBoxItems.Add(condition);

            //添加项目总监筛选条件
            unit = this.m_CurrentData.DefaultView.ToTable(true, "承接人");
            condition = ComboBoxItemContent.CreateItem("承接人", unit.Rows.ForeachToStrings("承接人"));
            base.PageControl.Gantt.Controller.ComboBoxItems.Add(condition);

            //添加单据类型筛选条件
            unit = this.m_CurrentData.DefaultView.ToTable(true, "工单类型");
            condition = ComboBoxItemContent.CreateItem("工单类型", unit.Rows.ForeachToStrings("工单类型"));
            base.PageControl.Gantt.Controller.ComboBoxItems.Add(condition);
        }

        /// <summary>
        /// 过滤数据
        /// </summary>
        private void FilterData()
        {
            base.PageControl.Gantt.Controller.Rows = null;

            DataRow[] data = this.m_CurrentData.Select("1=1");

            //过滤日期
            var conditionStart = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == "起始日期");
            var conditionEnd = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == "结束日期");
            if (conditionStart.Item1 != null && conditionEnd.Item1 != null)
            {
                var result = data.Where(row =>
                (Convert.ToDateTime(row["开始时间"].ToString()) > Convert.ToDateTime(conditionStart.Item2))
                &&
                (Convert.ToDateTime(row["结束时间"].ToString()) < Convert.ToDateTime(conditionEnd.Item2))).ToArray();

                data = result;
            }
            else
            {
                return;
            }

            //筛选部门
            var condition = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == "所属部门");
            if (condition.Item1 != null)
            {
                if (condition.Item2 == "全部")
                {

                }
                else
                {
                    var result = data.Where(row => row["所属部门"].ToString() == condition.Item2).ToArray();
                    data = result;
                }
            }

            //筛选承接人
            condition = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == "承接人");
            if (condition.Item1 != null)
            {
                if (condition.Item2 == "全部")
                {

                }
                else
                {
                    var result = data.Where(row => row["承接人"].ToString() == condition.Item2).ToArray();
                    data = result;
                }
            }

            //筛选工单类型
            condition = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == "工单类型");
            if (condition.Item1 != null)
            {
                if (condition.Item2 == "全部")
                {

                }
                else
                {
                    var result = data.Where(row => row["工单类型"].ToString() == condition.Item2).ToArray();
                    data = result;
                }
            }

            var worker = new BackgroundWorker();
            base.PageControl.Gantt.Controller.Loading = true;
            worker.DoWork += (o, args) =>
            {
                LoadedData(data);
            };
            worker.RunWorkerCompleted += (o, args) =>
            {
                base.PageControl.Gantt.Controller.Loading = false;
            };
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadedData(DataRow[] rows)
        {
            ObservableCollection<DataColumn_1> data = new ObservableCollection<DataColumn_1>();

            foreach (DataRow dr in rows)
            {
                //第一列
                var column1 = dr["所属部门"].ToString();
                var row1 = data.SingleOrDefault(r => r.ColumnContent_1 == column1);
                if (row1 == null)
                {
                    row1 = new DataColumn_1();
                    row1.ColumnContent_1 = column1;
                    data.Add(row1);
                }

                //第二列
                var column2 = dr["承接人"].ToString();
                var row2 = row1.Rows.SingleOrDefault(r => r.ColumnContent_2 == column2);
                if (row2 == null)
                {
                    row2 = new DataColumn_2_5();
                    row2.ColumnContent_2 = column2;
                    row1.Rows.Add(row2);
                }

                //第三列
                var column3 = dr["项目"].ToString();
                var row3 = row2.Rows.SingleOrDefault(r => r.ColumnContent_3 == column3);
                if (row3 == null)
                {
                    row3 = new DataColumn_3();
                    row3.ColumnContent_3 = column3;
                    row2.Rows.Add(row3);
                }

                //第四列
                var dd = dr["地点"].ToString();
                var xmzj = dr["项目总监"].ToString();
                var khjl = dr["客户经理"].ToString();
                var djlx = dr["工单类型"].ToString();
                var zczj = dr["支撑总监"].ToString();
                var fazj = dr["方案专家"].ToString();
                var sxbz = dr["事项备注"].ToString();

                var gdlx = dr["工单类型"].ToString();
                var sx = dr["事项"].ToString();
                var gdzt = dr["工单状态"].ToString();
                var t1 = dr["开始时间"].ToString();
                var t2 = dr["结束时间"].ToString();

                var startTime = DateTime.Parse(t1);
                var endTime = DateTime.Parse(t2);
                //var row4 = row3.FindCanAddCell(startTime.Day, endTime.Day);
                var row4 = row3.FindCanAddCell(startTime, endTime);
                if (row4 != null)
                {
                    //row4.Cells[startTime.Day - 1].LeftThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    //row4.Cells[endTime.Day - 1].RightThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    //row4.Cells[startTime.Day - 1].ShowContent = sx;
                    row4.Cells[(startTime - GanttViewModel.StartDay).Days].LeftThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    row4.Cells[(endTime - GanttViewModel.StartDay).Days].RightThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    row4.Cells[(startTime - GanttViewModel.StartDay).Days].ShowContent = sx;

                    //公司（蓝色）、外勤（橙色）、出差（红色）、终止（灰色）、完成（绿色）
                    var color = gdlx == "产出" ? "#1E90FF" : gdlx == "外勤" ? "#FFA500" : gdlx == "出差" ? "#FF4500" : gdlx == "终止" ? "#D3D3D3" : gdlx == "完成" ? "#92D050" : "#FFFFFF";

                    //for (int i = startTime.Day - 1; i < endTime.Day; i++)
                    for (int i = (startTime - GanttViewModel.StartDay).Days; i < (endTime - GanttViewModel.StartDay).Days + 1; i++)
                    {
                        row4.Cells[i].Color = color;
                        row4.Cells[i].TipContent = $"{sxbz}";
                    }
                }
                else
                {
                    row4 = new DataColumn_4();
                    row3.Rows.Add(row4);

                    //row4.Cells[startTime.Day - 1].LeftThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    //row4.Cells[endTime.Day - 1].RightThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    //row4.Cells[startTime.Day - 1].ShowContent = sx;
                    row4.Cells[(startTime - GanttViewModel.StartDay).Days].LeftThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    row4.Cells[(endTime - GanttViewModel.StartDay).Days].RightThickness = base.PageControl.Gantt.Controller.CellLineWidth;
                    row4.Cells[(startTime - GanttViewModel.StartDay).Days].ShowContent = sx;

                    //公司（蓝色）、外勤（橙色）、出差（红色）、终止（灰色）、完成（绿色）
                    var color = gdlx == "产出" ? "#1E90FF" : gdlx == "外勤" ? "#FFA500" : gdlx == "出差" ? "#FF4500" : gdlx == "终止" ? "#D3D3D3" : gdlx == "完成" ? "#92D050" : "#FFFFFF";

                    //for (int i = startTime.Day - 1; i < endTime.Day; i++)
                    for (int i = (startTime - GanttViewModel.StartDay).Days; i < (endTime - GanttViewModel.StartDay).Days + 1; i++)
                    {
                        row4.Cells[i].Color = color;
                        row4.Cells[i].TipContent = $"{sxbz}";
                    }
                }

                //第五列
                var ts = endTime - startTime;
                row2.ColumnContent_5 += ts.TotalDays;
            }
            var rankTable = new DataTable();
            rankTable.Columns.Add("承接人");
            rankTable.Columns.Add("项目");
            rankTable.Columns.Add("人日");

            foreach (var dataColumn1 in data)
            {
                foreach (var dataColumn2_5 in dataColumn1.Rows)
                {
                   
                    foreach (var dataColumn3 in dataColumn2_5.Rows)
                    {
                        var newRow = rankTable.NewRow();
                        newRow["承接人"] = dataColumn2_5.ColumnContent_2;
                        newRow["项目"] = dataColumn3.ColumnContent_3;
                        newRow["人日"] = string.Format("{0:F2}", dataColumn2_5.ColumnContent_5);
                        rankTable.Rows.Add(newRow);
                    }
                }
            }
            base.PageControl.Gantt.Controller.Rows = new ObservableCollection<DataColumn_1>(data.OrderBy(dc => dc.ColumnContent_1));
            base.PageControl.Gantt.Screening.Controller.Rows = new DataView(rankTable);
        }

        /// <summary>
        /// 条件变更
        /// </summary>
        private void ConditionChanged(List<string> types, List<string> contents)
        {
            #region 缓存筛选条件

            for (int i = 0; i < types.Count; i++)
            {
                var condition = this.m_CurrentCondition.SingleOrDefault(vt => vt.Item1 == types[i]);
                if (condition.Item1 != null)
                {
                    this.m_CurrentCondition.Remove(condition);
                }
                condition.Item1 = types[i];
                condition.Item2 = contents[i];
                this.m_CurrentCondition.Add(condition);
            }

            #endregion

            FilterData();
        }
    }
}
