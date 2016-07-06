using Lm.Eic.App.Mes.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ZhuiFengLib.Extension;

namespace Lm.Eic.App.Mes.Business.Daily.Reports
{
    public interface IReport
    {
        /// <summary>
        /// 导出日报到Excel
        /// </summary>
        /// <param name="dataList"></param>
        void ExportReportToExcel(IList<Model.Bpm_Daily> dataList);

        /// <summary>
        /// 葱样板简历档案
        /// </summary>
        /// <param name="TemplateFileName"></param>
        /// <param name="OutputFileName"></param>
        void CreateFileFromTemplate(string TemplateFileName);
    }

    public class ReportBase : IReport
    {
        public void ExportReportToExcel(IList<Bpm_Daily> dataList)
        {
            // throw new NotImplementedException();
        }

        private void InitializeWorkbook()
        {
            if (!FileName.IsNullOrEmpty())
            {
                Wk = WorkbookFactory.Create(FileName);

                FontOne = new HSSFFont(NPOI.HSSF.Util.HSSFColor.Blue.Index, new NPOI.HSSF.Record.FontRecord());
                FontOne.FontName = "宋体";
                FontOne.FontHeightInPoints = 11;

                CellStyleOne = Wk.CreateCellStyle();
                CellStyleOne.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

                CellStyleTwo = Wk.CreateCellStyle();
                CellStyleTwo.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                CellStyleTwo.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Blue.Index;
               // CellStyleTwo.SetFont(FontOne);
            }
        }

        public IWorkbook Wk { get; set; }

        /// <summary>
        /// 无小数点的整数
        /// </summary>
        public ICellStyle CellStyleOne { get; set; }

        /// <summary>
        /// 保留两位小数点
        /// </summary>
        public ICellStyle CellStyleTwo { get; set; }

        /// <summary>
        /// 蓝色 宋体 11号字体
        /// </summary>
        public HSSFFont FontOne { get; set; }

        /// <summary>
        /// 完整的日报文件名称
        /// </summary>
        public string FileName { get; set; }

        /// 從樣板建立檔案.
        public void CreateFileFromTemplate(string TemplateFileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileName = sfd.FileName.ToString();
                //获得文件路径
                File.Copy(TemplateFileName, sfd.FileName.ToString(), true);
                InitializeWorkbook();
            }
        }

        public void CopyRange(ISheet sheet, int fromRowIndex, int fromColIndex, int toRowIndex, int toColIndex, bool onlyData)
        {
            IRow sourceRow = sheet.GetRow(fromRowIndex);
            ICell sourceCell = sourceRow.GetCell(fromColIndex);
            if (sourceRow != null && sourceCell != null)
            {
                IRow changingRow = null;
                ICell changingCell = null;
                changingRow = sheet.GetRow(toRowIndex);
                if (changingRow == null)
                    changingRow = sheet.CreateRow(toRowIndex);
                changingCell = changingRow.GetCell(toColIndex);
                if (changingCell == null)
                    changingCell = changingRow.CreateCell(toColIndex);

                if (onlyData)//仅数据
                {
                    //对单元格的值赋值
                    changingCell.SetCellValue(sourceCell.StringCellValue);
                }
                else         //非仅数据
                {
                    //单元格的编码
                    //changingCell.Encoding = sourceCell.Encoding;
                    //单元格的格式
                    changingCell.CellStyle = sourceCell.CellStyle;
                    //单元格的公式
                    //if (sourceCell.CellFormula == "")
                    changingCell.SetCellValue(sourceCell.StringCellValue);
                    //else
                    //    changingCell.SetCellFormula(sourceCell.CellFormula);
                }
            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        /// <summary>
        /// 复制行格式并插入指定行数
        /// </summary>
        /// <param name="sheet">当前sheet</param>
        /// <param name="startRowIndex">起始行位置</param>
        /// <param name="sourceRowIndex">模板行位置</param>
        /// <param name="insertCount">插入行数</param>
        public void CopyRow(ISheet sheet, int startRowIndex, int sourceRowIndex, int insertCount)
        {
            ISheet sourceSheet = Wk.GetSheet(Wk.GetSheetName(1));
            IRow sourceRow = sourceSheet.GetRow(sourceRowIndex);
            int sourceCellCount = sourceRow.Cells.Count;

            //1. 批量移动行,清空插入区域
            sheet.ShiftRows(startRowIndex, //开始行
                            sheet.LastRowNum, //结束行
                            insertCount, //插入行总数
                            true,        //是否复制行高
                            false        //是否重置行高
                            );

            int startMergeCell = -1; //记录每行的合并单元格起始位置
            for (int i = startRowIndex; i < startRowIndex + insertCount; i++)
            {
                IRow targetRow = null;
                ICell oldCell = null;
                ICell newCell = null;

                targetRow = sheet.CreateRow(i);
                targetRow.Height = sourceRow.Height;//复制行高

                for (int m = sourceRow.FirstCellNum; m < sourceRow.LastCellNum; m++)
                {
                    oldCell = sourceRow.GetCell(m);
                    newCell = targetRow.CreateCell(m);

                    // If the old cell is null jump to next cell
                    if (oldCell == null)
                    {
                        newCell = null;
                        continue;
                    }

                    // Set the cell data value
                    CopyCell(oldCell, newCell);

                    startMergeCell = MergeCell(sheet, sourceCellCount, startMergeCell, i, oldCell, m);
                }
            }
        }

        /// 合并单元格
        private int MergeCell(ISheet sheet, int sourceCellCount, int startMergeCell, int i, ICell oldCell, int m)
        {
            if (oldCell.IsMergedCell)
            {
                if (startMergeCell <= 0)
                    startMergeCell = m;
                else if (startMergeCell > 0 && sourceCellCount == m + 1)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m));
                    startMergeCell = -1;
                }
            }
            else
            {
                if (startMergeCell >= 0)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m - 1));
                    startMergeCell = -1;
                }
            }

            return startMergeCell;
        }
        
        /// <summary>
        /// CopyCell
        /// </summary>
        /// <param name="oldCell"></param>
        /// <param name="newCell"></param>
        public ICell CopyCell(ICell oldCell, ICell newCell)
        {
            // Copy style from old cell and apply to new cell
            var newCellStyle = Wk.CreateCellStyle();
            newCellStyle.CloneStyleFrom(oldCell.CellStyle); ;
            newCell.CellStyle = newCellStyle;

            // If there is a cell comment, copy
            if (newCell.CellComment != null) newCell.CellComment = oldCell.CellComment;

            // If there is a cell hyperlink, copy
            if (oldCell.Hyperlink != null) newCell.Hyperlink = oldCell.Hyperlink;

            // Set the cell data type
            newCell.SetCellType(oldCell.CellType);

            switch (oldCell.CellType)
            {
                case CellType.Blank:
                    newCell.SetCellValue(oldCell.StringCellValue);
                    break;

                case CellType.Boolean:
                    newCell.SetCellValue(oldCell.BooleanCellValue);
                    break;

                case CellType.Error:
                    newCell.SetCellErrorValue(oldCell.ErrorCellValue);
                    break;

                case CellType.Formula:
                    newCell.SetCellFormula(oldCell.CellFormula);
                    break;

                case CellType.Numeric:
                    newCell.SetCellValue(oldCell.NumericCellValue);
                    break;

                case CellType.String:
                    newCell.SetCellValue(oldCell.RichStringCellValue);
                    break;

                case CellType.Unknown:
                    newCell.SetCellValue(oldCell.StringCellValue);
                    break;
            }

            return newCell;
        }

        /// <summary>
        /// 生成有公式的单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="Formula">公式</param>
        /// <param name="cellStyle">样式 PS：如果不设置格式 请设置为Null</param>
        public void CreateFormulaCell(ICell cell, string Formula, ICellStyle cellStyle)
        {
            cell.CellFormula = Formula;                       //本日累计达成率 = 实际产出累计/计划产出累计
            if (cellStyle == null)
                return;
            cell.CellStyle = cellStyle;
        }

        public void BulidHelder()
        {
        }
    }
}