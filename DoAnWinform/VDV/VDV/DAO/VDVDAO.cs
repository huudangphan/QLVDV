using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDV.DAO
{
    class VDVDAO
    {
        private static VDVDAO instance;

        public static VDVDAO Instance
        {
            get { if (instance == null) instance = new VDVDAO(); return instance; }
            private set { instance = value; }
        }

        private VDVDAO() { }
        public DataTable GetBD()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaVDV_bd as [Mã cầu thủ],TenVDV_bd as[Tên cầu thủ],gioitinh as[Giới tính],[Vị trí],chieucao as[Chiều cao(cm)],cannang as[Cân nặng(kg)],ttsk as[Tình Trạng] FROM dbo.bongda");
        }
        public DataTable GetDK()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaVDV_dk as[Mã VDV] , TenVDV_dk as[Tên VDV],gioitinh as[Giới tính] , chieucao as[Chiều cao(cm)],cannang as[Cân nặng(kg)] ,Tttnhat_dk_100m as[TTTN 100m(s)] , Tttnhat_dk_200m as[TTTN 200m(s)] , Tttnhat_dk_500m as[TTTN 500m(s)] ,Tttnhat_dk_1000m as[TTTN 1000m(s)],ttsk as[Tình trạng] FROM dbo.dienkinh");

        }
        public DataTable GetNC()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaVDV_nc as[Mã VDV],Ten_VDV_nc as[Tên VDV],gioitinh as[Giới tính] ,chieucao_nc as[Chiều cao(cm)],cannang_nc as[Cân nặng(kg)],Tttnhat_nc as[TTTN(cm)],ttsk as[Tình trạng]   from dbo.NhayCao ");
        }
        public DataTable GetNX()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaVDV_nx as[Mã VDV],TenVDV_nx as[Tên VDV],gioitinh as[Giới tính],cannang_nx as[Cân nặng(kg)],chieucao_nx as[Chiều cao(cm)],Tttnhat_nx as[TTTN(cm)],ttsk as[Tình trạng] from dbo.NhayXa ");
        }
        public DataTable GetB()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaVDV_boi as[Mã VDV],TenVDV_boi as[Tên VDV],gioitinh as[Giới tính],cannang_boi as[Cân nặng(kg)],chieucao_boi as[Chiều cao(cm)],Tttnhat_boi_100m as[TTTN 100m(s)],Tttnhat_boi_200m as[TTTN 200m(s)]," +
                "Tttnhat_boi_500m as[TTTN 500m(s)],ttsk as[Tình trạng] FROM dbo.Boi  ");
        }
        public bool insertbd(string mavdv,string tenvdv,string gioitinh,string vitri,double chieucao,int cannang,string ttsk)
        {
            
            string query = string.Format("INSERT dbo.BongDa(MaVDV_bd,TenVDV_bd,gioitinh,[Vị trí],chieucao,cannang,ttsk) VALUES(N'{0}',N'{1}',N'{2}',N'{3}',{4},{5},N'{6}')", mavdv, tenvdv,gioitinh, vitri, chieucao, cannang,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updatebd(string mavdv, string tenvdv, string gioitinh, string vitri, double chieucao, int cannang,string ttsk)
        {
            string query = string.Format("UPDATE dbo.BongDa SET MaVDV_bd=N'{0}',TenVDV_bd=N'{1}',gioitinh=N'{2}',[Vị trí]=N'{3}',chieucao=N'{4}',cannang=N'{5}',ttsk=N'{6}' WHERE MaVDV_bd=N'{0}'", mavdv,tenvdv,gioitinh,vitri,chieucao,cannang,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deletebd(string mavdv)
        {
            string query = string.Format("DELETE BongDa where MaVDV_bd=N'{0}'", mavdv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool insertb(string mavdv, string tenvdv,string gioitinh,int cannang,int chieucao,int tttn100m,int tttn200m,int tttn500m,string ttsk)
        {

            string query = string.Format("INSERT dbo.Boi(MaVDV_boi,TenVDV_boi,gioitinh,cannang_boi,chieucao_boi,Tttnhat_boi_100m,Tttnhat_boi_200m,Tttnhat_boi_500m,ttsk) VALUES(N'{0}',N'{1}',N'{2}',{3},{4},{5},{6},{7},N'{8}')", mavdv, tenvdv,gioitinh, cannang,chieucao,tttn100m,tttn200m,tttn500m,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updateb(string mavdv, string tenvdv,string gioitinh, int cannang, int chieucao, int tttn100m, int tttn200m, int tttn500m,string ttsk)
        {
            string query = string.Format("UPDATE dbo.Boi SET MaVDV_boi=N'{0}',TenVDV_boi=N'{1}',gioitinh=N'{2}',cannang_boi={3},chieucao_boi={4},Tttnhat_boi_100m={5},Tttnhat_boi_200m={6},Tttnhat_boi_500m={7},ttsk=N'{8}' WHERE MaVDV_boi=N'{0}'", mavdv, tenvdv,gioitinh ,cannang,chieucao,tttn100m,tttn200m,tttn500m,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteb(string mavdv)
        {
            string query = string.Format("DELETE Boi where MaVDV_boi=N'{0}'", mavdv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool insertdk(string mavdv, string tenvdv,string gioitinh,  int chieucao, int cannang,int tttn100m,int tttn200m,int tttn500m,int tttn1000m,string ttsk)
        {

            string query = string.Format("INSERT dbo.DienKinh(MaVDV_dk,TenVDV_dk,gioitinh,chieucao,cannang,Tttnhat_dk_100m,Tttnhat_dk_200m,Tttnhat_dk_500m,Tttnhat_dk_1000m,ttsk) VALUES(N'{0}',N'{1}',N'{2}',{3},{4},{5},{6},{7},{8},N'{9}')", mavdv, tenvdv,gioitinh, chieucao,cannang,tttn100m,tttn200m,tttn200m,tttn1000m,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updatedk(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn100m, int tttn200m, int tttn500m, int tttn1000m,string ttsk)
        {
            string query = string.Format("UPDATE dbo.DienKinh SET MaVDV_dk=N'{0}',TenVDV_dk=N'{1}',gioitinh=N'{2}',chieucao={3},cannang={4},Tttnhat_dk_100m={5},Tttnhat_dk_200m={6},Tttnhat_dk_500m={7},Tttnhat_dk_1000m={8},ttsk=N'{9}' WHERE MaVDV_dk=N'{0}'", mavdv, tenvdv,gioitinh, chieucao,cannang,tttn100m,tttn200m,tttn500m,tttn1000m,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deletedk(string mavdv)
        {
            string query = string.Format("DELETE DienKinh where MaVDV_dk=N'{0}'", mavdv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool insertnc(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang,int tttn,string ttsk)
        {

            string query = string.Format("INSERT dbo.Nhaycao(MaVDV_nc,Ten_VDV_nc,gioitinh,chieucao_nc,cannang_nc,Tttnhat_nc,ttsk) VALUES(N'{0}',N'{1}',N'{2}',{3},{4},{5},N'{6}')", mavdv, tenvdv,gioitinh, chieucao, cannang,tttn,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updatenc(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn,string ttsk)
        {
            string query = string.Format("UPDATE dbo.NhayCao SET MaVDV_nc=N'{0}',Ten_VDV_nc=N'{1}',gioitinh=N'{2}',chieucao_nc={3},cannang_nc={4},Tttnhat_nc={5},ttsk=N'{6}' WHERE MaVDV_nc=N'{0}'", mavdv, tenvdv,gioitinh, chieucao,cannang,tttn,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deletenc(string mavdv)
        {
            string query = string.Format("DELETE NhayCao where MaVDV_nc=N'{0}'", mavdv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool insertnx(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn,string ttsk)
        {

            string query = string.Format("INSERT dbo.Nhayxa(MaVDV_nx,TenVDV_nx,gioitinh,cannang_nx,chieucao_nx,Tttnhat_nx,ttsk) VALUES(N'{0}',N'{1}',N'{2}',{3},{4},{5},N'{6}')", mavdv, tenvdv,gioitinh, cannang, chieucao,  tttn,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updatenx(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn,string ttsk)
        {
            string query = string.Format("UPDATE dbo.Nhayxa SET MaVDV_nx=N'{0}',TenVDV_nx=N'{1}',gioitinh=N'{2}',cannang_nx={3},chieucao_nx={4},Tttnhat_nx={5},ttsk=N'{6}' WHERE MaVDV_nx=N'{0}'", mavdv, tenvdv,gioitinh, cannang, chieucao,  tttn,ttsk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deletenx(string mavdv)
        {
            string query = string.Format("DELETE Nhayxa where MaVDV_nx=N'{0}'", mavdv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
