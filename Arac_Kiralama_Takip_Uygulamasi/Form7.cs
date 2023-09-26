using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Arac_Kiralama_Takip_Uygulamasi
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source= vt.mdb");
        private void Form6_Load(object sender, EventArgs e)
        {
            TextBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand VeriKaydet = new OleDbCommand("insert into kullanici_bilgi(kullanici_adi,sifre) values(@id,@sifre)", con);
            VeriKaydet.Parameters.AddWithValue("@id", TextBox1.Text);
            VeriKaydet.Parameters.AddWithValue("@sifre", TextBox2.Text);
            VeriKaydet.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kullanıcı başarıyla eklendi..");
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand VeriSil = new OleDbCommand("Delete from kullanici_bilgi where kullanici_adi=@id", con);
            VeriSil.Parameters.AddWithValue("@id", TextBox1.Text);
            VeriSil.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kullanıcı başarıyla silindi..");
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form6_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                TextBox2.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                TextBox2.PasswordChar = '*';
            }
        }
    }
}
