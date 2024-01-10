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
            Hang ob = new Hang(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            lop.Insert_Bus(ob);
            Form1_Load(sender, e);
            textBox1.Clear(); textBox2.Clear();
            textBox3.Clear(); textBox4.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hang ob = new Hang(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
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
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

