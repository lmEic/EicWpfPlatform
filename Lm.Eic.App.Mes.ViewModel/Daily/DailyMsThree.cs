using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business.Ast;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Model;
using System;
using System.Linq;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;


namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    /// <summary>
    /// 从制七课继承
    /// </summary>
    class DailyMsThree :DailyMsSeven
    {
        internal DailyMsThree() : base()
        {
            Detartment = "制三课";
        }

        /// <summary>
        /// 机台编号
        /// </summary>
        public override string AssetNum
        {
            get { return Daily.Detailed.AssetNum; }
            set
            {
                Daily.Detailed.AssetNum = value;
                this.RaisePropertyChanged("AssetNum");
                if (!value.IsNullOrEmpty())
                {
                    Equipment = new Equipment($"MS3_{value}");
                    Daily.Detailed.AssetName = Equipment?.Detailed?.AssetName;
                    ProcessID = Equipment?.Detailed?.ProcessID;
                    MasterName = Equipment?.Detailed?.MasterName;
                }

            }
        }



    }
}
