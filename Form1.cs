using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {//thêm tt
            if (check() == true)
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtMaHang.Text;
                item.SubItems.Add(txtTenHang.Text);
                item.SubItems.Add(txtSL.Text);
                lsvBanHang.Items.Add(item);
            }
            else 
            {
                MessageBox.Show("Nhập thiếu dữ liệu hoặc trùng mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            
        }
        public bool check()
        {
            if (txtSL.Text.Trim() == "" ||
                txtMaHang.Text.Trim() == "" ||
                txtTenHang.Text.Trim() == "")
                return false;
            foreach (ListViewItem x in lsvBanHang.Items)
                if (string.Compare(x.Text, txtMaHang.Text, true) == 0)
                    return false;
   
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (lsvBanHang.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("Bạn có muốn sửa ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = lsvBanHang.SelectedItems[0].Index;
                    if (i >= 0)
                    {
                       // if(check() == true)
                        // {
                        lsvBanHang.Items[i].Text = txtMaHang.Text;
                        //  }
                        // else
                        // {
                        //     MessageBox.Show("Mã bị trùng !", "Thông báo",MessageBoxButtons.OKCancel ,MessageBoxIcon.Warning);
                        //  }
                        lsvBanHang.Items[i].SubItems[1].Text = txtTenHang.Text;
                        lsvBanHang.Items[i].SubItems[2].Text = txtSL.Text;
                    }
                }
                
            }
        }

        private void lsvBanHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvBanHang.SelectedItems.Count > 0)
            {
                int i = lsvBanHang.SelectedItems[0].Index;
                if (i >= 0)
                {
                    txtMaHang.Text = lsvBanHang.Items[i].Text;
                    txtTenHang.Text = lsvBanHang.Items[i].SubItems[1].Text;
                    txtSL.Text = lsvBanHang.Items[i].SubItems[2].Text;
                }
            }
            
            
        }
        public int Tong()
        {
            int sum = 0;
            foreach (ListViewItem x in lsvBanHang.Items)
            {
                sum += int.Parse(x.SubItems[2].Text);
            }
            return sum;

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Tổng số lượng: {Tong().ToString()}");
            if(lsvBanHang.SelectedItems.Count > 0)
            {
                int i = lsvBanHang.SelectedIndices[0];
                if (MessageBox.Show("Xác nhận xóa ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lsvBanHang.Items.RemoveAt(i);
                }
                
            }
        }
    }
}
