using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PhBT
{
    public partial class Form1 : Form
    {
        string id = "0";
        void nn()
        {
            id = "0";
            textBox2.Text = "";
            string cl = "nam";
            if(comboBox1.SelectedIndex==0)
            {
                cl = "nam";
            }
            else if(comboBox1.SelectedIndex==1)
            {
                cl = "phn";
            }
            else if(comboBox1.SelectedIndex==2)
            {
                cl = "job";
            }
            else if(comboBox1.SelectedIndex==3)
            {
                cl = "adres";
            }
            else if(comboBox1.SelectedIndex==4)
            {
                cl = "toz";
            }
            else
            {
                cl = "nam";
            }

            Class1.con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * From phbtb where "+cl+" like '%"+textBox1.Text+"%'",Class1.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "phbtb");
            dataGridView1.DataSource = ds.Tables["phbtb"].DefaultView;
            Class1.con.Close();

            label1.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["job"].Visible = false;
            dataGridView1.Columns["adres"].Visible = false;
            dataGridView1.Columns["toz"].Visible = false;

            dataGridView1.Columns["nam"].HeaderText = "نام";
            dataGridView1.Columns["phn"].HeaderText = "تماس";

            dataGridView1.Columns["nam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            nn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                textBox2.Text =
                    "شغل : " + dataGridView1.CurrentRow.Cells["job"].Value.ToString() + Environment.NewLine +
                    "آدرس : " + dataGridView1.CurrentRow.Cells["adres"].Value.ToString() + Environment.NewLine +
                    "توضیحات : " + dataGridView1.CurrentRow.Cells["toz"].Value.ToString();

                id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.se = "s";
            f2.ShowDialog();
            nn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id != "0")
            {
                if (MessageBox.Show("آیا از حذف این مخاطب مطمئن هسنید؟", "عملیات غیر قابل بازگشت", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string qq = "delete from phbtb where ID ='" + id + "'";
                    OleDbCommand com = new OleDbCommand(qq, Class1.con);

                    Class1.con.Open();
                    com.ExecuteNonQuery();
                    Class1.con.Close();

                    nn();
                }
            }
            else
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id != "0")
            {
                Form2 f2 = new Form2();
                f2.se = "e";

                f2.id = id;
                f2.textBox1.Text = dataGridView1.CurrentRow.Cells["nam"].Value.ToString();
                f2.textBox2.Text = dataGridView1.CurrentRow.Cells["phn"].Value.ToString();
                f2.textBox3.Text = dataGridView1.CurrentRow.Cells["job"].Value.ToString();
                f2.textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
                f2.textBox5.Text = dataGridView1.CurrentRow.Cells["toz"].Value.ToString();

                f2.ShowDialog();

                nn();
            }
            else
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nn();
        }
    }
}
