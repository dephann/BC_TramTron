using System;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.Utils;

namespace NDPSo
{
    public class EventLogController
    {
       public static bool InsertEventLog(ObjEventLog objEventLog)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.InsertEventLog(objEventLog);
		}

		public static bool InsertEventLog(int? userId, string userName, string eventActionCode, string result, string oldValueText, string newValueText)
		{
			IServices factory = ServiceFactories.GetFactory(0);
			return factory.InsertEventLog(userId, userName, eventActionCode, result, oldValueText, newValueText);
		}
    }
}
