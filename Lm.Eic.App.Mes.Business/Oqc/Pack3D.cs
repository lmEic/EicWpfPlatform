using Lm.Eic.App.Mes.Model;
using System;
using System.Collections.Generic;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： Pack3D
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 16:11:29 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    public class Pack3D : Orm<Model.OQC_Pack3D>
    {
        public Pack3D() : base(Model.Operation.DbTwoMes)
        {
        }

       

        public void Add(IList<User_3D_Test_Good>  user3DTestGoodList,string clientSN, OrderPackLot selectPackLot)
        {
            var temModelList = new ModelList_obs();
            foreach (var temUserTest3D in user3DTestGoodList)
            {
                DelBy(m => m.SN == temUserTest3D.SN);
                temModelList.Add(GetModelForUser3DTestGood(temUserTest3D,  clientSN, selectPackLot));
            }
           
            Add(temModelList);
        }

        public void Add(User_3D_Test_Good user3D, string clientSN, OrderPackLot selectPackLot)
        {
            DelBy(m => m.SN == user3D.SN);
            Add(GetModelForUser3DTestGood(user3D, clientSN, selectPackLot));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        OQC_Pack3D GetModelForUser3DTestGood(User_3D_Test_Good modelOne,string clientSN, OrderPackLot selectPackLot)
        {
            var model = new OQC_Pack3D();
            model.SN = modelOne.SN;
            model.Name = modelOne.Name;
            model.Type = modelOne.Type;
            model.Result = modelOne.Result;
            model.Curvature = modelOne.Curvature;
            model.Curvature_Result = modelOne.Curvature_Result;
            model.Spherical = modelOne.Spherical;
            model.Spherical_Result = modelOne.Spherical_Result;
            model.Planar = modelOne.Planar;
            model.Planar_Result = modelOne.Planar_Result;
            model.Apex_Offset = modelOne.Apex_Offset;
            model.Apex_Offset_Result = modelOne.Apex_Offset_Result;
            model.Bearing = modelOne.Bearing;
            model.Bearing_Result = modelOne.Bearing_Result;
            model.Apex_Angle = modelOne.Apex_Angle;
            model.Apex_Angle_Result = modelOne.Apex_Angle_Result;
            model.Tilt_Offset = modelOne.Tilt_Offset;
            model.Tilt_Offset_Result = modelOne.Tilt_Offset_Result;
            model.Tilt_Angle = modelOne.Tilt_Angle;
            model.Tilt_Angle_Result = modelOne.Tilt_Angle_Result;
            model.KeyError = modelOne.KeyError;
            model.KeyError_Result = modelOne.KeyError_Result;
            model.FiberRq = modelOne.FiberRq;
            model.FiberRq_Result = modelOne.FiberRq_Result;
            model.FiberRa = modelOne.FiberRa;
            model.FiberRa_Result = modelOne.FiberRa_Result;
            model.FerruleRq = modelOne.FerruleRq;
            model.FerruleRq_Result = modelOne.FerruleRq_Result;
            model.FerruleRa = modelOne.FerruleRa;
            model.FerruleRa_Result = modelOne.FerruleRa_Result;
            model.Diameter = modelOne.Diameter;
            model.Diameter_Result = modelOne.Diameter_Result;
            model.Test_Date = modelOne.Test_Date;
            model.Test_Time = modelOne.Test_Time;
            model.D = modelOne.D;
            model.E = modelOne.E;
            model.F = modelOne.F;
            model.A = modelOne.A;
            model.ClientSN = clientSN;
            model.OrderID = selectPackLot.Detailed.OrderID;
            model.PackLot = selectPackLot.Detailed.PackLot;
            model.PackDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return model;
        }

       
    }
}