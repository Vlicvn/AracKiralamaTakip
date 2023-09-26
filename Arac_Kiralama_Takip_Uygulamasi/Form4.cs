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
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.Oledb.12.0; Data Source = vt.mdb");
        void doldur()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM musteri_bilgileri", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }
            
        private void Form3_Load(object sender, EventArgs e)
        {
            doldur();
            DataGridView1.ClearSelection();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
                con.Open();
                OleDbCommand guncelle = new OleDbCommand();
                guncelle.Connection = con;
                string sql = "UPDATE musteri_bilgileri set ad='" + TextBox2.Text + "',soyad='" + TextBox3.Text + "',cinsiyet='" + ComboBox1.Text + "',dogum_tarihi='" + DateTimePicker1.Text + "',dogum_yeri='" + TextBox4.Text + "',telefon='" + TextBox5.Text + "',ceptel='" + TextBox6.Text + "',email='" + TextBox7.Text + "',adres='" + TextBox8.Text + "',ehliyet_no='" + TextBox9.Text + "',ehliyet_tarihi='" + DateTimePicker2.Text + "',ehliyet_verilen_yer='" + TextBox10.Text + "' where tcno='" + TextBox1.Text + "'";
                guncelle.CommandText = sql;
                guncelle.ExecuteNonQuery();
                con.Close();
                doldur();
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                ComboBox1.Text = " ";
                DateTimePicker1.Text = string.Empty;
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
                DateTimePicker2.Text = string.Empty;
                TextBox10.Text = " ";
                DataGridView1.ClearSelection();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
                OleDbCommand sil = new OleDbCommand();
                con.Open();
                sil.Connection = con;
                string sql = "DELETE from musteri_bilgileri WHERE tcno='" + DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                sil.CommandText = sql;
                sil.ExecuteNonQuery();
                MessageBox.Show("Müşteri başarıyla silinmiştir.");
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                ComboBox1.Text = " ";
                DateTimePicker1.Text = string.Empty;
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
                DateTimePicker2.Text = string.Empty;
                TextBox10.Text = " ";
                con.Close();
                doldur();
                DataGridView1.ClearSelection();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text!=" ")
            {
                OleDbCommand kaydet = new OleDbCommand();
                con.Open();
                kaydet.Connection = con;
                string sql = "Insert into musteri_bilgileri (tcno,ad,soyad,cinsiyet,dogum_tarihi,dogum_yeri,telefon,ceptel,email,adres,ehliyet_no,ehliyet_tarihi,ehliyet_verilen_yer) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + ComboBox1.Text + "','" + DateTimePicker1.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + DateTimePicker2.Text + "','" + TextBox10.Text + "')";
                kaydet.CommandText = sql;
                kaydet.ExecuteNonQuery();
                con.Close();
                doldur();
                MessageBox.Show("Kayıt işlemi başarıyla tamamlanmıştır!");
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                TextBox3.Text = " ";
                TextBox4.Text = " ";
                ComboBox1.Text = " ";
                DateTimePicker1.Text = string.Empty;
                TextBox5.Text = " ";
                TextBox6.Text = " ";
                TextBox7.Text = " ";
                TextBox8.Text = " ";
                TextBox9.Text = " ";
                DateTimePicker2.Text = string.Empty;
                TextBox10.Text = " ";

            }
            else
            {
                MessageBox.Show("Tc Kimlik No alanını boş bırakmayınız !");
            }
            DataGridView1.ClearSelection();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox1.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString(); // datagridview1'deki seçili satırdaki o. hücreyi form3'ün textbox1'e yaz
            TextBox2.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();  // datagridview1'deki seçili satırdaki 1.hücreyi form3'ün textbox2'ye yaz
            TextBox3.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();  //datagridview1'deki seçili satırdaki 2.hücreyi form3'ün textbox3'e yaz
            ComboBox1.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            DateTimePicker1.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            TextBox4.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            TextBox5.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();  // datagridview1'deki seçili satırdaki 1.hücreyi form3'ün textbox2'ye yaz
            TextBox6.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();  // datagridview1'deki seçili satırdaki 2.hücreyi form3'ün textbox3'e yaz
            TextBox7.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
            TextBox8.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();
            TextBox9.Text = DataGridView1.CurrentRow.Cells[10].Value.ToString();
            DateTimePicker2.Text = DataGridView1.CurrentRow.Cells[11].Value.ToString();
            TextBox10.Text = DataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string sorgu = "Select * from musteri_bilgileri where tcno Like '%" + textBox11.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataGridView1.DataSource = ds.Tables[0];
            con.Close();
            DataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = " ";
            TextBox2.Text = " ";
            TextBox3.Text = " ";
            TextBox4.Text = " ";
            ComboBox1.Text = " ";
            DateTimePicker1.Text=string.Empty;
            TextBox5.Text = " ";
            TextBox6.Text = " ";
            TextBox7.Text = " ";
            TextBox8.Text = " ";
            TextBox9.Text = " ";
            DateTimePicker2.Text = string.Empty;
            TextBox10.Text = " ";

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
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
