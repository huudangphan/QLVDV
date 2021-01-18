using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VDV.DTO;
using VDV.DAO;

namespace VDV.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE name = N'" + userName + "' AND pass = N'" + passWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
        public bool getpass( string name,string pass)
        {
            string query = string.Format("SELECT * FROM dbo.TaiKhoan WHERE name=N'{0}' and pass=N'{1}'", name,pass);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Updatepass(string newpass ,string name)
        {
            string query = string.Format("UPDATE dbo.TaiKhoan SET pass=N'{0}' WHERE name=N'{1}'", newpass,name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public Account GetAccountByUserName(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from TaiKhoan where name = '" + name + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT name,type FROM dbo.TaiKhoan");
        }
        public bool insertaccount(string name, int type,string pass)
        {
            string query = string.Format("INSERT dbo.TaiKhoan (name, type,pass)VALUES (N'{0}',{1},N'{2}')", name, type,pass);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updateaccount(string name,int type,string pass)
        {
            string query = string.Format("UPDATE dbo.TaiKhoan SET name=N'{0}',type=N'{1}',pass=N'{2}' WHERE name=N'{0}'", name, type,pass);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteaccount(string name)
        {
            string query=string.Format("DELETE TaiKhoan where name=N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
    }
}
