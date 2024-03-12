using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_FunctionHelper
	{
		public static void CopyToObjSEC_Function(SEC_Function fromEnt, ObjSEC_Function toObj)
		{
			toObj.FunctionID = fromEnt.FunctionID;
			toObj.FunctionCode = fromEnt.FunctionCode;
			toObj.FunctionName = fromEnt.FunctionName;
			toObj.MenuName = fromEnt.MenuName;
			toObj.OtherName = fromEnt.OtherName;
			toObj.FunctionType = fromEnt.FunctionType;
			toObj.ParentID = fromEnt.ParentID;
			toObj.IsStatic = fromEnt.IsStatic;
			toObj.ShowAsBarItem = fromEnt.ShowAsBarItem;
			toObj.DisplayOrder = fromEnt.DisplayOrder;
			toObj.BeginAsAGroup = fromEnt.BeginAsAGroup;
			toObj.Visible = fromEnt.Visible;
			toObj.Description = fromEnt.Description;
			toObj.TypeInfoID = fromEnt.TypeInfoID;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.FunctionID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_Function(ObjSEC_Function fromObj, SEC_Function toEnt)
		{
			toEnt.FunctionID = fromObj.FunctionID;
			toEnt.FunctionCode = fromObj.FunctionCode;
			toEnt.FunctionName = fromObj.FunctionName;
			toEnt.MenuName = fromObj.MenuName;
			toEnt.OtherName = fromObj.OtherName;
			toEnt.FunctionType = fromObj.FunctionType;
			toEnt.ParentID = fromObj.ParentID;
			toEnt.IsStatic = fromObj.IsStatic;
			toEnt.ShowAsBarItem = fromObj.ShowAsBarItem;
			toEnt.DisplayOrder = fromObj.DisplayOrder;
			toEnt.BeginAsAGroup = fromObj.BeginAsAGroup;
			toEnt.Visible = fromObj.Visible;
			toEnt.Description = fromObj.Description;
			toEnt.TypeInfoID = fromObj.TypeInfoID;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjSEC_Function BuildNewObjSEC_Function(SEC_Function entSEC_Function)
		{
			ObjSEC_Function objSEC_Function = new ObjSEC_Function();
			SEC_FunctionHelper.CopyToObjSEC_Function(entSEC_Function, objSEC_Function);
			return objSEC_Function;
		}

		public static IList<ObjSEC_Function> BuildListObjSEC_Function(IList<SEC_Function> lstEntSEC_Function)
		{
			IList<ObjSEC_Function> lstObjSEC_Function = new List<ObjSEC_Function>();
			foreach (SEC_Function entSEC_Function in lstEntSEC_Function)
			{
				lstObjSEC_Function.Add(SEC_FunctionHelper.BuildNewObjSEC_Function(entSEC_Function));
			}
			return lstObjSEC_Function;
		}

		public static SEC_Function BuildNewEntSEC_Function(ObjSEC_Function objSEC_Function)
		{
			SEC_Function entSEC_Function = new SEC_Function();
			SEC_FunctionHelper.CopyToEntSEC_Function(objSEC_Function, entSEC_Function);
			return entSEC_Function;
		}

		public static IList<SEC_Function> BuildListEntSEC_Function(IList<ObjSEC_Function> lstObjSEC_Function)
		{
			IList<SEC_Function> lstEntSEC_Function = new List<SEC_Function>();
			foreach (ObjSEC_Function objSEC_Function in lstObjSEC_Function)
			{
				lstEntSEC_Function.Add(SEC_FunctionHelper.BuildNewEntSEC_Function(objSEC_Function));
			}
			return lstEntSEC_Function;
		}
	}
}
