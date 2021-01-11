using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DXY.WorkSheet
{
    public static class Hepler
    {
        /// <summary>
        /// 获取数据表
        /// </summary>
        public static DataTable GetData(string filePath, string sheetName)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0; HDR=YES; IMEX=1'";
            string selectCommandText = $"SELECT * FROM [{sheetName}$]";

            using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText, connectionString))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 遍历所有行，提取某一列内容集合
        /// </summary>
        public static IEnumerable<string> ForeachToStrings(this DataRowCollection rows, string columnName)
        {
            var result = new List<string>();
            foreach (DataRow row in rows)
            {
                result.Add(row[columnName].ToString());
            }

            result = new List<string>(result.OrderBy(s => s));
            return result;
        }

        /// <summary>
        /// 遍历所有行，获取符合年月的数据
        /// </summary>
        public static DataRow[] ForeachToRows(this DataRowCollection rows, string columnName1, string columnName2, DateTime current)
        {
            var result = new List<DataRow>();
            foreach (DataRow row in rows)
            {
                var data1 = DateTime.Parse(row[columnName1].ToString());
                var data2 = DateTime.Parse(row[columnName2].ToString());

                if (data1.ToString("yyyy-MM") == current.ToString("yyyy-MM") && data2.ToString("yyyy-MM") == current.ToString("yyyy-MM"))
                {
                    result.Add(row);
                }
            }

            return result.ToArray();
        }
    }
}
