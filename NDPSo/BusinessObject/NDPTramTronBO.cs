using Microsoft.Practices.Unity;
using NDPSo.Core;
using NDPSo.DAL;
using NDPSo.Data;
using NDPSo.EntityModel;
using NDPSo.KWS;
using NDPSo.MasterData.TonKho;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace NDPSo.BusinessObject
{
    public class NDPTramTronBO
    {
        public ObjCongTruong GetCongTruongByKey(int miID) => CongTruongHelper.BuildNewObjCongTruong(IoC.Current.Container.Resolve<ICongTruongRepository>().GetById(miID));

        public IList<ObjCongTruong> ListCongTruong() => CongTruongHelper.BuildListObjCongTruong(IoC.Current.Container.Resolve<ICongTruongRepository>().SelectAll());

        public IList<ObjCongTruong> ListCongTruong_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active)
        {
            return CongTruongHelper.BuildListObjCongTruong(IoC.Current.Container.Resolve<ICongTruongRepository>().ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active));
        }

        public bool SaveCongTruong(IList<ObjCongTruong> lst)
        {
            ICongTruongRepository truongRepository = IoC.Current.Container.Resolve<ICongTruongRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjCongTruong objCongTruong in (IEnumerable<ObjCongTruong>)lst)
                    {
                        if (objCongTruong.MarkAsDeleted)
                            truongRepository.Delete(truongRepository.GetById(objCongTruong.CongTruongID));
                        else if (objCongTruong.IsNewObject)
                        {
                            CongTruong entity = CongTruongHelper.BuildNewEntCongTruong(objCongTruong);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            truongRepository.Add(entity);
                        }
                        else
                        {
                            CongTruong congTruong = truongRepository.GetById(objCongTruong.CongTruongID);
                            CongTruongHelper.CopyToEntCongTruong(objCongTruong, congTruong);
                            congTruong.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            congTruong.LatestUpdateDate = new DateTime?(DateTime.Now);
                            truongRepository.Update(congTruong);
                        }
                    }
                    truongRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }


        public ObjDuLieuTron GetDuLieuTronByKey(int miID)
        {
            DuLieuTron entDuLieuTron = IoC.Current.Container.Resolve<IDuLieuTronRepository>().GetById(miID);
            return entDuLieuTron == null ? (ObjDuLieuTron)null : DuLieuTronHelper.BuildNewObjDuLieuTron(entDuLieuTron);
        }

        public IList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated)
        {
            IDuLieuTronRepository rep = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
            IMACRepository repMAC = IoC.Current.Container.Resolve<IMACRepository>();
            IList<DuLieuTron> lstEnt = new List<DuLieuTron>();
            if (includeInActivated)
            {
                lstEnt = (from o in rep.SelectAll()
                          orderby o.LnNo
                          select o).ToList<DuLieuTron>();
            }
            else
            {
                lstEnt = (from o in rep.SelectAll()
                          where o.Activated
                          orderby o.LnNo
                          select o).ToList<DuLieuTron>();
            }
            IList<ObjDuLieuTron> lstObj = DuLieuTronHelper.BuildListObjDuLieuTron(lstEnt);
            foreach (ObjDuLieuTron obj in lstObj)
            {
                MAC mac = repMAC.GetById(obj.MACID.Value);
                obj.NPMACThemBotNuoc1 = mac.ThemBotNuoc1;
                obj.NPMACThemBotNuoc2 = mac.ThemBotNuoc2;
            }
            return lstObj;
        }

        public ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT)
        {
            try
            {
                IDuLieuTronRepository lieuTronRepository = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
                DuLieuTron entity = DuLieuTronHelper.BuildNewEntDuLieuTron(objDLT);
                lieuTronRepository.Add(entity);
                lieuTronRepository.Save();
                objDLT.DuLieuTronID = entity.DuLieuTronID;
                objDLT.VersionNo = entity.VersionNo;
                objDLT.CreatedBy = new int?(GlobalValues.UserID);
                objDLT.CreationDate = new DateTime?(DateTime.Now);
                return objDLT;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (ObjDuLieuTron)null;
            }
        }

        public ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT)
        {
            try
            {
                IDuLieuTronRepository lieuTronRepository = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
                DuLieuTron duLieuTron = lieuTronRepository.GetById(objDLT.DuLieuTronID);
                DuLieuTronHelper.CopyToEntDuLieuTron(objDLT, duLieuTron);
                lieuTronRepository.Update(duLieuTron);
                lieuTronRepository.Save();
                objDLT.VersionNo = duLieuTron.VersionNo;
                objDLT.LatestUpdatedBy = new int?(GlobalValues.UserID);
                objDLT.LatestUpdateDate = new DateTime?(DateTime.Now);
                return objDLT;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (ObjDuLieuTron)null;
            }
        }

        public bool DeleteDulieuTron(int id)
        {
            try
            {
                IDuLieuTronRepository lieuTronRepository = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
                lieuTronRepository.Delete(lieuTronRepository.GetById(id));
                lieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        public bool SaveDuLieuTron(IList<ObjDuLieuTron> lstDLT)
        {
            IDuLieuTronRepository lieuTronRepository = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
            foreach (ObjDuLieuTron objDuLieuTron in (IEnumerable<ObjDuLieuTron>)lstDLT)
            {
                if (objDuLieuTron.MarkAsDeleted)
                {
                    lieuTronRepository.Delete(lieuTronRepository.GetById(objDuLieuTron.DuLieuTronID));
                }
                else
                {
                    if (objDuLieuTron.DuLieuTronID > 0)
                    {
                        objDuLieuTron.LatestUpdateDate = new DateTime?(DateTime.Now);
                        objDuLieuTron.LatestUpdatedBy = new int?(GlobalValues.UserID);
                    }
                    else
                    {
                        objDuLieuTron.CreationDate = new DateTime?(DateTime.Now);
                        objDuLieuTron.CreatedBy = new int?(GlobalValues.UserID);
                    }
                    DuLieuTron entity = DuLieuTronHelper.BuildNewEntDuLieuTron(objDuLieuTron);
                    lieuTronRepository.Update(entity);
                }
            }
            lieuTronRepository.Save();
            return true;
        }
        public bool InsertEventLog(ObjEventLog objEventLog)
        {
            try
            {
                IEventLogRepository eventLogRepository = IoC.Current.Container.Resolve<IEventLogRepository>();
                EventLog entity = EventLogHelper.BuildNewEntEventLog(objEventLog);
                eventLogRepository.Attach(entity);
                eventLogRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        public bool InsertEventLog(
          int? userId,
          string userName,
          string eventActionCode,
          string result,
          string oldValueText,
          string newValueText)
        {
            bool flag;
            try
            {
                IEventLogRepository eventLogRepository = IoC.Current.Container.Resolve<IEventLogRepository>();
                EventActionCode eventActionCode1 = IoC.Current.Container.Resolve<IEventActionCodeRepository>().DoQuery().Where<EventActionCode>((Expression<Func<EventActionCode, bool>>)(o => o.Code == eventActionCode)).FirstOrDefault<EventActionCode>();
                if (eventActionCode1 == null)
                {
                    TramTronLogger.WriteError(new System.Exception(string.Format("EventActionCode [{0}] không tồn tại.", (object)eventActionCode)));
                    flag = false;
                }
                else
                {
                    eventLogRepository.Update(new EventLog()
                    {
                        LogDate = DateTime.Now,
                        LogCode = eventActionCode1.Code,
                        EventActionCodeID = eventActionCode1.EventActionCodeID,
                        EventActionContent = result,
                        UserID = userId,
                        UserName = userName,
                        OldValueText = oldValueText,
                        NewValueText = newValueText
                    });
                    eventLogRepository.Save();
                    flag = true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                flag = false;
            }
            return flag;
        }

        public IList<ObjEventLog> ListEventLog_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          int? userID,
          int? eventActionCodeID)
        {
            return EventLogHelper.BuildListObjEventLog(IoC.Current.Container.Resolve<IEventLogRepository>().ListEventLog_ByCondition(fromDate, toDate, userID, eventActionCodeID));
        }


        public ObjHopDong GetHopDongByKey(int miID)
        {
            HopDong entHopDong = IoC.Current.Container.Resolve<IHopDongRepository>().GetById(miID);
            if (entHopDong == null)
                return (ObjHopDong)null;
            ObjHopDong hopDongByKey = HopDongHelper.BuildNewObjHopDong(entHopDong);
            hopDongByKey.NPMACMaMAC = entHopDong.MAC.MaMAC;
            hopDongByKey.NPMACTenMAC = entHopDong.MAC.TenMAC;
            hopDongByKey.NPMACThemBotNuoc1 = entHopDong.MAC.ThemBotNuoc1;
            hopDongByKey.NPMACThemBotNuoc2 = entHopDong.MAC.ThemBotNuoc2;
            return hopDongByKey;
        }

        public ObjHopDong GetHopDongByMaHD(string maHD)
        {
            HopDong entHopDong = IoC.Current.Container.Resolve<IHopDongRepository>().DoQuery().Where<HopDong>((Expression<Func<HopDong, bool>>)(o => o.MaHopDong == maHD)).First<HopDong>();
            return entHopDong == null ? (ObjHopDong)null : HopDongHelper.BuildNewObjHopDong(entHopDong);
        }

        public IList<ObjHopDong> ListHopDong() => HopDongHelper.BuildListObjHopDong(IoC.Current.Container.Resolve<IHopDongRepository>().SelectAll());

        public IList<ObjHopDong> ListHopDong_ByCondition(
          string maHopDong,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          int? khachHangID,
          int? congTruongID,
          int? macID)
        {
            return HopDongHelper.BuildListObjHopDong(IoC.Current.Container.Resolve<IHopDongRepository>().ListHopDong_ByCondition(maHopDong, fromDate, toDate, status, khachHangID, congTruongID, macID));
        }

        public bool SaveHopDong(IList<ObjHopDong> lstHD)
        {
            IHopDongRepository hopDongRepository = IoC.Current.Container.Resolve<IHopDongRepository>();
            foreach (ObjHopDong objHopDong in (IEnumerable<ObjHopDong>)lstHD)
            {
                if (objHopDong.MarkAsDeleted)
                {
                    hopDongRepository.Delete(hopDongRepository.GetById(objHopDong.HopDongID));
                }
                else if (objHopDong.IsNewObject)
                {
                    HopDong entity = HopDongHelper.BuildNewEntHopDong(objHopDong);
                    entity.TongPhieu = 0;
                    entity.CreatedBy = new int?(GlobalValues.UserID);
                    entity.CreationDate = new DateTime?(DateTime.Now);
                    hopDongRepository.Add(entity);
                }
                else if(!objHopDong.IsNewObject)
                {
                    HopDong hopDong = hopDongRepository.GetById(objHopDong.HopDongID);
                    HopDongHelper.CopyToEntHopDong(objHopDong, hopDong);
                    hopDong.LatestUpdatedBy = new int?(GlobalValues.UserID);
                    hopDong.LatestUpdateDate = new DateTime?(DateTime.Now);
                    hopDongRepository.Update(hopDong);
                }
            }
            hopDongRepository.Save();
            return true;
        }

        public ObjHopDong SaveHopDong(ObjHopDong objHD)
        {
            IHopDongRepository hopDongRepository = IoC.Current.Container.Resolve<IHopDongRepository>();
            HopDong hopDong = HopDongHelper.BuildNewEntHopDong(objHD);

            if (hopDong.HopDongID > 0)
            {
                hopDong.LatestUpdatedBy = new int?(GlobalValues.UserID);
                hopDong.LatestUpdateDate = new DateTime?(DateTime.Now);
                hopDongRepository.Update(hopDong);
                hopDongRepository.Save();
            }
            else
            {
                objHD.TongPhieu = 0;
                objHD.CreatedBy = new int?(GlobalValues.UserID);
                objHD.CreationDate = new DateTime?(DateTime.Now);
                objHD.LatestUpdatedBy = new int?(GlobalValues.UserID);
                objHD.LatestUpdateDate = new DateTime?(DateTime.Now);
                hopDongRepository.Add(hopDong);
                hopDongRepository.Save();
            }
            
            if (objHD.HopDongID > 0)
                hopDong = hopDongRepository.GetById(hopDong.HopDongID);
            HopDongHelper.CopyToObjHopDong(hopDong, objHD);
            return objHD;
        }

        public ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT)
        {
            IHopDongRepository hopDongRepository = IoC.Current.Container.Resolve<IHopDongRepository>();
            IDuLieuTronRepository lieuTronRepository = IoC.Current.Container.Resolve<IDuLieuTronRepository>();
            HopDong hopDong = HopDongHelper.BuildNewEntHopDong(objHD);
            hopDongRepository.Update(hopDong);
            hopDongRepository.Save();
            DuLieuTron entity = DuLieuTronHelper.BuildNewEntDuLieuTron(objDLT);
            entity.HopDong = hopDong;
            lieuTronRepository.Update(entity);
            lieuTronRepository.Save();
            HopDongHelper.CopyToObjHopDong(hopDong, objHD);
            return objHD;
        }



        public ObjKhachHang GetKhachHangByKey(int miID) => KhachHangHelper.BuildNewObjKhachHang(IoC.Current.Container.Resolve<IKhachHangRepository>().GetById(miID));

        public IList<ObjKhachHang> ListKhachHang() => KhachHangHelper.BuildListObjKhachHang(IoC.Current.Container.Resolve<IKhachHangRepository>().SelectAll());

        public IList<ObjKhachHang> ListKhachHang_ByCondition(DateTime? fromDate,DateTime? toDate,string maKH,string tenKH,string diaChi,string phone,bool? active)
        {
            return KhachHangHelper.BuildListObjKhachHang(IoC.Current.Container.Resolve<IKhachHangRepository>().ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active));
        }

        public bool SaveKhachHang(IList<ObjKhachHang> lst)
        {
            IKhachHangRepository khachHangRepository = IoC.Current.Container.Resolve<IKhachHangRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjKhachHang objKhachHang in (IEnumerable<ObjKhachHang>)lst)
                    {
                        if (objKhachHang.MarkAsDeleted)
                            khachHangRepository.Delete(khachHangRepository.GetById(objKhachHang.KhachHangID));
                        else if (objKhachHang.IsNewObject)
                        {
                            KhachHang entity = KhachHangHelper.BuildNewEntKhachHang(objKhachHang);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            khachHangRepository.Add(entity);
                        }
                        else
                        {
                            KhachHang khachHang = khachHangRepository.GetById(objKhachHang.KhachHangID);
                            KhachHangHelper.CopyToEntKhachHang(objKhachHang, khachHang);
                            khachHang.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            khachHang.LatestUpdateDate = new DateTime?(DateTime.Now);
                            khachHangRepository.Update(khachHang);
                        }
                    }
                    khachHangRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }

        public ObjMAC GetMACByKey(int id)
        {
            MAC entMAC = IoC.Current.Container.Resolve<IMACRepository>().GetById(id);
            ObjMAC macByKey = new ObjMAC();
            if (entMAC != null)
            {
                macByKey = MACHelper.BuildNewObjMAC(entMAC);
                macByKey.NPSUMSiloValue = entMAC.MACSiloes.Sum<MACSilo>((Func<MACSilo, Decimal?>)(o => o.SiloValue));
            }
            return macByKey;
        }

        public IList<ObjMAC> ListMAC()
        {
            IList<MAC> macList = IoC.Current.Container.Resolve<IMACRepository>().SelectAll();
            IList<ObjMAC> objMacList = (IList<ObjMAC>)new List<ObjMAC>();
            foreach (MAC entMAC in (IEnumerable<MAC>)macList)
            {
                ObjMAC objMac = MACHelper.BuildNewObjMAC(entMAC);
                objMac.NPSUMSiloValue = entMAC.MACSiloes.Sum<MACSilo>((Func<MACSilo, Decimal?>)(o => o.SiloValue));
                objMacList.Add(objMac);
            }
            return objMacList;
        }

        public IList<ObjMAC> ListMAC_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maMAC,
          string tenMAC,
          bool? active)
        {
            IList<MAC> macList = IoC.Current.Container.Resolve<IMACRepository>().ListMAC_ByCondition(fromDate, toDate, maMAC, tenMAC, active);
            IList<ObjMAC> objMacList = (IList<ObjMAC>)new List<ObjMAC>();
            foreach (MAC entMAC in (IEnumerable<MAC>)macList)
            {
                ObjMAC objMac = MACHelper.BuildNewObjMAC(entMAC);
                objMac.NPSUMSiloValue = entMAC.MACSiloes.Sum<MACSilo>((Func<MACSilo, Decimal?>)(o => o.SiloValue));
                objMacList.Add(objMac);
            }
            return objMacList;
        }

        public bool SaveMAC(IList<ObjMAC> lstMAC)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var repMAC = IoC.Current.Container.Resolve<IMACRepository>();
                    var repMACSilo = IoC.Current.Container.Resolve<IMACSiloRepository>();

                    foreach (var objMAC in lstMAC)
                    {
                        if (objMAC.MarkAsDeleted)
                        {
                            var macToDelete = repMAC.GetById(objMAC.MACID);
                            repMAC.Delete(macToDelete);
                            InsertEventLog(GlobalValues.UserID, GlobalValues.DisplayUser, "MAC_DEL", objMAC.MaMAC, string.Empty, string.Empty);
                        }
                        else
                        {
                            MAC entMAC;
                            if (objMAC.IsNewObject)
                            {
                                entMAC = MACHelper.BuildNewEntMAC(objMAC);
                                //entMAC.CreatedBy = GlobalValues.UserID;
                                entMAC.CreationDate = DateTime.Now;

                                foreach (var objMACSilo in objMAC.LstMACSilo)
                                {
                                    var entMACSilo = MACSiloHelper.BuildNewEntMACSilo(objMACSilo);
                                    entMACSilo.MAC = entMAC;
                                    entMAC.MACSiloes.Add(entMACSilo);
                                }
                                repMAC.Add(entMAC);
                                InsertEventLog(GlobalValues.UserID, GlobalValues.DisplayUser, "MAC_NEW", objMAC.MaMAC, string.Empty, string.Empty);
                            }
                            else
                            {
                                entMAC = repMAC.GetById(objMAC.MACID);

                                var oldValues = MACHelper.GenMemberValues(entMAC);
                                oldValues += BuildString_MACSiloEventLog(MACSiloHelper.BuildListObjMACSilo(entMAC.MACSiloes.ToList()));
                                var newValues = MACHelper.GenMemberValues(objMAC);
                                newValues += BuildString_MACSiloEventLog(objMAC.LstMACSilo);

                                InsertEventLog(GlobalValues.UserID, GlobalValues.DisplayUser, "MAC_EDIT", objMAC.MaMAC, oldValues, newValues);

                                MACHelper.CopyToEntMAC(objMAC, entMAC);
                                entMAC.LatestUpdatedBy = GlobalValues.UserID;
                                entMAC.LatestUpdateDate = DateTime.Now;

                                foreach (var objMACSilo in objMAC.LstMACSilo)
                                {
                                    var entMACSilo = entMAC.MACSiloes.FirstOrDefault(x => x.MACSiloID == objMACSilo.MACSiloID);
                                    if (entMACSilo == null && objMACSilo.IsNewObject)
                                    {
                                        entMACSilo = MACSiloHelper.BuildNewEntMACSilo(objMACSilo);
                                        entMACSilo.MAC = entMAC;
                                        entMAC.MACSiloes.Add(entMACSilo);
                                    }
                                    else if (objMACSilo.MarkAsDeleted)
                                    {
                                        entMAC.MACSiloes.Remove(entMACSilo);
                                        repMACSilo.Delete(repMACSilo.GetById(objMACSilo.MACSiloID));
                                    }
                                    else
                                    {
                                        MACSiloHelper.CopyToEntMACSilo(objMACSilo, entMACSilo);
                                    }
                                }
                                repMAC.Update(entMAC);
                            }
                        }
                    }

                    repMAC.Save();
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    TramTronLogger.WriteError(ex);
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    {
                        return false;
                    }
                    return true;
                }
            }
        }
        private string BuildString_MACSiloEventLog(IList<ObjMACSilo> lst)
        {
            string str1 = "#1@#";
            string str2 = "#2@#";
            string empty = string.Empty;
            foreach (ObjMACSilo objMacSilo in (IEnumerable<ObjMACSilo>)lst)
            {
                if (!objMacSilo.MarkAsDeleted)
                    empty += string.Format("{0}{1}{2}{3}", (object)str1, (object)objMacSilo.NPSiloMaSilo, (object)str2, (object)objMacSilo.SiloValue);
            }
            return empty;
        }

        public ObjMACSilo GetMACSiloByKey(int miID) => MACSiloHelper.BuildNewObjMACSilo(IoC.Current.Container.Resolve<IMACSiloRepository>().GetById(miID));

        public IList<ObjMACSilo> ListMACSilo() => MACSiloHelper.BuildListObjMACSilo(IoC.Current.Container.Resolve<IMACSiloRepository>().SelectAll());

        public IList<ObjMACSilo> ListMACSilo_ByMACID(int macID) => MACSiloHelper.BuildListObjMACSilo(IoC.Current.Container.Resolve<IMACSiloRepository>().ListMACSilo_ByMACID(macID));

        public IList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID) => MACSiloHelper.BuildListObjMACSilo((IList<MACSilo>)IoC.Current.Container.Resolve<IPhieuTronRepository>().GetById(ptID).HopDong.MAC.MACSiloes.ToList<MACSilo>());

        public IList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID) => MACSiloHelper.BuildListObjMACSilo((IList<MACSilo>)IoC.Current.Container.Resolve<IHopDongRepository>().GetById(hdID).MAC.MACSiloes.ToList<MACSilo>());

        public bool SaveMACSilo(IList<ObjMACSilo> lstCT)
        {
            IMACSiloRepository macSiloRepository = IoC.Current.Container.Resolve<IMACSiloRepository>();
            foreach (ObjMACSilo objMACSilo in (IEnumerable<ObjMACSilo>)lstCT)
            {
                if (objMACSilo.MarkAsDeleted)
                {
                    macSiloRepository.Delete(macSiloRepository.GetById(objMACSilo.MACSiloID));
                }
                else
                {
                    MACSilo entity = MACSiloHelper.BuildNewEntMACSilo(objMACSilo);
                    macSiloRepository.Add(entity);
                }
            }
            macSiloRepository.Save();
            return true;
        }

        public ObjMaterial GetMaterialByKey(int miID) => MaterialHelper.BuildNewObjMaterial(IoC.Current.Container.Resolve<IMaterialRepository>().GetById(miID));

        public IList<ObjMaterial> ListMaterial() => MaterialHelper.BuildListObjMaterial(IoC.Current.Container.Resolve<IMaterialRepository>().SelectAll());

        public IList<ObjMaterial> ListMaterial_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maVT,
          string tenVT,
          bool? active)
        {
            return MaterialHelper.BuildListObjMaterial(IoC.Current.Container.Resolve<IMaterialRepository>().ListMaterial_ByCondition(fromDate, toDate, maVT, tenVT, active));
        }

        public bool SaveMaterial(IList<ObjMaterial> lst)
        {
            IMaterialRepository materialRepository = IoC.Current.Container.Resolve<IMaterialRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjMaterial objMaterial in (IEnumerable<ObjMaterial>)lst)
                    {
                        if (objMaterial.MarkAsDeleted)
                            materialRepository.Delete(materialRepository.GetById(objMaterial.MaterialID));
                        else if (objMaterial.IsNewObject)
                        {
                            Material entity = MaterialHelper.BuildNewEntMaterial(objMaterial);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            materialRepository.Add(entity);
                        }
                        else
                        {
                            Material material = materialRepository.GetById(objMaterial.MaterialID);
                            MaterialHelper.CopyToEntMaterial(objMaterial, material);
                            material.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            material.LatestUpdateDate = new DateTime?(DateTime.Now);
                            materialRepository.Update(material);
                        }
                    }
                    materialRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }

        public ObjMeTron GetMeTronByKey(int miID) => MeTronHelper.BuildNewObjMeTron(IoC.Current.Container.Resolve<IMeTronRepository>().GetById(miID));

        public IList<ObjMeTron> ListMeTron() => MeTronHelper.BuildListObjMeTron(IoC.Current.Container.Resolve<IMeTronRepository>().SelectAll());

        public IList<ObjMeTron> ListMeTronByPhieuTronID(int ptID) => MeTronHelper.BuildListObjMeTron((IList<MeTron>)IoC.Current.Container.Resolve<IMeTronRepository>().DoQuery().Where<MeTron>((Expression<Func<MeTron, bool>>)(o => o.PhieuTronID == ptID)).ToList<MeTron>());

        public bool SaveMeTron(IList<ObjMeTron> lstCT)
        {
            IMeTronRepository meTronRepository = IoC.Current.Container.Resolve<IMeTronRepository>();
            foreach (ObjMeTron objMeTron in (IEnumerable<ObjMeTron>)lstCT)
            {
                if (objMeTron.MarkAsDeleted)
                {
                    meTronRepository.Delete(meTronRepository.GetById(objMeTron.MeTronID));
                }
                else
                {
                    MeTron entity = MeTronHelper.BuildNewEntMeTron(objMeTron);
                    meTronRepository.Add(entity);
                }
            }
            meTronRepository.Save();
            return true;
        }

        public ObjMeTronChiTiet GetMeTronChiTietByKey(int miID) => MeTronChiTietHelper.BuildNewObjMeTronChiTiet(IoC.Current.Container.Resolve<IMeTronChiTietRepository>().GetById(miID));

        public IList<ObjMeTronChiTiet> ListMeTronChiTiet() => MeTronChiTietHelper.BuildListObjMeTronChiTiet(IoC.Current.Container.Resolve<IMeTronChiTietRepository>().SelectAll());

        public IList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID) => MeTronChiTietHelper.BuildListObjMeTronChiTiet((IList<MeTronChiTiet>)IoC.Current.Container.Resolve<IMeTronChiTietRepository>().DoQuery().Where<MeTronChiTiet>((Expression<Func<MeTronChiTiet, bool>>)(o => o.MeTron.PhieuTronID == ptID)).ToList<MeTronChiTiet>());
        public IList<ObjMeTronChiTietGiaoHang> ListMeTronChiTietGiaoHangByPhieuTronID(int ptID) => MeTronChiTietGiaoHangHelper.BuildListObjMeTronChiTiet((IList<MeTronChiTietGiaoHang>)IoC.Current.Container.Resolve<IMeTronChiTietGiaoHangRepository>().DoQuery().Where<MeTronChiTietGiaoHang>((Expression<Func<MeTronChiTietGiaoHang, bool>>)(o => o.MeTron.PhieuTronID == ptID)).ToList<MeTronChiTietGiaoHang>());

        public bool SaveMeTronChiTiet(IList<ObjMeTronChiTiet> lstCT)
        {
            IMeTronChiTietRepository chiTietRepository = IoC.Current.Container.Resolve<IMeTronChiTietRepository>();
            foreach (ObjMeTronChiTiet objMeTronChiTiet in (IEnumerable<ObjMeTronChiTiet>)lstCT)
            {
                if (objMeTronChiTiet.MarkAsDeleted)
                {
                    chiTietRepository.Delete(chiTietRepository.GetById(objMeTronChiTiet.MeTronChiTietID));
                }
                else
                {
                    MeTronChiTiet entity = MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMeTronChiTiet);
                    chiTietRepository.Add(entity);
                }
            }
            chiTietRepository.Save();
            return true;
        }

        public ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID1)
        {
            /*IMeTronChiTietRepository chiTietRepository = IoC.Current.Container.Resolve<IMeTronChiTietRepository>();
            IMeTronRepository meTronRepository1 = IoC.Current.Container.Resolve<IMeTronRepository>();
            IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            PhieuTron entity1 = phieuTronRepository.GetLastest();
            if (entity1 == null)
            {
                entity1 = new PhieuTron();
                entity1.MaPhieuTron = "NULL";
                entity1.NgayPhieuTron = new DateTime?(DateTime.Now);
                phieuTronRepository.Update(entity1);
                phieuTronRepository.Save();
            }
            MeTron entity2 = (MeTron)null;
            MeTron tronFromPhieuTron = meTronRepository1.GetLatestMeTronFromPhieuTron(entity1.PhieuTronID);
            bool flag = false;
            int? sttSiloPlc;
            if (tronFromPhieuTron == null)
            {
                sttSiloPlc = objMTCT.STTSiloPLC;
                int num = 0;
                if (sttSiloPlc.GetValueOrDefault() == num & sttSiloPlc.HasValue)
                    flag = true;
            }
            if (flag)
            {     
                entity2 = new MeTron()
                {
                    PhieuTronID = entity1.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entity1.KLDuTinhCuaTungMe,
                    CreatedBy = new int?(GlobalValues.UserID),
                    CreationDate = new DateTime?(DateTime.Now)
                };
            
                meTronRepository1.Add(entity2);
                meTronRepository1.Save();
                objMTCT.MeTronID = entity2.MeTronID;
                MeTronChiTiet meTronChiTiet = MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMTCT);
                chiTietRepository.Add(meTronChiTiet);
                chiTietRepository.Save();
                MeTronChiTietHelper.CopyToObjMeTronChiTiet(meTronChiTiet, objMTCT);
                return objMTCT;
            }
            else
            {
                IMeTronRepository meTronRepository2 = meTronRepository1;
                int phieuTronId = entity1.PhieuTronID;
                sttSiloPlc = objMTCT.STTSiloPLC;
                int lnNo = sttSiloPlc.Value;
                entity2 = meTronRepository2.GetMeTron(phieuTronId, lnNo);

                meTronRepository1.Update(entity2);
                meTronRepository1.Save();
                objMTCT.MeTronID = entity2.MeTronID;
                MeTronChiTiet meTronChiTiet = MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMTCT);
                chiTietRepository.Add(meTronChiTiet);
                chiTietRepository.Save();
                MeTronChiTietHelper.CopyToObjMeTronChiTiet(meTronChiTiet, objMTCT);
                return objMTCT;
            }
            if (entity2 == null)
                entity2 = new MeTron()
                {
                    PhieuTronID = entity1.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entity1.KLDuTinhCuaTungMe,
                    CreatedBy = new int?(GlobalValues.UserID),
                    CreationDate = new DateTime?(DateTime.Now)
                };
            if (entity2 == null)
            {
               

            }
            return objMTCT;*/




            IMeTronChiTietRepository repMTCT = IoC.Current.Container.Resolve<IMeTronChiTietRepository>();
            IMeTronRepository repMT = IoC.Current.Container.Resolve<IMeTronRepository>();
            IPhieuTronRepository repPT = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            PhieuTron entLastestPT = repPT.GetLastest();

            if (entLastestPT == null)
            {
                entLastestPT = new PhieuTron
                {
                    MaPhieuTron = "PHIEU_RONG",
                    NgayPhieuTron = new DateTime?(DateTime.Now)
                };
                repPT.Add(entLastestPT);
                repPT.Save();
            }

            MeTron entMT = null;
            MeTron entLatestMT = repMT.GetLatestMeTronFromPhieuTron(entLastestPT.PhieuTronID);
            bool isNewPT_TronManual = false;

            if (entLatestMT == null)
            {
                int? sttsiloPLC = objMTCT.STTSiloPLC;
                int num = 0;

                if (sttsiloPLC.GetValueOrDefault() == num && sttsiloPLC != null)
                {
                    isNewPT_TronManual = true;
                }
            }

            if (isNewPT_TronManual)
            {
                entMT = new MeTron
                {
                    PhieuTronID = entLastestPT.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entLastestPT.KLDuTinhCuaTungMe,
                    CreatedBy = GlobalValues.UserID,
                    CreationDate = new DateTime?(DateTime.Now)
                };
                repMT.Add(entMT);
            }

            if (entMT == null)
            {
                entMT = repMT.GetMeTron(entLastestPT.PhieuTronID, objMTCT.STTSiloPLC.Value);
            }

            if (entMT == null)
            {
                entMT = new MeTron
                {
                    PhieuTronID = entLastestPT.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entLastestPT.KLDuTinhCuaTungMe,
                    CreatedBy = GlobalValues.UserID,
                    CreationDate = new DateTime?(DateTime.Now)
                };
                
                repMT.Add(entMT);
            }
            else
            {
                // Thực hiện cập nhật dữ liệu của entMT bằng cách gọi repMT.Update(entMT);
                repMT.Update(entMT);
            }


            repMT.Save();
            objMTCT.MeTronID = entMT.MeTronID;

            

            MeTronChiTiet entMTCT = MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMTCT);
            // Sử dụng repMTCT.Add hoặc repMTCT.Update tùy vào việc bạn muốn thêm mới hoặc cập nhật entMTCT
            repMTCT.Add(entMTCT);

            if (objMTCT.PLCSaveId == 1) //Add save by hand mix
            {
                entMT.KhoiLuong = 0;
                entMT.LatestUpdatedBy = GlobalValues.UserID;
                entMT.LatestUpdateDate = DateTime.Now;
                repMT.Update(entMT);// Add  save by hand mix
                repMT.Save();
            }
            repMTCT.Save();

            MeTronChiTietHelper.CopyToObjMeTronChiTiet(entMTCT, objMTCT);
            return objMTCT;
        }
        public ObjMeTronChiTietGiaoHang SaveMeTronChiTietGiaoHang(ObjMeTronChiTietGiaoHang objMTCT, int phieuTronID1)
        {

            IMeTronChiTietGiaoHangRepository repMTCT = IoC.Current.Container.Resolve<IMeTronChiTietGiaoHangRepository>();
            IMeTronRepository repMT = IoC.Current.Container.Resolve<IMeTronRepository>();
            IPhieuTronRepository repPT = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            PhieuTron entLastestPT = repPT.GetLastest();

            if (entLastestPT == null)
            {
                entLastestPT = new PhieuTron
                {
                    MaPhieuTron = "PHIEU_RONG",
                    NgayPhieuTron = new DateTime?(DateTime.Now)
                };
                repPT.Add(entLastestPT);
                repPT.Save();
            }

            MeTron entMT = null;
            MeTron entLatestMT = repMT.GetLatestMeTronFromPhieuTron(entLastestPT.PhieuTronID);
            bool isNewPT_TronManual = false;

            if (entLatestMT == null)
            {
                int? sttsiloPLC = objMTCT.STTSiloPLC;
                int num = 0;

                if (sttsiloPLC.GetValueOrDefault() == num && sttsiloPLC != null)
                {
                    isNewPT_TronManual = true;
                }
            }

            if (isNewPT_TronManual)
            {
                entMT = new MeTron
                {
                    PhieuTronID = entLastestPT.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entLastestPT.KLDuTinhCuaTungMe,
                    CreatedBy = GlobalValues.UserID,
                    CreationDate = new DateTime?(DateTime.Now)
                };
                repMT.Add(entMT);
            }

            if (entMT == null)
            {
                entMT = repMT.GetMeTron(entLastestPT.PhieuTronID, objMTCT.STTSiloPLC.Value);
            }

            if (entMT == null)
            {
                entMT = new MeTron
                {
                    PhieuTronID = entLastestPT.PhieuTronID,
                    LnNo = objMTCT.STTSiloPLC,
                    IsManual = objMTCT.IsManual,
                    NgayMeTron = new DateTime?(DateTime.Now),
                    KhoiLuong = entLastestPT.KLDuTinhCuaTungMe,
                    CreatedBy = GlobalValues.UserID,
                    CreationDate = new DateTime?(DateTime.Now)
                };
                
                repMT.Add(entMT);
            }
            else
            {
                // Thực hiện cập nhật dữ liệu của entMT bằng cách gọi repMT.Update(entMT);
                repMT.Update(entMT);
            }


            repMT.Save();
            objMTCT.MeTronID = entMT.MeTronID;

            

            MeTronChiTietGiaoHang entMTCT = MeTronChiTietGiaoHangHelper.BuildNewEntMeTronChiTiet(objMTCT);
            // Sử dụng repMTCT.Add hoặc repMTCT.Update tùy vào việc bạn muốn thêm mới hoặc cập nhật entMTCT
            repMTCT.Add(entMTCT);

            if (objMTCT.PLCSaveId == 1) //Add save by hand mix
            {
                entMT.KhoiLuong = 0;
                entMT.LatestUpdatedBy = GlobalValues.UserID;
                entMT.LatestUpdateDate = DateTime.Now;
                repMT.Update(entMT);// Add  save by hand mix
                repMT.Save();
            }
            repMTCT.Save();

            MeTronChiTietGiaoHangHelper.CopyToObjMeTronChiTiet(entMTCT, objMTCT);
            return objMTCT;
        }


        public ObjNhomSilo GetNhomSiloByKey(int miID) => NhomSiloHelper.BuildNewObjNhomSilo(IoC.Current.Container.Resolve<INhomSiloRepository>().GetById(miID));

        public IList<ObjNhomSilo> ListNhomSilo() => NhomSiloHelper.BuildListObjNhomSilo(IoC.Current.Container.Resolve<INhomSiloRepository>().SelectAll());

        public bool SaveNhomSilo(IList<ObjNhomSilo> lstCT)
        {
            INhomSiloRepository nhomSiloRepository = IoC.Current.Container.Resolve<INhomSiloRepository>();
            foreach (ObjNhomSilo objNhomSilo in (IEnumerable<ObjNhomSilo>)lstCT)
            {
                if (objNhomSilo.MarkAsDeleted)
                {
                    nhomSiloRepository.Delete(nhomSiloRepository.GetById(objNhomSilo.NhomSiloID));
                }
                else
                {
                    NhomSilo entity = NhomSiloHelper.BuildNewEntNhomSilo(objNhomSilo);
                    nhomSiloRepository.Update(entity);
                }
            }
            nhomSiloRepository.Save();
            return true;
        }

      
        public ObjPhieuTron GetPhieuTronByKey(int miID) => PhieuTronHelper.BuildNewObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().GetById(miID));
        public ObjPhieuGiaoHang GetPhieuGiaoHangByKey(int miID) => PhieuGiaoHangHelper.BuildNewObjPhieuTron(IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>().GetById(miID));

        public ObjPhieuTron GetPhieuTronByCode(string code)
        {
            PhieuTron byCode = IoC.Current.Container.Resolve<IPhieuTronRepository>().GetByCode(code);
            return byCode == null ? (ObjPhieuTron)null : PhieuTronHelper.BuildNewObjPhieuTron(byCode);
        }
        public ObjPhieuGiaoHang GetPhieuGiaoHangByCode(string code)
        {
            PhieuGiaoHang byCode = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>().GetByCode(code);
            return byCode == null ? (ObjPhieuGiaoHang)null : PhieuGiaoHangHelper.BuildNewObjPhieuTron(byCode);
        }

        public IList<ObjPhieuTron> ListPhieuTron() => PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().SelectAll());
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang() => PhieuGiaoHangHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>().SelectAll());

        public IList<ObjPhieuTron> ListPhieuTron_ForTronOnline() => PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().ListPhieuTron_ForTronOnline());

        public IList<ObjPhieuTron> ListPhieuTron_ByStatus(int status) => PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().ListPhieuTron_ByStatus(status));

        public IList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued) => PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().ListPhieuTron_ByIsQueued(isQueued));
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByIsQueued(bool isQueued) => PhieuGiaoHangHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>().ListPhieuTron_ByIsQueued(isQueued));

        public IList<ObjPhieuTron> ListPhieuTron_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          bool? isQueued)
        {
            return PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, status, isQueued));
        }
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          bool? isQueued)
        {
            return PhieuGiaoHangHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>().ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, isQueued));
        }

        public IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length) => IoC.Current.Container.Resolve<IPhieuTronRepository>().ListMaPhieuTron_AutoComplete(strInput, length);

        public IList<ObjPhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length) => PhieuTronHelper.BuildListObjPhieuTron(IoC.Current.Container.Resolve<IPhieuTronRepository>().ListPhieuTron_AutoComplete(strInput, length));

        public bool SavePhieuTron(IList<ObjPhieuTron> lstPT)
        {
            IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            IHopDongRepository hopDongRepository = IoC.Current.Container.Resolve<IHopDongRepository>();
            foreach (ObjPhieuTron objPhieuTron in (IEnumerable<ObjPhieuTron>)lstPT)
            {
                if (objPhieuTron.MarkAsDeleted)
                {
                    phieuTronRepository.Delete(phieuTronRepository.GetById(objPhieuTron.PhieuTronID));
                }
                else
                {
                    PhieuTron phieuTron;
                    Decimal? nullable1;
                    if (objPhieuTron.IsNewObject)
                    {
                        phieuTron = PhieuTronHelper.BuildNewEntPhieuTron(objPhieuTron);
                        HopDong entity = hopDongRepository.GetById(objPhieuTron.HopDongID.Value);
                        HopDong hopDong = entity;
                        nullable1 = hopDong.KLTaoPhieuTron;
                        Decimal? klDuTinh = phieuTron.KLDuTinh;
                        hopDong.KLTaoPhieuTron = nullable1.HasValue & klDuTinh.HasValue ? new Decimal?(nullable1.GetValueOrDefault() + klDuTinh.GetValueOrDefault()) : new Decimal?();
                        entity.Status = new int?(1);
                        hopDongRepository.Update(entity);
                        hopDongRepository.Save();
                    }
                    else
                    {
                        phieuTron = phieuTronRepository.GetById(objPhieuTron.PhieuTronID);
                        HopDong hopDong = phieuTron.HopDong;
                        Decimal? klTaoPhieuTron = hopDong.KLTaoPhieuTron;
                        Decimal? klDuTinh = objPhieuTron.KLDuTinh;
                        Decimal? nullable2 = phieuTron.KLDuTinh;
                        nullable1 = klDuTinh.HasValue & nullable2.HasValue ? new Decimal?(klDuTinh.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new Decimal?();
                        Decimal? nullable3;
                        if (!(klTaoPhieuTron.HasValue & nullable1.HasValue))
                        {
                            nullable2 = new Decimal?();
                            nullable3 = nullable2;
                        }
                        else
                            nullable3 = new Decimal?(klTaoPhieuTron.GetValueOrDefault() + nullable1.GetValueOrDefault());
                        hopDong.KLTaoPhieuTron = nullable3;
                        PhieuTronHelper.CopyToEntPhieuTron(objPhieuTron, phieuTron);
                    }
                    phieuTronRepository.Add(phieuTron);
                }
            }
            phieuTronRepository.Save();
            return true;
        }
        public bool SavePhieuGiaoHang(IList<ObjPhieuGiaoHang> lstPT)
        {
            IPhieuGiaoHangRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>();
            foreach (ObjPhieuGiaoHang objPhieuTron in (IEnumerable<ObjPhieuGiaoHang>)lstPT)
            {
                if (objPhieuTron.MarkAsDeleted)
                {
                    phieuTronRepository.Delete(phieuTronRepository.GetById(objPhieuTron.PhieuTronID));
                }
                else
                {
                    PhieuGiaoHang phieuTron;
                    if (objPhieuTron.IsNewObject)
                    {
                        phieuTron = PhieuGiaoHangHelper.BuildNewEntPhieuTron(objPhieuTron);
                        phieuTron.GioBD = DateTime.Now.ToString("HH:mm:ss");
                        phieuTron.GioKT = DateTime.Now.AddMinutes(ConfigManager.TramTronConfig.AddMinuteGioKT).ToString("HH:mm:ss");
                        phieuTron.CreatedBy = new int?(GlobalValues.UserID);
                        phieuTron.CreationDate = DateTime.Now;
                        phieuTronRepository.Add(phieuTron);
                    }
                    else
                    {
                        phieuTron = phieuTronRepository.GetById(objPhieuTron.PhieuTronID);
                        PhieuGiaoHangHelper.CopyToEntPhieuTron(objPhieuTron, phieuTron);
                        phieuTron.LatestUpdatedBy = new int?(GlobalValues.UserID);
                        phieuTron.LatestUpdateDate = DateTime.Now;
                        phieuTronRepository.Update(phieuTron);
                    }
                }
            }
            phieuTronRepository.Save();
            return true;
        }

        public bool AddOrAttachPhieuTron(ObjPhieuTron objPT)
        {
            IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            PhieuTron entity = PhieuTronHelper.BuildNewEntPhieuTron(objPT);
            phieuTronRepository.Add(entity);
            phieuTronRepository.Save();
            return true;
        }
        public bool UpdatePhieuTron(ObjPhieuTron objPT, decimal klThuc)
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();

                PhieuTron existingEntity = phieuTronRepository.GetById(objPT.PhieuTronID);

                if (existingEntity != null)
                {
                    existingEntity.KLThuc = klThuc;
                    existingEntity.LatestUpdateDate = new DateTime?(DateTime.Now);
                    phieuTronRepository.Update(existingEntity);
                    phieuTronRepository.Save();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool UpdatePhieuGiaoHang(ObjPhieuGiaoHang objPT, string gioKT)
        {
            try
            {
                IPhieuGiaoHangRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>();

                PhieuGiaoHang existingEntity = phieuTronRepository.GetById(objPT.PhieuTronID);

                if (existingEntity != null)
                {
                    existingEntity.GioKT = gioKT;
                    existingEntity.LatestUpdateDate = new DateTime?(DateTime.Now);
                    phieuTronRepository.Update(existingEntity);
                    phieuTronRepository.Save();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool ResolveUnfinishPhieuTron1()
        {
            IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
            foreach (PhieuTron entity in (IEnumerable<PhieuTron>)phieuTronRepository.ListPhieuTron_ForTronOnline())
            {
                int? status = entity.Status;
                int num = 3;
                if (status.GetValueOrDefault() == num & status.HasValue)
                {
                    entity.Status = new int?(5);
                    phieuTronRepository.Update(entity);
                }
            }
            phieuTronRepository.Save();
            return true;
        }

        public bool ResolveUnfinishPhieuTron()
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                PhieuTron lastest = phieuTronRepository.GetLastest();
                lastest.Status = new int?(5);
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        
        public ObjSilo GetSiloByKey(int miID) => SiloHelper.BuildNewObjSilo(IoC.Current.Container.Resolve<ISiloRepository>().GetById(miID));

        public IList<ObjSilo> ListSilo() => SiloHelper.BuildListObjSilo(IoC.Current.Container.Resolve<ISiloRepository>().SelectAll());

        public IList<ObjSilo> ListSilo_ByActivated(bool activated) => SiloHelper.BuildListObjSilo(IoC.Current.Container.Resolve<ISiloRepository>().ListSilo_ByActivated(activated));

        public IList<ObjSilo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL) => SiloHelper.BuildListObjSilo(IoC.Current.Container.Resolve<ISiloRepository>().ListSilo_ByActivated_MaNhomSilo(activated, maNhomSL));

        public bool SaveSilo(IList<ObjSilo> lstSilo)
        {
            ISiloRepository siloRepository = IoC.Current.Container.Resolve<ISiloRepository>();
            using (TransactionScope transactionScope = new TransactionScope())
            {
                foreach (ObjSilo objSilo in (IEnumerable<ObjSilo>)lstSilo)
                {
                    if (objSilo.MarkAsDeleted)
                    {
                        siloRepository.Delete(siloRepository.GetById(objSilo.SiloID));
                        this.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "SILO_DEL", objSilo.MaSilo, string.Empty, string.Empty);
                    }
                    else if (objSilo.IsNewObject)
                    {
                        Silo entity = SiloHelper.BuildNewEntSilo(objSilo);
                        siloRepository.Add(entity);
                        this.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "SILO_NEW", objSilo.MaSilo, string.Empty, string.Empty);
                    }
                    else
                    {
                        Silo silo = siloRepository.GetById(objSilo.SiloID);
                        string oldValueText = SiloHelper.GenMemberValues(silo);
                        string newValueText = SiloHelper.GenMemberValues(objSilo);
                        this.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "SILO_EDIT", objSilo.MaSilo, oldValueText, newValueText);
                        SiloHelper.CopyToEntSilo(objSilo, silo);
                        siloRepository.Update(silo);
                    }
                }
                siloRepository.Save();
                transactionScope.Complete();
                return true;
            }
        }


        public ObjWeigh GetWeighByKey(int miID) => WeighHelper.BuildNewObjWeigh(IoC.Current.Container.Resolve<IWeighRepository>().GetById(miID));

        public IList<ObjWeigh> ListWeigh() => WeighHelper.BuildListObjWeigh(IoC.Current.Container.Resolve<IWeighRepository>().SelectAll());

        public bool SaveWeigh(IList<ObjWeigh> lstCT)
        {
            IWeighRepository weighRepository = IoC.Current.Container.Resolve<IWeighRepository>();
            foreach (ObjWeigh objWeigh in (IEnumerable<ObjWeigh>)lstCT)
            {
                if (objWeigh.MarkAsDeleted)
                {
                    weighRepository.Delete(weighRepository.GetById(objWeigh.WeighID));
                }
                else
                {
                    Weigh entity = WeighHelper.BuildNewEntWeigh(objWeigh);
                    weighRepository.Update(entity);
                }
            }
            weighRepository.Save();
            return true;
        }

        public ObjWeiSiloSaving GetWeiSiloSavingByKey(int miID) => WeiSiloSavingHelper.BuildNewObjWeiSiloSaving(IoC.Current.Container.Resolve<IWeiSiloSavingRepository>().GetById(miID));

        public IList<ObjWeiSiloSaving> ListWeiSiloSaving() => WeiSiloSavingHelper.BuildListObjWeiSiloSaving(IoC.Current.Container.Resolve<IWeiSiloSavingRepository>().SelectAll());

        public bool SaveWeiSiloSaving(IList<ObjWeiSiloSaving> lstCT)
        {
            IWeiSiloSavingRepository savingRepository = IoC.Current.Container.Resolve<IWeiSiloSavingRepository>();
            foreach (ObjWeiSiloSaving objWeiSiloSaving in (IEnumerable<ObjWeiSiloSaving>)lstCT)
            {
                if (objWeiSiloSaving.MarkAsDeleted)
                {
                    savingRepository.Delete(savingRepository.GetById(objWeiSiloSaving.WeiSiloSavingID));
                }
                else
                {
                    WeiSiloSaving entity = WeiSiloSavingHelper.BuildNewEntWeiSiloSaving(objWeiSiloSaving);
                    savingRepository.Update(entity);
                }
            }
            savingRepository.Save();
            return true;
        }

        public ObjWeiSiloVisible GetWeiSiloVisibleByKey(int miID) => WeiSiloVisibleHelper.BuildNewObjWeiSiloVisible(IoC.Current.Container.Resolve<IWeiSiloVisibleRepository>().GetById(miID));

        public IList<ObjWeiSiloVisible> ListWeiSiloVisible() => WeiSiloVisibleHelper.BuildListObjWeiSiloVisible(IoC.Current.Container.Resolve<IWeiSiloVisibleRepository>().SelectAll());

        public bool SaveWeiSiloVisible(IList<ObjWeiSiloVisible> lstCT)
        {
            IWeiSiloVisibleRepository visibleRepository = IoC.Current.Container.Resolve<IWeiSiloVisibleRepository>();
            foreach (ObjWeiSiloVisible objWeiSiloVisible in (IEnumerable<ObjWeiSiloVisible>)lstCT)
            {
                if (objWeiSiloVisible.MarkAsDeleted)
                {
                    visibleRepository.Delete(visibleRepository.GetById(objWeiSiloVisible.WeiSiloVisibleID));
                }
                else
                {
                    WeiSiloVisible entity = WeiSiloVisibleHelper.BuildNewEntWeiSiloVisible(objWeiSiloVisible);
                    visibleRepository.Update(entity);
                }
            }
            visibleRepository.Save();
            return true;
        }

        public ObjHangMuc GetHangMucByKey(int miID) => HangMucHelper.BuildNewObjHangMuc(IoC.Current.Container.Resolve<IHangMucRepository>().GetById(miID));

        public IList<ObjHangMuc> ListHangMuc() => HangMucHelper.BuildListObjHangMuc(IoC.Current.Container.Resolve<IHangMucRepository>().SelectAll());

        public IList<ObjHangMuc> ListHangMuc_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          bool? active)
        {
            return HangMucHelper.BuildListObjHangMuc(IoC.Current.Container.Resolve<IHangMucRepository>().ListHangMuc_ByCondition(fromDate, toDate, maKH, tenKH, active));
        }

        public bool SaveHangMuc(IList<ObjHangMuc> lst)
        {
            IHangMucRepository hangMucRepository = IoC.Current.Container.Resolve<IHangMucRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjHangMuc objHangMuc in (IEnumerable<ObjHangMuc>)lst)
                    {
                        if (objHangMuc.MarkAsDeleted)
                            hangMucRepository.Delete(hangMucRepository.GetById(objHangMuc.HangMucID));
                        else if (objHangMuc.IsNewObject)
                        {
                            HangMuc entity = HangMucHelper.BuildNewEntHangMuc(objHangMuc);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            hangMucRepository.Add(entity);
                        }
                        else
                        {
                            HangMuc hangMuc = hangMucRepository.GetById(objHangMuc.HangMucID);
                            HangMucHelper.CopyToEntHangMuc(objHangMuc, hangMuc);
                            hangMuc.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            hangMuc.LatestUpdateDate = new DateTime?(DateTime.Now);
                            hangMucRepository.Update(hangMuc);
                        }
                    }
                    hangMucRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }


        public ObjNhanVien GetNhanVienByKey(int miID) => NhanVienHelper.BuildNewObjNhanVien(IoC.Current.Container.Resolve<INhanVienRepository>().GetById(miID));

        public IList<ObjNhanVien> ListNhanVien() => NhanVienHelper.BuildListObjNhanVien(IoC.Current.Container.Resolve<INhanVienRepository>().SelectAll());

        public IList<ObjNhanVien> ListNhanVien_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            return NhanVienHelper.BuildListObjNhanVien(IoC.Current.Container.Resolve<INhanVienRepository>().ListNhanVien_ByCondition(fromDate, toDate, maKH, tenKH, phone, active));
        }

        public bool SaveNhanVien(IList<ObjNhanVien> lst)
        {
            INhanVienRepository nhanVienRepository = IoC.Current.Container.Resolve<INhanVienRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjNhanVien objNhanVien in (IEnumerable<ObjNhanVien>)lst)
                    {
                        if (objNhanVien.MarkAsDeleted)
                            nhanVienRepository.Delete(nhanVienRepository.GetById(objNhanVien.NhanVienID));
                        else if (objNhanVien.IsNewObject)
                        {
                            NhanVien entity = NhanVienHelper.BuildNewEntNhanVien(objNhanVien);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            nhanVienRepository.Add(entity);
                        }
                        else
                        {
                            NhanVien nhanVien = nhanVienRepository.GetById(objNhanVien.NhanVienID);
                            NhanVienHelper.CopyToEntNhanVien(objNhanVien, nhanVien);
                            nhanVien.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            nhanVien.LatestUpdateDate = new DateTime?(DateTime.Now);
                            nhanVienRepository.Update(nhanVien);
                        }
                    }
                    nhanVienRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }
        public ObjTaiXe GetTaiXeByKey(int miID) => TaiXeHelper.BuildNewObjTaiXe(IoC.Current.Container.Resolve<ITaiXeRepository>().GetById(miID));

        public IList<ObjTaiXe> ListTaiXe() => TaiXeHelper.BuildListObjTaiXe(IoC.Current.Container.Resolve<ITaiXeRepository>().SelectAll());

        public IList<ObjTaiXe> ListTaiXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            return TaiXeHelper.BuildListObjTaiXe(IoC.Current.Container.Resolve<ITaiXeRepository>().ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active));
        }

        public bool SaveTaiXe(IList<ObjTaiXe> lst)
        {
            ITaiXeRepository taiXeRepository = IoC.Current.Container.Resolve<ITaiXeRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjTaiXe objTaiXe in (IEnumerable<ObjTaiXe>)lst)
                    {
                        if (objTaiXe.MarkAsDeleted)
                            taiXeRepository.Delete(taiXeRepository.GetById(objTaiXe.TaiXeID));
                        else if (objTaiXe.IsNewObject)
                        {
                            TaiXe entity = TaiXeHelper.BuildNewEntTaiXe(objTaiXe);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            taiXeRepository.Add(entity);
                        }
                        else
                        {
                            TaiXe taiXe = taiXeRepository.GetById(objTaiXe.TaiXeID);
                            TaiXeHelper.CopyToEntTaiXe(objTaiXe, taiXe);
                            taiXe.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            taiXe.LatestUpdateDate = new DateTime?(DateTime.Now);
                            taiXeRepository.Update(taiXe);
                        }
                    }
                    taiXeRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }

        public ObjXe GetXeByKey(int miID) => XeHelper.BuildNewObjXe(IoC.Current.Container.Resolve<IXeRepository>().GetById(miID));

        public IList<ObjXe> ListXe() => XeHelper.BuildListObjXe(IoC.Current.Container.Resolve<IXeRepository>().SelectAll());

        public IList<ObjXe> ListXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string bienSo,
          bool? active)
        {
            return XeHelper.BuildListObjXe(IoC.Current.Container.Resolve<IXeRepository>().ListXe_ByCondition(fromDate, toDate, bienSo, active));
        }

        public bool SaveXe(IList<ObjXe> lst)
        {
            IXeRepository xeRepository = IoC.Current.Container.Resolve<IXeRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjXe objXe in (IEnumerable<ObjXe>)lst)
                    {
                        if (objXe.MarkAsDeleted)
                            xeRepository.Delete(xeRepository.GetById(objXe.XeID));
                        else if (objXe.IsNewObject)
                        {
                            Xe entity = XeHelper.BuildNewEntXe(objXe);
                            entity.CreatedBy = new int?(GlobalValues.UserID);
                            entity.CreationDate = new DateTime?(DateTime.Now);
                            xeRepository.Add(entity);
                        }
                        else
                        {
                            Xe xe = xeRepository.GetById(objXe.XeID);
                            XeHelper.CopyToEntXe(objXe, xe);
                            xe.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            xe.LatestUpdateDate = new DateTime?(DateTime.Now);
                            xeRepository.Update(xe);
                        }
                    }
                    xeRepository.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        return false;
                }
            }
            return false;
        }


        public ObjTimerPara GetTimerParaByKey(int miID) => TimerParaHelper.BuildNewObjTimerPara(IoC.Current.Container.Resolve<ITimerParaRepository>().GetById(miID));

        public IList<ObjTimerPara> ListTimerPara() => TimerParaHelper.BuildListObjTimerPara(IoC.Current.Container.Resolve<ITimerParaRepository>().SelectAll());

        public bool SaveTimerPara(IList<ObjTimerPara> lstCT)
        {
            ITimerParaRepository timerParaRepository = IoC.Current.Container.Resolve<ITimerParaRepository>();
            foreach (ObjTimerPara objTimerPara in (IEnumerable<ObjTimerPara>)lstCT)
            {
                if (objTimerPara.MarkAsDeleted)
                {
                    timerParaRepository.Delete(timerParaRepository.GetById(objTimerPara.TimerParaID));
                }
                else
                {
                    TimerPara entity = TimerParaHelper.BuildNewEntTimerPara(objTimerPara);
                    timerParaRepository.Update(entity);
                }
            }
            timerParaRepository.Save();
            return true;
        }


        public ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int miID)
        {
            TinhDoHutNuoc entTinhDoHutNuoc = IoC.Current.Container.Resolve<ITinhDoHutNuocRepository>().GetById(miID);
            ObjTinhDoHutNuoc tinhDoHutNuocByKey = TinhDoHutNuocHelper.BuildNewObjTinhDoHutNuoc(entTinhDoHutNuoc);
            tinhDoHutNuocByKey.BLstTinhDoHutNuocChiTiet = new BindingList<ObjTinhDoHutNuocChiTiet>();
            foreach (TinhDoHutNuocChiTiet entTinhDoHutNuocChiTiet in entTinhDoHutNuoc.TinhDoHutNuocChiTiets)
                tinhDoHutNuocByKey.BLstTinhDoHutNuocChiTiet.Add(TinhDoHutNuocChiTietHelper.BuildNewObjTinhDoHutNuocChiTiet(entTinhDoHutNuocChiTiet));
            return tinhDoHutNuocByKey;
        }

        public IList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc() => TinhDoHutNuocHelper.BuildListObjTinhDoHutNuoc(IoC.Current.Container.Resolve<ITinhDoHutNuocRepository>().SelectAll());

        public bool SaveTinhDoHutNuoc(IList<ObjTinhDoHutNuoc> lstTDHN)
        {
            ITinhDoHutNuocRepository hutNuocRepository = IoC.Current.Container.Resolve<ITinhDoHutNuocRepository>();
            ITinhDoHutNuocChiTietRepository chiTietRepository = IoC.Current.Container.Resolve<ITinhDoHutNuocChiTietRepository>();
            foreach (ObjTinhDoHutNuoc objTinhDoHutNuoc in (IEnumerable<ObjTinhDoHutNuoc>)lstTDHN)
            {
                if (objTinhDoHutNuoc.MarkAsDeleted)
                    hutNuocRepository.Delete(hutNuocRepository.GetById(objTinhDoHutNuoc.TinhDoHutNuocID));
                else if (objTinhDoHutNuoc.TinhDoHutNuocID > 0)
                {
                    TinhDoHutNuoc tinhDoHutNuoc = hutNuocRepository.GetById(objTinhDoHutNuoc.TinhDoHutNuocID);
                    TinhDoHutNuocHelper.CopyToEntTinhDoHutNuoc(objTinhDoHutNuoc, tinhDoHutNuoc);
                    for (int index = tinhDoHutNuoc.TinhDoHutNuocChiTiets.Count - 1; index >= 0; --index)
                        chiTietRepository.Delete(tinhDoHutNuoc.TinhDoHutNuocChiTiets.First<TinhDoHutNuocChiTiet>());
                    chiTietRepository.Save();
                    foreach (ObjTinhDoHutNuocChiTiet objTinhDoHutNuocChiTiet in (Collection<ObjTinhDoHutNuocChiTiet>)objTinhDoHutNuoc.BLstTinhDoHutNuocChiTiet)
                        TinhDoHutNuocChiTietHelper.BuildNewEntTinhDoHutNuocChiTiet(objTinhDoHutNuocChiTiet).TinhDoHutNuoc = tinhDoHutNuoc;
                    hutNuocRepository.Add(tinhDoHutNuoc);
                }
                else
                {
                    TinhDoHutNuoc entity = TinhDoHutNuocHelper.BuildNewEntTinhDoHutNuoc(objTinhDoHutNuoc);
                    foreach (ObjTinhDoHutNuocChiTiet objTinhDoHutNuocChiTiet in (Collection<ObjTinhDoHutNuocChiTiet>)objTinhDoHutNuoc.BLstTinhDoHutNuocChiTiet)
                        TinhDoHutNuocChiTietHelper.BuildNewEntTinhDoHutNuocChiTiet(objTinhDoHutNuocChiTiet).TinhDoHutNuoc = entity;
                    hutNuocRepository.Update(entity);
                }
            }
            hutNuocRepository.Save();
            return true;
        }


        public ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, List<ObjMeTron> lstMT)
        {
            try
            {
                IHopDongRepository hopDongRepository = IoC.Current.Container.Resolve<IHopDongRepository>();
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                IMeTronRepository meTronRepository = IoC.Current.Container.Resolve<IMeTronRepository>();
                IMeTronChiTietRepository chiTietRepository = IoC.Current.Container.Resolve<IMeTronChiTietRepository>();
                foreach (ObjMeTron objMeTron in lstMT)
                {
                    MeTron entity1 = MeTronHelper.BuildNewEntMeTron(objMeTron);
                    entity1.CreatedBy = new int?(GlobalValues.UserID);
                    entity1.CreationDate = new DateTime?(DateTime.Now);
                    entity1.PhieuTronID = objPT.PhieuTronID;
                    meTronRepository.Add(entity1);
                    foreach (ObjMeTronChiTiet objMeTronChiTiet in objMeTron.LstMeTronChiTiet)
                    {
                        MeTronChiTiet entity2 = MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMeTronChiTiet);
                        entity2.CreatedBy = new int?(GlobalValues.UserID);
                        entity2.CreationDate = new DateTime?(DateTime.Now);
                        entity2.MeTron = entity1;
                        chiTietRepository.Add(entity2);
                    }
                }
                meTronRepository.Save();
                chiTietRepository.Save();
                PhieuTron phieuTron1 = phieuTronRepository.GetById(objPT.PhieuTronID);
                Decimal num1 = 0M;
                foreach (MeTron entity in phieuTron1.MeTrons)
                {
                    Decimal valueOrDefault = objPT.KLDuTinhCuaTungMe.GetValueOrDefault();
                    entity.KhoiLuong = new Decimal?(valueOrDefault);
                    meTronRepository.Update(entity);
                    num1 += valueOrDefault;
                }
                phieuTron1.KLThuc = new Decimal?(num1);
                PhieuTron phieuTron2 = phieuTron1;
                Decimal? nullable = phieuTron2.SLMeDaTron;
                Decimal count = (Decimal)lstMT.Count;
                phieuTron2.SLMeDaTron = nullable.HasValue ? new Decimal?(nullable.GetValueOrDefault() + count) : new Decimal?();
                nullable = phieuTron1.SLMeDuTinh;
                Decimal? slMeDaTron = phieuTron1.SLMeDaTron;
                if (nullable.GetValueOrDefault() == slMeDaTron.GetValueOrDefault() & nullable.HasValue == slMeDaTron.HasValue)
                {
                    phieuTron1.Status = new int?(6);
                }
                else
                {
                    Decimal? slMeDuTinh = phieuTron1.SLMeDuTinh;
                    nullable = phieuTron1.SLMeDaTron;
                    if (!(slMeDuTinh.GetValueOrDefault() > nullable.GetValueOrDefault() & slMeDuTinh.HasValue & nullable.HasValue))
                        phieuTron1.Status = new int?(7);
                }
                phieuTronRepository.Update(phieuTron1);
                phieuTronRepository.Save();
                meTronRepository.Save();
                HopDong entity3 = hopDongRepository.GetById(objPT.HopDongID.Value);
                Decimal num2 = 0M;
                foreach (PhieuTron phieuTron3 in entity3.PhieuTrons)
                {
                    Decimal num3 = num2;
                    nullable = phieuTron3.KLThuc;
                    Decimal num4 = nullable.Value;
                    num2 = num3 + num4;
                }
                entity3.KLDaGiao = new Decimal?(num2);
                hopDongRepository.Add(entity3);
                hopDongRepository.Save();
                return PhieuTronHelper.BuildNewObjPhieuTron(phieuTron1);
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (ObjPhieuTron)null;
            }
        }

        public bool SaveNhanVienTronOnline(int id)
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                PhieuTron lastest = phieuTronRepository.GetLastest();
                lastest.NhanVienID = new int?(id);
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool SaveTaiXeTronOnline(int id)
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                PhieuTron lastest = phieuTronRepository.GetLastest();
                lastest.TaiXeID = new int?(id);
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public bool SaveTaiXeTronOnlinePhieuGiaoHang(string id)
        {
            try
            {
                IPhieuGiaoHangRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>();
                PhieuGiaoHang lastest = phieuTronRepository.GetLastest();
                lastest.TenTaiXe = id;
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool SaveXeTronOnline(int id)
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                PhieuTron lastest = phieuTronRepository.GetLastest();
                lastest.XeID = new int?(id);
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                    return false;
            }
        }
        public bool SaveXeTronOnlinePhieuGiaoHang(string id)
        {
            try
            {
                IPhieuGiaoHangRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>();
                PhieuGiaoHang lastest = phieuTronRepository.GetLastest();
                lastest.BienSo = id;
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool SaveNiemChiTronOnline(string niemchi)
        {
            try
            {
                IPhieuTronRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuTronRepository>();
                PhieuTron lastest = phieuTronRepository.GetLastest();
                lastest.MoTa = niemchi;
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public bool SaveNiemChiTronOnlinePhieuGiaoHang(string niemchi)
        {
            try
            {
                IPhieuGiaoHangRepository phieuTronRepository = IoC.Current.Container.Resolve<IPhieuGiaoHangRepository>();
                PhieuGiaoHang lastest = phieuTronRepository.GetLastest();
                lastest.NiemChi = niemchi;
                phieuTronRepository.Update(lastest);
                phieuTronRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDoAmSiloOnlineBySiloID(int siloID, Decimal doAm)
        {
            try
            {
                ISiloRepository siloRepository = IoC.Current.Container.Resolve<ISiloRepository>();
                Silo silo = siloRepository.GetById(siloID);
                silo.DoAm_NhomSlioAgg = doAm;
                siloRepository.Update(silo);
                siloRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public bool UpdateHutNuocSiloOnlineBySiloID(int siloID, Decimal doHutNuoc)
        {
            try
            {
                ISiloRepository siloRepository = IoC.Current.Container.Resolve<ISiloRepository>();
                Silo silo = siloRepository.GetById(siloID);
                silo.DoHutNuoc_NhomSiloAgg = doHutNuoc;
                siloRepository.Update(silo);
                siloRepository.Save();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1)
        {
            try
            {
                IMACRepository macRepository = IoC.Current.Container.Resolve<IMACRepository>();
                MAC mac = macRepository.GetById(macId);
                mac.ThemBotNuoc1 = themBotNuoc1;
                macRepository.Update(mac);
                macRepository.Save();
                return MACHelper.BuildNewObjMAC(mac);
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (ObjMAC)null;
            }
        }

        public ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2)
        {
            try
            {
                IMACRepository macRepository = IoC.Current.Container.Resolve<IMACRepository>();
                MAC mac = macRepository.GetById(macId);
                mac.ThemBotNuoc2 = themBotNuoc2;
                macRepository.Update(mac);
                macRepository.Save();
                return MACHelper.BuildNewObjMAC(mac);
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (ObjMAC)null;
            }
        }


        //============
        public Objvw_DataMix GetDataMixByKey(int datamixID) => vw_DataMixHelper.BuildNewObjvw_DataMix(IoC.Current.Container.Resolve<IViewDataMixRepository>().GetById(datamixID));
        public IList<Objvw_DataMix> ListDataMix() => vw_DataMixHelper.BuildListObjvw_DataMix(IoC.Current.Container.Resolve<IViewDataMixRepository>().SelectAll());
        public IList<Objvw_DataMix> ListDataMix_ByCondition(
            DateTime? fromDate,
            DateTime? toDate,
            string maPhieuTron,
            string khachHang,
            string congTruong,
            string hangMuc,
            string taiXe,
            string bienSo,
            string mac,
            string nhanVien
            ) 
        {
            return vw_DataMixHelper.BuildListObjvw_DataMix(IoC.Current.Container.Resolve<IViewDataMixRepository>().ListDataMix_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, taiXe, bienSo, mac, nhanVien));
        }

        public IList<Objvw_DataMix> ListDataMix_ByCondition(
            DateTime? fromDate,
            TimeSpan? fromTime,
            DateTime? toDate,
            TimeSpan? toTime,
            string maPhieuTron,
            int? khachHang,
            int? congTruong,
            int? hangMuc,
            int? mac,
            int? bienSo,
            int? taiXe,
            int? nhanVien,
            bool? moPhong)
        {
            return vw_DataMixHelper.BuildListObjvw_DataMix(IoC.Current.Container.Resolve<IViewDataMixRepository>().ListDataMix_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong));
        }

        public IList<Objvw_SumWeight> ListSumWeight_ByCondition(
            DateTime? fromDate,
            DateTime? toDate,
            string maPhieuTron,
            int? khachHang,
            int? congTruong,
            int? hangMuc,
            int? mac,
            int? bienSo,
            int? taiXe,
            int? nhanVien,
            bool? moPhong)
        {
            return vw_SumWeightHelper.BuildListObjvw_SumWeight(IoC.Current.Container.Resolve<IViewSumWeightRepository>().ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong));
        }

        public ObjAggregationResult GetSumForIsQueuedAndTimeRange(
            DateTime? fromDate,
            DateTime? toDate,
            bool? mophong)
        {
            return vw_DataMixHelper.BuildNewAggregation(IoC.Current.Container.Resolve<IViewDataMixRepository>().GetSumForIsQueuedAndTimeRange(fromDate, toDate, mophong));
        }

        public IList<Objvw_MaterialDetailDayWithID> ListTotalMaterial_ByCondition(int? materialID, bool? isManual)
        {
            //return vw_TotalMaterialHelper.BuildListObjvw_TotalMateria(IoC.Current.Container.Resolve<Ivw_TotalMaterialRepository>().ListvwTotalMaterial_ByCondition(materialID, isManual));
            return vw_PvMaterialDetailDayWithIDHelper.BuildListObjvw_MaterialDetailDayWithID(IoC.Current.Container.Resolve<Ivw_MaterialDetailDayRepository>().ListvwMaterialDetailDay_ByCondition(null, null, materialID, isManual));
        }
        public IList<Objvw_MaterialDetailDayWithID> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual)
        {
            return vw_PvMaterialDetailDayWithIDHelper.BuildListObjvw_MaterialDetailDayWithID(IoC.Current.Container.Resolve<Ivw_MaterialDetailDayRepository>().ListvwMaterialDetailDay_ByCondition_Update(fromDate, toDate, materialID, isManual));
        }
        
        public IList<Objvw_TranferDetailDayWithID> ListTranferDetailDay_ByCondition(
         DateTime? fromDate,
         DateTime? toDate,
         int? xeID,
         bool? isQueued)
        {
            return vw_TranferDetailDayWithIDHelper.BuildListObjvw_TranferDetailDayWithID(IoC.Current.Container.Resolve<Ivw_TranferDetailDayRepository>().ListTranferDetailDay_ByCondition_Update(fromDate, toDate, xeID, isQueued));
        }
        public IList<Objvw_TranferDetailDayWithID> ListTotalTranfer_ByCondition(
         int? xeID,
         bool? isManual)
        {
            return vw_TranferDetailDayWithIDHelper.BuildListObjvw_TranferDetailDayWithID(IoC.Current.Container.Resolve<Ivw_TotalTranferRepository>().ListvwTotalTranfer_ByCondition(xeID, isManual));
        }
        public IList<Objvw_DriverDetailDayWithID> ListTotalDriver_ByCondition(
        int? taixeID,
        bool? isManual)
        {
            return vw_DriverDetailDayWithIDHelper.BuildListObjvw_DriverDetailDayWithID(IoC.Current.Container.Resolve<Ivw_TotalDriverRepository>().ListvwTotalDriver_ByCondition(taixeID, isManual));
        }

        public IList<Objvw_DriverDetailDayWithID> ListDriverDetailDay__ByCondition(
            DateTime? fromDate,
            DateTime? toDate,
            int? taiXeID,
            bool? isManual)
        {
            return vw_DriverDetailDayWithIDHelper.BuildListObjvw_DriverDetailDayWithID(IoC.Current.Container.Resolve<Ivw_DriverDetailDayRepository>().ListDriverDetailDay_ByCondition_Update(fromDate, toDate, taiXeID, isManual));
        }
        // ── TonKho ────────────────────────────────────────────────

        public ObjTonKho GetTonKhoByKey(int id) =>
            TonKhoHelper.BuildNewObjTonKho(IoC.Current.Container.Resolve<ITonKhoRepository>().GetById(id));

        public IList<ObjTonKho> ListTonKho() =>
            TonKhoHelper.BuildListObjTonKho(IoC.Current.Container.Resolve<ITonKhoRepository>().ListTonKho_WithStatus());

        public (int HetKho, int CanhBao) DemCanhBao()
        {
            var list = IoC.Current.Container.Resolve<ITonKhoRepository>().DoQuery().ToList();
            return (
                list.Count(t => t.SoLuongTon <= 0),
                list.Count(t => t.SoLuongTon > 0 && t.SoLuongTon < t.MucCanhBao)
            );
        }

        public bool SaveTonKho(IList<ObjTonKho> lst)
        {
            ITonKhoRepository repo = IoC.Current.Container.Resolve<ITonKhoRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjTonKho obj in lst)
                    {
                        if (obj.IsNewObject)
                        {
                            TonKho ent = TonKhoHelper.BuildNewEntTonKho(obj);
                            ent.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            ent.LatestUpdateDate = new DateTime?(DateTime.Now);
                            repo.Add(ent);
                        }
                        else
                        {
                            TonKho ent = repo.GetById(obj.TonKhoID);
                            TonKhoHelper.CopyToEntTonKho(obj, ent);
                            ent.LatestUpdatedBy = new int?(GlobalValues.UserID);
                            ent.LatestUpdateDate = new DateTime?(DateTime.Now);
                            repo.Update(ent);
                        }
                    }
                    repo.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        // ── NhapKho ───────────────────────────────────────────────

        public ObjNhapKho GetNhapKhoByKey(int id) =>
            NhapKhoHelper.BuildNewObjNhapKho(IoC.Current.Container.Resolve<INhapKhoRepository>().GetById(id));

        public IList<ObjNhapKho> ListNhapKho() =>
            NhapKhoHelper.BuildListObjNhapKho(IoC.Current.Container.Resolve<INhapKhoRepository>().SelectAll());

        public IList<ObjNhapKho> ListNhapKho_BySiloID(int siloID) =>
            NhapKhoHelper.BuildListObjNhapKho(IoC.Current.Container.Resolve<INhapKhoRepository>().ListNhapKho_BySiloID(siloID));

        public bool SaveNhapKho(IList<ObjNhapKho> lst)
        {
            INhapKhoRepository repo = IoC.Current.Container.Resolve<INhapKhoRepository>();
            ITonKhoRepository tonKhoRepo = IoC.Current.Container.Resolve<ITonKhoRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjNhapKho obj in lst)
                    {
                        if (obj.MarkAsDeleted) continue;

                        if (obj.IsNewObject)
                        {
                            obj.MaPhieuNhap = repo.GenMaPhieuNhap();
                            NhapKho ent = NhapKhoHelper.BuildNewEntNhapKho(obj);
                            ent.CreatedBy = new int?(GlobalValues.UserID);
                            ent.CreationDate = new DateTime?(DateTime.Now);
                            ent.IsApplied = true;
                            repo.Add(ent);

                            // Cộng vào TonKho
                            TonKho tonKho = tonKhoRepo.GetBySiloID(obj.SiloID);
                            if (tonKho != null)
                            {
                                tonKho.SoLuongTon += obj.SoLuongNhap;
                                tonKho.LatestUpdatedBy = new int?(GlobalValues.UserID);
                                tonKho.LatestUpdateDate = new DateTime?(DateTime.Now);
                                tonKhoRepo.Update(tonKho);
                            }
                        }
                    }
                    repo.Save();
                    tonKhoRepo.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        // ── XuatKho ───────────────────────────────────────────────

        public ObjXuatKho GetXuatKhoByKey(int id) =>
            XuatKhoHelper.BuildNewObjXuatKho(IoC.Current.Container.Resolve<IXuatKhoRepository>().GetById(id));

        public IList<ObjXuatKho> ListXuatKho_ByPhieuTron(int phieuTronID) =>
            XuatKhoHelper.BuildListObjXuatKho(IoC.Current.Container.Resolve<IXuatKhoRepository>().ListXuatKho_ByPhieuTron(phieuTronID));

        public bool SaveXuatKho(IList<ObjXuatKho> lst)
        {
            IXuatKhoRepository repo = IoC.Current.Container.Resolve<IXuatKhoRepository>();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    foreach (ObjXuatKho obj in lst)
                    {
                        if (obj.IsNewObject)
                        {
                            XuatKho ent = XuatKhoHelper.BuildNewEntXuatKho(obj);
                            ent.CreatedBy = new int?(GlobalValues.UserID);
                            ent.CreationDate = new DateTime?(DateTime.Now);
                            repo.Add(ent);
                        }
                    }
                    repo.Save();
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        public ObjTonKho GetTonKhoBySiloID(int siloID)
        {
            var ent = IoC.Current.Container.Resolve<ITonKhoRepository>().GetBySiloID(siloID);
            return ent != null ? TonKhoHelper.BuildNewObjTonKho(ent) : null;
        }

        // Thay thế sp_XuatKho_TuDong cho một MeTron
        public void XuatKhoTheoMeTron(int meTronID, int phieuTronID, int duLieuTronID)
        {
            IXuatKhoRepository xuatRepo = IoC.Current.Container.Resolve<IXuatKhoRepository>();
            ITonKhoRepository tonKhoRepo = IoC.Current.Container.Resolve<ITonKhoRepository>();
            IMeTronChiTietRepository mtctRepo = IoC.Current.Container.Resolve<IMeTronChiTietRepository>();

            IList<MeTronChiTiet> chiTiets = mtctRepo.ListByMeTronID(meTronID);
            if (chiTiets.Count == 0)
            {
                TramTronLogger.WriteInfo($"[XuatKho] Không có MeTronChiTiet — MeTronID={meTronID}");
                return;
            }

            bool daXuat = xuatRepo.DoQuery().Any(x => x.MeTronID == meTronID);
            if (daXuat)
            {
                TramTronLogger.WriteInfo($"[XuatKho] Skip — đã xuất kho MeTronID={meTronID}");
                return;
            }

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (MeTronChiTiet ct in chiTiets)
                {
                    decimal soLuong = ct.ValueBat ?? 0;
                    if (soLuong <= 0 || ct.MACSilo == null || ct.MaterialID == null) continue;

                    int siloID = ct.MACSilo.SiloID;

                    var ent = new XuatKho
                    {
                        SiloID = siloID,
                        MaterialID = ct.MaterialID.Value,
                        SoLuongXuat = soLuong,
                        MeTronID = meTronID,
                        MeTronChiTietID = ct.MeTronChiTietID,
                        PhieuTronID = phieuTronID,
                        DuLieuTronID = duLieuTronID,
                        NgayXuat = DateTime.Now,
                        CreatedBy = GlobalValues.UserID,
                        CreationDate = DateTime.Now
                    };
                    xuatRepo.Add(ent);

                    TonKho tonKho = tonKhoRepo.GetBySiloID(siloID);
                    if (tonKho != null)
                    {
                        tonKho.SoLuongTon -= soLuong;
                        tonKho.LatestUpdatedBy = GlobalValues.UserID;
                        tonKho.LatestUpdateDate = DateTime.Now;
                        tonKhoRepo.Update(tonKho);
                    }
                }
                xuatRepo.Save();
                tonKhoRepo.Save();
                ts.Complete();
            }
        }


        // Loop qua tất cả MeTron của một PhieuTron rồi gọi XuatKhoTheoMeTron
        public void XuatKhoTheoPhieuTron(int phieuTronID, int duLieuTronID)
        {
            IMeTronRepository meTronRepo = IoC.Current.Container.Resolve<IMeTronRepository>();
            List<int> meTronIDs = meTronRepo.DoQuery()
                .Where(m => m.PhieuTronID == phieuTronID)
                .Select(m => m.MeTronID)
                .ToList();
            TramTronLogger.WriteInfo($"[XuatKho] Tìm thấy {meTronIDs.Count} MeTron — PhieuTronID={phieuTronID}");

            if (meTronIDs.Count == 0)
            {
                TramTronLogger.WriteInfo($"[XuatKho] CẢNH BÁO: Không có MeTron nào — PhieuTronID={phieuTronID}");
                return;
            }

            foreach (int meTronID in meTronIDs)
            {
                try
                {
                    XuatKhoTheoMeTron(meTronID, phieuTronID, duLieuTronID);
                    TramTronLogger.WriteInfo($"[XuatKho] OK — MeTronID={meTronID}");
                }
                catch (Exception ex)
                {
                    TramTronLogger.WriteInfo($"[XuatKho] LỖI MeTronID={meTronID}: {ex.Message}");
                    TramTronLogger.WriteError(ex);
                }
            }
        }
        public System.Data.DataTable GetSiloListForNhapKho()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("SiloID", typeof(int));
            dt.Columns.Add("TenHienThi", typeof(string));
            dt.Columns.Add("MaterialName", typeof(string));
            dt.Columns.Add("MaSilo", typeof(string));

            var silos = IoC.Current.Container.Resolve<ISiloRepository>().DoQuery()
                .Where(s => s.MaterialID != null && (s.Activated == null || s.Activated.Value))
                .OrderBy(s => s.MaSilo)
                .ToList();

            foreach (var s in silos)
                dt.Rows.Add(s.SiloID, s.MaSilo + " — " + s.MaterialName, s.MaterialName, s.MaSilo);

            return dt;
        }
        public List<ObjKiemTraTonKho> KiemTraNhuCau()
        {
            var list = new List<ObjKiemTraTonKho>();
            var sc = ConfigManager.ServiceConfig;
            string connStr = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                DataSource = sc.ServerName,
                InitialCatalog = sc.DatabaseName,
                UserID = sc.UserID,
                Password = sc.Password,
                IntegratedSecurity = false
            }.ConnectionString;

            const string sql = @"
                WITH NhuCau AS (
                    SELECT s.SiloID, s.MaSilo, m.MaterialName,
                           SUM(ISNULL(d.DLT_SLMeDuTinh,1) * ISNULL(ms.SiloValue,0)) AS TongCanDung
                    FROM DuLieuTron d
                    JOIN MACSilo  ms ON ms.MACID     = d.MACID
                    JOIN Silo     s  ON s.SiloID     = ms.SiloID
                    JOIN Material m  ON m.MaterialID = s.MaterialID
                    WHERE d.Status IN (0,2) AND s.MaterialID IS NOT NULL
                    GROUP BY s.SiloID, s.MaSilo, m.MaterialName
                )
                SELECT n.MaterialName, n.MaSilo,
                       ISNULL(tk.SoLuongTon,0)               AS TonHienTai,
                       n.TongCanDung,
                       ISNULL(tk.SoLuongTon,0)-n.TongCanDung AS ChenhLech,
                       ISNULL(tk.MucCanhBao,500)             AS MucCanhBao,
                       CASE WHEN ISNULL(tk.SoLuongTon,0) >= n.TongCanDung THEN 2
                            WHEN ISNULL(tk.SoLuongTon,0) >  0             THEN 1
                            ELSE 0 END AS TrangThaiID
                FROM NhuCau n
                LEFT JOIN TonKho tk ON tk.SiloID = n.SiloID
                ORDER BY TrangThaiID ASC, ChenhLech ASC";

            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new ObjKiemTraTonKho
                        {
                            MaterialName = rd["MaterialName"].ToString(),
                            MaSilo = rd["MaSilo"].ToString(),
                            TonHienTai = Convert.ToDecimal(rd["TonHienTai"]),
                            TongCanDung = Convert.ToDecimal(rd["TongCanDung"]),
                            ChenhLech = Convert.ToDecimal(rd["ChenhLech"]),
                            MucCanhBao = Convert.ToDecimal(rd["MucCanhBao"]),
                            TrangThaiID = Convert.ToInt32(rd["TrangThaiID"])
                        });
            }
            return list;
        }
    }
}