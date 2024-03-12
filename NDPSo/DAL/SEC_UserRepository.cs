using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public class SEC_UserRepository : EFRepository<SEC_User>, ISEC_UserRepository, IEFRepository<SEC_User>
	{
		public SEC_UserRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new SEC_User(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public SEC_User GetSEC_User_ByUsername_Pass(string username, string password)
		{
			string decryptedPassword = EncryptionHelper.Encrypt(password);
			//string decryptedPassword = password;
			Specification<SEC_User> spec = new Specification<SEC_User>((SEC_User u) => u.UserName == username && u.Password == decryptedPassword);
			SEC_User user = base.DoQuery(spec).FirstOrDefault<SEC_User>();
			if (user == null)
			{
				return null;
			}
			if (user.Password != decryptedPassword)
			{
				return null;
			}
			return user;
		}

		public IList<SEC_User> ListSEC_User_ByActive(bool? active)
        {
			return this.SelectAll((ISpecification<SEC_User>)new Specification<SEC_User>((Expression<Func<SEC_User, bool>>)(o => (bool?)o.IsActived == active || active == new bool?())));

		}
	}
}