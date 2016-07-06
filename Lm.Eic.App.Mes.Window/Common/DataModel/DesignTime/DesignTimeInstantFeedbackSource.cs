﻿using System;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using Lm.Eic.App.Mes.Window.Common.Utils;
using Lm.Eic.App.Mes.Window.Common.DataModel;
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace Lm.Eic.App.Mes.Window.Common.DataModel.DesignTime
{
    class DesignTimeInstantFeedbackSource<TProjection, TPrimaryKey> : IInstantFeedbackSource<TProjection>
        where TProjection : class
    {
        void IInstantFeedbackSource<TProjection>.Refresh() { }

        bool IInstantFeedbackSource<TProjection>.IsLoadedProxy(object threadSafeProxy)
        {
            return true;
        }

        bool IListSource.ContainsListCollection
        {
            get { return true; }
        }

        IList IListSource.GetList()
        {
            return DesignTimeHelper.CreateDesignTimeObjects<TProjection>(2).ToList();
        }

        TProperty IInstantFeedbackSource<TProjection>.GetPropertyValue<TProperty>(object threadSafeProxy, Expression<Func<TProjection, TProperty>> propertyExpression)
        {
            return default(TProperty);
        }
    }
}