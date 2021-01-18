using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDV.DAO;

namespace VDV
{
    public partial class fAdmin : Form
    {
        BindingSource accountlist = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            loaddata();
          
        }

      
        public void loaddata()
        {
            dtgvaccount.DataSource = accountlist;
            addaccountBinding();
            loadaccount();

        }
        void addaccountBinding()
        {
            txtusername.DataBindings.Add(new Binding("Text", dtgvaccount.DataSource, "name"));
            //txtpass.DataBindings.Add(new Binding("Text", dtgvaccount.DataSource, "pass"));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvaccount.DataSource, "type"));
            
        }
        
        void loadaccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadaccount();
        }
        void addaccount(string name,int type,string pass)
        {
            if(AccountDAO.Instance.insertaccount(name,type,pass))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            loadaccount();
        }
        void editaccount(string name, int type,string pass)
        {
            if (AccountDAO.Instance.updateaccount(name, type,pass))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  tài khoản thất bại");
            }
            loadaccount();
        }
        void deleteaccount(string name)
        {
            if (AccountDAO.Instance.deleteaccount(name))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            loadaccount();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text;
            int type = (int)numericUpDown1.Value;
            string pass = txtpass.Text;
            addaccount(name, type,pass);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text;
            int type = (int)numericUpDown1.Value;
            string pass = txtpass.Text;
            editaccount(name, type,pass);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text;

            deleteaccount(name);
        }
    }
}
