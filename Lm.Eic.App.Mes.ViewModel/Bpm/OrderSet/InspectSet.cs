using GalaSoft.MvvmLight.Command;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
* 类 名： InspectSet
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/25/2016 1:24:31 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    public class InspectSet : OrderSetBase
    {
        public InspectSet()
        {
        }

        public InspectSet(string orderID)
        {
            InspectConfigList = new Business.Orm<Model.OQC_OrderInspectConfig>.ModelList_obs(Business.Operation.OqcHelper.InspectConfig.GetModelList(m => m.OrderID == orderID));
            //  SelectInspectConfig = new Business.Oqc.OrderInspectConfig(orderID);
            SelectInspectConfig.Detailed = InspectConfigList.Count > 0 ? InspectConfigList[0] : null;
            string s = SelectInspectConfig?.Detailed?.InspectStandardName.ToString();
            InspectStandardList = new Business.Orm<Model.OQC_OrderInspectStatnard>.ModelList_obs(Business.Operation.OqcHelper.InspectStandard.GetModelList(m => m.InspectStandardName == s));
        }

        private Business.Oqc.OrderInspectConfig selectInspectConfig = new Business.Oqc.OrderInspectConfig();

        /// <summary>
        ///  选择的检测标准
        /// </summary>
        public Business.Oqc.OrderInspectConfig SelectInspectConfig
        {
            get { return selectInspectConfig; }
            set
            {
                selectInspectConfig = value;
                this.RaisePropertyChanged(nameof(SelectInspectConfig));
            }
        }

        private InspectSetParameter paramenter = new InspectSetParameter();

        /// <summary>
        /// 设置参数
        /// </summary>
        public InspectSetParameter Paramenter
        {
            get { return paramenter; }
            set
            {
                paramenter = value;
                this.RaisePropertyChanged(nameof(Paramenter));
            }
        }

        private Business.Oqc.OrderInspectStandard.ModelList_obs inspectStandardList = new Business.Orm<Model.OQC_OrderInspectStatnard>.ModelList_obs();

        /// <summary>
        /// 检测标准列表
        /// </summary>
        public Business.Oqc.OrderInspectStandard.ModelList_obs InspectStandardList
        {
            get { return inspectStandardList; }
            set
            {
                inspectStandardList = value;
                this.RaisePropertyChanged(nameof(InspectStandardList));
            }
        }

        private Business.Oqc.OrderInspectConfig.ModelList_obs inspectConfigList = new Business.Orm<Model.OQC_OrderInspectConfig>.ModelList_obs();

        /// <summary>
        /// 检测配置列表
        /// </summary>
        public Business.Oqc.OrderInspectConfig.ModelList_obs InspectConfigList
        {
            get { return inspectConfigList; }
            set
            {
                inspectConfigList = value;
                this.RaisePropertyChanged(nameof(InspectConfigList));
            }
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public RelayCommand SavaToDb => new RelayCommand(() =>
        {
            //保存检测配置数据
            var _inspectConfig = new Model.OQC_OrderInspectConfig();
            _inspectConfig.OrderID = order?.Detailed?.OrderID;      //工单单号
            _inspectConfig.IsInspect = paramenter.IsInspect3D;
            _inspectConfig.InspectMethod = paramenter.InspectMethod;
            _inspectConfig.InspectStandardName = paramenter.InspectStandardName;
            _inspectConfig.ConnectList = Paramenter.ConnectorList;
            _inspectConfig.IsInspect3D = Paramenter.IsInspect3D;
            _inspectConfig.InspectStandard_3D = $"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_3D";
            _inspectConfig.IsInspectExfo = paramenter.IsInspectExfo;
            _inspectConfig.InspectStandard_Exfo = $"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_Exfo";

            Business.Operation.OqcHelper.InspectConfig.Add(_inspectConfig);
            InspectConfigList.Add(_inspectConfig);

            /*保存检测参数数据*/
            //添加3D检测标准
            if (Paramenter.IsInspect3D)
            {
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_3D", "Curvature", paramenter.RcoMin, paramenter.RcoMax, string.Empty);
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_3D", "Apex_Offset", paramenter.AoMin, paramenter.AoMax, string.Empty);
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_3D", "Spherical", paramenter.FhMin, paramenter.FhMax, string.Empty);
            }
            //添加角度检测标准
            if (Paramenter.IsInspectAe)
            {
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_3D", "Tilt_Angle", paramenter.AeMin, paramenter.AeMax, string.Empty);
            }
            //添加Exfo检测标准
            if (Paramenter.IsInspectExfo)
            {
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_Exfo", "IL_A", paramenter.IlMin, paramenter.IlMax, "1550nm");
                CreterInspectStandard($"{order.Detailed.OrderID}_{paramenter.InspectStandardName}_Exfo", "Refl_A", paramenter.RlMin, paramenter.RlMax, "1550nm");
            }
            msg.MessageInfo("保存成功");
        });

        private bool CreterInspectStandard(string inspectStandardName, string fieldName, double? min, double? max, string type)
        {
            //ROC
            var inspectStandard = new Model.OQC_OrderInspectStatnard();
            inspectStandard.OrderID = order.Detailed.OrderID;
            inspectStandard.InspectStandardName = inspectStandardName;
            inspectStandard.FieldName = fieldName;
            inspectStandard.Min = min;
            inspectStandard.Max = max;
            inspectStandard.Type = type;
            InspectStandardList.Add(inspectStandard);
            return Business.Operation.OqcHelper.InspectStandard.Add(inspectStandard);
        }
    }

    /// <summary>
    /// 检测设置参数模型
    /// </summary>
    public class InspectSetParameter : VMbase
    {
        public ZhuiFengLib.Obs<string> InspectMethodList { get; set; } = new ZhuiFengLib.Obs<string>() { "一码一签", "两码一签","双并", "跳线" };

        /// <summary>
        /// 是否检测3D 看是否设置3D的前三个参数值
        /// </summary>
        public bool IsInspect3D => (RcoMin + RcoMax + FhMin + FhMax + AoMin + AoMax) == null ? false : true;

        /// <summary>
        /// 是否检测Exfo 看是否设置Exfo的两个参数值
        /// </summary>
        public bool IsInspectExfo => (IlMax + IlMin + rlMax + RlMin) == null ? false : true;

        /// <summary>
        /// 是否检测角度
        /// </summary>
        public bool IsInspectAe => (AeMin + AeMax) == null ? false : true;

        private string inspectMethod = string.Empty;

        /// <summary>
        /// 检测方法的名称
        /// </summary>
        public string InspectMethod
        {
            get { return inspectMethod; }
            set
            {
                inspectMethod = value;
                this.RaisePropertyChanged(nameof(InspectMethod));
            }
        }

        private bool isInspectConnector = false;

        /// <summary>
        /// 是否根据标志位查找相应的检测标准
        /// </summary>
        public bool IsInspectConnector
        {
            get { return isInspectConnector; }
            set
            {
                isInspectConnector = value;
                this.RaisePropertyChanged(nameof(IsInspectConnector));
            }
        }

        private string inspectStandardName = string.Empty;

        /// <summary>
        /// 检测标准的名字
        /// </summary>
        public string InspectStandardName
        {
            get { return inspectStandardName; }
            set
            {
                inspectStandardName = value;
                this.RaisePropertyChanged(nameof(InspectStandardName));
            }
        }

        private string connectorList = string.Empty;

        /// <summary>
        /// 接头与检测名字对应的列表-=》逗号分隔
        /// </summary>
        public string ConnectorList
        {
            get { return connectorList; }
            set
            {
                connectorList = value;
                this.RaisePropertyChanged(nameof(ConnectorList));
            }
        }

        private double? rcoMin;

        /// <summary>
        ///
        /// </summary>
        public double? RcoMin
        {
            get { return rcoMin; }
            set
            {
                rcoMin = value;
                this.RaisePropertyChanged(nameof(RcoMin));
            }
        }

        private double? rcoMax;

        /// <summary>
        ///
        /// </summary>
        public double? RcoMax
        {
            get { return rcoMax; }
            set
            {
                rcoMax = value;
                this.RaisePropertyChanged(nameof(RcoMax));
            }
        }

        private double? aoMin;

        /// <summary>
        ///
        /// </summary>
        public double? AoMin
        {
            get { return aoMin; }
            set
            {
                aoMin = value;
                this.RaisePropertyChanged(nameof(AoMin));
            }
        }

        private double? aoMax;

        /// <summary>
        ///
        /// </summary>
        public double? AoMax
        {
            get { return aoMax; }
            set
            {
                aoMax = value;
                this.RaisePropertyChanged(nameof(AoMax));
            }
        }

        private double? fhMin;

        /// <summary>
        ///
        /// </summary>
        public double? FhMin
        {
            get { return fhMin; }
            set
            {
                fhMin = value;
                this.RaisePropertyChanged(nameof(FhMin));
            }
        }

        private double? fhMax;

        /// <summary>
        ///
        /// </summary>
        public double? FhMax
        {
            get { return fhMax; }
            set
            {
                fhMax = value;
                this.RaisePropertyChanged(nameof(FhMax));
            }
        }

        private double? aeMin;

        /// <summary>
        ///
        /// </summary>
        public double? AeMin
        {
            get { return aeMin; }
            set
            {
                aeMin = value;
                this.RaisePropertyChanged(nameof(AeMin));
            }
        }

        private double? aeMax;

        /// <summary>
        ///
        /// </summary>
        public double? AeMax
        {
            get { return aeMax; }
            set
            {
                aeMax = value;
                this.RaisePropertyChanged(nameof(AeMax));
            }
        }

        private double? ilMin;

        /// <summary>
        ///
        /// </summary>
        public double? IlMin
        {
            get { return ilMin; }
            set
            {
                ilMin = value;
                this.RaisePropertyChanged(nameof(IlMin));
            }
        }

        private double? ilMax;

        /// <summary>
        ///
        /// </summary>
        public double? IlMax
        {
            get { return ilMax; }
            set
            {
                ilMax = value;
                this.RaisePropertyChanged(nameof(IlMax));
            }
        }

        private double? rlMin;

        /// <summary>
        ///
        /// </summary>
        public double? RlMin
        {
            get { return rlMin; }
            set
            {
                rlMin = value;
                this.RaisePropertyChanged(nameof(RlMin));
            }
        }

        private double? rlMax;

        /// <summary>
        ///
        /// </summary>
        public double? RlMax
        {
            get { return rlMax; }
            set
            {
                rlMax = value;
                this.RaisePropertyChanged(nameof(RlMax));
            }
        }
    }
}