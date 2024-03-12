using System;

namespace NDPSo.ClientSetting
{
	public class ServiceFactories
	{
		public static IServices GetFactory(int mode)
		{
			if (mode == 0)
			{
				return new LocalServicesFactory();
			}
			if (mode != 1)
			{
				return new LocalServicesFactory();
			}
			//return new WCFServicesFactory();
			return new LocalServicesFactory();
		}
	}
}
