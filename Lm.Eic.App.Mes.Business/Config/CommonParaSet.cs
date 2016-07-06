using Lm.Eic.App.Mes.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lm.Eic.App.Mes.Business.Config
{
    /// <summary>
    /// 为系统提供下拉列表数据源
    /// </summary>
    public class CommonParaSet
    {
        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetParaList()
        {
            var result = new List<string>();
            //var listSourcs = Model.Operation.DbMes.Config_CommonParaSet.Local.Distinct(new ParaIDComparer()).ToList();
            var listSourcs = Model.Operation.DbMes.Config_CommonParaSet.ToList().Distinct(new ParaIDComparer()).ToList();
            foreach (var value in listSourcs)
                result.Add(value.ParameterName);
            return result;
        }

        /// <summary>
        /// 获取下拉列表参数
        /// </summary>
        /// <param name="commonPara">下拉列表类型</param>
        /// <returns></returns>
        public List<string> GetValueList(string commonPara)
        {
            var result = new List<string>();
            var listSourcs = Model.Operation.DbMes.Config_CommonParaSet.Where(p => p.ParameterName == commonPara.ToString()).ToList();
            foreach (var value in listSourcs)
                result.Add(value.ParameterValue);
            return result;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Para"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(string Para, List<string> values)
        {
            foreach (var value in values)
                Model.Operation.DbMes.Config_CommonParaSet.Add(new Model.Config_CommonParaSet()
                {
                    ParameterName = Para,
                    ParameterValue = value,
                    CurrentTemperature = "Not",
                    OpDate = DateTime.Now,
                    OpPerson = "003833"
                });

            return Model.Operation.DbMes.SaveChanges() > 0 ? true : false;
        }
    }

    /// <summary>
    ///  去重复比较器 CommonParaSet
    /// </summary>
    internal class ParaIDComparer : IEqualityComparer<Config_CommonParaSet>
    {
        public bool Equals(Config_CommonParaSet x, Config_CommonParaSet y)
        {
            if (x == null)

                return y == null;

            return x.ParameterName == y.ParameterName;
        }

        public int GetHashCode(Config_CommonParaSet obj)
        {
            if (obj == null)
                return 0;
            return obj.ParameterName.GetHashCode();
        }
    }
}