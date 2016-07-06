namespace Lm.Eic.App.Mes.Business
{
    public static class Operation
    {
        public static class BpmHeper
        {
            private static Bpm.Order order;

            /// <summary>
            /// 工单
            /// </summary>
            public static Bpm.Order Order => order = order == null ? new Bpm.Order() : order;

            private static Bpm.Process process;

            /// <summary>
            /// 工序
            /// </summary>
            public static Bpm.Process Process => process = process == null ? new Bpm.Process() : process;

            private static Bpm.Product product;

            /// <summary>
            /// 产品
            /// </summary>
            public static Bpm.Product Product => product = product == null ? new Bpm.Product() : product;

            private static Bpm.ProcessTemplate processTemplate;

            /// <summary>
            /// 工序模板
            /// </summary>
            public static Bpm.ProcessTemplate ProcessTemplate => processTemplate = processTemplate == null ? new Bpm.ProcessTemplate() : processTemplate;
        }

        public static class AstHeper
        {
            static Ast.Equipment equipment;
            /// <summary>
            /// 
            /// </summary>
            public static Ast.Equipment Equitment => equipment = equipment == null ? new Ast.Equipment() : equipment;

        }

        public static class DailyHelper
        {
            static Daily.Daily daily;
            /// <summary>
            /// 日报操作
            /// </summary>
            public static Daily.Daily Daily => daily = daily == null ? new Daily.Daily() : daily;

        }

        /// <summary>
        /// ＨＲ业务层帮助类
        /// </summary>
        public static class HrHelper
        {
            private static Hr.Hr_User user;

            /// <summary>
            /// 用户业务层
            /// </summary>
            public static Hr.Hr_User User => user = user == null ? new Hr.Hr_User() : user;
        }

        /// <summary>
        /// 业务逻辑帮助类
        /// </summary>
        public static class ConfigHelper
        {
            private static Config.CommonParaSet commonParaSet;

            /// <summary>
            ///
            /// </summary>
            public static Config.CommonParaSet CommonParaSet => commonParaSet = commonParaSet == null ? new Config.CommonParaSet() : commonParaSet;
        }

        /// <summary>
        /// Oqc业务逻辑帮助类
        /// </summary>
        public static class OqcHelper
        {
            private static Oqc.OrderBtPrintConfig btPrintConfig;

            /// <summary>
            /// 标签打印配置
            /// </summary>
            public static Oqc.OrderBtPrintConfig BtPrintConfig => btPrintConfig = btPrintConfig == null ? new Oqc.OrderBtPrintConfig() : btPrintConfig;

            private static Oqc.BtPrintTemplate btPrintTemplate;

            /// <summary>
            /// 标签打印模板
            /// </summary>
            public static Oqc.BtPrintTemplate BtPrintTemplate => btPrintTemplate = btPrintTemplate == null ? new Oqc.BtPrintTemplate() : btPrintTemplate;

            private static Oqc.OrderInspectStandard inspectStandard;

            /// <summary>
            /// 装袋检测标准
            /// </summary>
            public static Oqc.OrderInspectStandard InspectStandard => inspectStandard = inspectStandard == null ? new Oqc.OrderInspectStandard() : inspectStandard;

            private static Oqc.Pack3D pack3D;

            private static Oqc.OrderInspectConfig inspectConfig;

            /// <summary>
            /// 装袋检测配置
            /// </summary>
            public static Oqc.OrderInspectConfig InspectConfig => inspectConfig = inspectConfig == null ? new Oqc.OrderInspectConfig() : inspectConfig;

            /// <summary>
            /// 已包装的3D数据
            /// </summary>
            public static Oqc.Pack3D Pack3D => pack3D = pack3D == null ? new Oqc.Pack3D() : pack3D;

            private static Oqc.PackExfo packExfo;

            /// <summary>
            /// 已包装的Exfo数据
            /// </summary>
            public static Oqc.PackExfo PackExfo => packExfo = packExfo == null ? new Oqc.PackExfo() : packExfo;

            private static Oqc.OrderPackLot packLot;

            /// <summary>
            /// 包装批号
            /// </summary>
            public static Oqc.OrderPackLot PackLot => packLot = packLot == null ? new Oqc.OrderPackLot() : packLot;

            private static Oqc.OrderSerialNumber serialNumber;

            /// <summary>
            /// 条码
            /// </summary>
            public static Oqc.OrderSerialNumber SerialNumber => serialNumber = serialNumber == null ? new Oqc.OrderSerialNumber() : serialNumber;

            private static Oqc.UserTestExfo userTestExfo;

            /// <summary>
            /// Exfo测试原始数据
            /// </summary>
            public static Oqc.UserTestExfo UserTestExfo => userTestExfo = userTestExfo == null ? new Oqc.UserTestExfo() : userTestExfo;

            private static Oqc.UserTest3D userTest3D;

            /// <summary>
            /// 3D测试原始数据
            /// </summary>
            public static Oqc.UserTest3D UserTest3D => userTest3D = userTest3D == null ? new Oqc.UserTest3D() : userTest3D;
        }
    }
}