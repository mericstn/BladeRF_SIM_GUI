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
    public partial class UC_Okuma : UserControl
    {
        private C_Uygulamalar c_okuma;
        public UC_Okuma()
        {
            c_okuma = new C_Uygulamalar();
            InitializeComponent();
            guncelle();
        }
        private void guncelle()
        {
            cihaz_model_combobox.SelectedIndex = 1;
           
            rx_frekans_textbox.Text             = c_okuma.rx_frekans;
            rx_ornekleme_orani_textbox.Text     = c_okuma.rx_ornekleme_orani;
            rx_bant_genisligi_textbox.Text      = c_okuma.rx_bant_genisligi;
            rx_anten_kazanci_textbox.Text       = c_okuma.rx_anten_kazanci;
            rx_zaman_asimi_textbox.Text         = c_okuma.rx_zaman_asimi;
            rx_biastee_checkbox.Text            = c_okuma.rx_biastee;
            rx_kanal_combobox.SelectedIndex     = 0;
            rx_yazilacak_dosya_adi_textbox.Text = c_okuma.rx_yazilacak_dosya_adi;

            vap_tampon_sayisi_textbox.Text        = c_okuma.vap_tampon_sayisi;
            vap_tampon_boyutu_textbox.Text        = c_okuma.vap_tampon_boyutu;
            vap_veri_transfer_sayisi_textbox.Text = c_okuma.vap_veri_transfer_sayisi;
            vap_zaman_asimi_textbox.Text          = c_okuma.vap_zaman_asimi;
        }

        private void baslat_picbox_Click(object sender, EventArgs e)
        {

        }

        private void durdur_picbox_Click(object sender, EventArgs e)
        {

        }

        private void rx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_frekans = rx_frekans_textbox.Text;
        }

        private void rx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_ornekleme_orani = rx_ornekleme_orani_textbox.Text;
        }

        private void rx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_bant_genisligi = rx_bant_genisligi_textbox.Text;
        }

        private void rx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_anten_kazanci = rx_anten_kazanci_textbox.Text;
        }

        private void rx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_zaman_asimi = rx_zaman_asimi_textbox.Text;
        }

        private void rx_biastee_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rx_biastee_checkbox.Checked)
            {
                c_okuma.tx_biastee = "Aktif";
            }
            else
            {
                c_okuma.tx_biastee = "Kapali";
            }
            rx_biastee_checkbox.Text = c_okuma.rx_biastee;

        }

        private void vap_tampon_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.vap_tampon_sayisi = vap_tampon_sayisi_textbox.Text;
        }

        private void vap_tampon_boyutu_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.vap_tampon_boyutu = vap_tampon_boyutu_textbox.Text;
        }

        private void vap_veri_transfer_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.vap_veri_transfer_sayisi = vap_veri_transfer_sayisi_textbox.Text;
        }

        private void vap_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.vap_zaman_asimi = vap_zaman_asimi_textbox.Text;
        }

     

        private void cihaz_model_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cihaz_model_combobox.SelectedIndex == 0)
            {
                c_okuma.cihaz_model = "BladeRFv1.0";
            }
            else if (cihaz_model_combobox.SelectedIndex == 1)
            {
                c_okuma.cihaz_model = "BladeRFv2.0";
            }
        }

        private void rx_yazilacak_dosya_adi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_okuma.rx_yazilacak_dosya_adi = rx_yazilacak_dosya_adi_textbox.Text;
        }

        private void rx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rx_kanal_combobox.SelectedIndex == 0)
            {
                c_okuma.rx_kanal = "RX1";
            }
            else if (rx_kanal_combobox.SelectedIndex == 1)
            {
                c_okuma.rx_kanal = "RX2";
            }
        }
    }
}
