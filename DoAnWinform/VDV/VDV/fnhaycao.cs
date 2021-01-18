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
    public partial class fnhaycao : Form
    {

        BindingSource listnc = new BindingSource();
        public fnhaycao()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {

            dtgvnhaycao.DataSource = listnc;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmavdv.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Mã VDV"));
            txttenvdv.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Tên VDV"));
            txtgioitinh.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Giới tính"));
            txtchieucao.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Chiều cao(cm)"));
            txtcannang.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Cân nặng(kg)"));
            txttttn.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "TTTN(cm)"));
            txtttsk.DataBindings.Add(new Binding("Text", dtgvnhaycao.DataSource, "Tình trạng"));



        }
        void loadctbd()
        {
            listnc.DataSource = VDVDAO.Instance.GetNC();
        }
        void insertnc(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn,string ttsk)
        {
            if (VDVDAO.Instance.insertnc(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn,ttsk))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadctbd();
        }
        void updatenc(string mavdv, string tenvdv,string gioitinh, int chieucao, int cannang, int tttn,string ttsk)
        {
            if (VDVDAO.Instance.updatenc(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn,ttsk))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  thất bại");
            }
            loadctbd();
        }
        void deletenc(string mavdv)
        {
            if (VDVDAO.Instance.deletenc(mavdv))
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
            insertnc(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn,ttsk);
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
            updatenc(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn,ttsk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            deletenc(mavdv);
        }
    }
}
