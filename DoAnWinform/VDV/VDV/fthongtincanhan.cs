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
    public partial class fthongtincanhan : Form
    {
        private Account loginAccount;

        Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;

                changeAccount(loginAccount);
            }
        }

        public fthongtincanhan(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void changeAccount(Account acc)
        {
            txtname.Text = loginAccount.Name;

        }

        private void btnthoatTT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncapNhat_Click(object sender, EventArgs e)
        {
            updateaccount();
        }
        void updateaccount()
        {
            string pass = txtmatKhau.Text;
            string newpass = txtmatKhauMoi.Text;
            string reenterpass = txtxacNhanmk.Text;
            string username = txtname.Text;
            if (AccountDAO.Instance.getpass(username,pass))
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu hiện tại");

            }
          
            else
            {

                if (!newpass.Equals(reenterpass))
                {
                    MessageBox.Show("Xác nhận mật khẩu sai");
                }

                else
                {
                    if (AccountDAO.Instance.Updatepass(newpass, username))
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật mật khẩu thất bại");
                    }
                }
            }
        }
    }
}
