using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public class TimerParaRepository : EFRepository<TimerPara>, ITimerParaRepository, IEFRepository<TimerPara>
	{
		public TimerParaRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new TimerPara(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}