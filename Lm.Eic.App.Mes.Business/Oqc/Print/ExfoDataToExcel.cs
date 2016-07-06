using System;
using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.Business.Oqc.Print
{
    public class ExfoDataToExcel
    {

        /// <summary>  
        /// 写入Excel文档  
        /// </summary>  
        /// <param name="Path">文件名称</param>  
        private bool SaveFP2toExcel(string ExcelName, string _lineName, string _lineValue)
        {
            try
            {
                string Path = $"D:\\模板\\PrintTemplates\\Data_Source\\{ExcelName}.xlsx";
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                //插入数据的命令
                cmd.CommandText = $"INSERT INTO [sheet1$] {_lineName} VALUES {_lineValue}";
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                msg.MessageErr("写入Excel发生错误：" + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 清除指定Excel中的数据
        /// </summary>
        /// <param name="_Patch"></param>
        /// <returns></returns>
        public bool Delete_ExcelData(string _Patch, int start, int end)
        {
            try
            {
                // kill_Process("excel");
                //将数据填充到模板
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null) { return false; }
                xlApp.Workbooks._Open(_Patch);
                Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
                //删除指定区域
                for (int t = start; t < end; t++)
                {
                    Excel.Range m_objRange = (Excel.Range)oSheet.Rows[t, System.Reflection.Missing.Value];
                    m_objRange.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }

                //填充完成后的操作          
                xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
                xlApp.AlertBeforeOverwriting = false;
                xlApp.SaveWorkspace(); //保存工作簿  
                xlApp.Quit();          //确保Excel进程关闭  
                xlApp = null;
                GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出 
                return true;
            }
            catch (SyntaxErrorException ex)
            {
                msg.MessageErr(ex.Message);
                return false;
            }
        }

        private bool kill_Process(string _ProcessName)
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(_ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
            return true;
        }


    }
}
