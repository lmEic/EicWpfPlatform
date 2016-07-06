using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.ViewModel
{
    /// <summary>
    /// ViewModeBase 自定义基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class VMbase : ViewModelBase, IDisposable
    {
        #region IDisposable Support

        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }

    /// <summary>
    /// ViewModeBase 自定义基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class VMbase<TEntity> : ViewModelBase, IVMbase<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="business">逻辑类</param>
        public VMbase(Business.IOrm<TEntity> business)
        {
            this.BusinessOperation = business;
        }

        /// <summary>
        /// 逻辑类
        /// </summary>
        public Business.IOrm<TEntity> BusinessOperation { get; set; }





        /// <summary>
        /// 数据实体模型
        /// </summary>
        public TEntity Detailed
        {
            get { return BusinessOperation.Detailed; }
            set
            {
                BusinessOperation.Detailed = value;
                this.RaisePropertyChanged(nameof(Detailed));
                //界面控件启用状态
                ModeControl.IsEnEdit = true;
                ModeControl.IsEnSava = false;
                ModeControl.IsEnCancel = false;
                ModeControl.IsEnDelete = true;
                ModeControl.IsEnConrols = false;
            }
        }


        /// <summary>
        /// 数据实体模型列表
        /// </summary>
        public IList<TEntity> ModelList_Obs
        {
            get { return BusinessOperation.ModelList; }
            set
            {
                try
                {
                    BusinessOperation.ModelList = new Business.Orm<TEntity>.ModelList_obs(value.ToList()); this.RaisePropertyChanged(nameof(ModelList_Obs));

                }catch(Exception ex) { msg.MessageInfo(ex.Message); }
            }
        }

        private ModeControl modelControl = new ModeControl();

        /// <summary>
        /// 状态控制
        /// </summary>
        public ModeControl ModeControl
        {
            get { return modelControl; }
            set
            {
                modelControl = value;
                this.RaisePropertyChanged(nameof(ModeControl));
            }
        }

        /// <summary>
        /// 添加 对Detailed属性 实例化一个新的实体类
        /// </summary>
        abstract public void Add();

        /// <summary>
        ///  添加 命令
        /// </summary>
        public RelayCommand AddCommand => new RelayCommand(() =>
        {
            Add();
            //界面控件启用状态
            ModeControl.IsEnEdit = false;
            ModeControl.IsEnSava = true;
            ModeControl.IsEnCancel = true;
            ModeControl.IsEnDelete = false;
            ModeControl.IsEnConrols = true;
        });


        public virtual void Edit() { }

        /// <summary>
        /// 修改  命令
        /// </summary>
        public RelayCommand EditCommand => new RelayCommand(() =>
        {
            Edit();
            //界面控件启用状态
            ModeControl.IsEnEdit = true;
            ModeControl.IsEnSava = true;
            ModeControl.IsEnCancel = true;
            ModeControl.IsEnDelete = true;
            ModeControl.IsEnConrols = true;
        });

        /// <summary>
        /// 删除  命令
        /// </summary>
        public RelayCommand DeleteCommand => new RelayCommand(() =>
        {
            if (!BusinessOperation.IsNull && msg.IsOkMessage("确定要执行删除操作麽！"))
            {
                BusinessOperation.Delete(Detailed);
                ModelList_Obs.Remove(Detailed);
            }
        });

        public virtual void Sava()
        {
            if (ModeControl.IsEnEdit)
                BusinessOperation.Update(Detailed);
            else
            {
                BusinessOperation.Add(Detailed);
                ModelList_Obs.Add(Detailed);
            }
        }

        /// <summary>
        /// 保存  命令
        /// </summary>
        public RelayCommand SaveCommand => new RelayCommand(() =>
        {
            Sava();
            //界面控件启用状态
            ModeControl.IsEnEdit = true;
            ModeControl.IsEnSava = true;
            ModeControl.IsEnCancel = false;
            ModeControl.IsEnDelete = true;
            ModeControl.IsEnConrols = false;
        });

        /// <summary>
        /// 保存  命令
        /// </summary>
        public RelayCommand CancelCommand => new RelayCommand(() =>
        {
            //界面控件启用状态
            ModeControl.IsEnConrols = false;
        });

        /// <summary>
        /// 按指定条件进行搜索
        /// 抽象方法 必须实现
        /// </summary>
        abstract public void Seach();

        /// <summary>
        /// 搜索
        /// </summary>
        public RelayCommand SearchCommand => new RelayCommand(() =>
        {
            Seach();
        });

        /// <summary>
        /// 从Excel中导入一条 或多条数据
        /// 抽象方法 必须实现
        /// </summary>
        virtual public void ImportForExcel()
        {
            try
            {
                var sfd = new OpenFileDialog();
                sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ModelList_Obs = ExDataTable.GetDataTableForExcel(sfd.FileName).ConvertToList<TEntity>();
                    foreach (var temModel in ModelList_Obs)
                    {
                        BusinessOperation.UpdateForExcel(temModel);
                    }
                }
                msg.MessageInfo("导入成功！");
            }catch(Exception ex) { msg.MessageInfo($"从Excel导入列表失败！\r\n{ex.Message}"); }
          
        }

        /// <summary>
        ///  导入
        /// </summary>
        public RelayCommand ImportCommand => new RelayCommand(() =>
        {
            ImportForExcel();
        });

        /// <summary>
        /// 导出到Excel 允许子类重写
        /// </summary>
        public virtual void ExportToExcel()
        {
            ModelList_Obs.ToList().ExportToExcel(true, 1);
        }

        /// <summary>
        ///  导出
        /// </summary>
        public RelayCommand ExportCommand => new RelayCommand(() =>
        {
            ExportToExcel();
        });
    }

    /// <summary>
    /// 状态控制
    /// </summary>
    public class ModeControl : ViewModelBase
    {
        private bool isEnAdd = true;

        /// <summary>
        /// 添加按钮是否可用
        /// </summary>
        public bool IsEnAdd
        {
            get { return isEnAdd; }
            set
            {
                isEnAdd = value;
                this.RaisePropertyChanged(nameof(IsEnAdd));
            }
        }

        private bool isEnEdit = false;

        /// <summary>
        /// 编辑按钮是否可用
        /// </summary>
        public bool IsEnEdit
        {
            get { return isEnEdit; }
            set
            {
                isEnEdit = value;
                this.RaisePropertyChanged(nameof(IsEnEdit));
            }
        }

        private bool isEnDelete = false;

        /// <summary>
        /// 删除按钮是否可用
        /// </summary>
        public bool IsEnDelete
        {
            get { return isEnDelete; }
            set
            {
                isEnDelete = value;
                this.RaisePropertyChanged(nameof(IsEnDelete));
            }
        }

        private bool isEnSava = false;

        /// <summary>
        /// 保存按钮是否可用
        /// </summary>
        public bool IsEnSava
        {
            get { return isEnSava; }
            set
            {
                isEnSava = value;
                this.RaisePropertyChanged(nameof(IsEnSava));
            }
        }

        private bool isEnCancel = false;

        /// <summary>
        ///
        /// </summary>
        public bool IsEnCancel
        {
            get { return isEnCancel; }
            set
            {
                isEnCancel = value;
                this.RaisePropertyChanged(nameof(IsEnCancel));
            }
        }

        private bool isEnControl = false;

        /// <summary>
        /// 窗体上的录入控件是否可用
        /// </summary>
        public bool IsEnConrols
        {
            get { return isEnControl; }
            set
            {
                isEnControl = value;
                this.RaisePropertyChanged(nameof(IsEnConrols));
            }
        }
    }
}