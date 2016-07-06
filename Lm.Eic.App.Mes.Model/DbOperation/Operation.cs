namespace Lm.Eic.App.Mes.Model
{
    public static class Operation
    {
        private static DbMes dbMes;

        /// <summary>
        /// MES数据服务
        /// </summary>
        public static DbMes DbMes => dbMes = dbMes == null ? new DbMes() : dbMes;

        private static DbErp dbErp;

        /// <summary>
        /// ERP数据服务
        /// </summary>
        public static DbErp DbErp => dbErp = dbErp == null ? new DbErp() : dbErp;

        private static DbTwoMes dbTwoMes;

        /// <summary>
        /// QQQQ-MS2 MES 数据服务
        /// </summary>
        public static DbTwoMes DbTwoMes => dbTwoMes = dbTwoMes == null ? new DbTwoMes() : dbTwoMes;

        private static DbTwoLine dbTwoLine;

        /// <summary>
        /// QQQQ-MS2 TwoLine 数据服务
        /// </summary>
        public static DbTwoLine DbTwoLine => dbTwoLine = dbTwoLine == null ? new DbTwoLine() : dbTwoLine;
    }

    public enum DbList
    {
        DbMes,
        DbErp,
        DbTwoMes,
        DbTwoLine
    }
}