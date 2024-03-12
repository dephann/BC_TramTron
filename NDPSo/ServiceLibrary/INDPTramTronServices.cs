using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace NDPSo.ServiceLibrary
{
    [ServiceContract]
    public interface INDPTramTronServices
    {
        

        [OperationContract]
        ObjCongTruong GetCongTruongByKey(int ctID);

        [OperationContract]
        IList<ObjCongTruong> ListCongTruong();

        [OperationContract]
        IList<ObjCongTruong> ListCongTruong_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active);

        [OperationContract]
        bool SaveCongTruong(IList<ObjCongTruong> lstCT);
        [OperationContract]
        ObjKhachHang GetKhachHangByKey(int ctID);

        [OperationContract]
        IList<ObjKhachHang> ListKhachHang();

        [OperationContract]
        IList<ObjKhachHang> ListKhachHang_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active);

        [OperationContract]
        bool SaveKhachHang(IList<ObjKhachHang> lstCT);
        [OperationContract]
        string GetNextCode(string strTblName);
    }
}
