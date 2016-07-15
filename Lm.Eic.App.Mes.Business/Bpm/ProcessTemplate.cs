using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Utility.UtilityException;
using System;
using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class ProcessTemplate : Orm<Model.BPM_ProductTemplate>
    {
        public ProcessTemplate() : base(Model.Operation.DbTwoMes)
        {
        }

     

        /// <summary>
        /// 获取磨具ID列表
        /// </summary>
        /// <param name="ptID"></param>
        /// <param name="processID"></param>
        /// <returns></returns>
        public List<string> GetMouldList(string ptID, string processID)
        {
            try
            {
                var mouldList = new List<string>();
                var procssTemplateList = GetModelList(m => m.PtID == ptID && m.ProcessID == processID);
                //foreach (var pt in procssTemplateList)   待修改数据库
                //   mouldList.Add(pt.MouldNum);    
                return mouldList;
            }
            catch (Exception e)
            {
                throw new RepoitoryException("获取磨具列表失败！", e);
            }
        }
    }
}