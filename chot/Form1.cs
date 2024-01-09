using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DTO;
using OfficeOpenXml;
using System.Data.SqlClient;

namespace chot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        lop_BUS lop = new lop_BUS();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lop.Load_BUS();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            phieuthu ob = new phieuthu(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            lop.Insert_Bus(ob);
            Form1_Load(sender, e);
            textBox1.Clear(); textBox2.Clear();
            textBox3.Clear(); textBox4.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            phieuthu ob = new phieuthu(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            lop.Update_Bus(ob);
            Form1_Load(sender, e);
            textBox1.Clear(); textBox2.Clear();
            textBox3.Clear(); textBox4.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            lop.Delete_Bus(textBox1.Text);
            Form1_Load(sender, e);
            textBox1.Clear(); textBox2.Clear();
            textBox3.Clear(); textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
        
            dataGridView1.DataSource = dt;


            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel | *.xlsx | Excel 2012 | *.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn không hợp lệ!");
                return;
            }
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "Trần Thị Thu Hường.";
                p.Workbook.Properties.Title = "Báo cáo thống kê.";
                object value = p.Workbook.Worksheets.Add("Danh_sach_lop");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Danh_sach_lop_" + textBox2.Text;
                ws.Cells.Style.Font.Size = 11;
                ws.Cells.Style.Font.Name = "Calibri";
                string[] arrColumnHeader = { "Ma hang ",
                                        "Ten hang ",
                                        "Don vi tinh  ",
                                          "So luong ban    ",
                                            };
                var countColHeader = arrColumnHeader.Count();
                ws.Cells[1, 1].Value = "Thống kê thông tin";
                ws.Cells[1, 1, 1, countColHeader].Merge = true;
                ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                int colIndex = 1;
                int rowIndex = 2;
                foreach (var item in arrColumnHeader)
                {
                    var cell = ws.Cells[rowIndex, colIndex];
                    cell.Value = item;
                    colIndex++;
                }
                List<phieuthu> list = new List<phieuthu>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    phieuthu ob = new phieuthu();
                    ob.sopt = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    ob.ngaythu = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    ob.makh = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    ob.sotien = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    list.Add(ob);
                }
                foreach (var item in list)
                {
                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.sopt;
                    ws.Cells[rowIndex, colIndex++].Value = item.ngaythu;
                    ws.Cells[rowIndex, colIndex++].Value = item.makh;
                    ws.Cells[rowIndex, colIndex++].Value = item.sotien;

                }
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);

            }
            MessageBox.Show("Xuất file Excel thành công!");
        }

    }
}

