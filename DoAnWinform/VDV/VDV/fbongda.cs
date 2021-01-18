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
    public partial class fbongda : Form
    {
        BindingSource listBD = new BindingSource();
        public fbongda()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            dtgvbongda.DataSource = listBD;

            addctbdBinding();
            loadctbd();
        }
        void addctbdBinding()
        {
            
            txtmacauthu.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Mã cầu thủ"));
            txttencauthu.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Tên cầu thủ"));
            txtgioitinh.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Giới tính"));
            txtvitri.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Vị trí"));
            txtchieucao.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Chiều cao(cm)"));
            txtcannang.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Cân nặng(kg)"));
            txtttsk.DataBindings.Add(new Binding("Text", dtgvbongda.DataSource, "Tình trạng"));


        }
        void loadctbd()
        {
            listBD.DataSource = VDVDAO.Instance.GetBD();
        }
        void insertbd(string mavdv,string tenvdv,string gioitinh,string vitri,int chieucao,int cannang,string ttsk)
        {
            if(VDVDAO.Instance.insertbd(mavdv,tenvdv,gioitinh,vitri,chieucao,cannang,ttsk))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            loadctbd();
        }
        void updatebd(string mavdv, string tenvdv,string gioitinh, string vitri, int chieucao, int cannang,string ttsk)
        {
            if (VDVDAO.Instance.updatebd(mavdv, tenvdv,gioitinh, vitri, chieucao, cannang,ttsk))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            loadctbd();
        }
        void deletebd(string mavdv)
        {
            if (VDVDAO.Instance.deletebd(mavdv))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            loadctbd();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mavdv = txtmacauthu.Text;
            string tenvdv = txttencauthu.Text;
            string gioitinh = txtgioitinh.Text;
            string vitri = txtvitri.Text;
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int cannang = Convert.ToInt32(txtcannang.Text);
            string ttsk = txtttsk.Text;
            insertbd(mavdv, tenvdv,gioitinh, vitri, chieucao, cannang,ttsk);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mavdv = txtmacauthu.Text;
            string tenvdv = txttencauthu.Text;
            string gioitinh = txtgioitinh.Text;
            string vitri = txtvitri.Text;
            int chieucao = Convert.ToInt32(txtchieucao.Text);
            int cannang = Convert.ToInt32(txtcannang.Text);
            string ttsk = txtttsk.Text;
            updatebd(mavdv, tenvdv,gioitinh, vitri, chieucao, cannang,ttsk);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mavdv = txtmacauthu.Text;
            deletebd(mavdv);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
