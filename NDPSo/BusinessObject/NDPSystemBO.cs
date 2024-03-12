using Microsoft.Practices.Unity;
using NDPSo.Core;
using NDPSo.DAL;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NDPSo.BusinessObject
{
	public class NDPSystemBO
	{
		public string GetNextCode(string strTblName)
		{
			ISysCodeGenRepository codeGenRepository = IoC.Current.Container.Resolve<ISysCodeGenRepository>();
			SysCodeGen codeGenByTblName = codeGenRepository.GetSysCodeGen_ByTblName(strTblName);
			
			string nextCode = this.BuildCode(codeGenByTblName.Prefix, new int?(codeGenByTblName.Length), new int?(codeGenByTblName.CurrentNumber));
			if (nextCode == string.Empty)
				return "Error Code";
			++codeGenByTblName.CurrentNumber;
			codeGenRepository.Update(codeGenByTblName);
			codeGenRepository.Save();
			
			return nextCode;
		}

		private string BuildCode(string prefix, int? length, int? number)
		{
			string strNumber = number.ToString();
			int length2 = strNumber.Length;
			int? num = length;
			if (length2 > num.GetValueOrDefault() & num != null)
			{
				return string.Empty;
			}
			for (; ; )
			{
				int length3 = strNumber.Length;
				num = length;
				if (!(length3 < num.GetValueOrDefault() & num != null))
				{
					break;
				}
				strNumber = "0" + strNumber;
			}
			return string.Format("{0}{1}", prefix, strNumber);
		}
	}
}
