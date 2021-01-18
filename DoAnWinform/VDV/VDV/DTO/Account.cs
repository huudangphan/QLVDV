using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDV.DAO;

namespace VDV.DTO
{
   public class Account
    {
        
        public Account(string name,int type, string pass = null)
        {
            this.name = name;
            this.Type = type;
            this.pass = pass;

        }
        public Account(DataRow row)
        {
            this.name = row["name"].ToString();
            this.Type = (int)row["type"];
            this.pass = row["pass"].ToString();
        }
        private string name;
        public string Name { get => name; set => name = value; }
        private string pass;
        public string Pass { get => pass; set => pass = value; }    
        private int type;

        
        
        public int Type { get => type; set => type = value; }
    }
}
