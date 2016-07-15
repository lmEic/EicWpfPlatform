using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Utility.Common;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;
using System.Threading;
using System.Threading.Tasks;

namespace Lm.Eic.App.Mes.Business.Daily.Reports
{
    public class MsOne : ReportBase, IReport
    {
        public new void ExportReportToExcel(IList<BPM_Daily> DailyList)
        {
            try
            {
                ExportReportMsOne(DailyList.Where(m => !m.OrderID.StartsWith("520")));
                ExportReportMsSix(DailyList.Where(m => m.OrderID.StartsWith("520") && !m.AssetNum.IsNullOrEmpty()));
                ExportReportMsSix_Assist(DailyList.Where(m => m.OrderID.StartsWith("520") && m.AssetNum.IsNullOrEmpty()),
                DailyList.Where(m => m.OrderID.StartsWith("520") && !m.AssetNum.IsNullOrEmpty()).Count()+8);

                FileStream fs2 = File.Create(FileName);
                Wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                msg.MessageInfo("提示：创建成功！");
            }
            catch (Exception ex) { msg.MessageInfo(ex.Message); }
        }

        //导出制一课的日报
        private void ExportReportMsOne(IEnumerable<BPM_Daily> DataListMsOne)
        {
            List<BPM_Daily> ReportDataList = new List<BPM_Daily>();
            var CacheProcessList = Operation.BpmHeper.Process.GetModelList(m => m.Department == Department.STR_MsOne || m.Department == Department.STR_DpOne); //制一部工序列表

           
            foreach (var daily in DataListMsOne)
            {
                if (ReportDataList.FirstOrDefault(m => m.OrderID == daily.OrderID) == null) //如果在待导出的日报列表中未找到此工单  进行汇总计算
                {
                    var temdaily = ExList.ModelCopy(daily);
                    var temProductAlias = $"{temdaily.ProductName.Replace("-", "")}-";
                    temdaily.StandardHours = Math.Round(Convert.ToDouble(CacheProcessList.Where(m => m.ProcessID.StartsWith(temProductAlias)).Sum(x => x.StandardHours)), 2);
                    temdaily.TotalWorkHoursPmc = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Where(m => m.ProcessSign == "结束站").Sum(x => x.Qty);  //实际产出 = 工序为包装的产量总和
                    temdaily.QtyOK = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Sum(x => x.QtyOK);  //各工序产出合计
                    temdaily.QtyNG = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Sum(x => x.QtyNG);  //各工序不良合计
                    temdaily.WorkHours = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Sum(x => x.WorkHours);  //生产工时之和
                    temdaily.NotWorkHours = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Sum(x => x.NotWorkHours);  //非生产工时之和
                     
                    temdaily.Fpy = 1.00;
                    Parallel.ForEach(DataListMsOne.Where(m => m.OrderID == daily.OrderID), tt =>
                        {
                            temdaily.Fpy = temdaily.Fpy * tt.Fpy;
                        });

                    temdaily.TotalWorkHoursStandard = DataListMsOne.Where(m => m.OrderID == daily.OrderID).Sum(x => x.Qty * x.StandardHours) / 3600;
                    //得到工时 =  SUM（每道工序的产量*标准工时）
                    //直通率 =各工序的良率相乘
                    ReportDataList.Add(temdaily);
                }
            }

            #region Export
            CreateFileFromTemplate(@"\\192.168.0.65\Templates\DailyReports\DailyReportMsOne.xlsx");
            //导出制一课日报
            ISheet tb2 = Wk.GetSheet(Wk.GetSheetName(0));
            IRow row;
            //写入日报的日期
            tb2.GetRow(2).GetCell(22).SetCellValue(DataListMsOne.ToList()[0].Date.Value.Date.ToString("yyyy-MM-dd"));
            int t2 = 5;
            CopyRow(tb2, 5, 2, ReportDataList.Count);  //生成占位行
            foreach (var temmodul in ReportDataList)
            {
                row = tb2.GetRow(t2);
                row.GetCell(0).SetCellValue(temmodul.AssetNum);                                       //机台编号
                row.GetCell(1).SetCellValue(temmodul.OrderID);                                        //工单单号
                row.GetCell(2).SetCellValue(temmodul.ProductName);                                    //品名
                row.GetCell(3).SetCellValue(temmodul.Spec);                                           //规格 
                row.GetCell(4).SetCellValue(Convert.ToDouble(temmodul.OrderCount));                   //批量
                row.GetCell(5).SetCellValue(Convert.ToDouble(temmodul.StandardHours));                //PCS/H
                                                                                                      // row.GetCell(6).SetCellValue(Convert.ToDouble(temmodul.Qty));                        //计划产出
                row.GetCell(7).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursPmc));            //实际产出 = 工序为包装的产量总和
                row.GetCell(8).SetCellValue(0);                                                       //本日入库 = 0
                row.GetCell(9).SetCellValue(Convert.ToDouble(temmodul.QtyOK));                          //各工序产出合计 = 各工序产出总和 PS:包括包装
                row.GetCell(10).SetCellValue(Convert.ToDouble(temmodul.QtyNG));                       //各工序不良合计 = 各工序不良总和 PS:包括包装
                row.GetCell(11).SetCellValue(Convert.ToDouble(temmodul.Fpy));                         //直通率
                CreateFormulaCell(row.GetCell(12), $"K{t2 + 1}/J{t2 + 1}", null);                     //不良率 = 不良数/总产出
                CreateFormulaCell(row.GetCell(13), $" O{t2 + 1} + P{t2 + 1}", null);                  //投入工时
                row.GetCell(14).SetCellValue(Convert.ToDouble(temmodul.WorkHours));                   // 作业工时
                row.GetCell(15).SetCellValue(Convert.ToDouble(temmodul.NotWorkHours));                //非作业工时
                row.GetCell(16).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursStandard));      //得到工时
                CreateFormulaCell(row.GetCell(17), $"Q{t2 + 1}/N{t2 + 1}", null);                     //生产效率 = 得到工时/投入工时
                CreateFormulaCell(row.GetCell(18), $"Q{t2 + 1}/O{t2 + 1}", null);                     //作业效率 = 得到工时/作业工时
                CreateFormulaCell(row.GetCell(19), $"IF((N{t2 + 1}-P{t2 + 1})<>0,O{t2 + 1}/(N{t2 + 1}-P{t2 + 1}),0)", null);             //线平衡率
                CreateFormulaCell(row.GetCell(20), $"H{t2 + 1}/G{t2 + 1}", null);                     //本日达成率 = 实际产出/计划产出
                CreateFormulaCell(row.GetCell(21), $"X{t2 + 1}/W{t2 + 1}", null);                     //本日累计达成率 = 实际产出累计/计划产出累计
                // row.GetCell(22).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursStandard));   //计划产出累计

                var orderDailyList = Business.Operation.DailyHelper.Daily.GetModelList(m => m.OrderID == temmodul.OrderID);
                var allQty = orderDailyList.Where(m=>m.ProcessSign== "结束站").Sum(m => m.Qty);
                var allWorkHours = orderDailyList.Sum(m => m.WorkHours);
                row.GetCell(23).SetCellValue(Convert.ToDouble(allQty));                              //实际产出累计
                row.GetCell(24).SetCellValue(Convert.ToDouble(allWorkHours));                        //投入工时累计
                t2++;
            }

            //生成底部公式
            row = tb2.GetRow(t2);
            CreateFormulaCell(row.GetCell(6), $"SUM(G6:G{t2})", null);             
            CreateFormulaCell(row.GetCell(7), $"SUM(H6:H{t2})", null);
            CreateFormulaCell(row.GetCell(8), $"SUM(I6:I{t2})", null);
            CreateFormulaCell(row.GetCell(9), $"SUM(J6:J{t2})", null);
            CreateFormulaCell(row.GetCell(10), $"SUM(K6:K{t2})", null);
            CreateFormulaCell(row.GetCell(11), $"AVERAGEA(L6:L{t2})", null);
            CreateFormulaCell(row.GetCell(12), $" IF(J{t2+1} <> 0, K{t2+1} / J{t2+1}, 0)", null);
            CreateFormulaCell(row.GetCell(13), $"SUM(N6:N{t2})", null);
            CreateFormulaCell(row.GetCell(14), $"SUM(O6:O{t2})", null);
            CreateFormulaCell(row.GetCell(15), $"SUM(P6:P{t2})", null);
            CreateFormulaCell(row.GetCell(16), $"SUM(Q6:Q{t2})", null);
            CreateFormulaCell(row.GetCell(17), $"IF(N{t2 + 1}<>0,Q{t2 + 1}/N{t2 + 1},0)", null);
            CreateFormulaCell(row.GetCell(18), $"IF(O{t2 + 1}<>0,Q{t2 + 1}/O{t2 + 1},0)", null);
            CreateFormulaCell(row.GetCell(19), $"IF((N{t2 + 1}-P{t2 + 1})<>0,O{t2 + 1}/(N{t2 + 1}-P{t2 + 1}),0)", null);
            CreateFormulaCell(row.GetCell(20), $"IF(G{t2 + 1}<>0,H{t2 + 1}/G{t2 + 1},0)", null);
            CreateFormulaCell(row.GetCell(21), $"IF(W{t2 + 1}<>0,W{t2 + 1}/X{t2 + 1},0)", null);
            CreateFormulaCell(row.GetCell(22), $"SUM(W6:W{t2})", null);
            CreateFormulaCell(row.GetCell(23), $"SUM(X6:X{t2})", null);
            CreateFormulaCell(row.GetCell(24), $"SUM(Y6:Y{t2})", null);
            CreateFormulaCell(row.GetCell(26), $"SUM(AA6:AA{t2})", null);


            Wk.Write(File.Create(FileName));   //向打开的这个xls文件中写入mySheet表并保存。
            #endregion Export
        }

        /// <summary>
        /// 导出制六课的日报
        /// </summary>
        private void ExportReportMsSix(IEnumerable<BPM_Daily> DataListMsSix)
        {
            CreateFileFromTemplate(@"\\192.168.0.65\Templates\DailyReports\DailyReportMsSix.xlsx");

            //导出汇总
            ISheet tb = Wk.GetSheet(Wk.GetSheetName(0));
            IRow row;
            tb.GetRow(2).GetCell(20).SetCellValue(DataListMsSix.ToList()[0].Date.Value.Date.ToString("yyyy-MM-dd"));
            int t = 5;
            CopyRow(tb, 5, 2, DataListMsSix.Count());  //生成占位行
            foreach (var temmodul in DataListMsSix)   //导出制六课日报
            {
                row = tb.GetRow(t);
                row.GetCell(0).SetCellValue(temmodul.AssetNum);                                                      //机台编号
                row.GetCell(1).SetCellValue(temmodul.OrderID);                                                       //工单单号
                row.GetCell(2).SetCellValue(temmodul.ProductName);                                                   //品名
                row.GetCell(3).SetCellValue(temmodul.ProcessName);                                                   //规格 PS：制六规格=工序名
                row.GetCell(4).SetCellValue(Convert.ToDouble(temmodul.OrderCount));                                  //批量
                row.GetCell(5).SetCellValue(Math.Round(Convert.ToDouble(3600 / temmodul.StandardHours)));            //PCS/H
                row.GetCell(6).SetCellValue(Convert.ToDouble(temmodul.Qty));                                         //产量
                row.GetCell(7).SetCellValue(Convert.ToDouble(temmodul.QtyNG));                                       //不良数量
                CreateFormulaCell(row.GetCell(8), $"IF(G{t+1}=0,0,H{t + 1}/G{t + 1})", null);                //不良率 = 不良数/本日产出
                row.GetCell(9).SetCellValue(Convert.ToDouble(temmodul.SetHours));                                    //设置时数
                row.GetCell(10).SetCellValue(Convert.ToDouble(temmodul.WorkHours));                                  //投入工时 = 作业工时
                row.GetCell(11).SetCellValue(Convert.ToDouble(temmodul.WorkHours));                                  //作业工时
                row.GetCell(12).SetCellValue(Convert.ToDouble(temmodul.AttendanceHours));                            //出勤时数
                CreateFormulaCell(row.GetCell(13), $"J{t + 1}-L{t+1}", null);                                //非生产工时 = 设置时数 -作业工时
                row.GetCell(14).SetCellValue(Convert.ToDouble(Math.Round(Convert.ToDouble(temmodul.TotalWorkHoursStandard), 2)));            //得到工时
                CreateFormulaCell(row.GetCell(15), $"IF(J{t + 1}=0,0,L{t + 1}/J{t + 1})", null);             //稼动率 = 作业工时/设置时数                 
                CreateFormulaCell(row.GetCell(16), $"IF(K{t + 1}=0,0,O{t + 1}/K{t + 1})", null);             //生产效率 = 得到工时/投入工时                 
                CreateFormulaCell(row.GetCell(17), $"IF(L{t + 1}=0,0,O{t + 1}/L{t + 1})", null);             //作业效率 = 得到工时/作业工时                
                CreateFormulaCell(row.GetCell(18), $"IF(M{t + 1}=0,0,L{t + 1}/M{t + 1})", null);             //人机配比 = 作业工时/出勤工时                
                row.GetCell(19).SetCellValue(temmodul.Name);            //作业员
                t++;
            }


            //生成底部公式
            row = tb.GetRow(t);
            CreateFormulaCell(row.GetCell(6), $"SUM(G6:G{t})", null);
            CreateFormulaCell(row.GetCell(7), $"SUM(H6:H{t})", null);
            CreateFormulaCell(row.GetCell(8), $"IF(G{t+1}=0,0,H{t+1}/G{t+1})", null);
            CreateFormulaCell(row.GetCell(9), $"SUM(J6:J{t})", null);
            CreateFormulaCell(row.GetCell(10), $"SUM(K6:K{t})", null);
            CreateFormulaCell(row.GetCell(11), $"SUM(L6:L{t})", null);
            CreateFormulaCell(row.GetCell(12), $"SUM(M6:M{t})", null);
            CreateFormulaCell(row.GetCell(13), $"SUM(N6:N{t})", null);
            CreateFormulaCell(row.GetCell(14), $"SUM(O6:O{t})", null);
            CreateFormulaCell(row.GetCell(15), $"IF(J{t+1}=0,0,L{t+1}/J{t+1})", null);
            CreateFormulaCell(row.GetCell(16), $"IF(K{t + 1}=0,0,O{t + 1}/K{t + 1})", null);
            CreateFormulaCell(row.GetCell(17), $"IF(N{t + 1}<>0,Q{t + 1}/N{t + 1},0)", null);
            CreateFormulaCell(row.GetCell(18), $"IF(L{t+1}=0,0,O{t+1}/L{t+1})", null);
            CreateFormulaCell(row.GetCell(19), $"IF(M{t+1}=0,0,L{t+1}/M{t+1})", null);
           

            Wk.Write(File.Create(FileName));   //向打开的这个xls文件中写入mySheet表并保存。
        }

        /// <summary>
        /// 导出制六课的日报 辅助工序
        /// </summary>
        private void ExportReportMsSix_Assist(IEnumerable<BPM_Daily> DataListMsSix,int StartRow)
        {

            //导出汇总
            ISheet tb = Wk.GetSheet(Wk.GetSheetName(0));
            IRow row;

            int t = StartRow;
            CopyRow(tb, StartRow, 4, DataListMsSix.Count());  //生成占位行
            foreach (var temmodul in DataListMsSix)   //导出制六课日报
            {
                row = tb.GetRow(t);
                row.GetCell(1).SetCellValue(temmodul.OrderID);                                                         //工单单号
                row.GetCell(2).SetCellValue(temmodul.ProductName);                                                     //品名
                row.GetCell(3).SetCellValue(temmodul.ProcessName);                                                     //规格 PS：制六规格=工序名
                row.GetCell(4).SetCellValue(Convert.ToDouble(temmodul.OrderCount));                                    //批量
                row.GetCell(5).SetCellValue(Math.Round(Convert.ToDouble(3600 / temmodul.StandardHours)));              //标准工时
                row.GetCell(6).SetCellValue(Convert.ToDouble(temmodul.Qty));                                           //产量
               // row.GetCell(7).SetCellValue(Convert.ToDouble(temmodul.QtyNG));            //非工序产出
                row.GetCell(8).SetCellValue(Convert.ToDouble(temmodul.QtyNG));                                         //不良数量
                CreateFormulaCell(row.GetCell(9), $"IF(G{t+1}=\"\",0,I{t+1}/G{t+1})", null);
                row.GetCell(10).SetCellValue(Convert.ToDouble(temmodul.InputHours));                                   //投入工时 = 作业工时
                row.GetCell(11).SetCellValue(Convert.ToDouble(temmodul.WorkHours));                                    //作业工时
                row.GetCell(12).SetCellValue(Convert.ToDouble(temmodul.NotWorkHours));                                 //非作业工时
                row.GetCell(13).SetCellValue(Convert.ToDouble(Math.Round(Convert.ToDouble(temmodul.TotalWorkHoursStandard), 2)));            //得到工时
                CreateFormulaCell(row.GetCell(14), $"IF(ISERROR(N{t+1}/K{t+1}),0,N{t+1}/K{t+1})", null);
                CreateFormulaCell(row.GetCell(15), $"IF(ISERROR(N{t + 1}/K{t + 1}),0,N{t + 1}/K{t + 1})", null);
                row.GetCell(16).SetCellValue(temmodul.Name);                                                            //作业员
                t++;
            }

            //生成底部公式
            row = tb.GetRow(t);
            CreateFormulaCell(row.GetCell(6), $"SUM(G{StartRow-1}:G{t})", null);
            CreateFormulaCell(row.GetCell(7), $"SUM(H{StartRow-1}:H{t})", null);
            CreateFormulaCell(row.GetCell(8), $"SUM(I{StartRow-1}:I{t})", null);
            CreateFormulaCell(row.GetCell(9), $"IF(G{t+1}=0,\"\",I{t+1}/G{t+1})", null);
            CreateFormulaCell(row.GetCell(10), $"SUM(K{StartRow-1}:K{t})", null);
            CreateFormulaCell(row.GetCell(11), $"SUM(L{StartRow-1}:L{t})", null);
            CreateFormulaCell(row.GetCell(12), $"SUM(M{StartRow-1}:M{t})", null);
            CreateFormulaCell(row.GetCell(13), $"SUM(N{StartRow-1}:N{t})", null);
            CreateFormulaCell(row.GetCell(14), $"IF(K{t+1}=0,\"\",N{t+1}/K{t+1})", null);
            CreateFormulaCell(row.GetCell(15), $"IF(L{t+1}=0,\"\",N{t+1}/L{t+1})", null);


            //生成日报求和公式
            t = t + 2;
            row = tb.GetRow(t);
            CreateFormulaCell(row.GetCell(7), $"SUM(G{t-1},H{t-1},G{t-8})", null);
            CreateFormulaCell(row.GetCell(8), $"SUM(I{t - 1},H{t - 8})", null);
            CreateFormulaCell(row.GetCell(9), $"IF(H{t+1}=0,\"\",I{t+1}/H{t+1})", null);
            CreateFormulaCell(row.GetCell(10), $"SUM(K{t - 1},K{t - 8})", null);
            CreateFormulaCell(row.GetCell(11), $"SUM(L{t - 1},L{t - 8})", null);
            CreateFormulaCell(row.GetCell(12), $"SUM(M{t - 1},N{t - 8})", null);
            CreateFormulaCell(row.GetCell(13), $"SUM(N{t - 1},O{t - 8})", null);
            CreateFormulaCell(row.GetCell(14), $"IF(K{t+1}=0,\"\",N{t+1}/K{t+1})", null);
            CreateFormulaCell(row.GetCell(15), $"IF(L{t+1}=0,\"\",N{t+1}/L{t+1})", null);
        }
    }
}