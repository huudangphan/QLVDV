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

namespace VDV
{
    public partial class fnhayxa : Form
    {
        BindingSource listnx = new BindingSource();
        public fnhayxa()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {

            dtgvnhayxa.DataSource = listnx;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmavdv.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Mã VDV"));
            txttenvdv.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Tên VDV"));
            txtgioitinh.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Giới tính"));
            txtcannang.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Cân nặng(kg)"));
            txtchieucao.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Chiều cao(cm)"));

            txttttn.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "TTTN(cm)"));
            txtttsk.DataBindings.Add(new Binding("Text", dtgvnhayxa.DataSource, "Tình trạng"));



        }
        void loadctbd()
        {
            listnx.DataSource = VDVDAO.Instance.GetNX();
        }
        void insertnx(string mavdv, string tenvdv,string gioitinh, int cannang, int chieucao,  int tttn,string ttsk)
        {
            if (VDVDAO.Instance.insertnx(mavdv, tenvdv,gioitinh, cannang, chieucao,  tttn,ttsk))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadctbd();
        }
        void updatenx(string mavdv, string tenvdv,string gioitinh, int cannang, int chieucao,  int tttn,string ttsk)
        {
            if (VDVDAO.Instance.updatenx(mavdv, tenvdv,gioitinh, cannang, chieucao, tttn,ttsk))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  thất bại");
            }
            loadctbd();
        }
        void deletenx(string mavdv)
        {
            if (VDVDAO.Instance.deletenx(mavdv))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            loadctbd();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            string tenvdv = txttenvdv.Text;
            string gioitinh = txtgioitinh.Text;
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int cannang = Convert.ToInt32(txtcannang.Text);
            int tttn = Convert.ToInt32(txttttn.Text);
            string ttsk = txtttsk.Text;
            insertnx(mavdv, tenvdv,gioitinh, cannang, chieucao, tttn,ttsk);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            string tenvdv = txttenvdv.Text;
            string gioitinh = txtgioitinh.Text;
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int cannang = Convert.ToInt32(txtcannang.Text);
            int tttn = Convert.ToInt32(txttttn.Text);
            string ttsk = txtttsk.Text;
            updatenx(mavdv, tenvdv,gioitinh, cannang, chieucao, tttn,ttsk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            deletenx(mavdv);
        }
    }
}
