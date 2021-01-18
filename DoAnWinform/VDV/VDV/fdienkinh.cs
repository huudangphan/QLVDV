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
    public partial class fdienkinh : Form
    {
        BindingSource listdk = new BindingSource();
        public fdienkinh()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            
            //dtgvdienkinh.DataSource = listdk;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmacauthu.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Mã VDV"));
            txttencauthu.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Tên VDV"));   
            txtgioitinh.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Giới tính"));
            txtchieucao.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Chiều cao(cm)"));
            txtcannang.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Cân nặng(kg)"));
            txt100m.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "TTTN 100m(s)"));
            txt200m.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "TTTN 200m(s)"));
            txt500m.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "TTTN 500m(s)"));
            txt1000m.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "TTTN 1000m(s)"));
            txtttsk.DataBindings.Add(new Binding("Text", dtgvdienkinh.DataSource, "Tình Trạng"));


        }
        void loadctbd()
        {
            listdk.DataSource = VDVDAO.Instance.GetDK();
        }
        void insertdk(string mavdv, string tenvdv,string gioitinh,  int chieucao, int cannang, int tttn100m, int tttn200m, int tttn500m,int tttn1000m,string ttsk)
        {
            if (VDVDAO.Instance.insertdk(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn100m, tttn200m, tttn500m, tttn1000m,ttsk))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadctbd();
        }
        void updatedk(string mavdv, string tenvdv,string gioitinh,  int chieucao, int cannang, int tttn100m, int tttn200m, int tttn500m,int tttn1000m,string ttsk)
        {
            if (VDVDAO.Instance.updatedk(mavdv, tenvdv, gioitinh, chieucao, cannang, tttn100m, tttn200m, tttn500m,tttn1000m,ttsk))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật  thất bại");
            }
            loadctbd();
        }
        void deletedk(string mavdv)
        {
            if (VDVDAO.Instance.deletedk(mavdv))
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
            string mavdv = txtmacauthu.Text;
            string tenvdv = txttencauthu.Text;
            string gioitinh = txtgioitinh.Text;
            int cannang = Convert.ToInt32(txtcannang.Text);
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int tttn100m = Convert.ToInt32(txt100m.Text);
            int tttn200m = Convert.ToInt32(txt200m.Text);
            int tttn500m = Convert.ToInt32(txt500m.Text);
            int tttn1000m = Convert.ToInt32(txt1000m.Text);
            string ttsk = txtttsk.Text;
            insertdk(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn100m, tttn200m, tttn500m, tttn1000m,ttsk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mavdv = txtmacauthu.Text;
            string tenvdv = txttencauthu.Text;
            string gioitinh = txtgioitinh.Text;
            int cannang = Convert.ToInt32(txtcannang.Text);
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int tttn100m = Convert.ToInt32(txt100m.Text);
            int tttn200m = Convert.ToInt32(txt200m.Text);
            int tttn500m = Convert.ToInt32(txt500m.Text);
            int tttn1000m = Convert.ToInt32(txt1000m.Text);
            string ttsk = txtttsk.Text;
            updatedk(mavdv, tenvdv,gioitinh, chieucao, cannang, tttn100m, tttn200m, tttn500m, tttn1000m,ttsk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mavdv = txtmacauthu.Text;
            deletedk(mavdv);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
