using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PomzaExport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = ATA-PC\\AAA;Initial Catalog = Pomza_Export_Sart; Integrated Security = True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void hesapbutton_Click(object sender, EventArgs e)
        {
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand bul = new SqlCommand("Select PerNo, Dogum_Tarihi, Is_Basi, Kullanilan_Yıllık_izin from Personel_Bilgileri where PerAd=@PerAd and PerSoyad=@PerSoyad", baglanti);
            bul.Parameters.AddWithValue("@PerAd", txtad.Text);
            bul.Parameters.AddWithValue("@PerSoyad", txtsoyad.Text);

            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                txtperno.Text = dr[0].ToString();
                datdtar.Text = dr[1].ToString();
                datisbasi.Text = dr[2].ToString();

                if (dr[3] == DBNull.Value) { txtkulizin.Text = "0"; }
                else { txtkulizin.Text = dr[3].ToString(); }
            }
            baglanti.Close();



            int izin;

            DateTime dta = Convert.ToDateTime(datdtar.Text);
            DateTime isbas = Convert.ToDateTime(datisbasi.Text);

            int yas = DateTime.Today.Year - dta.Year;
            if (DateTime.Today.DayOfYear < dta.DayOfYear) { yas = yas - 1; }
            int yil = DateTime.Today.Year - isbas.Year;
            if (DateTime.Today.DayOfYear < isbas.DayOfYear) { yil = yil - 1; }

            if (yil >= 16) { izin = 270 + (yil * 26); }
            else if (yas >= 50 && yil < 16) { izin = yil * 20; }
            else if (yil >= 6 && yil < 16) { izin = 70 + ((yil - 5) * 20); }
            else { izin = yil * 14; }

            txthakizin.Text = Convert.ToString(izin);

            int kul = Convert.ToInt16(txtkulizin.Text);
            int kaiz = izin - kul;

            txtkalizin.Text = Convert.ToString(kaiz);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.listeleTableAdapter.Fill(this.pomza_Export_SartDataSet1.Listele);

        }

        private void txthakizin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkulizin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkalizin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonduzelt_Click(object sender, EventArgs e)
        {
            DialogResult sec=
            MessageBox.Show("Kullanılan İzinler Veri Tabanında Değiştirilecek","Dikkat",MessageBoxButtons.OKCancel);

            if (sec == DialogResult.OK)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Personel_Bilgileri set Kullanilan_Yıllık_izin=@Kulizin where PerNo=@PerNo", baglanti);

                komut.Parameters.AddWithValue("@PerNo", txtperno.Text);
                komut.Parameters.AddWithValue("@Kulizin", txtkulizin.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();

                int izin;

                DateTime dta = Convert.ToDateTime(datdtar.Text);
                DateTime isbas = Convert.ToDateTime(datisbasi.Text);

                int yas = DateTime.Today.Year - dta.Year;
                if (DateTime.Today.DayOfYear < dta.DayOfYear) { yas = yas - 1; }
                int yil = DateTime.Today.Year - isbas.Year;
                if (DateTime.Today.DayOfYear < isbas.DayOfYear) { yil = yil - 1; }

                if (yil >= 16) { izin = 270 + (yil * 26); }
                else if (yas >= 50 && yil < 16) { izin = yil * 20; }
                else if (yil >= 6 && yil < 16) { izin = 70 + ((yil - 5) * 20); }
                else { izin = yil * 14; }

                txthakizin.Text = Convert.ToString(izin);

                int kul = Convert.ToInt16(txtkulizin.Text);
                int kaiz = izin - kul;

                txtkalizin.Text = Convert.ToString(kaiz);
            }
            else {
                baglanti.Open();
                SqlCommand bul = new SqlCommand("Select Kullanilan_Yıllık_izin from Personel_Bilgileri where PerAd=@PerAd and PerSoyad=@PerSoyad", baglanti);
                bul.Parameters.AddWithValue("@PerAd", txtad.Text);
                bul.Parameters.AddWithValue("@PerSoyad", txtsoyad.Text);

                SqlDataReader dr = bul.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0] == DBNull.Value) { txtkulizin.Text = "0"; }
                    else { txtkulizin.Text = dr[0].ToString(); }
                }
                baglanti.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtperno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();


            baglanti.Open();
            SqlCommand bul = new SqlCommand("Select Dogum_Tarihi, Is_Basi, Kullanilan_Yıllık_izin from Personel_Bilgileri where PerAd=@PerAd and PerSoyad=@PerSoyad and PerNo=@PerNo", baglanti);
            bul.Parameters.AddWithValue("@PerNo", txtperno.Text);
            bul.Parameters.AddWithValue("@PerAd", txtad.Text);
            bul.Parameters.AddWithValue("@PerSoyad", txtsoyad.Text);

            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                datdtar.Text = dr[0].ToString();
                datisbasi.Text = dr[1].ToString();

                if (dr[2] == DBNull.Value) { txtkulizin.Text = "0"; }
                else { txtkulizin.Text = dr[2].ToString(); }
            }
            baglanti.Close();



            int izin;

            DateTime dta = Convert.ToDateTime(datdtar.Text);
            DateTime isbas = Convert.ToDateTime(datisbasi.Text);

            int yas = DateTime.Today.Year - dta.Year;
            if (DateTime.Today.DayOfYear < dta.DayOfYear) { yas = yas - 1; }
            int yil = DateTime.Today.Year - isbas.Year;
            if (DateTime.Today.DayOfYear < isbas.DayOfYear) { yil = yil - 1; }

            if (yil >= 16) { izin = 270 + (yil * 26); }
            else if (yas >= 50 && yil < 16) { izin = yil * 20; }
            else if (yil >= 6 && yil < 16) { izin = 70 + ((yil - 5) * 20); }
            else { izin = yil * 14; }

            txthakizin.Text = Convert.ToString(izin);

            int kul = Convert.ToInt16(txtkulizin.Text);
            int kaiz = izin - kul;

            txtkalizin.Text = Convert.ToString(kaiz);
        }
    }
}
