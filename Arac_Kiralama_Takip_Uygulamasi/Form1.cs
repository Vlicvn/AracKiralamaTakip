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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                Opacity += 0.020;
            }
            if (Opacity == 1.0)
            {
                islem = true;
            }
            if (islem)
            {
                Opacity -= 0.020;
            }
            if (Opacity == 0)
            {
                Login gecis = new Login();
                gecis.Show();
                this.Hide();
                timer1.Enabled = false;
            }
        }
    }
}
