using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Arac_Kiralama_Takip_Uygulamasi
{
    public partial class Login : Form
    {
        OleDbConnection con;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public Login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string user = kullaniciad.Text;
            string pass = sifre.Text;
            con = new OleDbConnection("Provider = Microsoft.ACE.Oledb.12.0; Data Source = vt.mdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select*from kullanici_bilgi where kullanici_adi='" + user + "'and sifre='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı!","Giriş Yapıldı!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Form3 gecis = new Form3();
                gecis.Show();   
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz! Kullanıcı adınızı ve şifrenizi boş bırakmadığınızdan emin olunuz!",  "Giriş Yapılamadı!", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
            con.Close();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            sifre.PasswordChar = '*';
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
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (move==true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x , MousePosition.Y - mouse_y);
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                sifre.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                sifre.PasswordChar = '*';
            }

        }
    }
}
