using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ZhuiFengLib.Extension
{
    public static class ExDataTable
    {
        /// <summary>
        /// DataTable转换为List
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<TEntity> List<TEntity>(this DataTable dt)
        {
            var list = new List<TEntity>();
            var t = typeof(TEntity);
            var plist = new List<PropertyInfo>(typeof(TEntity).GetProperties());

            foreach (DataRow item in dt.Rows)
            {
                var s = Activator.CreateInstance<TEntity>();
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    var info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            info.SetValue(s, item[i], null);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类列表</returns>
        public static List<T> ToList<T>(this DataTable pData)
        {
            // 返回值初始化
            var result = new List<T>();
            for (var j = 0; j < pData.Rows.Count; j++)
            {
                var t = (T)Activator.CreateInstance(typeof(T));
                var propertys = t.GetType().GetProperties();
                foreach (var pi in propertys)
                {
                    if (pData.Columns.IndexOf(pi.Name.ToUpper()) != -1 && pData.Rows[j][pi.Name.ToUpper()] != DBNull.Value)
                    {
                        var temValue = pData.Rows[j][pi.Name.ToUpper()];
                        if (!temValue.ToString().IsNullOrEmpty())
                        {
                            pi.SetValue(t, ConventHelper.GetOracleParamter(pi.Name, pi, temValue), null);
                        }
                    }
                    else
                    {
                        pi.SetValue(t, null, null);
                    }
                }
                result.Add(t);
            }
            return result;
        }

        /// <summary>
        /// 利用反射和泛型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<TEntity> ConvertToList<TEntity>(this DataTable dt) where TEntity : class, new()
        {
            // 定义集合
            List<TEntity> ts = new List<TEntity>();

            // 获得此模型的类型
            Type type = typeof(TEntity);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                TEntity t = new TEntity();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                                       //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出
                                                   //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (!value.ToString().IsNullOrEmpty())
                        {
                            pi.SetValue(t, ConventHelper.GetOracleParamter(pi.Name, pi, value), null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }

            return ts;
        }

        /// <summary>
        /// 从Excel表中获取数据
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static DataTable GetDataTableForExcel(string patch)
        {
            var stream = new FileStream(patch, FileMode.Open, FileAccess.Read);

            var workbook = WorkbookFactory.Create(stream);  //使用接口，自动识别excel2003/2007格式

            var sheet = workbook.GetSheetAt(0);                //得到里面第一个sheet

            var table = new DataTable(sheet.SheetName);
            for (var rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                    break;

                if (rowIndex == 0)
                {
                    for (var cellIndex = 0; cellIndex < row.LastCellNum; cellIndex++)
                    {
                        var value = row.GetCell(cellIndex).ToString();

                        if (string.IsNullOrEmpty(value)) break;
                        table.Columns.Add(new DataColumn(value));
                    }
                }
                else
                {
                    var datarow = table.NewRow();
                    var objectArray = new object[table.Columns.Count];
                    for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                    {
                        try
                        {
                            var cell = row.GetCell(columnIndex);

                            if (cell != null)
                                objectArray[columnIndex] = cell.ToString();
                            else
                                objectArray[columnIndex] = string.Empty;
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine(error.Message);
                            Debug.WriteLine("Column Index" + columnIndex);
                            Debug.WriteLine("Row Index" + row.RowNum);
                        }
                    }
                    datarow.ItemArray = objectArray;
                    table.Rows.Add(datarow);
                }
            }
            return table;
        }

        #region 利用泛型将DataSet转为Model

        /// <summary>
        /// 将DataSet转为Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<T> PutAllVal<T>(T entity, DataSet ds) where T : new()
        {
            List<T> lists = new List<T>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lists.Add(PutVal(new T(), row));
                }
            }
            return lists;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T PutVal<T>(T entity, DataRow row) where T : new()
        {
            //初始化 如果为null
            if (entity == null)
            {
                entity = new T();
            }
            //得到类型
            Type type = typeof(T);
            //取得属性集合
            PropertyInfo[] pi = type.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                //给属性赋值
                if (row[item.Name] != null && row[item.Name] != DBNull.Value)
                {
                    if (item.PropertyType == typeof(System.Nullable<System.DateTime>))
                    {
                        item.SetValue(entity, Convert.ToDateTime(row[item.Name].ToString()), null);
                    }
                    else
                    {
                        item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                    }
                }
            }
            return entity;
        }

        #endregion 利用泛型将DataSet转为Model
    }

    /// <summary>
    /// DataTable与实体类互相转换
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public class ModelHandler<T> where T : new()
    {
        #region DataTable转换成实体类

        /// <summary>
        /// 填充对象列表：用DataSet的第一个表填充实体类
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public List<T> FillModel(DataSet ds)
        {
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[0]);
            }
        }

        /// <summary>
        /// 填充对象列表：用DataSet的第index个表填充实体类
        /// </summary>
        public List<T> FillModel(DataSet ds, int index)
        {
            if (ds == null || ds.Tables.Count <= index || ds.Tables[index].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[index]);
            }
        }

        /// <summary>
        /// 填充对象列表：用DataTable填充实体类
        /// </summary>
        public List<T> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                //T model = (T)Activator.CreateInstance(typeof(T));
                T model = new T();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    model.GetType().GetProperty(propertyInfo.Name).SetValue(model, dr[propertyInfo.Name], null);
                }
                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>
        /// 填充对象：用DataRow填充实体类
        /// </summary>
        public T FillModel(DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            //T model = (T)Activator.CreateInstance(typeof(T));
            T model = new T();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                model.GetType().GetProperty(propertyInfo.Name).SetValue(model, dr[propertyInfo.Name], null);
            }
            return model;
        }

        #endregion DataTable转换成实体类

        #region 实体类转换成DataTable

        /// <summary>
        /// 实体类转换成DataSet
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataSet FillDataSet(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            else
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(FillDataTable(modelList));
                return ds;
            }
        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataTable FillDataTable(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dt = CreateData(modelList[0]);

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private DataTable CreateData(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }

        #endregion 实体类转换成DataTable
    }

    /// <summary>
    /// Summary description for LinqToDataTable
    /// </summary>
    public static class LinqToDataTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names

            PropertyInfo[] oProps = null;

            // Could add a check to verify that there is an element 0

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow

                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();

                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow(); foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }

            return (dtReturn);
        }

        public delegate object[] CreateRowDelegate<T>(T t);
    }
}