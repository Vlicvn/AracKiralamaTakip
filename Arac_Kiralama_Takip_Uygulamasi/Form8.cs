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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source= vt.mdb");
        void doldur()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kullanici_bilgi", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
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
        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form7_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            doldur();
            dataGridView1.ClearSelection();
        }
    }
}
