using System;
using System.Data;
using System.Reflection;

namespace ZhuiFengLib.Extension
{
    public class ConventHelper
    {
        /// <summary>
        /// http://zhidao.baidu.com/link?url=voGmkNU09qf9V8ALx3yOa1xbD6VNEDJyQ17LBepgPATmd-qctzY6ooRNE9Dshz73szFTfoX4aVEM2WsWTctZYK
        /// 获取属性的类型 并将传进来的值转换为属性的类型
        /// PS:使用前 请进行空值检查
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="info">属性元</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static object GetOracleParamter(string name, PropertyInfo info, object value)
        {
            object sqlp = null;
            if (value.ToString().IsNullOrEmpty())     //如果为空 不再执行后续计算 直接返回Null
                return sqlp;

            try
            {
                var propertyType = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                if (propertyType.Equals(typeof(String)))
                {
                    sqlp = value.ToString();
                }
                else if (propertyType.Equals(typeof(int)))
                {
                    sqlp = Convert.ToInt32(value);
                }
                else if (propertyType.Equals(typeof(decimal)))
                {
                    sqlp = Convert.ToDecimal(value);
                }
                else if (propertyType.Equals(typeof(System.DateTime)))
                {
                    sqlp = Convert.ToDateTime(value);
                }
                else if (propertyType.Equals(typeof(double)))
                {
                    sqlp = Convert.ToDouble(value);
                }
                else if (propertyType.Equals(typeof(bool)))
                {
                    sqlp = Convert.ToBoolean(value);
                }
            }
            catch { }
            return sqlp;
        }
    }

    public class OracleParameter
    {
        private string name;
        private DbType type;

        public string Name { get { return name; } }

        public DbType Type { get { return type; } }

        public OracleParameter(string name, DbType @string)
        {
            this.name = name;
            this.type = @string;
        }
    }
}