using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Takip_Uygulamasi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void MüsteriTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 gecis = new Form4();
            gecis.Show();
            this.Hide();
        }

        private void AraçTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 gecis = new Form5();
            gecis.Show();
            this.Hide();
        }

        private void sözleşmeTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 gecis = new Form6();
            gecis.Show();
            this.Hide();
        }

        private void kULLANICIEKLESİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 gecis = new Form7();
            gecis.Show();
            this.Hide();
        }
        private void kullanıcılarıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 gecis = new Form8();
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
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        
    }
}
