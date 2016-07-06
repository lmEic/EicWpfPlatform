using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using msg = ZhuiFengLib.Message.Message;

namespace ZhuiFengLib.Extension
{
    public static class ExList
    {
        #region List<T>

        //http://blog.csdn.net/flyingdream123/article/details/9294973
        //要复制的实例必须可序列化，包括实例引用的其它实例都必须在类定义时加[Serializable]特性。
        public static T Copy<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

        //http://www.cnblogs.com/bradwarden/archive/2012/06/19/2554854.html
        /// <summary>
        /// 调用方式：
        /// ListSort("Name","desc");//表示对Name进行desc排序
        ///ListSort("Id","asc");//表示对Id进行asc排序。如此如果参数很多的话减少了很多判断。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="infoList"></param>
        /// <param name="field"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static List<T> ListSort<T>(this List<T> infoList, string field, string rule)
        {
            if (!string.IsNullOrEmpty(rule) && (rule.ToLower().Equals("desc") || rule.ToLower().Equals("asc")))
            {
                try
                {
                    infoList.Sort(
                        delegate (T info1, T info2)
                        {
                            Type t = typeof(T);
                            PropertyInfo pro = t.GetProperty(field);
                            return rule.ToLower().Equals("asc") ?
                                pro.GetValue(info1, null).ToString().CompareTo(pro.GetValue(info2, null).ToString()) :
                                pro.GetValue(info2, null).ToString().CompareTo(pro.GetValue(info1, null).ToString());
                        });
                }
                catch (Exception ex)
                {
                    msg.MessageInfo(ex.Message);
                }
            }
            else
                msg.MessageInfo("ruls is wrong");
            return infoList;
        }

        /// <summary>
        ///  将实体类列表到处到Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dt"></param>
        /// <param name="patch">绝对路径</param>
        /// <param name="isCreateTitle">是否生成标题</param>
        public static void ExportToExcel<T>(this List<T> dt, string patch, bool isCreateTitle, int inputStartRow)
        {
            m_ExportToExcel(dt, patch, isCreateTitle, inputStartRow);
        }

        /// <summary>
        ///  将实体类列表到处到Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ls"></param>
        /// <param name="isCreateTitle">是否生成标题</param>
        public static void ExportToExcel<T>(this List<T> ls, bool isCreateTitle, int inputStartRow)
        {
            //string localFilePath, fileNameExt, newFileName, FilePath;
            var sfd = new SaveFileDialog();
            //设置文件类型
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";

            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var localFilePath = sfd.FileName; //获得文件路径
                var fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                m_ExportToExcel(ls, localFilePath, isCreateTitle, inputStartRow);
            }
        }

        /// <summary>
        /// 将实体类列表到处到根据模板创建的Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ls"></param>
        /// <param name="modulePatch"></param>
        /// <param name="inputStartRow"></param>
        public static void ExportToExcel_forModule<T>(this List<T> ls, string modulePatch, int inputStartRow)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                File.Copy(modulePatch, localFilePath, true);
                m_ExportToExcel(ls, localFilePath, false, inputStartRow);
            }
        }

        /// <summary>
        /// 判断此集合是否为空 集合是否大于1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this List<T> dt)
        {
            return dt != null && dt.Count >= 1;
        }

        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dt"></param>
        /// <param name="patch">导出的绝对路径</param>
        /// <param name="isCreateTitle">是否创建标题</param>
        /// <param name="inputStartRow">数据从第几行开始插入 请默认设置为 1 </param>
        private static void m_ExportToExcel<T>(List<T> dt, string patch, bool isCreateTitle, int inputStartRow)
        {
            if (dt.Count > 0)
            {
                ISheet tb = null;
                IWorkbook wk = null;
                if (File.Exists(patch))               //如果文件存在 说明是从模板创建的
                {
                    wk = WorkbookFactory.Create(patch);
                    tb = wk.GetSheet(wk.GetSheetName(0));
                }
                else                                  //如果文件不存在，说明需要新建一个Excel
                {
                    wk = new XSSFWorkbook();
                    tb = wk.CreateSheet("mySheet");
                }

                if (isCreateTitle)                    //创建标题
                {
                    var row = tb.CreateRow(0); var temCell = 0;
                    var properties = dt[0].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var item in properties)  //为新行 myRow 赋值
                    {
                        row.CreateCell(temCell).SetCellValue(item.Name);
                        temCell++;
                    }
                }

                foreach (var t in dt)                 //创建数据填充
                {
                    var datarow = tb.CreateRow(inputStartRow);

                    var myproperties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    var cellD = 0;
                    foreach (var item2 in myproperties)
                    {
                        var value = item2.GetValue(t, null);
                        if (value != null)
                        {
                            switch (value.GetType().ToString())
                            {
                                case "System.String"://字符串类型
                                    datarow.CreateCell(cellD).SetCellValue(string.Format("{0}", value));
                                    break;
                                //case "System.DateTime"://日期类型
                                //    DateTime dateV;
                                //    DateTime.TryParse(value.ToString(), out dateV);
                                //    datarow.CreateCell(cellD).SetCellValue(dateV);

                                // datarow.CreateCell(cellD).CellStyle =
                                //break;
                                case "System.Boolean"://布尔型
                                    bool boolV = false;
                                    bool.TryParse(value.ToString(), out boolV);
                                    datarow.CreateCell(cellD).SetCellValue(boolV);
                                    break;

                                case "System.Int16"://整型
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(value.ToString(), out intV);
                                    datarow.CreateCell(cellD).SetCellValue(intV);
                                    break;

                                case "System.Decimal"://浮点型
                                case "System.Double":
                                    double doubV = 0;
                                    double.TryParse(value.ToString(), out doubV);
                                    datarow.CreateCell(cellD).SetCellValue(doubV);
                                    break;

                                case "System.DBNull"://空值处理
                                    datarow.CreateCell(cellD).SetCellValue("");
                                    break;

                                default:
                                    datarow.CreateCell(cellD).SetCellValue(string.Format("{0}", value));
                                    break;
                            }
                        }
                        cellD++;
                    }
                    inputStartRow++;
                }

                var fs2 = File.Create(patch);
                wk.Write(fs2);                         //向打开的这个xls文件中写入mySheet表并保存。

                MessageBox.Show("提示：导出完成！");
            }
            else
            {
                MessageBox.Show("无任何需要导出的项目！");
            }
        }

        #endregion List<T>

        //要复制的实例必须可序列化，包括实例引用的其它实例都必须在类定义时加[Serializable]特性。
        public static T ModelCopy<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
    }
}