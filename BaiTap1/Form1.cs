using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BaiTap1
{
    public partial class Form1 : Form
    {
        private StudentManager studentManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboLop.SelectedIndex = 0;
            try
            {
                
                studentManager = new StudentManager("students.txt");

                
                HienThiDanhSachGrid(studentManager.ListStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            ContextMenuStrip ctxMonHoc = new ContextMenuStrip();
            ctxMonHoc.Items.Add("Thêm môn mới", null, CtxThemMon_Click);
            ctxMonHoc.Items.Add("Xóa môn đã chọn", null, CtxXoaMon_Click);
            clbMonHoc.ContextMenuStrip = ctxMonHoc;


            lvDanhSach.FullRowSelect = true;
            lvDanhSach.MultiSelect = true;

            ContextMenuStrip ctxGrid = new ContextMenuStrip();
            ctxGrid.Items.Add("Xóa sinh viên đã chọn", null, CtxXoaSinhVien_Click);
            lvDanhSach.ContextMenuStrip = ctxGrid;
        }


        private void CtxThemMon_Click(object sender, EventArgs e)
        {
            string monMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học mới:", "Thêm môn học", "");
            while (!string.IsNullOrWhiteSpace(monMoi))
            {
                if (clbMonHoc.Items.Contains(monMoi))
                {
                    MessageBox.Show("Thong bao", $"mon hoc {monMoi}  da on tai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    monMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học mới:", "Thêm môn học", "");
                }
                else
                {
                    clbMonHoc.Items.Add(monMoi, true);
                    break;
                }
            }
        }

        private void CtxXoaMon_Click(object sender, EventArgs e)
        {
            if (clbMonHoc.SelectedIndex != -1)
            {
                // 1. Lấy tên môn học đang được chọn
                string tenMon = clbMonHoc.SelectedItem.ToString();

                // 2. Hỏi xác nhận người dùng có muốn xóa không
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa '{tenMon}' đã chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // 3. Nếu chọn Yes thì mới tiến hành xóa
                if (result == DialogResult.Yes)
                {
                    clbMonHoc.Items.RemoveAt(clbMonHoc.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 môn trong danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void CtxXoaSinhVien_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sinh viên để xóa!", "Thông báo");
                return;
            }

            var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {lvDanhSach.SelectedItems.Count} sinh viên đã chọn?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                List<string> listMSSV = new List<string>();
                foreach (ListViewItem item in lvDanhSach.SelectedItems)
                {
                    if (!string.IsNullOrEmpty(item.Text))
                        listMSSV.Add(item.Text);
                }

                studentManager.DeleteMultiple(listMSSV);
                HienThiDanhSachGrid(studentManager.ListStudents);
                MessageBox.Show("Đã xóa thành công!", "Thông báo");
            }
        }





        private void HienThiDanhSachGrid(List<Student> list)
        {
            lvDanhSach.Items.Clear();

            foreach (var s in list)
            {
                ListViewItem item = new ListViewItem(s.MSSV);
                item.SubItems.Add(s.HoTenLot);
                item.SubItems.Add(s.Ten);
                item.SubItems.Add(s.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(s.Lop);
                item.SubItems.Add(s.CMND);
                item.SubItems.Add(s.SoDienThoai);
                item.SubItems.Add(s.DiaChi);

                lvDanhSach.Items.Add(item);
            }
        }

        private void lvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0) return;

            ListViewItem item = lvDanhSach.SelectedItems[0];
            string mssv = item.Text;
            var student = studentManager.ListStudents.FirstOrDefault(s => s.MSSV == mssv);

            if (student != null)
            {
                txtMSSV.Text = student.MSSV;
                txtHoTenLot.Text = student.HoTenLot;
                txtTen.Text = student.Ten;
                dtpNgaySinh.Value = student.NgaySinh;
                rdoNam.Checked = student.GioiTinh == "Nam";
                rdoNu.Checked = student.GioiTinh == "Nữ";
                cboLop.Text = student.Lop;
                txtCMND.Text = student.CMND;
                txtSDT.Text = student.SoDienThoai;
                txtDiaChi.Text = student.DiaChi;

                // Uncheck toàn bộ môn học rồi check lại các môn sinh viên đã đăng ký
                for (int i = 0; i < clbMonHoc.Items.Count; i++)
                {
                    string mon = clbMonHoc.Items[i].ToString();
                    clbMonHoc.SetItemChecked(i, student.DanhSachMonHoc.Contains(mon));
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraRong()) return;

            Student s = LayDuyLieuTuForm();
            if (studentManager.AddOrUpdate(s, out string msg))
            {
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachGrid(studentManager.ListStudents);
            }
            else
            {
                MessageBox.Show(msg, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool KiemTraRong()
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTenLot.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(cboLop.Text) ||
                string.IsNullOrWhiteSpace(txtCMND.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                (!rdoNam.Checked && !rdoNu.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả các trường thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Student LayDuyLieuTuForm()
        {
            List<string> dsMon = clbMonHoc.CheckedItems.Cast<string>().ToList();

            return new Student(
                txtMSSV.Text.Trim(),
                txtHoTenLot.Text.Trim(),
                txtTen.Text.Trim(),
                dtpNgaySinh.Value,
                rdoNam.Checked ? "Nam" : "Nữ",
                cboLop.Text.Trim(),
                txtCMND.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                dsMon
            );
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            btnThemMoi_Click(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string mssv = txtMSSV.Text.Trim();
            string ten = txtTen.Text.Trim();
            string lop = cboLop.Text.Trim();

            var result = studentManager.Search(mssv, ten, lop);
            HienThiDanhSachGrid(result);

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào phù hợp!", "Kết quả tìm kiếm");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;  
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Reload();
            HienThiDanhSachGrid(studentManager.ListStudents);
        }

        private void Reload()
        {
            // 1. Xóa trắng các TextBox (dùng .Clear() hoặc .Text = "")
            txtMSSV.Clear();
            txtHoTenLot.Clear();
            txtTen.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            // 2. Reset các RadioButton, DateTimePicker và ComboBox
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            cboLop.SelectedIndex = -1; // Bỏ chọn lớp

            // 3. Bỏ tích chọn tất cả các môn học trong CheckedListBox
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }

            // 4. Bỏ chọn dòng/ô đang được chọn trên ListView
            lvDanhSach.SelectedIndices.Clear();

            // 5. Đưa con trỏ chuột về lại ô MSSV
            txtMSSV.Focus();
        }
    }
}
