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
using System.Drawing.Printing;

namespace Arac_Kiralama_Takip_Uygulamasi
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.Oledb.12.0; Data Source = vt.mdb");
       
        void doldur()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM sozlesme_bilgi", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }
        void combotc()
        {
            ComboBox1.Items.Clear();
            con.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = con;
            kmt.CommandText = "Select tcno from musteri_bilgileri";
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                ComboBox1.Items.Add(oku[0].ToString());
            }

            con.Close();
        }
        void comboPlaka()
        {
            ComboBox3.Items.Clear();
            con.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = con;
            kmt.CommandText = "Select plaka from arac_bilgi Where durum='Boşta'";
            OleDbDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ComboBox3.Items.Add(oku[0].ToString());
            }
            con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           if(TextBox1.Text != "" && TextBox17.Text != "") 
            {
                con.Open();
                OleDbCommand kmt = new OleDbCommand();
                kmt.Connection = con;
                kmt.CommandText = "INSERT INTO sozlesme_bilgi(tcno,ad,soyad,cinsiyet,dogum_tarihi,dogum_yeri,telefon,ceptel,email,adres,ehliyet_no,ehliyet_tarihi,ehliyet_verilen_yer,surucu_ad,kefil_ad,kefil_soyad,kefil_adres,kefil_tel,kefil_cep,plaka,marka,tip,model,renk,gunluk,haftalik,aylik,cikis_zamani,donus_zamani,ek_tutar,toplam,aciklama) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + ComboBox2.Text + "','" + DateTimePicker1.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + DateTimePicker2.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox13.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "','" + TextBox18.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "','" + TextBox22.Text + "','" + TextBox23.Text + "','" + TextBox24.Text + "','" + DateTimePicker3.Text + "','" + DateTimePicker4.Text + "','" + TextBox25.Text + "','" + TextBox26.Text + "','" + TextBox27.Text + "')";
                kmt.ExecuteNonQuery();
                con.Close();

                con.Open();
                OleDbCommand kmt1 = new OleDbCommand();
                kmt1.Connection = con;
                kmt1.CommandText = "UPDATE arac_bilgi SET durum='Kirada' WHERE plaka='" + ComboBox3.Text + "' ";
                kmt1.ExecuteNonQuery();
                con.Close();

                doldur();
                ComboBox3.Text = "";
                comboPlaka();
                MessageBox.Show("Kiralama işlemi tamamlandı ! ");
                ComboBox1.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                ComboBox2.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                ComboBox3.Text = "";
                TextBox17.Text = "";
                TextBox18.Text = "";
                TextBox19.Text = "";
                TextBox20.Text = "";
                TextBox21.Text = "";
                TextBox22.Text = "";
                TextBox23.Text = "";
                TextBox24.Text = "";
                TextBox25.Text = "";
                TextBox26.Text = "";
                TextBox27.Text = "";
            }
            else
            {
                MessageBox.Show("Müşteri ve Araç seçimi yapınız !");
            }
            DataGridView1.ClearSelection();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            doldur();
            combotc();
            comboPlaka();
            DataGridView1.ClearSelection();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            
            if (DataGridView1.CurrentRow.Cells[0].Value.ToString()!="") 
            {
                con.Open();
                OleDbCommand kmt = new OleDbCommand();
                kmt.Connection = con;
                kmt.CommandText = "UPDATE arac_bilgi SET durum='Boşta' WHERE plaka='" + DataGridView1.CurrentRow.Cells[19].Value.ToString() + "'";
                kmt.ExecuteNonQuery();
                con.Close();

                con.Open();
                OleDbCommand kmt1 = new OleDbCommand();
                kmt1.Connection = con;
                kmt1.CommandText = "DELETE from sozlesme_bilgi WHERE plaka='" + DataGridView1.CurrentRow.Cells[19].Value.ToString() + "'";
                kmt1.ExecuteNonQuery();
                con.Close();

                comboPlaka();
                doldur();
                MessageBox.Show("Teslim alma işlemi gerçekleştirildi !");

                ComboBox1.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                ComboBox2.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
                TextBox13.Text = "";
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox16.Text = "";
                ComboBox3.Text = "";
                TextBox17.Text = "";
                TextBox18.Text = "";
                TextBox19.Text = "";
                TextBox20.Text = "";
                TextBox21.Text = "";
                TextBox22.Text = "";
                TextBox23.Text = "";
                TextBox24.Text = "";
                TextBox25.Text = "";
                TextBox26.Text = "";
                TextBox27.Text = "";

            }
            else
            {
                MessageBox.Show("Bir sözleşme seçiniz!!");
            }
            DataGridView1.ClearSelection();
        }
        
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = con;
            kmt.CommandText = "Select * from musteri_bilgileri where tcno='" + ComboBox1.Text + "'";
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                TextBox1.Text = oku[0].ToString();
                TextBox2.Text = oku[1].ToString();
                TextBox3.Text = oku[2].ToString();
                ComboBox2.Text = oku[3].ToString();
                DateTimePicker1.Text = oku[4].ToString();
                TextBox4.Text = oku[5].ToString();
                TextBox5.Text = oku[6].ToString();
                TextBox6.Text = oku[7].ToString();
                TextBox7.Text = oku[8].ToString();
                TextBox8.Text = oku[9].ToString();
                TextBox9.Text = oku[10].ToString();
                DateTimePicker2.Text = oku[11].ToString();
                TextBox10.Text = oku[12].ToString();
            }

            con.Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = con;
            kmt.CommandText = "Select * from arac_bilgi where plaka='" + ComboBox3.Text + "'";
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                TextBox17.Text = oku[0].ToString();
                TextBox18.Text = oku[1].ToString();
                TextBox19.Text = oku[2].ToString();
                TextBox20.Text = oku[3].ToString();
                TextBox21.Text = oku[4].ToString();
                TextBox22.Text = oku[5].ToString();
                TextBox23.Text = oku[6].ToString();
                TextBox24.Text = oku[7].ToString();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form5_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            ComboBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox16.Text = "";
            ComboBox3.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
            TextBox19.Text = "";
            TextBox20.Text = "";
            TextBox21.Text = "";
            TextBox22.Text = "";
            TextBox23.Text = "";
            TextBox24.Text = "";
            TextBox25.Text = "";
            TextBox26.Text = "";
            TextBox27.Text = "";

        }


        private void button9_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string dashline = "-------------------------------------------------------------------------------------------------------------------------------------------";
            Bitmap bitmap = Properties.Resources.ustprint1;
            Image image = new Bitmap(bitmap);
            e.Graphics.DrawImage(image, 25, 25, 750,150);
            e.Graphics.DrawString("Tarih : " + DateTime.Now, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(550, 200));
            e.Graphics.DrawString("TC Kimlik No : "+ DataGridView1.CurrentRow.Cells[0].Value.ToString(), new Font("Arial",11,FontStyle.Regular),Brushes.Black, new Point(40,200));
            e.Graphics.DrawString("Ad : " + DataGridView1.CurrentRow.Cells[1].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 225));
            e.Graphics.DrawString("Soyad : " + DataGridView1.CurrentRow.Cells[2].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 250));
            e.Graphics.DrawString("Cinsiyet : " + DataGridView1.CurrentRow.Cells[3].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 275));
            e.Graphics.DrawString("Doğum Tarihi : " + DataGridView1.CurrentRow.Cells[4].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 300));
            e.Graphics.DrawString("Doğum Yeri : " + DataGridView1.CurrentRow.Cells[5].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 325));
            e.Graphics.DrawString("Telefon : " + DataGridView1.CurrentRow.Cells[6].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 350));
            e.Graphics.DrawString("Cep Telefon : " + DataGridView1.CurrentRow.Cells[7].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 375));
            e.Graphics.DrawString("Email : " + DataGridView1.CurrentRow.Cells[8].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 400));
            e.Graphics.DrawString("Adres : " + DataGridView1.CurrentRow.Cells[9].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 425));
            e.Graphics.DrawString("Ehliyet No : " + DataGridView1.CurrentRow.Cells[10].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 450));
            e.Graphics.DrawString("Ehliyet Tarihi : " + DataGridView1.CurrentRow.Cells[11].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 475));
            e.Graphics.DrawString("Ehliyet Verilen Yer : " + DataGridView1.CurrentRow.Cells[12].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 500));

            e.Graphics.DrawString(dashline, new Font("Arial", 11, FontStyle.Regular), Brushes.SteelBlue, new Point(40, 515));

            e.Graphics.DrawString("Sürücü Ad: " + DataGridView1.CurrentRow.Cells[13].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 530));
            e.Graphics.DrawString("Kefil Ad: " + DataGridView1.CurrentRow.Cells[14].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 555));
            e.Graphics.DrawString("Kefil Soyad: " + DataGridView1.CurrentRow.Cells[15].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 580));
            e.Graphics.DrawString("Kefil Adres: " + DataGridView1.CurrentRow.Cells[16].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 605));
            e.Graphics.DrawString("Kefil Telefon: " + DataGridView1.CurrentRow.Cells[17].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 630));
            e.Graphics.DrawString("Kefil Cep Telefon: " + DataGridView1.CurrentRow.Cells[18].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 655));

            e.Graphics.DrawString(dashline, new Font("Arial", 11, FontStyle.Regular), Brushes.SteelBlue, new Point(40, 670));

            e.Graphics.DrawString("Plaka : " + DataGridView1.CurrentRow.Cells[19].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 685));
            e.Graphics.DrawString("Marka : " + DataGridView1.CurrentRow.Cells[20].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 710));
            e.Graphics.DrawString("Tip : " + DataGridView1.CurrentRow.Cells[21].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 735));
            e.Graphics.DrawString("Model : " + DataGridView1.CurrentRow.Cells[22].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 760));
            e.Graphics.DrawString("Renk : " + DataGridView1.CurrentRow.Cells[23].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 785));

            e.Graphics.DrawString(dashline, new Font("Arial", 11, FontStyle.Regular), Brushes.SteelBlue, new Point(40, 800));

            e.Graphics.DrawString("Günlük : " + DataGridView1.CurrentRow.Cells[24].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 815));
            e.Graphics.DrawString("Haftalık : " + DataGridView1.CurrentRow.Cells[25].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 840));
            e.Graphics.DrawString("Aylık : " + DataGridView1.CurrentRow.Cells[26].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 865));

            e.Graphics.DrawString(dashline, new Font("Arial", 11, FontStyle.Regular), Brushes.SteelBlue, new Point(40, 880));

            e.Graphics.DrawString("Çıkış Zamanı : " + DataGridView1.CurrentRow.Cells[27].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 895));
            e.Graphics.DrawString("Dönüş Zamanı : " + DataGridView1.CurrentRow.Cells[28].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 920));

            e.Graphics.DrawString(dashline, new Font("Arial", 11, FontStyle.Regular), Brushes.SteelBlue, new Point(40, 935));

            e.Graphics.DrawString("Ek Tutar : " + DataGridView1.CurrentRow.Cells[29].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 950));
            e.Graphics.DrawString("Toplam : " + DataGridView1.CurrentRow.Cells[30].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 975));
            e.Graphics.DrawString("Açıklama : " + DataGridView1.CurrentRow.Cells[31].Value.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, 1000));
            e.Graphics.DrawString("Kiracı İmzası  ", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, 1070));
            e.Graphics.DrawString("Temsilci İmzası  ", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(450, 1070));
      

        }

        private void button8_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }
    }
}
