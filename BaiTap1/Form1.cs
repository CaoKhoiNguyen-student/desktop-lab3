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


            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.MultiSelect = true;

            ContextMenuStrip ctxGrid = new ContextMenuStrip();
            ctxGrid.Items.Add("Xóa sinh viên đã chọn", null, CtxXoaSinhVien_Click);
            dgvDanhSach.ContextMenuStrip = ctxGrid;
        }


        private void CtxThemMon_Click(object sender, EventArgs e)
        {
            string monMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học mới:", "Thêm môn học", "");
            if (!string.IsNullOrWhiteSpace(monMoi) && !clbMonHoc.Items.Contains(monMoi))
            {
                clbMonHoc.Items.Add(monMoi, true);
            }
        }

        private void CtxXoaMon_Click(object sender, EventArgs e)
        {
            if (clbMonHoc.SelectedIndex != -1)
            {
                clbMonHoc.Items.RemoveAt(clbMonHoc.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 môn trong danh sách để xóa!", "Thông báo");
            }
        }


        private void CtxXoaSinhVien_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sinh viên để xóa!", "Thông báo");
                return;
            }

            var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dgvDanhSach.SelectedRows.Count} sinh viên đã chọn?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                List<string> listMSSV = new List<string>();
                foreach (DataGridViewRow row in dgvDanhSach.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                        listMSSV.Add(row.Cells[0].Value.ToString());
                }

                studentManager.DeleteMultiple(listMSSV);
                HienThiDanhSachGrid(studentManager.ListStudents);
                MessageBox.Show("Đã xóa thành công!", "Thông báo");
            }
        }





        private void HienThiDanhSachGrid(List<Student> list)
        {
            dgvDanhSach.Rows.Clear();

            foreach (var s in list)
            {
                dgvDanhSach.Rows.Add(
                    s.MSSV,
                    s.HoTenLot,
                    s.Ten,
                    s.NgaySinh.ToString("dd/MM/yyyy"),
                    s.Lop,
                    s.CMND,
                    s.SoDienThoai,
                    s.DiaChi
                );
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDanhSach.Rows.Count - 1) return;

            string mssv = dgvDanhSach.Rows[e.RowIndex].Cells[0].Value?.ToString();
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
    }
}
