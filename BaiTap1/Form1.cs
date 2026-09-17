using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                // Khởi tạo đối tượng (Tự động đọc file students.txt)
                studentManager = new StudentManager("students.txt");

                // Hiển thị danh sách lên DataGridView
                HienThiDanhSachGrid(studentManager.ListStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 3. Hàm hỗ trợ đẩy dữ liệu từ danh sách lên DataGridView
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
    }
}
