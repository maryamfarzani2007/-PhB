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
    public partial class Form2 : Form
    {
        public string se = "s",id="0";
        void submit()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("ابتدا فیلد های زیر را تکمیل کنید");
            }
            else
            {
                if(se=="s")
                {
                    save();
                }
                else
                {
                    edit();
                }
            }
        }
        void save()
        {
            id = Guid.NewGuid().ToString();

            string qq = "insert into phbtb (id,nam,phn,job,adres,toz) values ('"+id+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')";
            OleDbCommand com = new OleDbCommand(qq,Class1.con);

            Class1.con.Open();
            com.ExecuteNonQuery();
            Class1.con.Close();

            MessageBox.Show("ذخیره سازی با موفقیت انجام شد");
            pak();
            
        }
        void edit()
        {
            string qq = "update phbtb set nam=@nam,phn=@phn,job=@job,adres=@adres,toz=@toz where ID='"+id+"'";
            using (OleDbCommand com = new OleDbCommand(qq, Class1.con))
            {
                com.CommandType = CommandType.Text;

                com.Parameters.AddWithValue("nam", textBox1.Text);
                com.Parameters.AddWithValue("phn", textBox2.Text);
                com.Parameters.AddWithValue("job", textBox3.Text);
                com.Parameters.AddWithValue("adres", textBox4.Text);
                com.Parameters.AddWithValue("toz", textBox5.Text);

                Class1.con.Open();
                com.ExecuteNonQuery();
                Class1.con.Close();
            }

            MessageBox.Show("ویرایش با موفقیت انجام شد");
        }
        void pak()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            textBox1.Focus();
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            submit();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
