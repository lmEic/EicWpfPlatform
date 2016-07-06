namespace Lm.Eic.App.Mes.Model
{
    public static class ConnectString
    {
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ConnectString()
        {
            //if (ZhuiFengLib.NetWork.GetIp.CheckIsOffice)
            //{
            //    dbErp = "name = DbErp";
            //    dbMes = "name=DbMes";
            //    dbTwoLine = "name = DbTwoLine";
            //    dbTwoMes = "name=DbTwoMes";
            //}
            //else
            //{
            //    dbErp = "name = DbErp2";
            //    dbMes = "name=DbMes2";
            //    dbTwoLine = "name = DbTwoLine2";
            //    dbTwoMes = "name=DbTwoMes2";
            //}

            
                dbErp = "name = DbErp";
                dbMes = "name=DbMes";
                dbTwoLine = "name = DbTwoLine";
                dbTwoMes = "name=DbTwoMes";
           
        }

        private static string dbErp, dbMes, dbTwoLine, dbTwoMes;

        /// <summary>
        /// 连接ERP
        /// </summary>
        public static string DbErp => dbErp;

        /// <summary>
        /// 连接到制五部MES
        /// </summary>
        public static string DbMes => dbMes;

        /// <summary>
        /// 连接到制六部 TwoLine
        /// </summary>
        public static string DbTwoLine => dbTwoLine;

        /// <summary>
        /// 连接到制六部MES
        /// </summary>
        public static string DbTwoMes => dbTwoMes;
    }
}