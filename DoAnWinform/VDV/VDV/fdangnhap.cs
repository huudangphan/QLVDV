using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDV.DAO;
using VDV.DTO;

namespace VDV
{
    public partial class fdangnhap : Form
    {
        public fdangnhap()
        {
            InitializeComponent();
        }   

       
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string userName = txttendangnhap.Text;
            string passWord = txtmatkhau.Text;
            if(login(userName,passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                frmmain f = new frmmain(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Nhập sai tên đăng nhập hoặc mật khẩu");
            }                     
        
        }
        bool login(string username,string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void fdangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
