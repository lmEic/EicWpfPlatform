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
    /// IDbTwoMesUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IDbTwoMesUnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// The OQC_InspectStatnard entities repository.
        /// </summary>
        IRepository<OQC_InspectStatnard, decimal> OQC_InspectStatnard { get; }

        /// <summary>
        /// The OQC_OrderInspectConfig entities repository.
        /// </summary>
        IRepository<OQC_OrderInspectConfig, decimal> OQC_OrderInspectConfig { get; }

        /// <summary>
        /// The OQC_OrderInspectStatnard entities repository.
        /// </summary>
        IRepository<OQC_OrderInspectStatnard, decimal> OQC_OrderInspectStatnard { get; }

        /// <summary>
        /// The OQC_OrderPackLot entities repository.
        /// </summary>
        IRepository<OQC_OrderPackLot, string> OQC_OrderPackLot { get; }

        /// <summary>
        /// The OQC_OrderPrintConfig entities repository.
        /// </summary>
        IRepository<OQC_OrderPrintConfig, string> OQC_OrderPrintConfig { get; }

        /// <summary>
        /// The OQC_OrderPrintLabInfo entities repository.
        /// </summary>
        IRepository<OQC_OrderPrintLabInfo, decimal> OQC_OrderPrintLabInfo { get; }

        /// <summary>
        /// The OQC_Pack3D entities repository.
        /// </summary>
        IRepository<OQC_Pack3D, decimal> OQC_Pack3D { get; }

        /// <summary>
        /// The OQC_PackExfo entities repository.
        /// </summary>
        IRepository<OQC_PackExfo, decimal> OQC_PackExfo { get; }

        /// <summary>
        /// The OQC_ProductInspectStandard entities repository.
        /// </summary>
        IRepository<OQC_ProductInspectStandard, decimal> OQC_ProductInspectStandard { get; }

        /// <summary>
        /// The OQC_ProductPrintConfig entities repository.
        /// </summary>
        IRepository<OQC_ProductPrintConfig, decimal> OQC_ProductPrintConfig { get; }

        /// <summary>
        /// The OQC_ProductSerialNumberConfig entities repository.
        /// </summary>
        IRepository<OQC_ProductSerialNumberConfig, decimal> OQC_ProductSerialNumberConfig { get; }

        /// <summary>
        /// The OQC_SerialNumber entities repository.
        /// </summary>
        IRepository<OQC_SerialNumber, string> OQC_SerialNumber { get; }
    }
}
