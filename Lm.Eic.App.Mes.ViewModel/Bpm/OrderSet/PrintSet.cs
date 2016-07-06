using GalaSoft.MvvmLight.Command;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
* 类 名： PrintSet
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/25/2016 1:23:48 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    public class PrintSet : OrderSetBase
    {
        public PrintSet()
        {
        }

        public PrintSet(string orderID)
        {
            LabContentList = new Business.Orm<Model.OQC_OrderPrintLabInfo>.ModelList_obs(Business.Operation.OqcHelper.BtPrintTemplate.GetModelList(m => m.OrderID == orderID));
            BtPrintConfig = new Business.Oqc.OrderBtPrintConfig(orderID);
        }

        private Business.Oqc.Print.BtPrintBase PrintPigtail = new Business.Oqc.Print.BtPrintBase();

        private Business.Oqc.OrderBtPrintConfig btPrintConfig = new Business.Oqc.OrderBtPrintConfig();

        /// <summary>
        /// 打印配置
        /// </summary>
        public Business.Oqc.OrderBtPrintConfig BtPrintConfig
        {
            get { return btPrintConfig; }
            set
            {
                btPrintConfig = value;
                this.RaisePropertyChanged(nameof(BtPrintConfig));
                SelectLabName = BtPrintConfig.Detailed.LabName;
                SelectPrintType = BtPrintConfig.Detailed.PrintType;
                TriggerCount = BtPrintConfig.Detailed.TriggerCount;
            }
        }

        /// <summary>
        /// 所选的标签名字
        /// </summary>
        public string SelectLabName
        {
            get { return BtPrintConfig.Detailed.LabName; }
            set
            {
                BtPrintConfig.Detailed.LabName = value;
                this.RaisePropertyChanged("SelectLabName");
                PrintPigtail.SetLaberFormat = $"\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\{value}";
            }
        }

        /// <summary>
        /// 所选的打印类型
        /// </summary>
        public string SelectPrintType
        {
            get { return BtPrintConfig.Detailed.PrintType; }
            set
            {
                BtPrintConfig.Detailed.PrintType = value;
                this.RaisePropertyChanged("SelectPrintType");
            }
        }

        private Business.Oqc.BtPrintTemplate.ModelList_obs labContentList = new Business.Orm<Model.OQC_OrderPrintLabInfo>.ModelList_obs();

        /// <summary>
        /// 标签内容
        /// </summary>
        public Business.Oqc.BtPrintTemplate.ModelList_obs LabContentList
        {
            get { return labContentList; }
            set
            {
                labContentList = value;
                this.RaisePropertyChanged("LabContentList");
            }
        }

        /// <summary>
        ///  打印触发数量
        /// </summary>
        public int? TriggerCount
        {
            get { return BtPrintConfig.Detailed.TriggerCount; }
            set
            {
                BtPrintConfig.Detailed.TriggerCount = value;
                this.RaisePropertyChanged("TriggerCount");
            }
        }

        /// <summary>
        /// 载入标签
        /// </summary>
        public RelayCommand LoadLabCommand => new RelayCommand(() =>
        {
            LabContentList = PrintPigtail.CreateTemplateList();
        });

        /// <summary>
        /// 生成标签
        /// </summary>
        public RelayCommand CreateLabCommand => new RelayCommand(() =>
        {
            PrintPigtail.SetLabContent(LabContentList);
            PrintPigtail.CreateLabImage();
        });

        /// <summary>
        /// 标签预览
        /// </summary>
        public RelayCommand<System.Windows.Controls.Image> CreatePreviewCommand => new RelayCommand<System.Windows.Controls.Image>((img) =>
        {
            try
            {
                BitmapImage BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(File.ReadAllBytes(@"D:\Thumbnail.jpeg"));  //bufPic是图片二进制，byte类型
                BI.EndInit();
                img.Source = BI;
            }
            catch (Exception ex) { msg.MessageErr(ex.Message); }
        });

        /// <summary>
        /// 保存至数据库
        /// </summary>
        public RelayCommand SavaToDbCommand => new RelayCommand(() =>
        {
            foreach (var tem in labContentList)
            {
                Business.Operation.OqcHelper.BtPrintTemplate.DelBy(m => m.OrderID == order.Detailed.OrderID && m.Name == tem.Name);
                tem.OrderID = order.Detailed.OrderID;
                Business.Operation.OqcHelper.BtPrintTemplate.Add(tem);
            }
            Business.Operation.OqcHelper.BtPrintConfig.DelBy(m => m.PackLot == order.Detailed.OrderID);
            var temPrintConfig = new Model.OQC_OrderPrintConfig()
            {
                OrderID = order.Detailed.OrderID,
                PackLot = order.Detailed.OrderID,
                PrintType = SelectPrintType,
                LabName = SelectLabName,
                TriggerCount = TriggerCount,
                LabPath = $@"D:\模板\PrintTemplates\HP_Templates\{SelectLabName}",
                DataSourcesPath = $@"D:\模板\PrintTemplates\Data_Source\{SelectLabName.Substring(0, SelectLabName.Length - 4)}.xlsx"
            };
            if (!SelectPrintType.Equals("HP打印"))
            {
                temPrintConfig.LabPath = $@"D:\模板\PrintTemplates\BT_Templates\{SelectLabName}";
                temPrintConfig.DataSourcesPath = string.Empty;
            }
            if (Business.Operation.OqcHelper.BtPrintConfig.Add(temPrintConfig))
                msg.MessageInfo("保存成功！");
        });
    }
}