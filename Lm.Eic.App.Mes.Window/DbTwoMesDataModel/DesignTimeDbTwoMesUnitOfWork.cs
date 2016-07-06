using System;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using Lm.Eic.App.Mes.Window.Common.Utils;
using Lm.Eic.App.Mes.Window.Common.DataModel;
using Lm.Eic.App.Mes.Window.Common.DataModel.DesignTime;
using Lm.Eic.App.Mes.Window.Common.DataModel.EntityFramework;
using Lm.Eic.App.Mes.Model;

namespace Lm.Eic.App.Mes.Window.DbTwoMesDataModel
{
    /// <summary>
    /// A DbTwoMesDesignTimeUnitOfWork instance that represents the design-time implementation of the IDbTwoMesUnitOfWork interface.
    /// </summary>
    public class DbTwoMesDesignTimeUnitOfWork : DesignTimeUnitOfWork, IDbTwoMesUnitOfWork
    {

        /// <summary>
        /// Initializes a new instance of the DbTwoMesDesignTimeUnitOfWork class.
        /// </summary>
        public DbTwoMesDesignTimeUnitOfWork()
        {
        }

        IRepository<OQC_InspectStatnard, decimal> IDbTwoMesUnitOfWork.OQC_InspectStatnard
        {
            get { return GetRepository((OQC_InspectStatnard x) => x.ID_Key); }
        }

        IRepository<OQC_OrderInspectConfig, decimal> IDbTwoMesUnitOfWork.OQC_OrderInspectConfig
        {
            get { return GetRepository((OQC_OrderInspectConfig x) => x.ID_Key); }
        }

        IRepository<OQC_OrderInspectStatnard, decimal> IDbTwoMesUnitOfWork.OQC_OrderInspectStatnard
        {
            get { return GetRepository((OQC_OrderInspectStatnard x) => x.ID_Key); }
        }

        IRepository<OQC_OrderPackLot, string> IDbTwoMesUnitOfWork.OQC_OrderPackLot
        {
            get { return GetRepository((OQC_OrderPackLot x) => x.PackLot); }
        }

        IRepository<OQC_OrderPrintConfig, string> IDbTwoMesUnitOfWork.OQC_OrderPrintConfig
        {
            get { return GetRepository((OQC_OrderPrintConfig x) => x.PackLot); }
        }

        IRepository<OQC_OrderPrintLabInfo, decimal> IDbTwoMesUnitOfWork.OQC_OrderPrintLabInfo
        {
            get { return GetRepository((OQC_OrderPrintLabInfo x) => x.ID_Key); }
        }

        IRepository<OQC_Pack3D, decimal> IDbTwoMesUnitOfWork.OQC_Pack3D
        {
            get { return GetRepository((OQC_Pack3D x) => x.ID_Key); }
        }

        IRepository<OQC_PackExfo, decimal> IDbTwoMesUnitOfWork.OQC_PackExfo
        {
            get { return GetRepository((OQC_PackExfo x) => x.ID_Key); }
        }

        IRepository<OQC_ProductInspectStandard, decimal> IDbTwoMesUnitOfWork.OQC_ProductInspectStandard
        {
            get { return GetRepository((OQC_ProductInspectStandard x) => x.ID_Key); }
        }

        IRepository<OQC_ProductPrintConfig, decimal> IDbTwoMesUnitOfWork.OQC_ProductPrintConfig
        {
            get { return GetRepository((OQC_ProductPrintConfig x) => x.ID_Key); }
        }

        IRepository<OQC_ProductSerialNumberConfig, decimal> IDbTwoMesUnitOfWork.OQC_ProductSerialNumberConfig
        {
            get { return GetRepository((OQC_ProductSerialNumberConfig x) => x.ID_Key); }
        }

        IRepository<OQC_SerialNumber, string> IDbTwoMesUnitOfWork.OQC_SerialNumber
        {
            get { return GetRepository((OQC_SerialNumber x) => x.SN); }
        }
    }
}
