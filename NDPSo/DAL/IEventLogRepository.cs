using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
	public interface IEventLogRepository : IEFRepository<EventLog>
	{
		IList<EventLog> ListEventLog_ByCondition(DateTime? fromDate, DateTime? toDate, int? userID, int? eventActionCodeID);
	}
}
