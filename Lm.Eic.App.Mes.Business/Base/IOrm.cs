using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lm.Eic.App.Mes.Business
{
    public interface IOrm<TEntity> where TEntity : class
    {
        TEntity Detailed { get; set; }
        bool IsNull { get; }
        Orm<TEntity>.ModelList_obs ModelList { get; set; }

        bool Add(TEntity model);

        int Add(Orm<TEntity>.ModelList_obs list_obs);

        void Add(TEntity model, Orm<TEntity>.ModelList_obs list_obs);

        int DelBy(Expression<Func<TEntity, bool>> delWhere);

        void Delete(TEntity entity);

        void Dispose();

        TEntity GetModel(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetModelList(Expression<Func<TEntity, bool>> predicate);

        void SaveChanges();

        bool Update(TEntity entity);
        bool UpdateForExcel(TEntity entity);
    }
}