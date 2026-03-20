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
    public class MeTronChiTietGiaoHangRepository : EFRepository<MeTronChiTietGiaoHang>, IMeTronChiTietGiaoHangRepository, IEFRepository<MeTronChiTietGiaoHang>
    {
        public MeTronChiTietGiaoHangRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new MeTronChiTietGiaoHang(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }
    }
}