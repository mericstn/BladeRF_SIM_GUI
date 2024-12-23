using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bladeRF_GUI_v1.ApplicationUserControls
{
    public partial class UC_Yazma : UserControl
    {
        private C_Uygulamalar c_yazma;
        public UC_Yazma()
        {
            c_yazma = new C_Uygulamalar();
            InitializeComponent();
            guncelle();
        }
        private void guncelle()
        {
            cihaz_model_combobox.SelectedIndex = 1;
           
            tx_frekans_textbox.Text             = c_yazma.kanal_tx_frekans;
            tx_ornekleme_orani_textbox.Text     = c_yazma.kanal_tx_ornekleme_orani;
            tx_bant_genisligi_textbox.Text      = c_yazma.kanal_tx_bant_genisligi;
            tx_anten_kazanci_textbox.Text       = c_yazma.kanal_tx_anten_kazanci;
            tx_zaman_asimi_textbox.Text         = c_yazma.kanal_tx_zaman_asimi;
            tx_biastee_checkbox.Text            = c_yazma.kanal_tx_biastee;
            tx_kanal_combobox.SelectedIndex     = 0;
            tx_okunacak_dosya_adi_textbox.Text  = c_yazma.tx_okunacak_dosya_adi;

            vap_tampon_sayisi_textbox.Text        = c_yazma.tx_tampon_sayisi;
            vap_tampon_boyutu_textbox.Text        = c_yazma.tx_tampon_boyutu;
            vap_veri_transfer_sayisi_textbox.Text = c_yazma.tx_veri_transfer_sayisi;
            vap_zaman_asimi_textbox.Text          = c_yazma.tx_zaman_asimi;
        }

        private void baslat_picbox_Click(object sender, EventArgs e)
        {

        }

        private void durdur_picbox_Click(object sender, EventArgs e)
        {

        }

        private void tx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.kanal_tx_frekans = tx_frekans_textbox.Text;
        }

        private void tx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.kanal_tx_ornekleme_orani = tx_ornekleme_orani_textbox.Text;
        }

        private void tx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.kanal_tx_bant_genisligi = tx_bant_genisligi_textbox.Text;
        }

        private void tx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.kanal_tx_anten_kazanci = tx_anten_kazanci_textbox.Text;
        }

        private void tx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.kanal_tx_zaman_asimi = tx_zaman_asimi_textbox.Text;
        }

        private void tx_biastee_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (tx_biastee_checkbox.Checked)
            {
                c_yazma.kanal_tx_biastee = "Aktif";
            }
            else
            {
                c_yazma.kanal_tx_biastee = "Kapali";
            }
            tx_biastee_checkbox.Text = c_yazma.kanal_tx_biastee;
        }

        private void vap_tampon_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.tx_tampon_sayisi = vap_tampon_sayisi_textbox.Text;
        }

        private void vap_tampon_boyutu_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.tx_tampon_boyutu = vap_tampon_boyutu_textbox.Text;
        }

        private void vap_veri_transfer_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.tx_veri_transfer_sayisi = vap_veri_transfer_sayisi_textbox.Text;

        }

        private void vap_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.tx_zaman_asimi = vap_zaman_asimi_textbox.Text;

        }

        private void cihaz_model_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cihaz_model_combobox.SelectedIndex == 0)
            {
                c_yazma.cihaz_model = "BladeRFv1.0";
            }
            else if (cihaz_model_combobox.SelectedIndex == 1)
            {
                c_yazma.cihaz_model = "BladeRFv2.0";
            }
        }

        private void tx_okunacak_dosya_adi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_yazma.tx_okunacak_dosya_adi = tx_okunacak_dosya_adi_textbox.Text;

        }

        private void tx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tx_kanal_combobox.SelectedIndex == 0)
            {
                c_yazma.kanal_tx_kanal = "TX1";
            }
            else if (tx_kanal_combobox.SelectedIndex == 1)
            {
                c_yazma.kanal_tx_kanal = "TX2";
            }
        }


    }
}
