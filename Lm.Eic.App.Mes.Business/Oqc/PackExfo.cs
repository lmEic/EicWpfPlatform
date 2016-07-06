using System;
using Lm.Eic.App.Mes.Model;
using System.Collections.Generic;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： PackExfo
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 16:11:43 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    public class PackExfo : Orm<Model.OQC_PackExfo>
    {
        public PackExfo() : base(Model.Operation.DbTwoMes)
        {
        }

    

       
        /// <summary>
        /// 将列表中的数据添加到已包装数据库
        /// </summary>
        /// <param name="userExfoTestGoodList"></param>
        /// <param name="clientSN"></param>
        /// <param name="selectPackLot"></param>
        public void Add(IList<User_JDS_Test_Good>  userExfoTestGoodList, string clientSN, OrderPackLot selectPackLot)
        {
            var temModelList = new ModelList_obs();
            foreach (var exfo in userExfoTestGoodList)
            {
                DelBy(m => m.SN == exfo.SN);
                temModelList.Add(GetModel(exfo, clientSN, selectPackLot));
            }
            Add(temModelList);
        }

        /// <summary>
        /// 将一条记录添加到已包装数据库
        /// </summary>
        /// <param name="exfo"></param>
        /// <param name="clientSN"></param>
        /// <param name="selectPackLot"></param>
        public void Add(User_JDS_Test_Good exfo,string clientSN, OrderPackLot selectPackLot)
        {
            DelBy(m => m.SN == exfo.SN);
            Add(GetModel(exfo, clientSN, selectPackLot));
        }
        
        OQC_PackExfo GetModel(User_JDS_Test_Good exfo, string clientSN, OrderPackLot selectPackLot)
        {
            var temMode = new OQC_PackExfo();
            temMode.SN = exfo.SN;
            temMode.Result = exfo.Result;
            temMode.Wave = exfo.Wave;
            temMode.IL_A = exfo.IL_A;
            temMode.Refl_A = exfo.Refl_A;
            temMode.ClientSN = clientSN;
            temMode.PackDate = DateTime.Now;
            temMode.PackLot = selectPackLot.Detailed.PackLot;
            temMode.OrderID = selectPackLot.Detailed.OrderID;
            return temMode;
        }
        
    }
}