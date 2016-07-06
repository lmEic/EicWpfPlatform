using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.Business
* 类 名： BtPrint
* 功 能： 提供使用Bt模板进行标签打印的服务
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 14:53:44 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　  │
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc.Print
{
    public  class BtPrintBase : IDisposable, IBtPrintBase
    {
        /// <summary>
        /// 初始化打印
        /// </summary>
        public BtPrintBase()
        {
            try
            {
                BtEngine.Start();
            }     //开启后台线程
            catch { msg.MessageInfo("打印服务未能启动，将导致无法打印！/r/n导致此错误的原因可能是您的计算机未安装BT打印软件或其它必要的服务程序！如有疑问请联系系统管理员"); }
        }

        private Engine m_engine = null;

        /// <summary>
        /// Bt打印服务
        /// </summary>
        public Engine BtEngine => m_engine = m_engine == null ? new Engine(true) : m_engine;

        public LabelFormatDocument btFormat { get; set; }

        private OrderBtPrintConfig printConfig = new OrderBtPrintConfig();
        /// <summary>
        /// 
        /// </summary>
        public OrderBtPrintConfig PrintConfig
        {
            get { return printConfig; }
            set
            {
                printConfig = value;
                
            }
        }


        /// <summary>
        /// 设置打印模板
        /// </summary>
        public string SetLaberFormat
        {
            set
            {
                if (value.Length > 52)
                {
                    try { btFormat = m_engine.Documents.Open(value); }
                    catch (Exception ex) { msg.MessageErr($"打开模板失败\r\n{ex.Message}"); }
                }
                else btFormat = null;
            }
        }

      

        /// <summary>
        /// 获取模板名字
        /// </summary>
        public string GetLaberFormatName { get; set; } = string.Empty;

        /// <summary>
        /// 设置打印机名称
        /// </summary>
        public string PrinterName { set { btFormat.PrintSetup.PrinterName = value; } }

        /// <summary>
        /// 释放内存
        /// </summary>
        public void Dispose()
        {
            if (m_engine != null)
            {
                m_engine.Stop();
                m_engine.Dispose();
            }
        }

        /// <summary>
        /// 获取指定路径下打印模板名称列表
        /// </summary>
        /// <param name="Patch"></param>
        public List<string> GetFileLabNames(string Patch)
        {
            List<string> resultList = new List<string>(); // 存放文件名
            try
            {
                foreach (var tem in System.IO.Directory.GetFiles(Patch, "*.btw"))

                    resultList.Add(tem.Substring(48));
            }
            catch (Exception ex)
            {
                msg.MessageErr("未启动ＢＴ线程！此模式下只可进行标签核对功能！\r\n" + ex.Message);
            }
            return resultList;
        }

        /// <summary>
        /// 获取指定路径下打印模板名称列表
        /// </summary>
        /// <param name="Patch"></param>
        public static List<string> GetFileLabNames()
        {
            List<string> resultList = new List<string>(); // 存放文件名
            try
            {
                foreach (var tem in System.IO.Directory.GetFiles("\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\", "*.btw"))

                    resultList.Add(tem.Substring(51));
            }
            catch (Exception ex)
            {
                msg.MessageErr("未启动ＢＴ线程！此模式下只可进行标签核对功能！\r\n" + ex.Message);
            }
            return resultList;
        }

        /// <summary>
        /// 将指定的文档生产图片
        /// </summary>
        /// <param name="btLab">标签</param>
        public void CreateLabImage(LabelFormatDocument btLab)
        {
            File.Delete(@"D:\Thumbnail.jpeg");
            btLab.ExportImageToFile(@"D:\Thumbnail.jpg", ImageType.JPEG, ColorDepth.ColorDepth256, new Resolution(1500), OverwriteOptions.Overwrite);
        }

        /// <summary>
        /// 将指定的文档生产图片
        /// </summary>
        /// <param name="btLab"></param>
        public void CreateLabImage()
        {
            File.Delete(@"D:\Thumbnail.jpeg");
            btFormat.ExportImageToFile(@"D:\Thumbnail.jpeg", ImageType.JPEG, ColorDepth.ColorDepth256, new Resolution(3840, 2160), OverwriteOptions.Overwrite);
        }

        /// <summary>
        /// 将标签内容转化为DataSet
        /// </summary>
        /// <param name="btLab">标签</param>
        /// <returns></returns>
        public DataSet CreateLabDataSet(LabelFormatDocument btLab)
        {
            try
            {
                DataSet ds = ZhuiFengLib.Xml.XmlDatasetConvert.ConvertXMLToDataSet(btLab.SubStrings.XML);
                if (ds.Tables[0].Rows.Count > 0)
                    return ds;
                else { msg.MessageInfo("未找到要设置的模板信息，请确认模板设置是否正确！"); return null; }
            }
            //获取异常信息
            catch (Exception ex) { msg.MessageInfo("加载模板信息过程中发生错误!\r\n" + ex.Message); return null; }
        }

        /// <summary>
        /// 将标签内容转化为DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet CreateLabDataSet()
        {
            try
            {
                DataSet ds = ZhuiFengLib.Xml.XmlDatasetConvert.ConvertXMLToDataSet(btFormat.SubStrings.XML);
                if (ds.Tables[0].Rows.Count > 0)
                    return ds;
                else { msg.MessageInfo("未找到要设置的模板信息，请确认模板设置是否正确！"); return null; }
            }
            //获取异常信息
            catch (Exception ex) { msg.MessageInfo("加载模板信息过程中发生错误!\r\n" + ex.Message); return null; }
        }

        /// <summary>
        /// 设置标签内容
        /// </summary>
        /// <param name="contentList"></param>
        public void SetLabContent(BtPrintTemplate.ModelList_obs contentList)
        {
            foreach (var rows in contentList)
            {
                if (btFormat.SubStrings.XML.ToString().Contains(rows.Name))
                    btFormat.SubStrings[rows.Name].Value = rows.Value;
            }
        }

        /// <summary>
        /// 将标签模板生成实体类列表
        /// </summary>
        /// <returns></returns>
        public BtPrintTemplate.ModelList_obs CreateTemplateList()
        {
            try
            {
                DataSet ds = ZhuiFengLib.Xml.XmlDatasetConvert.ConvertXMLToDataSet(btFormat.SubStrings.XML);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    msg.MessageInfo("未找到要设置的模板信息，请确认模板设置是否正确！"); return null;
                }
                else
                {
                    var result = new BtPrintTemplate.ModelList_obs();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        result.Add(new Model.OQC_OrderPrintLabInfo() { Name = row["Name"].ToString(), Value = row["Value"].ToString() });
                    }
                    return result;
                }
            }
            //获取异常信息
            catch (Exception ex) { msg.MessageInfo("加载模板信息过程中发生错误!\r\n" + ex.Message); return null; }
        }

        /// <summary>
        /// 标签内容信息
        /// </summary>
        public List<Model.OQC_OrderPrintLabInfo> LabContentList { get; set; } = new List<Model.OQC_OrderPrintLabInfo>();

        /// <summary>
        /// 待打印的Exfo数据
        /// </summary>
        public List<Model.User_JDS_Test_Good> ExfoDataList { get; set; } = new List<Model.User_JDS_Test_Good>();

        /// <summary>
        /// 具体的打印方法
        /// </summary>
        public virtual void OnPrint()
        {
            btFormat.Print();
           // msg.MessageInfo("开始打印...");
            if (PrintConfig.Detailed.PrintType == "HP打印")
            {
                ZhuiFengLib.OfficeHelper.ExcelHelper excel = 
                    new ZhuiFengLib.OfficeHelper.ExcelHelper(PrintConfig.Detailed.DataSourcesPath);
                excel.ClearDate();
            }
        }

        /// <summary>
        /// 开始打印
        /// </summary>
        public void StartPrint()
        {
            OnPrint();
        }
    }
}