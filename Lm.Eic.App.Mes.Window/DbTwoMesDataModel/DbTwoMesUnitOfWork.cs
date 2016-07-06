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
    /// A DbTwoMesUnitOfWork instance that represents the run-time implementation of the IDbTwoMesUnitOfWork interface.
    /// </summary>
    public class DbTwoMesUnitOfWork : DbUnitOfWork<DbTwoMes>, IDbTwoMesUnitOfWork
    {

        public DbTwoMesUnitOfWork(Func<DbTwoMes> contextFactory)
            : base(contextFactory)
        {
        }

        IRepository<OQC_InspectStatnard, decimal> IDbTwoMesUnitOfWork.OQC_InspectStatnard
        {
            get { return GetRepository(x => x.Set<OQC_InspectStatnard>(), (OQC_InspectStatnard x) => x.ID_Key); }
        }

        IRepository<OQC_OrderInspectConfig, decimal> IDbTwoMesUnitOfWork.OQC_OrderInspectConfig
        {
            get { return GetRepository(x => x.Set<OQC_OrderInspectConfig>(), (OQC_OrderInspectConfig x) => x.ID_Key); }
        }

        IRepository<OQC_OrderInspectStatnard, decimal> IDbTwoMesUnitOfWork.OQC_OrderInspectStatnard
        {
            get { return GetRepository(x => x.Set<OQC_OrderInspectStatnard>(), (OQC_OrderInspectStatnard x) => x.ID_Key); }
        }

        IRepository<OQC_OrderPackLot, string> IDbTwoMesUnitOfWork.OQC_OrderPackLot
        {
            get { return GetRepository(x => x.Set<OQC_OrderPackLot>(), (OQC_OrderPackLot x) => x.PackLot); }
        }

        IRepository<OQC_OrderPrintConfig, string> IDbTwoMesUnitOfWork.OQC_OrderPrintConfig
        {
            get { return GetRepository(x => x.Set<OQC_OrderPrintConfig>(), (OQC_OrderPrintConfig x) => x.PackLot); }
        }

        IRepository<OQC_OrderPrintLabInfo, decimal> IDbTwoMesUnitOfWork.OQC_OrderPrintLabInfo
        {
            get { return GetRepository(x => x.Set<OQC_OrderPrintLabInfo>(), (OQC_OrderPrintLabInfo x) => x.ID_Key); }
        }

        IRepository<OQC_Pack3D, decimal> IDbTwoMesUnitOfWork.OQC_Pack3D
        {
            get { return GetRepository(x => x.Set<OQC_Pack3D>(), (OQC_Pack3D x) => x.ID_Key); }
        }

        IRepository<OQC_PackExfo, decimal> IDbTwoMesUnitOfWork.OQC_PackExfo
        {
            get { return GetRepository(x => x.Set<OQC_PackExfo>(), (OQC_PackExfo x) => x.ID_Key); }
        }

        IRepository<OQC_ProductInspectStandard, decimal> IDbTwoMesUnitOfWork.OQC_ProductInspectStandard
        {
            get { return GetRepository(x => x.Set<OQC_ProductInspectStandard>(), (OQC_ProductInspectStandard x) => x.ID_Key); }
        }

        IRepository<OQC_ProductPrintConfig, decimal> IDbTwoMesUnitOfWork.OQC_ProductPrintConfig
        {
            get { return GetRepository(x => x.Set<OQC_ProductPrintConfig>(), (OQC_ProductPrintConfig x) => x.ID_Key); }
        }

        IRepository<OQC_ProductSerialNumberConfig, decimal> IDbTwoMesUnitOfWork.OQC_ProductSerialNumberConfig
        {
            get { return GetRepository(x => x.Set<OQC_ProductSerialNumberConfig>(), (OQC_ProductSerialNumberConfig x) => x.ID_Key); }
        }

        IRepository<OQC_SerialNumber, string> IDbTwoMesUnitOfWork.OQC_SerialNumber
        {
            get { return GetRepository(x => x.Set<OQC_SerialNumber>(), (OQC_SerialNumber x) => x.SN); }
        }
    }
}
