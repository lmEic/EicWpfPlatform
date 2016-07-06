using Lm.Eic.App.Mes.Utility.UtilityException;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using msg = ZhuiFengLib.Message.Message;

using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Lm.Eic.App.Mes.Business
{
    public abstract class Orm<TEntity> : IDisposable, IOrm<TEntity> where TEntity : class
    {
        #region Global Variable

        /// <summary>
        /// 构造函数 初始化基类
        /// </summary>
        /// <param name="db"></param>
        public Orm(DbContext db)
        {
            this.Db = db;
            DbTab = Db.Set<TEntity>();
        }

        //BMK 数据集
        private DbContext Db;

        //表
        private DbSet<TEntity> DbTab;

        /// <summary>
        /// 列表基类
        /// </summary>
        public class ModelList_obs : ObservableCollection<TEntity>
        {
            public ModelList_obs()
            {
            }

            public ModelList_obs(List<TEntity> list) : base(list)
            {
            }

            public void Add(List<TEntity> list)
            {
                foreach (var tem in list)
                    this.Add(tem);
            }
        }

        #endregion Global Variable

        #region Parameter

        

         
        private TEntity detailed = (TEntity)Activator.CreateInstance(typeof(TEntity));
        /// <summary>
        /// 数据模型
        /// </summary>
        virtual public  TEntity Detailed
        {
            get { return detailed; }
            set
            {
                detailed = value;
            }
        }


        /// <summary>
        /// 数据模型列表
        /// </summary>
        public ModelList_obs ModelList { get; set; }

        #endregion Parameter

        #region Public Method

        /// <summary>
        /// 实体类是否为空
        /// </summary>
        public bool IsNull
        {
            get { return Detailed == null ? true : false; }
        }

        /// <summary>
        /// 添加一个数据模型到数据库
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public virtual bool Add(TEntity model)
        {
            try
            {
                DbTab.Add(model);
                return Db.SaveChanges() > 0 ? true : false;
            }catch(Exception ex) { msg.MessageInfo($"添加实体失败 \r\n{ex.Message}" ); return false; }
           
        }

        /// <summary>
        /// 添加列表中的数据模型到数据中
        /// </summary>
        /// <param name="list_obs"></param>
        /// <returns></returns>
        public int Add(ModelList_obs list_obs)
        {
            foreach (var tem in list_obs)
                DbTab.Add(tem);
            return Db.SaveChanges();
        }

        /// <summary>
        /// 添加一个数据模型到列表
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="list_obs">列表</param>
        public void Add(TEntity model, ModelList_obs list_obs)
        {
            list_obs.Add(model);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> GetModelList(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return DbTab.Where(predicate)?.ToList();
            }
            catch (Exception e)
            {
                ZhuiFengLib.Message.Message.MessageInfo($"获取模板失败！\r\n{e.Message}");
                return null;
            }
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity GetModel(Expression<Func<TEntity, bool>> predicate)
        {
            var tList = GetModelList(predicate);
            return tList.Count > 0 ? tList[0] : null;
        }

        /// <summary>
        /// 监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool RemoveHoldingEntityInContext(TEntity entity)
        {
            ObjectContext objContext = ((IObjectContextAdapter)Db).ObjectContext;
            var objSet = objContext.CreateObjectSet<TEntity>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
            object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            if (exists)
            {
                objContext.Detach(foundEntity);
            }
            return (exists);
        }

        /// <summary>
        /// 更新本Detailed 到数据库
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update()
        {
            return Update(Detailed);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            RemoveHoldingEntityInContext(entity);
            try
            {
               // RemoveHoldingEntityInContext(entity);

                var set = Db.Set<TEntity>();
                set.Attach(entity);
                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    Add(entity);
                    return true;
                }
                catch (Exception ex)
                {

                    // throw new RepoitoryException("更新实体失败", e);
                    msg.MessageInfo($"更新或添加实体失败 \r\n{ex.Message}");
                    return false;
                }
             
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateForExcel(TEntity entity)
        {
            try
            {
                RemoveHoldingEntityInContext(entity);

                var set = Db.Set<TEntity>();
                set.Attach(entity);
                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    Add(entity);
                    return true;
                }
                catch (Exception ex)
                {
                    // throw new RepoitoryException("更新实体失败", e);
                    msg.MessageInfo($"更新或添加实体失败 \r\n{ex.Message}");
                    return false;
                }

            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            try
            {
                Db.Set<TEntity>().Attach(entity);
                Db.Set<TEntity>().Remove(entity);
                Db.SaveChanges();
                //context.Entry<T>(entity).State = EntityState.Deleted;
                //context.SaveChanges();
            }
            catch (Exception e)
            {
               // throw new RepoitoryException("删除实体失败", e);
                msg.MessageInfo($"删除实体失败{e.Message}");
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public virtual int DelBy(Expression<Func<TEntity, bool>> delWhere)
        {
            //查询要删除的数据
            List<TEntity> listDeleting = Db.Set<TEntity>().Where(delWhere).ToList();
            //将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                Db.Set<TEntity>().Attach(u);//先附加到 EF容器
                Db.Set<TEntity>().Remove(u);//标识为 删除 状态
            });
            //一次性 生成sql语句到数据库执行删除
            return Db.SaveChanges();
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new RepoitoryException("保存至数据库失败", e);
            }
        }

        /// <summary>
        /// 释放内存
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
        }

        #endregion Public Method
    }
}