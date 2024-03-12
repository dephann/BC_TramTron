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
    public class EventActionCodeRepository : EFRepository<EventActionCode>, IEventActionCodeRepository, IEFRepository<EventActionCode>
    {
        public EventActionCodeRepository(IDbContextManager dbCtxMng)
          : base(dbCtxMng)
        {
            this.KeyProperty = this.GetKeyColumnName(new EventActionCode(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }
    }
}
