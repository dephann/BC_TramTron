using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class vw_DataMixHelper
	{
		public static void CopyToObjvw_DataMix(vw_DataMix fromEnt, Objvw_DataMix toObj)
		{
			toObj.MeTronID = fromEnt.MeTronID;
			toObj.LnNo = fromEnt.LnNo;
			toObj.NgayMeTron = fromEnt.NgayMeTron;
			toObj.Ngay = fromEnt.Ngay;
			toObj.Gio = fromEnt.Gio;
			toObj.Phieu = new int?(fromEnt.Phieu);
			toObj.PhieuTronID = new int?(fromEnt.PhieuTronID);
			toObj.MaPhieuTron = fromEnt.MaPhieuTron;
			toObj.HD = new int?(fromEnt.HD);
			toObj.NoteHD = fromEnt.NoteHD;
			toObj.MaHopDong = fromEnt.MaHopDong;
			toObj.KH = fromEnt.KH;
			toObj.KH_int = fromEnt.KH_int;
			toObj.NoteKH = fromEnt.NoteKH;
			toObj.CT = fromEnt.CT;
			toObj.CT_int = fromEnt.CT_int;
			toObj.HM = fromEnt.HM;
			toObj.HM_int = fromEnt.HM_int;
			toObj.NoteCT = fromEnt.NoteCT;
			toObj.KLDuTinh = fromEnt.KLDuTinh;
			toObj.IsQueued = (bool)fromEnt.IsQueued;
			toObj.NV_int = fromEnt.NV_int;
			toObj.TenNV = fromEnt.TenNV;
			toObj.TaiXeID = fromEnt.TaiXeID;
			toObj.Name = fromEnt.Name;
			toObj.TX = fromEnt.TX;
			toObj.TX_int = new int?(fromEnt.TX_int);
			toObj.Plate = fromEnt.Plate;
			toObj.Xe_int = fromEnt.Xe_int;
			toObj.MAC = fromEnt.MAC;
			toObj.MAC_int = fromEnt.MAC_int;
			toObj.NoteMAC = fromEnt.NoteMAC;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.FullName = fromEnt.FullName;
			toObj.DoSut = fromEnt.DoSut;
			toObj.KLVC = fromEnt.KLVC;
			toObj.KLMe = fromEnt.KLMe;
			toObj.Agg1 = fromEnt.Agg1;
			toObj.Agg2 = fromEnt.Agg2;
			toObj.Agg3 = fromEnt.Agg3;
			toObj.Agg4 = fromEnt.Agg4;
			toObj.Agg5 = fromEnt.Agg5;
			toObj.Agg6 = fromEnt.Agg6;
			toObj.Ce1 = fromEnt.Ce1;
			toObj.Ce2 = fromEnt.Ce2;
			toObj.Ce3 = fromEnt.Ce3;
			toObj.Ce4 = fromEnt.Ce4;
			toObj.Ce5 = fromEnt.Ce5;
			toObj.Ce6 = fromEnt.Ce6;
			toObj.Wa1 = fromEnt.Wa1;
			toObj.Wa2 = fromEnt.Wa2;
			toObj.Add1 = fromEnt.Add1;
			toObj.Add2 = fromEnt.Add2;
			toObj.Add3 = fromEnt.Add3;
			toObj.Add4 = fromEnt.Add4;
			toObj.Add5 = fromEnt.Add5;
			toObj.Add6 = fromEnt.Add6;
			toObj.Add7 = fromEnt.Add7;
			toObj.Add8 = fromEnt.Add8;
			toObj.Agg1_Bat = fromEnt.Agg1_Bat;
			toObj.Agg2_Bat = fromEnt.Agg2_Bat;
			toObj.Agg3_Bat = fromEnt.Agg3_Bat;
			toObj.Agg4_Bat = fromEnt.Agg4_Bat;
			toObj.Agg5_Bat = fromEnt.Agg5_Bat;
			toObj.Agg6_Bat = fromEnt.Agg6_Bat;
			toObj.Ce1_Bat = fromEnt.Ce1_Bat;
			toObj.Ce2_Bat = fromEnt.Ce2_Bat;
			toObj.Ce3_Bat = fromEnt.Ce3_Bat;
			toObj.Ce4_Bat = fromEnt.Ce4_Bat;
			toObj.Ce5_Bat = fromEnt.Ce5_Bat;
			toObj.Ce6_Bat = fromEnt.Ce6_Bat;
			toObj.Wa1_Bat = fromEnt.Wa1_Bat;
			toObj.Wa2_Bat = fromEnt.Wa2_Bat;
			toObj.Add1_Bat = fromEnt.Add1_Bat;
			toObj.Add2_Bat = fromEnt.Add2_Bat;
			toObj.Add3_Bat = fromEnt.Add3_Bat;
			toObj.Add4_Bat = fromEnt.Add4_Bat;
			toObj.Add5_Bat = fromEnt.Add5_Bat;
			toObj.Add6_Bat = fromEnt.Add6_Bat;
			toObj.Add7_Bat = fromEnt.Add7_Bat;
			toObj.Add8_Bat = fromEnt.Add8_Bat;
			toObj.Agg1_Mac = fromEnt.Agg1_Mac;
			toObj.Agg2_Mac = fromEnt.Agg2_Mac;
			toObj.Agg3_Mac = fromEnt.Agg3_Mac;
			toObj.Agg4_Mac = fromEnt.Agg4_Mac;
			toObj.Agg5_Mac = fromEnt.Agg5_Mac;
			toObj.Agg6_Mac = fromEnt.Agg6_Mac;
			toObj.Ce1_Mac = fromEnt.Ce1_Mac;
			toObj.Ce2_Mac = fromEnt.Ce2_Mac;
			toObj.Ce3_Mac = fromEnt.Ce3_Mac;
			toObj.Ce4_Mac = fromEnt.Ce4_Mac;
			toObj.Ce5_Mac = fromEnt.Ce5_Mac;
			toObj.Ce6_Mac = fromEnt.Ce6_Mac;
			toObj.Wa1_Mac = fromEnt.Wa1_Mac;
			toObj.Wa2_Mac = fromEnt.Wa2_Mac;
			toObj.Add1_Mac = fromEnt.Add1_Mac;
			toObj.Add2_Mac = fromEnt.Add2_Mac;
			toObj.Add3_Mac = fromEnt.Add3_Mac;
			toObj.Add4_Mac = fromEnt.Add4_Mac;
			toObj.Add5_Mac = fromEnt.Add5_Mac;
			toObj.Add6_Mac = fromEnt.Add6_Mac;
			toObj.Add7_Mac = fromEnt.Add7_Mac;
			toObj.Add8_Mac = fromEnt.Add8_Mac;
			toObj.Agg1_Man = fromEnt.Agg1_Man;
			toObj.Agg2_Man = fromEnt.Agg2_Man;
			toObj.Agg3_Man = fromEnt.Agg3_Man;
			toObj.Agg4_Man = fromEnt.Agg4_Man;
			toObj.Agg5_Man = fromEnt.Agg5_Man;
			toObj.Agg6_Man = fromEnt.Agg6_Man;
			toObj.Ce1_Man= fromEnt.Ce1_Man;
			toObj.Ce2_Man = fromEnt.Ce2_Man;
			toObj.Ce3_Man = fromEnt.Ce3_Man;
			toObj.Ce4_Man = fromEnt.Ce4_Man;
			toObj.Ce5_Man = fromEnt.Ce5_Man;
			toObj.Ce6_Man = fromEnt.Ce6_Man;
			toObj.Wa1_Man = fromEnt.Wa1_Man;
			toObj.Wa2_Man = fromEnt.Wa2_Man;
			toObj.Add1_Man = fromEnt.Add1_Man;
			toObj.Add2_Man = fromEnt.Add2_Man;
			toObj.Add3_Man = fromEnt.Add3_Man;
			toObj.Add4_Man = fromEnt.Add4_Man;
			toObj.Add5_Man = fromEnt.Add5_Man;
			toObj.Add6_Man = fromEnt.Add6_Man;
			toObj.Add7_Man = fromEnt.Add7_Man;
			toObj.Add8_Man = fromEnt.Add8_Man;
			toObj.Agg1_Tol = fromEnt.Agg1_Tol;
			toObj.Agg2_Tol = fromEnt.Agg2_Tol;
			toObj.Agg3_Tol = fromEnt.Agg3_Tol;
			toObj.Agg4_Tol = fromEnt.Agg4_Tol;
			toObj.Agg5_Tol = fromEnt.Agg5_Tol;
			toObj.Agg6_Tol = fromEnt.Agg6_Tol;
			toObj.Ce1_Tol = fromEnt.Ce1_Tol;
			toObj.Ce2_Tol = fromEnt.Ce2_Tol;
			toObj.Ce3_Tol = fromEnt.Ce3_Tol;
			toObj.Ce4_Tol = fromEnt.Ce4_Tol;
			toObj.Ce5_Tol = fromEnt.Ce5_Tol;
			toObj.Wa1_Tol = fromEnt.Wa1_Tol;
			toObj.Wa2_Tol = fromEnt.Wa2_Tol;
			toObj.Add1_Tol = fromEnt.Add1_Tol;
			toObj.Add2_Tol = fromEnt.Add2_Tol;
			toObj.Add3_Tol = fromEnt.Add3_Tol;
			toObj.Add4_Tol = fromEnt.Add4_Tol;
			toObj.Add5_Tol = fromEnt.Add5_Tol;
			toObj.Add6_Tol = fromEnt.Add6_Tol;
			toObj.Add7_Tol = fromEnt.Add7_Tol;
			toObj.Add8_Tol = fromEnt.Add8_Tol;
			toObj.Agg1_PerTol = fromEnt.Agg1_PerTol;
			toObj.Agg2_PerTol = fromEnt.Agg2_PerTol;
			toObj.Agg3_PerTol = fromEnt.Agg3_PerTol;
			toObj.Agg4_PerTol = fromEnt.Agg4_PerTol;
			toObj.Agg5_PerTol = fromEnt.Agg5_PerTol;
			toObj.Agg6_PerTol = fromEnt.Agg6_PerTol;
			toObj.Ce1_PerTol = fromEnt.Ce1_PerTol;
			toObj.Ce2_PerTol = fromEnt.Ce2_PerTol;
			toObj.Ce3_PerTol = fromEnt.Ce3_PerTol;
			toObj.Ce4_PerTol = fromEnt.Ce4_PerTol;
			toObj.Ce5_PerTol = fromEnt.Ce5_PerTol;
			toObj.Wa1_PerTol = fromEnt.Wa1_PerTol;
			toObj.Wa2_PerTol = fromEnt.Wa2_PerTol;
			toObj.Add1_PerTol = fromEnt.Add1_PerTol;
			toObj.Add2_PerTol = fromEnt.Add2_PerTol;
			toObj.Add3_PerTol = fromEnt.Add3_PerTol;
			toObj.Add4_PerTol = fromEnt.Add4_PerTol;
			toObj.Add5_PerTol = fromEnt.Add5_PerTol;
			toObj.Add6_PerTol = fromEnt.Add6_PerTol;
			toObj.Add7_PerTol = fromEnt.Add7_PerTol;
			toObj.Add8_PerTol = fromEnt.Add8_PerTol;


			if (toObj.MeTronID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntvw_DataMix(Objvw_DataMix fromObj, vw_DataMix toEnt)
		{
			toEnt.MeTronID = fromObj.MeTronID;
			toEnt.LnNo = fromObj.LnNo;
			toEnt.NgayMeTron = fromObj.NgayMeTron;
			toEnt.Ngay = fromObj.Ngay;
			toEnt.Gio = new TimeSpan?(fromObj.Gio.Value);
			toEnt.Phieu = fromObj.Phieu.Value;
			toEnt.PhieuTronID = fromObj.PhieuTronID.Value;
			toEnt.MaPhieuTron = fromObj.MaPhieuTron;
			toEnt.HD = fromObj.HD.Value;
			toEnt.NoteHD = fromObj.NoteHD;
			toEnt.MaHopDong = fromObj.MaHopDong;
			toEnt.KH = fromObj.KH;
			toEnt.KH_int = fromObj.KH_int;
			toEnt.NoteKH = fromObj.NoteKH;
			toEnt.CT = fromObj.CT;
			toEnt.CT_int = fromObj.CT_int;
			toEnt.HM = fromObj.HM;
			toEnt.HM_int = fromObj.HM_int;
			toEnt.NoteCT = fromObj.NoteCT;
			toEnt.KLDuTinh = fromObj.KLDuTinh;
			toEnt.IsQueued = fromObj.IsQueued;
			toEnt.NV_int = fromObj.NV_int;
			toEnt.TenNV = fromObj.TenNV;
			toEnt.TaiXeID = fromObj.TaiXeID;
			toEnt.Name = fromObj.Name;
			toEnt.TX = fromObj.TX;
			toEnt.TX_int = fromObj.TX_int.Value;
			toEnt.Plate = fromObj.Plate;
			toEnt.Xe_int = fromObj.Xe_int;
			toEnt.MAC = fromObj.MAC;
			toEnt.MAC_int = fromObj.MAC_int;
			toEnt.NoteMAC = fromObj.NoteMAC;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.FullName = fromObj.FullName;
			toEnt.DoSut = fromObj.DoSut;
			toEnt.KLVC = fromObj.KLVC;
			toEnt.KLMe = fromObj.KLMe;
			toEnt.Agg1 = fromObj.Agg1;
			toEnt.Agg2 = fromObj.Agg2;
			toEnt.Agg3 = fromObj.Agg3;
			toEnt.Agg4 = fromObj.Agg4;
			toEnt.Agg5 = fromObj.Agg5;
			toEnt.Ce1 = fromObj.Ce1;
			toEnt.Ce2 = fromObj.Ce2;
			toEnt.Ce3 = fromObj.Ce3;
			toEnt.Ce4 = fromObj.Ce4;
			toEnt.Ce5 = fromObj.Ce5;
			toEnt.Ce6 = fromObj.Ce6;
			toEnt.Wa1 = fromObj.Wa1;
			toEnt.Wa2 = fromObj.Wa2;
			toEnt.Add1 = fromObj.Add1;
			toEnt.Add2 = fromObj.Add2;
			toEnt.Add3 = fromObj.Add3;
			toEnt.Add4 = fromObj.Add4;
			toEnt.Add5 = fromObj.Add5;
			toEnt.Add6 = fromObj.Add6;
			toEnt.Add7 = fromObj.Add7;
			toEnt.Add8 = fromObj.Add8;
			toEnt.Agg1_Bat = fromObj.Agg1_Bat;
			toEnt.Agg2_Bat = fromObj.Agg2_Bat;
			toEnt.Agg3_Bat = fromObj.Agg3_Bat;
			toEnt.Agg4_Bat = fromObj.Agg4_Bat;
			toEnt.Agg5_Bat = fromObj.Agg5_Bat;
			toEnt.Ce1_Bat = fromObj.Ce1_Bat;
			toEnt.Ce2_Bat = fromObj.Ce2_Bat;
			toEnt.Ce3_Bat = fromObj.Ce3_Bat;
			toEnt.Ce4_Bat = fromObj.Ce4_Bat;
			toEnt.Ce5_Bat = fromObj.Ce5_Bat;
			toEnt.Ce6_Bat = fromObj.Ce6_Bat;
			toEnt.Wa1_Bat = fromObj.Wa1_Bat;
			toEnt.Wa2_Bat = fromObj.Wa2_Bat;
			toEnt.Add1_Bat = fromObj.Add1_Bat;
			toEnt.Add2_Bat = fromObj.Add2_Bat;
			toEnt.Add3_Bat = fromObj.Add3_Bat;
			toEnt.Add4_Bat = fromObj.Add4_Bat;
			toEnt.Add5_Bat = fromObj.Add5_Bat;
			toEnt.Add6_Bat = fromObj.Add6_Bat;
			toEnt.Add7_Bat = fromObj.Add7_Bat;
			toEnt.Add8_Bat = fromObj.Add8_Bat;
			toEnt.Agg1_Mac = fromObj.Agg1_Mac;
			toEnt.Agg2_Mac = fromObj.Agg2_Mac;
			toEnt.Agg3_Mac = fromObj.Agg3_Mac;
			toEnt.Agg4_Mac = fromObj.Agg4_Mac;
			toEnt.Agg5_Mac = fromObj.Agg5_Mac;
			toEnt.Ce1_Mac = fromObj.Ce1_Mac;
			toEnt.Ce2_Mac = fromObj.Ce2_Mac;
			toEnt.Ce3_Mac = fromObj.Ce3_Mac;
			toEnt.Ce4_Mac = fromObj.Ce4_Mac;
			toEnt.Ce5_Mac = fromObj.Ce5_Mac;
			toEnt.Ce6_Mac = fromObj.Ce6_Mac;
			toEnt.Wa1_Mac = fromObj.Wa1_Mac;
			toEnt.Wa2_Mac = fromObj.Wa2_Mac;
			toEnt.Add1_Mac = fromObj.Add1_Mac;
			toEnt.Add2_Mac = fromObj.Add2_Mac;
			toEnt.Add3_Mac = fromObj.Add3_Mac;
			toEnt.Add4_Mac = fromObj.Add4_Mac;
			toEnt.Add5_Mac = fromObj.Add5_Mac;
			toEnt.Add6_Mac = fromObj.Add6_Mac;
			toEnt.Add7_Mac = fromObj.Add7_Mac;
			toEnt.Add8_Mac = fromObj.Add8_Mac;
			toEnt.Agg1_Man = fromObj.Agg1_Man;
			toEnt.Agg2_Man = fromObj.Agg2_Man;
			toEnt.Agg3_Man = fromObj.Agg3_Man;
			toEnt.Agg4_Man = fromObj.Agg4_Man;
			toEnt.Agg5_Man = fromObj.Agg5_Man;
			toEnt.Ce1_Man = fromObj.Ce1_Man;
			toEnt.Ce2_Man = fromObj.Ce2_Man;
			toEnt.Ce3_Man = fromObj.Ce3_Man;
			toEnt.Ce4_Man = fromObj.Ce4_Man;
			toEnt.Ce5_Man = fromObj.Ce5_Man;
			toEnt.Ce6_Man = fromObj.Ce6_Man;
			toEnt.Wa1_Man = fromObj.Wa1_Man;
			toEnt.Wa2_Man = fromObj.Wa2_Man;
			toEnt.Add1_Man = fromObj.Add1_Man;
			toEnt.Add2_Man = fromObj.Add2_Man;
			toEnt.Add3_Man = fromObj.Add3_Man;
			toEnt.Add4_Man = fromObj.Add4_Man;
			toEnt.Add5_Man = fromObj.Add5_Man;
			toEnt.Add6_Man = fromObj.Add6_Man;
			toEnt.Add7_Man = fromObj.Add7_Man;
			toEnt.Add8_Man = fromObj.Add8_Man;
			toEnt.Agg1_Tol = fromObj.Agg1_Tol;
			toEnt.Agg2_Tol = fromObj.Agg2_Tol;
			toEnt.Agg3_Tol = fromObj.Agg3_Tol;
			toEnt.Agg4_Tol = fromObj.Agg4_Tol;
			toEnt.Agg5_Tol = fromObj.Agg5_Tol;
			toEnt.Ce1_Tol = fromObj.Ce1_Tol;
			toEnt.Ce2_Tol = fromObj.Ce2_Tol;
			toEnt.Ce3_Tol = fromObj.Ce3_Tol;
			toEnt.Ce4_Tol = fromObj.Ce4_Tol;
			toEnt.Ce5_Tol = fromObj.Ce5_Tol;
			toEnt.Wa1_Tol = fromObj.Wa1_Tol;
			toEnt.Wa2_Tol = fromObj.Wa2_Tol;
			toEnt.Add1_Tol = fromObj.Add1_Tol;
			toEnt.Add2_Tol = fromObj.Add2_Tol;
			toEnt.Add3_Tol = fromObj.Add3_Tol;
			toEnt.Add4_Tol = fromObj.Add4_Tol;
			toEnt.Add5_Tol = fromObj.Add5_Tol;
			toEnt.Add6_Tol = fromObj.Add6_Tol;
			toEnt.Add7_Tol = fromObj.Add7_Tol;
			toEnt.Add8_Tol = fromObj.Add8_Tol;
			toEnt.Agg1_PerTol = fromObj.Agg1_PerTol;
			toEnt.Agg2_PerTol = fromObj.Agg2_PerTol;
			toEnt.Agg3_PerTol = fromObj.Agg3_PerTol;
			toEnt.Agg4_PerTol = fromObj.Agg4_PerTol;
			toEnt.Agg5_PerTol = fromObj.Agg5_PerTol;
			toEnt.Ce1_PerTol = fromObj.Ce1_PerTol;
			toEnt.Ce2_PerTol = fromObj.Ce2_PerTol;
			toEnt.Ce3_PerTol = fromObj.Ce3_PerTol;
			toEnt.Ce4_PerTol = fromObj.Ce4_PerTol;
			toEnt.Ce5_PerTol = fromObj.Ce5_PerTol;
			toEnt.Wa1_PerTol = fromObj.Wa1_PerTol;
			toEnt.Wa2_PerTol = fromObj.Wa2_PerTol;
			toEnt.Add1_PerTol = fromObj.Add1_PerTol;
			toEnt.Add2_PerTol = fromObj.Add2_PerTol;
			toEnt.Add3_PerTol = fromObj.Add3_PerTol;
			toEnt.Add4_PerTol = fromObj.Add4_PerTol;
			toEnt.Add5_PerTol = fromObj.Add5_PerTol;
			toEnt.Add6_PerTol = fromObj.Add6_PerTol;
			toEnt.Add7_PerTol = fromObj.Add7_PerTol;
			toEnt.Add8_PerTol = fromObj.Add8_PerTol;


		}

		public static Objvw_DataMix BuildNewObjvw_DataMix(vw_DataMix entvw_DataMix)
		{
			Objvw_DataMix objvw_DataMix = new Objvw_DataMix();
			vw_DataMixHelper.CopyToObjvw_DataMix(entvw_DataMix, objvw_DataMix);
			return objvw_DataMix;
		}

		public static IList<Objvw_DataMix> BuildListObjvw_DataMix(IList<vw_DataMix> lstEntvw_DataMix)
		{
			IList<Objvw_DataMix> lstObjvw_DataMix = new List<Objvw_DataMix>();
			foreach (vw_DataMix entvw_DataMix in lstEntvw_DataMix)
			{
				lstObjvw_DataMix.Add(vw_DataMixHelper.BuildNewObjvw_DataMix(entvw_DataMix));
			}
			return lstObjvw_DataMix;
		}

		public static vw_DataMix BuildNewEntvw_DataMix(Objvw_DataMix objvw_DataMix)
		{
			vw_DataMix entvw_DataMix = new vw_DataMix();
			vw_DataMixHelper.CopyToEntvw_DataMix(objvw_DataMix, entvw_DataMix);
			return entvw_DataMix;
		}

		public static IList<vw_DataMix> BuildListEntvw_DataMix(IList<Objvw_DataMix> lstObjvw_DataMix)
		{
			IList<vw_DataMix> lstEntvw_DataMix = new List<vw_DataMix>();
			foreach (Objvw_DataMix objvw_DataMix in lstObjvw_DataMix)
			{
				lstEntvw_DataMix.Add(vw_DataMixHelper.BuildNewEntvw_DataMix(objvw_DataMix));
			}
			return lstEntvw_DataMix;
		}

		public static ObjAggregationResult BuildNewAggregation(ObjAggregationResult obj)
        {
			return obj;
        }
	}
}
