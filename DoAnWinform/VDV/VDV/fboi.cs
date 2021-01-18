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
    public partial class fboi : Form
    {

        BindingSource listb = new BindingSource();
        public fboi()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {

            dtgvboi.DataSource = listb;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmavdv.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Mã VDV"));
            txttenvdv.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Tên VDV"));
            txtgioitinh.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Giới tính"));
            txtcannang.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Cân nặng(kg)"));
            txtchieucao.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Chiều cao(cm)"));
            txttttn100m.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "TTTN 100m(s)"));
            txttttn200m.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "TTTN 200m(s)"));
            txttttn500m.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "TTTN 500m(s)"));
            txtttsk.DataBindings.Add(new Binding("Text", dtgvboi.DataSource, "Tình trạng"));





        }
        void loadctbd()
        {
            listb.DataSource = VDVDAO.Instance.GetB();
        }
        void insertb(string mavdv,string tenvdv,string gioitinh,int cannang,int chieucao,int tttn100m,int tttn200m,int tttn500m,string ttsk)
        {
            if(VDVDAO.Instance.insertb(mavdv,tenvdv,gioitinh,cannang,chieucao,tttn100m,tttn200m,tttn500m,ttsk))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadctbd();
        }
        void updateb(string mavdv, string tenvdv,string gioitinh ,int cannang, int chieucao, int tttn100m, int tttn200m, int tttn500m,string ttsk)
        {
            if (VDVDAO.Instance.updateb(mavdv,tenvdv,gioitinh,cannang,chieucao,tttn100m,tttn200m,tttn500m,ttsk))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  thất bại");
            }
            loadctbd();
        }
        void deleteb(string mavdv)
        {
            if(VDVDAO.Instance.deleteb(mavdv))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  thất bại");
            }
            loadctbd();
        }
           

        private void button1_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            string tenvdv = txttenvdv.Text;
            string gioitinh = txtgioitinh.Text;
            int cannang = Convert.ToInt32(txtcannang.Text);
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int tttn100m = Convert.ToInt32(txttttn100m.Text);
            int tttn200m = Convert.ToInt32(txttttn200m.Text);
            int tttn500m = Convert.ToInt32(txttttn500m.Text);
            string ttsk = txtttsk.Text;
            insertb(mavdv, tenvdv,gioitinh, cannang, chieucao, tttn100m, tttn200m, tttn500m,ttsk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            string tenvdv = txttenvdv.Text;
            string gioitinh = txtgioitinh.Text;
            int cannang = Convert.ToInt32(txtcannang.Text);
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int tttn100m = Convert.ToInt32(txttttn100m.Text);
            int tttn200m = Convert.ToInt32(txttttn200m.Text);
            int tttn500m = Convert.ToInt32(txttttn500m.Text);
            string ttsk = txtttsk.Text;
            updateb(mavdv, tenvdv,gioitinh, cannang, chieucao, tttn100m, tttn200m, tttn500m,ttsk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mavdv = txtmavdv.Text;
            deleteb(mavdv);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
