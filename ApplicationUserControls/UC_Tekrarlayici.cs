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
    public partial class UC_Tekrarlayici : UserControl
    {
        private C_Uygulamalar c_tekrarlayici;
        public UC_Tekrarlayici()
        {
            c_tekrarlayici = new C_Uygulamalar();
            InitializeComponent();
            guncelle();
        }
        private void guncelle()
        {
            tx_frekans_textbox.Text         = c_tekrarlayici.tx_frekans;
            tx_ornekleme_orani_textbox.Text = c_tekrarlayici.tx_ornekleme_orani;
            tx_bant_genisligi_textbox.Text  = c_tekrarlayici.tx_bant_genisligi;
            tx_anten_kazanci_textbox.Text   = c_tekrarlayici.tx_anten_kazanci;
            tx_zaman_asimi_textbox.Text     = c_tekrarlayici.tx_zaman_asimi;
            tx_biastee_checkbox.Text        = c_tekrarlayici.tx_biastee;
            tx_kanal_combobox.SelectedIndex = 0;


            rx_frekans_textbox.Text         = c_tekrarlayici.rx_frekans;
            rx_ornekleme_orani_textbox.Text = c_tekrarlayici.rx_ornekleme_orani;
            rx_bant_genisligi_textbox.Text  = c_tekrarlayici.rx_bant_genisligi;
            rx_anten_kazanci_textbox.Text   = c_tekrarlayici.rx_anten_kazanci;
            rx_zaman_asimi_textbox.Text     = c_tekrarlayici.rx_zaman_asimi;
            rx_biastee_checkbox.Text        = c_tekrarlayici.rx_biastee;
            rx_kanal_combobox.SelectedIndex = 0;
            
            vap_tampon_sayisi_textbox.Text          = c_tekrarlayici.vap_tampon_sayisi;
            vap_tampon_boyutu_textbox.Text          = c_tekrarlayici.vap_tampon_boyutu;
            vap_veri_transfer_sayisi_textbox.Text   = c_tekrarlayici.vap_veri_transfer_sayisi;
            vap_zaman_asimi_textbox.Text            = c_tekrarlayici.vap_zaman_asimi;
        }

        private void baslat_picbox_Click(object sender, EventArgs e)
        {
            
        }

        private void durdur_picbox_Click(object sender, EventArgs e)
        {

        }

        private void tx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.tx_frekans = tx_frekans_textbox.Text;
        }

        private void tx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.tx_ornekleme_orani = tx_ornekleme_orani_textbox.Text;
        }

        private void tx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.tx_bant_genisligi = tx_bant_genisligi_textbox.Text;
        }

        private void tx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.tx_anten_kazanci = tx_anten_kazanci_textbox.Text;
        }

        private void tx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.tx_zaman_asimi = tx_zaman_asimi_textbox.Text;
        }
        private void tx_biastee_textbox_CheckedChanged(object sender, EventArgs e)
        {
            if (tx_biastee_checkbox.Checked)
            {
                c_tekrarlayici.tx_biastee = "Aktif"; 
            }
            else
            {
                c_tekrarlayici.tx_biastee = "Kapali";
            }
            tx_biastee_checkbox.Text = c_tekrarlayici.tx_biastee;

        }
        private void rx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rx_frekans = rx_frekans_textbox.Text;
        }

        private void rx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rx_ornekleme_orani = rx_ornekleme_orani_textbox.Text;
        }

        private void rx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rx_bant_genisligi = rx_bant_genisligi_textbox.Text;
        }

        private void rx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rx_anten_kazanci = rx_anten_kazanci_textbox.Text;
        }

        private void rx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rx_zaman_asimi = rx_zaman_asimi_textbox.Text;
        }

        private void rx_biastee_textbox_CheckedChanged(object sender, EventArgs e)
        {
            if (rx_biastee_checkbox.Checked)
            {
                c_tekrarlayici.rx_biastee = "Aktif";               
            }
            else
            {
                c_tekrarlayici.rx_biastee = "Kapali";          
            }
            rx_biastee_checkbox.Text = c_tekrarlayici.rx_biastee;
        }

        private void vap_tampon_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.vap_tampon_sayisi = vap_tampon_sayisi_textbox.Text;
        }

        private void vap_tampon_boyutu_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.vap_tampon_boyutu = vap_tampon_boyutu_textbox.Text;
        }

        private void vap_veri_transfer_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.vap_veri_transfer_sayisi = vap_veri_transfer_sayisi_textbox.Text;
        }

        private void vap_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.vap_zaman_asimi = vap_zaman_asimi_textbox.Text;
        }

        private void tx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tx_kanal_combobox.SelectedIndex ==0)
            {
                c_tekrarlayici.tx_kanal = "TX1"; // sadece 1 veya 2 yap
            }
            else if(tx_kanal_combobox.SelectedIndex == 1)
            {
                c_tekrarlayici.tx_kanal = "TX2";
            }
        }

        private void rx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rx_kanal_combobox.SelectedIndex == 0)
            {
                c_tekrarlayici.rx_kanal = "RX1";
            }
            else if (rx_kanal_combobox.SelectedIndex == 1)
            {
                c_tekrarlayici.rx_kanal = "RX2";
            }
        }
    }
}
