using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDV.DTO;
using VDV.DAO;

namespace VDV
{
   
   
    public partial class frmmain : Form
    {
        private Account loginAccount;

       Account LoginAccount {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
                
            }
        }

        public frmmain(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            changeAccount(loginAccount.Type);

        }
        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            
            f.ShowDialog();
        }

        

        private void frmmain_Load(object sender, EventArgs e)
        {

        }

        private void bóngĐáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbongda f = new fbongda();
            f.Show();
        }

        private void điềnKinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdienkinh f = new fdienkinh();
            f.Show();
        }

        private void nhảyCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fnhaycao f = new fnhaycao();
            f.Show();
        }

        private void nhảyXaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fnhayxa f = new fnhayxa();
            f.Show();
        }

        private void bơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fboi f = new fboi();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fthongtincanhan f = new fthongtincanhan(LoginAccount);
            f.Show();
        }
    }
}
