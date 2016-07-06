using System;
using System.Text.RegularExpressions;

namespace ZhuiFengLib.Extension
{
    public static class ExString
    {
        #region string

        /// <summary>
        /// 字符串是否为Null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 字符串是否为数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumber(this string s)
        {
            string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }


        /// <summary>
        /// 是否为Int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// 转换为Int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        ///  是否为double类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Isdouble(this string s)
        {
            double i;
            return double.TryParse(s, out i);
        }

        /// <summary>
        /// 转换为doublel类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double Todouble(this string s)
        {
            return double.Parse(s);
        }

        public static string Tuncate(this string value, int length)
        {
            return value?.Substring(0, Math.Min(value.Length, length));
        }

        #endregion string
    }
}