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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.Oledb.12.0; Data Source = vt.mdb");
        private void Button7_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }
        void doldur()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM arac_bilgi", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }
        void dgvrenk()
        {
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToString(DataGridView1.Rows[i].Cells[8].Value) == "Boşta")
                {
                    renk.BackColor = Color.GreenYellow;
                }
                else if (Convert.ToString(DataGridView1.Rows[i].Cells[8].Value) == "Kirada")
                {
                    renk.BackColor = Color.OrangeRed;
                }
                else
                {
                    renk.BackColor = Color.White;
                }
                DataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }
         private void Form4_Load(object sender, EventArgs e)
        {
            doldur();
            dgvrenk();
            DataGridView1.ClearSelection();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
           
                con.Open();
                string guncelle = "update arac_bilgi set marka=@marka,tip=@tip,model=@model,renk=@renk,gunluk=@gunluk,haftalik=@haftalik,aylik=@aylik,durum=@durum where plaka=@plaka";
                // arac tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
                OleDbCommand komut = new OleDbCommand(guncelle, con);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir OleDbCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@marka", TextBox2.Text);
                komut.Parameters.AddWithValue("@tip", TextBox3.Text);
                komut.Parameters.AddWithValue("@model", TextBox4.Text);
                komut.Parameters.AddWithValue("@renk", TextBox5.Text);
                komut.Parameters.AddWithValue("@gunluk", TextBox6.Text);
                komut.Parameters.AddWithValue("@haftalik", TextBox7.Text);
                komut.Parameters.AddWithValue("@aylik", TextBox8.Text);
                komut.Parameters.AddWithValue("@durum", TextBox9.Text);
                komut.Parameters.AddWithValue("@plaka", TextBox1.Text);
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                con.Close();
                MessageBox.Show("Araç Bilgileri Güncellendi.");
                doldur();
                dgvrenk();
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
                DataGridView1.ClearSelection();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
                OleDbCommand sil = new OleDbCommand();
                con.Open();
                sil.Connection = con;
                string sql = "DELETE from arac_bilgi WHERE plaka='" + DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                sil.CommandText = sql;
                sil.ExecuteNonQuery();
                MessageBox.Show("Araç başarıyla silinmiştir.");
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
                con.Close();
                doldur();
                dgvrenk();
                DataGridView1.ClearSelection();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != " ")
            {
                OleDbCommand kaydet = new OleDbCommand();
                con.Open();
                kaydet.Connection = con;
                string sql = "Insert into arac_bilgi (plaka,marka,tip,model,renk,gunluk,haftalik,aylik,durum) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" +TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "')";
                kaydet.CommandText = sql;
                kaydet.ExecuteNonQuery();
                con.Close();
                doldur();
                MessageBox.Show("Araç kayıt işlemi başarıyla tamamlanmıştır!");
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
            }
            else
            {
                MessageBox.Show("Plaka alanını boş bırakmayınız !");
            }
            dgvrenk();
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox1.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString(); // datagridview1'deki seçili satırdaki 0. hücreyi form3'ün textbox1'e yaz
            TextBox2.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();  // datagridview1'deki seçili satırdaki 1.hücreyi form3'ün textbox2'ye yaz
            TextBox3.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();  //datagridview1'deki seçili satırdaki 2.hücreyi form3'ün textbox3'e yaz
            TextBox4.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            TextBox5.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();  // datagridview1'deki seçili satırdaki 1.hücreyi form3'ün textbox2'ye yaz
            TextBox6.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();  // datagridview1'deki seçili satırdaki 2.hücreyi form3'ün textbox3'e yaz
            TextBox7.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            TextBox8.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            TextBox9.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
                con.Open();
                string sorgu = "Select * from arac_bilgi where plaka Like '%" + textBox10.Text + "%'";
                OleDbDataAdapter da = new OleDbDataAdapter(sorgu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataGridView1.DataSource = ds.Tables[0];
                con.Close();
                dgvrenk();
                DataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = " ";
            TextBox2.Text = " ";
            TextBox3.Text = " ";
            TextBox4.Text = " ";
            TextBox5.Text = " ";
            TextBox6.Text = " ";
            TextBox7.Text = " ";
            TextBox8.Text = " ";
            TextBox9.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
