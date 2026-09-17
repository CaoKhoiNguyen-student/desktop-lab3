using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BaiTapHD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {
            string Str = "";
            string Path = "../../students.json";
            List<StudentInfo> list = LoadJSON(Path);
            for (int i = 0; i < list.Count; i++)
            {
                StudentInfo Info = list[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}," +
                    " điểm TB: {3}\n", (i + 1), Info.MSSV, Info.Hoten, Info.Diem);
            }
            MessageBox.Show(Str);
        }

        private List<StudentInfo> LoadJSON(string Path)
        {

            List<StudentInfo> list = new List<StudentInfo>();

            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd();

            var array = (JObject)JsonConvert.DeserializeObject(json);
            var students = array["sinhvien"].Children();
            foreach (var item in students)
            {
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem, tongiao);
                list.Add(info);
            }
            return list;
        }
    }
}
