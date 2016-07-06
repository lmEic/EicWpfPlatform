using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZhuiFengLib.Extension;

namespace Lm.Eic.App.Mes.ViewModel.Config
{
    public class CommonParaSet : ViewModelBase
    {
        public CommonParaSet()
        {
            foreach (var Para in Business.Operation.ConfigHelper.CommonParaSet.GetParaList())
                ParameterNames.Add(Para);
        }

        public class ParameterValue_obs : ObservableCollection<string> { }

        private static ParameterValue_obs parrmenterValue;

        /// <summary>
        /// 参数列表
        /// </summary>
        public static ParameterValue_obs ParameterValues => parrmenterValue = parrmenterValue == null ? new ParameterValue_obs() : parrmenterValue;

        public class ParameterName_obs : ObservableCollection<string> { }

        private static ParameterName_obs parrmenterNames;

        /// <summary>
        /// 参数列表
        /// </summary>
        public static ParameterName_obs ParameterNames => parrmenterNames = parrmenterNames == null ? new ParameterName_obs() : parrmenterNames;

        private string paraName = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string ParaName
        {
            get { return paraName; }
            set
            {
                paraName = value;
                if (!paraName.IsNullOrEmpty())
                {
                    ParameterValues.Clear();
                    foreach (var myvalue in Business.Operation.ConfigHelper.CommonParaSet.GetValueList(paraName))
                        ParameterValues.Add(myvalue);
                }
                this.RaisePropertyChanged("ParaName");
            }
        }

        /// <summary>
        ///
        /// </summary>
        public RelayCommand<string> AddValue => new RelayCommand<string>((value) =>
        {
            ParameterValues.Add(value);
            Business.Operation.ConfigHelper.CommonParaSet.Add(ParaName, new List<string>() { value });
        });

        /// <summary>
        ///
        /// </summary>
        public RelayCommand<string> AddName => new RelayCommand<string>((value) =>
        {
            ParameterNames.Add(value);
        });
    }
}