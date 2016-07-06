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
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace Lm.Eic.App.Mes.Window.DbTwoMesDataModel
{
    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource
    {
        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        /// </summary>
        public static IUnitOfWorkFactory<IDbTwoMesUnitOfWork> GetUnitOfWorkFactory()
        {
            return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<IDbTwoMesUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime)
        {
            if (isInDesignTime)
                return new DesignTimeUnitOfWorkFactory<IDbTwoMesUnitOfWork>(() => new DbTwoMesDesignTimeUnitOfWork());
            return new DbUnitOfWorkFactory<IDbTwoMesUnitOfWork>(() => new DbTwoMesUnitOfWork(() => new DbTwoMes()));
        }
    }
}