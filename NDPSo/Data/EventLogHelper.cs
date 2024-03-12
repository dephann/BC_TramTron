using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class EventLogHelper
	{
		public static void CopyToObjEventLog(EventLog fromEnt, ObjEventLog toObj)
		{
			toObj.EventLogID = fromEnt.EventLogID;
			toObj.LogCode = fromEnt.LogCode;
			toObj.LogDate = fromEnt.LogDate;
			toObj.UserID = fromEnt.UserID;
			toObj.UserName = fromEnt.UserName;
			toObj.EventActionCodeID = fromEnt.EventActionCodeID;
			toObj.EventActionContent = fromEnt.EventActionContent;
			toObj.Description = fromEnt.Description;
			toObj.OldValueNumeric = fromEnt.OldValueNumeric;
			toObj.NewValueNumeric = fromEnt.NewValueNumeric;
			toObj.OldValueText = fromEnt.OldValueText;
			toObj.NewValueText = fromEnt.NewValueText;
			toObj.Title1 = fromEnt.Title1;
			toObj.Value1 = fromEnt.Value1;
			toObj.Content1 = fromEnt.Content1;
			toObj.Title2 = fromEnt.Title2;
			toObj.Value2 = fromEnt.Value2;
			toObj.Content2 = fromEnt.Content2;
			toObj.Title3 = fromEnt.Title3;
			toObj.Value3 = fromEnt.Value3;
			toObj.Content3 = fromEnt.Content3;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.EventLogID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntEventLog(ObjEventLog fromObj, EventLog toEnt)
		{
			toEnt.EventLogID = fromObj.EventLogID;
			toEnt.LogCode = fromObj.LogCode;
			toEnt.LogDate = fromObj.LogDate;
			toEnt.UserID = fromObj.UserID;
			toEnt.UserName = fromObj.UserName;
			toEnt.EventActionCodeID = fromObj.EventActionCodeID;
			toEnt.EventActionContent = fromObj.EventActionContent;
			toEnt.Description = fromObj.Description;
			toEnt.OldValueNumeric = fromObj.OldValueNumeric;
			toEnt.NewValueNumeric = fromObj.NewValueNumeric;
			toEnt.OldValueText = fromObj.OldValueText;
			toEnt.NewValueText = fromObj.NewValueText;
			toEnt.Title1 = fromObj.Title1;
			toEnt.Value1 = fromObj.Value1;
			toEnt.Content1 = fromObj.Content1;
			toEnt.Title2 = fromObj.Title2;
			toEnt.Value2 = fromObj.Value2;
			toEnt.Content2 = fromObj.Content2;
			toEnt.Title3 = fromObj.Title3;
			toEnt.Value3 = fromObj.Value3;
			toEnt.Content3 = fromObj.Content3;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjEventLog BuildNewObjEventLog(EventLog entEventLog)
		{
			ObjEventLog objEventLog = new ObjEventLog();
			EventLogHelper.CopyToObjEventLog(entEventLog, objEventLog);
			return objEventLog;
		}

		public static IList<ObjEventLog> BuildListObjEventLog(IList<EventLog> lstEntEventLog)
		{
			IList<ObjEventLog> lstObjEventLog = new List<ObjEventLog>();
			foreach (EventLog entEventLog in lstEntEventLog)
			{
				lstObjEventLog.Add(EventLogHelper.BuildNewObjEventLog(entEventLog));
			}
			return lstObjEventLog;
		}

		public static EventLog BuildNewEntEventLog(ObjEventLog objEventLog)
		{
			EventLog entEventLog = new EventLog();
			EventLogHelper.CopyToEntEventLog(objEventLog, entEventLog);
			return entEventLog;
		}

		public static IList<EventLog> BuildListEntEventLog(IList<ObjEventLog> lstObjEventLog)
		{
			IList<EventLog> lstEntEventLog = new List<EventLog>();
			foreach (ObjEventLog objEventLog in lstObjEventLog)
			{
				lstEntEventLog.Add(EventLogHelper.BuildNewEntEventLog(objEventLog));
			}
			return lstEntEventLog;
		}
	}
}
