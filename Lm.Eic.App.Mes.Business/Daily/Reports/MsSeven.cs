using Lm.Eic.App.Mes.Model;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using msg = ZhuiFengLib.Message.Message;
using ZhuiFengLib.Extension;
using System.Linq;

namespace Lm.Eic.App.Mes.Business.Daily.Reports
{
    public class MsSeven : ReportBase, IReport
    {
        public new void ExportReportToExcel(IList<Bpm_Daily> DailyList)
        {
            try
            {
                CreateFileFromTemplate(@"\\192.168.0.65\Templates\DailyReports\DailyReportMsSeven.xlsx");
                ISheet tb = Wk.GetSheet(Wk.GetSheetName(0));
                //写入日报的日期
                tb.GetRow(3).GetCell(0).SetCellValue($"录入日期:{DailyList[0].Date.Value.Date.ToString("yyyy-MM-dd")}");
                int RowIndex = 7;
                // RowIndex = CreartReport(DailyList.Where(m => !m.AssetNum.IsNullOrEmpty() && m.AssetName.StartsWith("CNC")).ToList().ListSort("AssetNum", "asc"), tb, RowIndex);
                var temList = DailyList.Where(m => !m.AssetNum.IsNullOrEmpty() && m.AssetName.StartsWith("CNC")).ToList();
                temList.Sort(new AssNumComparer());
                RowIndex = CreartReport(temList, tb, RowIndex);

                temList = DailyList.Where(m => !m.AssetNum.IsNullOrEmpty() && !m.AssetName.StartsWith("CNC")).ToList();
                temList.Sort(new AssNumComparer());
                RowIndex = CreartReport(temList, tb, RowIndex + 6);

                temList = DailyList.Where(m => m.AssetNum.IsNullOrEmpty()).ToList();
               // temList.Sort(new AssNumComparer());
                RowIndex = CreartReport(temList, tb, RowIndex + 5);
                //向打开的这个xls文件中写入mySheet表并保存。
                Wk.Write(File.Create(FileName));
                msg.MessageInfo("提示：创建成功！");
            }
            catch (Exception ex) { msg.MessageInfo(ex.Message); }
        }

        /// 创建日报
        private int CreartReport(IList<Bpm_Daily> DailyList, ISheet tb, int RowIndex)
        {
            if (DailyList.Count > 0)
            {
                CopyRow(tb, RowIndex, 2, DailyList.Count);  //生成占位行
                foreach (var temmodul in DailyList)        //导出制六课日报
                {
                    InsertModelToExcel(temmodul, tb.GetRow(RowIndex), RowIndex + 1);
                    RowIndex++;
                }
            }
            InsertFormulaToExcel(tb.GetRow(RowIndex), DailyList, RowIndex - DailyList.Count);
            return RowIndex;
        }

        /// 向Excel中插入一条数据
        private void InsertModelToExcel(Bpm_Daily temmodul, IRow row, int RowIndex)
        {
            if (!temmodul.AssetNum.IsNullOrEmpty())
                row.GetCell(0).SetCellValue($"{temmodul.AssetName}-{temmodul.AssetNum}");       //机台编号

            row.GetCell(1).SetCellValue(temmodul.OrderID);                                      //工单单号
            row.GetCell(2).SetCellValue(temmodul.ProductName);                                  //品名
            row.GetCell(3).SetCellValue(temmodul.Spec);                                         //规格  
            row.GetCell(4).SetCellValue(temmodul.ProcessName);                                  //工艺名称
            row.GetCell(5).SetCellValue(temmodul.ProcessID);                                    //工序
            row.GetCell(6).SetCellValue(temmodul.Name);                                         //作业员
            row.GetCell(7).SetCellValue(temmodul.MasterName);                                   //师傅
            row.GetCell(8).SetCellValue(Convert.ToDouble(temmodul.StandardHours));              //标准工时
            row.GetCell(9).SetCellValue(Convert.ToDouble(temmodul.Qty));                        //产量
            row.GetCell(10).SetCellValue(Convert.ToDouble(temmodul.QtyNG));                     //不良数
            row.GetCell(11).SetCellValue(Convert.ToDouble(temmodul.SetHours));                  //设置时数
                                                                                                //  row.GetCell(12).SetCellValue(Convert.ToDouble(temmodul.AttendanceHours));          //上班时数
            row.GetCell(13).SetCellValue(Convert.ToDouble(temmodul.InputHours));                //投入工时
            row.GetCell(14).SetCellValue(Convert.ToDouble(temmodul.WorkHours));                 //生产时数
            row.GetCell(15).SetCellValue(Convert.ToDouble(temmodul.AttendanceHours));           //出勤时数
            row.GetCell(16).SetCellValue(Convert.ToDouble(temmodul.NotWorkHours));              //非生成时数
            CreateFormulaCell(row.GetCell(17), $"IF(L{RowIndex}<>0,O{RowIndex}/L{RowIndex},0)", null);                                                  //稼动率
            CreateFormulaCell(row.GetCell(18), $"IF(ISERROR(X{RowIndex}/N{RowIndex}*100%),0,(X{RowIndex}/N{RowIndex}*100%))", null);                    //生成效率
            CreateFormulaCell(row.GetCell(19), $"IF(ISERROR(X{RowIndex} / O{RowIndex} * 100 %), 0, (X{RowIndex} / O{RowIndex} * 100 %))", null);        //作业效率
            CreateFormulaCell(row.GetCell(20), $"IF(ISERROR(K{RowIndex} / J{RowIndex}), 0, K{RowIndex} / J{RowIndex})", null);                          //不良率
            row.GetCell(21).SetCellValue(temmodul.ClassType);                                   //班别
            row.GetCell(22).SetCellValue(Convert.ToDouble(temmodul.Qty));                       //入库数
            CreateFormulaCell(row.GetCell(23), $"IF(ISERROR(J{RowIndex}/I{RowIndex}),0,(J{RowIndex}/I{RowIndex}))", null);                              //得到工时
            row.GetCell(24).SetCellValue(temmodul.Date.Value.Date.ToString("yyyy-MM-dd"));      //日期

        }

        /// <summary>
        /// 写入求和日报底部汇总公式
        /// </summary>
        /// <param name="RowIndex"></param>
        private void InsertFormulaToExcel(IRow row, IList<Bpm_Daily> DailyList, int startRowIndex)
        {
            int temRwoIndex = DailyList.Count + startRowIndex;
            // row.GetCell(1).SetCellValue($"本日開機台數：{DailyList.Count}台");
            CreateFormulaCell(row.GetCell(9), $"SUM(J{startRowIndex}:J{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(10), $"SUM(K{startRowIndex}:K{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(11), $"SUM(L{startRowIndex}:L{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(12), $"SUM(M{startRowIndex}:M{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(13), $"SUM(N{startRowIndex}:N{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(14), $"SUM(O{startRowIndex}:O{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(15), $"SUM(P{startRowIndex}:P{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(16), $"SUM(Q{startRowIndex}:Q{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(17), $"IF(L{temRwoIndex}<>0,O{temRwoIndex}/L{temRwoIndex},0)", null);
            CreateFormulaCell(row.GetCell(18), $"IF(ISERROR(X{temRwoIndex}/N{temRwoIndex}*100%),0,(X{temRwoIndex}/N{temRwoIndex}*100%))", null);                    //生成效率
            CreateFormulaCell(row.GetCell(19), $"IF(ISERROR(X{temRwoIndex} / O{temRwoIndex} * 100 %), 0, (X{temRwoIndex} / O{temRwoIndex} * 100 %))", null);        //作业效率
            CreateFormulaCell(row.GetCell(20), $"IF(ISERROR(K{temRwoIndex} / J{temRwoIndex}), 0, K{temRwoIndex} / J{temRwoIndex})", null);                          //不良率
            CreateFormulaCell(row.GetCell(22), $"SUM(W{startRowIndex}:W{startRowIndex + DailyList.Count})", null);
            CreateFormulaCell(row.GetCell(23), $"SUM(X{startRowIndex}:X{startRowIndex + DailyList.Count})", null);
        }



        public class AssNumComparer : IComparer<Bpm_Daily>
        {
            public int Compare(Bpm_Daily x, Bpm_Daily y)
            {
                try
                {
                    int temX = Convert.ToInt32(x.AssetNum);
                    int temY = Convert.ToInt32(y.AssetNum);
                    if (temX > temY) return 1;
                    if (temX < temY) return -1;
                    return 0;
                }
                catch
                {
                    return x.AssetNum.ToString().CompareTo(y.AssetNum.ToString());
                }
            }
        }
    }
}