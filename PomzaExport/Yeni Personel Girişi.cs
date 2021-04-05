using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PomzaExport
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = ATA-PC\\SQLPOMZA;Initial Catalog = Pomza_Export_Sart; Integrated Security = True");

        
        private void btnperkaydet_Click(object sender, EventArgs e)
        {
            string name = txtperno.Text + "_" + txtperad.Text + "_" + txtpersoy.Text;
            Directory.CreateDirectory(@"D:\Personel\"+name);



            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel_Bilgileri(PerNo,PerAd,PerSoyad,Cinsiyet,TC,Dogum_Yeri," +
                "Dogum_Tarihi,Baba_Adi,Ana_Adi,Adres,Ilce,Il,Telefon,Medeni_Durum,Cocuk_Sayisi,Es_Durumu,Kan_Grubu,Calisma_Durumu," +
                "Departman,Gorev,Is_Basi,Is_Sonu,Tesis_Sorumlusu,Egitim_Durumu,Mahalle) " +
                "values (@PerNo,@PerAd,@PerSoyad,@Cinsiyet,@TC,@Dogum_Yeri,@Dogum_Tarihi,@Baba_Adi,@Ana_Adi,@Adres,@Ilce,@Il,@Telefon," +
                "@Medeni_Durum,@Cocuk_Sayisi,@Es_Durumu,@Kan_Grubu,@Calisma_Durumu,@Departman,@Gorev,@Is_Basi,@Is_Sonu,@Tesis_Sorumlusu,@Egitim_Durumu,@Mahalle)", baglanti);

            komut.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komut.Parameters.AddWithValue("@PerAd", txtperad.Text);
            komut.Parameters.AddWithValue("@PerSoyad", txtpersoy.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", lblci.Text);
            komut.Parameters.AddWithValue("@TC", txttc.Text);
            komut.Parameters.AddWithValue("@Dogum_Yeri", txtdyer.Text);

            if (datedtar.Text == "")
            { komut.Parameters.AddWithValue("@Dogum_Tarihi", DBNull.Value); }
            else
            { komut.Parameters.AddWithValue("@Dogum_Tarihi", Convert.ToDateTime(datedtar.Text)); }

            komut.Parameters.AddWithValue("@Baba_Adi", txtbaba.Text);
            komut.Parameters.AddWithValue("@Ana_Adi", txtana.Text);
            komut.Parameters.AddWithValue("@Adres", txtadres.Text);
            komut.Parameters.AddWithValue("@Ilce", txtilce.Text);
            komut.Parameters.AddWithValue("@Il", txtil.Text);
            komut.Parameters.AddWithValue("@Telefon", txttlfn.Text);
            komut.Parameters.AddWithValue("@Medeni_Durum", lblm.Text);
            komut.Parameters.AddWithValue("@Cocuk_Sayisi", txtcocuksay.Text);

            if (rbecalisiyor.Checked == false && rbecalismiyor.Checked == false)
            { komut.Parameters.AddWithValue("@Es_Durumu", DBNull.Value); }
            else
            { komut.Parameters.AddWithValue("@Es_Durumu", lbes.Text); }

            komut.Parameters.AddWithValue("@Kan_Grubu", txtkan.Text);
            komut.Parameters.AddWithValue("@Calisma_Durumu", lblca.Text);
            komut.Parameters.AddWithValue("@Departman", cobdep.Text);
            komut.Parameters.AddWithValue("@Gorev", txtgorev.Text);

            if (dateisbasi.Text == "")
            { komut.Parameters.AddWithValue("@Is_Basi", DBNull.Value); }
            else
            { komut.Parameters.AddWithValue("@Is_Basi", Convert.ToDateTime(dateisbasi.Text)); }

            komut.Parameters.AddWithValue("@Tesis_Sorumlusu", cobtessor.Text);
            komut.Parameters.AddWithValue("@Egitim_Durumu", txtegitim.Text);
            komut.Parameters.AddWithValue("@Mahalle", txtmah.Text);

            if (dateissonu.Enabled == false)
            { komut.Parameters.AddWithValue("@Is_Sonu", DBNull.Value); }
            if (dateissonu.Enabled == true)
            { komut.Parameters.AddWithValue("@Is_Sonu", Convert.ToDateTime(dateissonu.Text)); }

            komut.ExecuteNonQuery();

          

            SqlCommand komutm = new SqlCommand("insert into Mesleki_Belge(PerNo,Sabit_Tesis_Opt_Bakim,Cevher_Haz_Zen," +
    "Is_Mak_Bakim,Kaynak,Elektrik,Forklift,Vinc,Mikser,Pompa,Kazici,Yukleyici,Dozer,Ilk_Yardim,Hijyen,AFAD," +
    "Kalorifer,Laborant)" +
    " values(@PerNo,@Sabit_Tesis_Opt_Bakim,@Cevher_Haz_Zen,@Is_Mak_Bakim,@Kaynak,@Elektrik,@Forklift," +
    "@Vinc,@Mikser,@Pompa,@Kazici,@Yukleyici,@Dozer,@Ilk_Yardim,@Hijyen,@AFAD,@Kalorifer,@Laborant)", baglanti);

            komutm.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komutm.Parameters.AddWithValue("@Sabit_Tesis_Opt_Bakim", cbsbttesis.Checked);
            komutm.Parameters.AddWithValue("@Cevher_Haz_Zen", cbcevhaz.Checked);
            komutm.Parameters.AddWithValue("@Is_Mak_Bakim", cbismakbak.Checked);
            komutm.Parameters.AddWithValue("@Kaynak", cbkaynak.Checked);
            komutm.Parameters.AddWithValue("@Elektrik", cbelektrik.Checked);
            komutm.Parameters.AddWithValue("@Forklift", cbforklift.Checked);
            komutm.Parameters.AddWithValue("@Vinc", cbvinc.Checked);
            komutm.Parameters.AddWithValue("@Mikser", cbmikser.Checked);
            komutm.Parameters.AddWithValue("@Pompa", cbpompa.Checked);
            komutm.Parameters.AddWithValue("@Kazici", cbkazici.Checked);
            komutm.Parameters.AddWithValue("@Yukleyici", cbyukleyici.Checked);
            komutm.Parameters.AddWithValue("@Dozer", cbdozer.Checked);
            komutm.Parameters.AddWithValue("@Ilk_Yardim", cbilkyardim.Checked);
            komutm.Parameters.AddWithValue("@Hijyen", cbhijyen.Checked);
            komutm.Parameters.AddWithValue("@AFAD", cbafad.Checked);
            komutm.Parameters.AddWithValue("@Kalorifer", cbkalorifer.Checked);
            komutm.Parameters.AddWithValue("@Laborant", cblab.Checked);
            komutm.ExecuteNonQuery();


            SqlCommand komute = new SqlCommand("Insert into Ehliyet(PerNo,M,A,A1,A2,B,BE,B1,C,CE,C1,C1E,D,DE,D1,D1E,F,G) " +
    "values(@PerNo,@M,@A,@A1,@A2,@B,@BE,@B1,@C,@CE,@C1,@C1E,@D,@DE,@D1,@D1E,@F,@G)", baglanti);

            komute.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komute.Parameters.AddWithValue("@M", cbm.Checked);
            komute.Parameters.AddWithValue("@A", cba.Checked);
            komute.Parameters.AddWithValue("@A1", cba1.Checked);
            komute.Parameters.AddWithValue("@A2", cba2.Checked);
            komute.Parameters.AddWithValue("@B", cbb.Checked);
            komute.Parameters.AddWithValue("@BE", cbbe.Checked);
            komute.Parameters.AddWithValue("@B1", cbb1.Checked);
            komute.Parameters.AddWithValue("@C", cbc.Checked);
            komute.Parameters.AddWithValue("@CE", cbce.Checked);
            komute.Parameters.AddWithValue("@C1", cbc1.Checked);
            komute.Parameters.AddWithValue("@C1E", cbc1e.Checked);
            komute.Parameters.AddWithValue("@D", cbd.Checked);
            komute.Parameters.AddWithValue("@DE", cbde.Checked);
            komute.Parameters.AddWithValue("@D1", cbd1.Checked);
            komute.Parameters.AddWithValue("@D1E", cbd1e.Checked);
            komute.Parameters.AddWithValue("@F", cbf.Checked);
            komute.Parameters.AddWithValue("@G", cbg.Checked);
            komute.ExecuteNonQuery();

            SqlCommand komuts = new SqlCommand("insert into SRC(PerNo,SRC1,SRC2,SRC3,SRC4,Psikoteknik," +
    "Baslangic_Tarihi,Bitis_Tarihi) values(@PerNo,@SRC1,@SRC2,@SRC3,@SRC4,@Psikoteknik," +
    "@Baslangic_Tarihi,@Bitis_Tarihi)", baglanti);

            komuts.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komuts.Parameters.AddWithValue("@SRC1", cbs1.Checked);
            komuts.Parameters.AddWithValue("@SRC2", cbs2.Checked);
            komuts.Parameters.AddWithValue("@SRC3", cbs3.Checked);
            komuts.Parameters.AddWithValue("@SRC4", cbs4.Checked);
            komuts.Parameters.AddWithValue("@Psikoteknik", cbpsi.Checked);
            if (cbpsi.Checked == true)
            {
                komuts.Parameters.AddWithValue("@Baslangic_Tarihi", Convert.ToDateTime(datebastar.Text));
                komuts.Parameters.AddWithValue("@Bitis_Tarihi", Convert.ToDateTime(datebittar.Text));
            }
            else
            {
                komuts.Parameters.AddWithValue("@Baslangic_Tarihi", DBNull.Value);
                komuts.Parameters.AddWithValue("@Bitis_Tarihi", DBNull.Value);
            }
            komuts.ExecuteNonQuery();


            SqlCommand komut2 = new SqlCommand("Insert into Sigorta(PerNo,SigortaKismi,SigortaSicilNo,MeslekKodu,MeslekTanimi)" +
                " values(@PerNo,@SigortaKismi,@SigortaSicilNo,@MeslekKodu,@MeslekTanimi)", baglanti);
            komut2.Parameters.AddWithValue("@PerNo",txtperno.Text);
            komut2.Parameters.AddWithValue("@SigortaKismi", txtsigkismi.Text);
            komut2.Parameters.AddWithValue("@SigortaSicilNo", txtsigsicilno.Text);
            komut2.Parameters.AddWithValue("@MeslekKodu", txtmeslekkod.Text);
            komut2.Parameters.AddWithValue("@MeslekTanimi", txtmeslektanimi.Text);
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void rbbay_CheckedChanged(object sender, EventArgs e)
        {
            lblci.Text = "True";
        }

        private void rbbayan_CheckedChanged(object sender, EventArgs e)
        {
            lblci.Text = "False";
        }


        private void rbcalisiyor_CheckedChanged(object sender, EventArgs e)
        {
            lblca.Text = "True";
            
        }

        private void rbcalismiyor_CheckedChanged(object sender, EventArgs e)
        {
            lblca.Text = "False";
            if (rbcalismiyor.Checked == true)
                { dateissonu.Enabled = true; }
            else { dateissonu.Enabled = false; }
            
        }



        private void rbevli_CheckedChanged(object sender, EventArgs e)
        {
            lblm.Text = "True";
            pes.Enabled = true;
        }

        private void rbekar_CheckedChanged(object sender, EventArgs e)
        {
            lblm.Text = "False";
            pes.Enabled = false;
        }


        private void cobdep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cobdep.Items.Add(cobdep.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cobtessor.Items.Add(cobtessor.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lbes.Text = "True";
        }

        private void rbecalismiyor_CheckedChanged(object sender, EventArgs e)
        {
            lbes.Text = "False";
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand bul = new SqlCommand("Select* from Personel_Bilgileri where PerAd=@PerAd and PerSoyad=@PerSoyad", baglanti);
            bul.Parameters.AddWithValue("@PerAd", bulad.Text);
            bul.Parameters.AddWithValue("@PerSoyad", bulsoyad.Text);

            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                txtperno.Text = dr[0].ToString();
                txtperad.Text = dr[1].ToString();
                txtpersoy.Text = dr[2].ToString();
                lblci.Text = dr[3].ToString();
                if (lblci.Text == "True")
                { rbbay.Checked = true; }
                else { rbbayan.Checked = true; }
                txttc.Text = dr[4].ToString();
                txtdyer.Text = dr[5].ToString();
                datedtar.Text = dr[6].ToString();
                txtbaba.Text = dr[7].ToString();
                txtana.Text = dr[8].ToString();
                txtadres.Text = dr[9].ToString();
                txtilce.Text = dr[11].ToString();
                txtil.Text = dr[12].ToString();
                txttlfn.Text = dr[13].ToString();
                lblm.Text = dr[14].ToString();
                if(lblm.Text=="True")
                { rbevli.Checked = true; }
                else { rbekar.Checked = true; }
                txtcocuksay.Text = dr[15].ToString();
                lbes.Text = dr[16].ToString();
                if(lbes.Text=="True")
                { rbecalisiyor.Checked = true; }
                else { rbecalismiyor.Checked = true; }
                txtkan.Text = dr[17].ToString();
                lblca.Text = dr[18].ToString();
                if(lblca.Text=="True")
                { rbcalisiyor.Checked = true; }
                else { rbcalismiyor.Checked = true; }
                cobdep.Text = dr[19].ToString();
                txtgorev.Text = dr[20].ToString();
                dateisbasi.Text = dr[21].ToString();
                dateissonu.Text = dr[22].ToString();              
                cobtessor.Text = dr[23].ToString();
                txtegitim.Text = dr[24].ToString();
                txtmah.Text = dr[10].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand bul1 = new SqlCommand("Select* from Mesleki_Belge where PerNo=@PerNo", baglanti);
            bul1.Parameters.AddWithValue("@PerNo", txtperno.Text);

            SqlDataReader dr1 = bul1.ExecuteReader();
            while (dr1.Read())
            {
                cbsbttesis.Checked = dr1[1].Equals(true);
                cbcevhaz.Checked = dr1[2].Equals(true);
                cbismakbak.Checked = dr1[3].Equals(true);
                cbkaynak.Checked = dr1[4].Equals(true);
                cbelektrik.Checked=dr1[5].Equals(true);
                cbforklift.Checked = dr1[6].Equals(true);
                cbvinc.Checked = dr1[7].Equals(true);
                cbmikser.Checked = dr1[8].Equals(true);
                cbpompa.Checked = dr1[9].Equals(true);
                cbkazici.Checked = dr1[10].Equals(true);
                cbyukleyici.Checked = dr1[11].Equals(true);
                cbdozer.Checked = dr1[12].Equals(true);
                cbilkyardim.Checked = dr1[13].Equals(true);
                cbhijyen.Checked = dr1[14].Equals(true);
                cbafad.Checked = dr1[15].Equals(true);
                cbkalorifer.Checked = dr1[16].Equals(true);
                cblab.Checked = dr1[17].Equals(true);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand bul2 = new SqlCommand("Select* from Ehliyet where PerNo=@PerNo", baglanti);
            bul2.Parameters.AddWithValue("@PerNo", txtperno.Text);

            SqlDataReader dr2 = bul2.ExecuteReader();
            while (dr2.Read())
            {
                cbm.Checked = dr2[1].Equals(true);
                cba.Checked = dr2[2].Equals(true);
                cba1.Checked = dr2[3].Equals(true);
                cba2.Checked = dr2[4].Equals(true);
                cbb.Checked = dr2[5].Equals(true);
                cbbe.Checked = dr2[6].Equals(true);
                cbb1.Checked = dr2[7].Equals(true);
                cbc.Checked = dr2[8].Equals(true);
                cbce.Checked = dr2[9].Equals(true);
                cbc1.Checked = dr2[10].Equals(true);
                cbc1e.Checked = dr2[11].Equals(true);
                cbd.Checked = dr2[12].Equals(true);
                cbde.Checked = dr2[13].Equals(true);
                cbd1.Checked = dr2[14].Equals(true);
                cbd1e.Checked = dr2[15].Equals(true);
                cbf.Checked = dr2[16].Equals(true);
                cbg.Checked = dr2[17].Equals(true);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand bul3 = new SqlCommand("Select* from SRC where PerNo=@PerNo", baglanti);
            bul3.Parameters.AddWithValue("@PerNo", txtperno.Text);

            SqlDataReader dr3 = bul3.ExecuteReader();
            while (dr3.Read())
            {
                cbs1.Checked = dr3[1].Equals(true);
                cbs2.Checked = dr3[2].Equals(true);
                cbs3.Checked = dr3[3].Equals(true);
                cbs4.Checked = dr3[4].Equals(true);
                cbpsi.Checked = dr3[5].Equals(true);
                datebastar.Text = dr3[6].ToString();
                datebittar.Text = dr3[7].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand bul4 = new SqlCommand("Select* from Sigorta where PerNo=@PerNo", baglanti);
            bul4.Parameters.AddWithValue("@PerNo", txtperno.Text);

            SqlDataReader dr4 = bul4.ExecuteReader();
            while (dr4.Read())
            {
                txtsigkismi.Text = dr4[1].ToString();
                txtsigsicilno.Text = dr4[2].ToString();
                txtmeslekkod.Text = dr4[3].ToString();
                txtmeslektanimi.Text = dr4[4].ToString();

            }
            baglanti.Close();

            if (rbcalismiyor.Checked == true)
            { dateissonu.Enabled = true; }
            else { dateissonu.Enabled = false; }

            if (cbpsi.Checked==true)
            {
                datebastar.Enabled = true;
                datebittar.Enabled = true;
            }
            else
            {
                datebastar.Enabled = false;
                datebittar.Enabled = false;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Personel_Bilgileri set PerAd=@PerAd,PerSoyad=@PerSoyad," +
                "Cinsiyet=@Cinsiyet,TC=@TC,Dogum_Yeri=@Dogum_Yeri,Dogum_Tarihi=@Dogum_Tarihi,Baba_Adi=@Baba_Adi,Ana_Adi=@Ana_Adi," +
                "Adres=@Adres,Ilce=@Ilce,Il=@Il,Telefon=@Telefon,Medeni_Durum=@Medeni_Durum,Cocuk_Sayisi=@Cocuk_Sayisi," +
                "Es_Durumu=@Es_Durumu,Kan_Grubu=@Kan_Grubu,Calisma_Durumu=@Calisma_Durumu,Departman=@Departman,Gorev=@Gorev," +
                "Is_Basi=@Is_Basi,Is_Sonu=@Is_Sonu,Tesis_Sorumlusu=@Tesis_Sorumlusu,Egitim_Durumu=@Egitim_Durumu,Mahalle=@Mahalle where PerNo=@PerNo", baglanti);

            komut.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komut.Parameters.AddWithValue("@PerAd", txtperad.Text);
            komut.Parameters.AddWithValue("@PerSoyad", txtpersoy.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", lblci.Text);
            komut.Parameters.AddWithValue("@TC", txttc.Text);
            komut.Parameters.AddWithValue("@Dogum_Yeri", txtdyer.Text);
            komut.Parameters.AddWithValue("@Dogum_Tarihi", Convert.ToDateTime(datedtar.Text));
            komut.Parameters.AddWithValue("@Baba_Adi", txtbaba.Text);
            komut.Parameters.AddWithValue("@Ana_Adi", txtana.Text);
            komut.Parameters.AddWithValue("@Adres", txtadres.Text);
            komut.Parameters.AddWithValue("@Ilce", txtilce.Text);
            komut.Parameters.AddWithValue("@Il", txtil.Text);
            komut.Parameters.AddWithValue("@Telefon", txttlfn.Text);
            komut.Parameters.AddWithValue("@Medeni_Durum", lblm.Text);
            komut.Parameters.AddWithValue("@Cocuk_Sayisi", txtcocuksay.Text);

            if (rbecalisiyor.Checked == false && rbecalismiyor.Checked == false)
            { komut.Parameters.AddWithValue("@Es_Durumu", DBNull.Value); }
            else
            { komut.Parameters.AddWithValue("@Es_Durumu", lbes.Text); }

            komut.Parameters.AddWithValue("@Kan_Grubu", txtkan.Text);
            komut.Parameters.AddWithValue("@Calisma_Durumu", lblca.Text);
            komut.Parameters.AddWithValue("@Departman", cobdep.Text);
            komut.Parameters.AddWithValue("@Gorev", txtgorev.Text);
            komut.Parameters.AddWithValue("@Is_Basi", Convert.ToDateTime(dateisbasi.Text));
            komut.Parameters.AddWithValue("@Tesis_Sorumlusu", cobtessor.Text);
            komut.Parameters.AddWithValue("@Egitim_Durumu", txtegitim.Text);
            komut.Parameters.AddWithValue("@Mahalle", txtmah.Text);

            if (dateissonu.Enabled == false)
            { komut.Parameters.AddWithValue("@Is_Sonu", DBNull.Value); }
            if (dateissonu.Enabled == true)
            { komut.Parameters.AddWithValue("@Is_Sonu", Convert.ToDateTime(dateissonu.Text)); }

            komut.ExecuteNonQuery();



            SqlCommand komutm = new SqlCommand("update Mesleki_Belge set Sabit_Tesis_Opt_Bakim=@Sabit_Tesis_Opt_Bakim," +
                "Cevher_Haz_Zen=@Cevher_Haz_Zen,Is_Mak_Bakim=@Is_Mak_Bakim,Kaynak=@Kaynak,Elektrik=@Elektrik,Forklift=@Forklift," +
                "Vinc=@Vinc,Mikser=@Mikser,Pompa=@Pompa,Kazici=@Kazici,Yukleyici=@Yukleyici,Dozer=@Dozer,Ilk_Yardim=@Ilk_Yardim," +
                "Hijyen=@Hijyen,AFAD=@AFAD,Kalorifer=@Kalorifer,Laborant=@Laborant where PerNo=@PerNo", baglanti);

            komutm.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komutm.Parameters.AddWithValue("@Sabit_Tesis_Opt_Bakim", cbsbttesis.Checked);
            komutm.Parameters.AddWithValue("@Cevher_Haz_Zen", cbcevhaz.Checked);
            komutm.Parameters.AddWithValue("@Is_Mak_Bakim", cbismakbak.Checked);
            komutm.Parameters.AddWithValue("@Kaynak", cbkaynak.Checked);
            komutm.Parameters.AddWithValue("@Elektrik", cbelektrik.Checked);
            komutm.Parameters.AddWithValue("@Forklift", cbforklift.Checked);
            komutm.Parameters.AddWithValue("@Vinc", cbvinc.Checked);
            komutm.Parameters.AddWithValue("@Mikser", cbmikser.Checked);
            komutm.Parameters.AddWithValue("@Pompa", cbpompa.Checked);
            komutm.Parameters.AddWithValue("@Kazici", cbkazici.Checked);
            komutm.Parameters.AddWithValue("@Yukleyici", cbyukleyici.Checked);
            komutm.Parameters.AddWithValue("@Dozer", cbdozer.Checked);
            komutm.Parameters.AddWithValue("@Ilk_Yardim", cbilkyardim.Checked);
            komutm.Parameters.AddWithValue("@Hijyen", cbhijyen.Checked);
            komutm.Parameters.AddWithValue("@AFAD", cbafad.Checked);
            komutm.Parameters.AddWithValue("@Kalorifer", cbkalorifer.Checked);
            komutm.Parameters.AddWithValue("@Laborant", cblab.Checked);
            komutm.ExecuteNonQuery();


            SqlCommand komute = new SqlCommand("update Ehliyet set M=@M,A=@A,A1=@A1,A2=@A2,B=@B,BE=@BE,B1=@B1,C=@C," +
                "CE=@CE,C1=@C1,C1E=@C1E,D=@D,DE=@DE,D1=@D1,D1E=@D1E,F=@F,G=@G where PerNo=@PerNo", baglanti);

            komute.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komute.Parameters.AddWithValue("@M", cbm.Checked);
            komute.Parameters.AddWithValue("@A", cba.Checked);
            komute.Parameters.AddWithValue("@A1", cba1.Checked);
            komute.Parameters.AddWithValue("@A2", cba2.Checked);
            komute.Parameters.AddWithValue("@B", cbb.Checked);
            komute.Parameters.AddWithValue("@BE", cbbe.Checked);
            komute.Parameters.AddWithValue("@B1", cbb1.Checked);
            komute.Parameters.AddWithValue("@C", cbc.Checked);
            komute.Parameters.AddWithValue("@CE", cbce.Checked);
            komute.Parameters.AddWithValue("@C1", cbc1.Checked);
            komute.Parameters.AddWithValue("@C1E", cbc1e.Checked);
            komute.Parameters.AddWithValue("@D", cbd.Checked);
            komute.Parameters.AddWithValue("@DE", cbde.Checked);
            komute.Parameters.AddWithValue("@D1", cbd1.Checked);
            komute.Parameters.AddWithValue("@D1E", cbd1e.Checked);
            komute.Parameters.AddWithValue("@F", cbf.Checked);
            komute.Parameters.AddWithValue("@G", cbg.Checked);
            komute.ExecuteNonQuery();

            SqlCommand komuts = new SqlCommand("update SRC set SRC1=@SRC1,SRC2=@SRC2,SRC3=@SRC3,SRC4=@SRC4," +
                "Psikoteknik=@Psikoteknik,Baslangic_Tarihi=@Baslangic_Tarihi,Bitis_Tarihi=@Bitis_Tarihi where PerNo=@PerNo", baglanti);

            komuts.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komuts.Parameters.AddWithValue("@SRC1", cbs1.Checked);
            komuts.Parameters.AddWithValue("@SRC2", cbs2.Checked);
            komuts.Parameters.AddWithValue("@SRC3", cbs3.Checked);
            komuts.Parameters.AddWithValue("@SRC4", cbs4.Checked);
            komuts.Parameters.AddWithValue("@Psikoteknik", cbpsi.Checked);
            if (cbpsi.Checked == true)
            {
                komuts.Parameters.AddWithValue("@Baslangic_Tarihi", Convert.ToDateTime(datebastar.Text));
                komuts.Parameters.AddWithValue("@Bitis_Tarihi", Convert.ToDateTime(datebittar.Text));
            }
            else
            {
                komuts.Parameters.AddWithValue("@Baslangic_Tarihi", DBNull.Value);
                komuts.Parameters.AddWithValue("@Bitis_Tarihi", DBNull.Value);
            }
            komuts.ExecuteNonQuery();


            SqlCommand komut2 = new SqlCommand("update Sigorta set PerNo=@PerNo,SigortaKismi=@SigortaKismi,SigortaSicilNo=@SigortaSicilNo," +
                "MeslekKodu=@MeslekKodu,MeslekTanimi=@MeslekTanimi where PerNo=@PerNo", baglanti);
            komut2.Parameters.AddWithValue("@PerNo", txtperno.Text);
            komut2.Parameters.AddWithValue("@SigortaKismi", txtsigkismi.Text);
            komut2.Parameters.AddWithValue("@SigortaSicilNo", txtsigsicilno.Text);
            komut2.Parameters.AddWithValue("@MeslekKodu", txtmeslekkod.Text);
            komut2.Parameters.AddWithValue("@MeslekTanimi", txtmeslektanimi.Text);
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
        }

        private void datebastar_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void lbes_Click(object sender, EventArgs e)
        {

        }

        private void lblm_Click(object sender, EventArgs e)
        {

        }

        private void datedtar_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
          
        }

        private void cbpsi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpsi.Checked == true)
            {
                datebastar.Enabled = true;
                datebittar.Enabled = true;
            }
            else
            {
                datebastar.Enabled = false;
                datebittar.Enabled = false;
            }
        }

        private void dateissonu_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void datebittar_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bulad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            bulad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            bulsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void lblca_Click(object sender, EventArgs e)
        {

        }

        private void dateissonu_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
          
        }

        private void pes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void asktecil_CheckedChanged(object sender, EventArgs e)
        {
            if (asktecil.Checked == true) { dateasktecil.Enabled = true; }
            else { dateasktecil.Enabled = false; }
        }

        private void askterhis_CheckedChanged(object sender, EventArgs e)
        {
            if (askterhis.Checked == true) { dateaskterhis.Enabled = true; }
            else { dateaskterhis.Enabled = false; }
        }
    }
}
