using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bladeRF_GUI_v1.Classes;
using bladeRF_GUI_v1.UserControls;


namespace bladeRF_GUI_v1.ApplicationUserControls
{
    public partial class UC_Tekrarlayici : UserControl
    {
        private C_Uygulamalar   c_tekrarlayici;
        private C_Ayarlar       c_ayarlar;
        private C_CLI           c_cli;
        public UC_Tekrarlayici(C_Ayarlar _ayarlar)
        {
            c_tekrarlayici  = new C_Uygulamalar();
            c_ayarlar       = _ayarlar;
            c_cli           = new C_CLI(c_ayarlar);
            InitializeComponent();
            guncelle();
        }
        private void guncelle()
        {
            tx_frekans_textbox.Text         = c_tekrarlayici.kanal_tx_frekans;
            tx_ornekleme_orani_textbox.Text = c_tekrarlayici.kanal_tx_ornekleme_orani;
            tx_bant_genisligi_textbox.Text  = c_tekrarlayici.kanal_tx_bant_genisligi;
            tx_anten_kazanci_textbox.Text   = c_tekrarlayici.kanal_tx_anten_kazanci;
            tx_zaman_asimi_textbox.Text     = c_tekrarlayici.kanal_tx_zaman_asimi;
            tx_biastee_checkbox.Text        = c_tekrarlayici.kanal_tx_biastee;
            tx_kanal_combobox.SelectedIndex = 0;


            rx_frekans_textbox.Text         = c_tekrarlayici.kanal_rx_frekans;
            rx_ornekleme_orani_textbox.Text = c_tekrarlayici.kanal_rx_ornekleme_orani;
            rx_bant_genisligi_textbox.Text  = c_tekrarlayici.kanal_rx_bant_genisligi;
            rx_anten_kazanci_textbox.Text   = c_tekrarlayici.kanal_rx_anten_kazanci;
            rx_zaman_asimi_textbox.Text     = c_tekrarlayici.kanal_rx_zaman_asimi;
            rx_biastee_checkbox.Text        = c_tekrarlayici.kanal_rx_biastee;
            rx_kanal_combobox.SelectedIndex = 0;
            
            vap_tampon_sayisi_textbox.Text          = c_tekrarlayici.rxtx_tampon_sayisi;
            vap_tampon_boyutu_textbox.Text          = c_tekrarlayici.rxtx_tampon_boyutu;
            vap_veri_transfer_sayisi_textbox.Text   = c_tekrarlayici.rxtx_veri_transfer_sayisi;
            vap_zaman_asimi_textbox.Text            = c_tekrarlayici.rxtx_zaman_asimi;         
        }

        private void cihaz_parametrelerini_kur_picbox_Click(object sender, EventArgs e)
        {
            if (!c_tekrarlayici.cihaz_parametrelerini_kur("RXTX",c_ayarlar.repeater_parametre_dosya_yolu))
            {
                MessageBox.Show($" Dosyaya parametre yazma işlemi başarısız!'\n {c_ayarlar.repeater_parametre_dosya_yolu}", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }
        private async void baslat_picbox_Click(object sender, EventArgs e)
        {
            
            baslat_picbox.Enabled = false;
            string komut = c_ayarlar.repeater_parametre_dosya_yolu;
            var (result, arguments) = await c_cli.CLI_isleyici_statik(komut, "Repeater");

            repeater_cikti_richtextbox.SelectionColor = Color.MidnightBlue;
            repeater_cikti_richtextbox.AppendText("CMD$ " + arguments + Environment.NewLine);
            repeater_cikti_richtextbox.SelectionColor = Color.Black;

            repeater_cikti_richtextbox.AppendText(result);
            repeater_cikti_richtextbox.SelectionStart = repeater_cikti_richtextbox.Text.Length;

            repeater_cikti_richtextbox.ScrollToCaret();

            baslat_picbox.Enabled = true;
        }



        private void tx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_tx_frekans = tx_frekans_textbox.Text;
        }

        private void tx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_tx_ornekleme_orani = tx_ornekleme_orani_textbox.Text;
        }

        private void tx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_tx_bant_genisligi = tx_bant_genisligi_textbox.Text;
        }

        private void tx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_tx_anten_kazanci = tx_anten_kazanci_textbox.Text;
        }

        private void tx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_tx_zaman_asimi = tx_zaman_asimi_textbox.Text;
        }
        private void tx_biastee_textbox_CheckedChanged(object sender, EventArgs e)
        {
            if (tx_biastee_checkbox.Checked)
            {
                c_tekrarlayici.kanal_tx_biastee = "Aktif"; 
            }
            else
            {
                c_tekrarlayici.kanal_tx_biastee = "Kapali";
            }
            tx_biastee_checkbox.Text = c_tekrarlayici.kanal_tx_biastee;

        }
        private void rx_frekans_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_rx_frekans = rx_frekans_textbox.Text;
        }

        private void rx_ornekleme_orani_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_rx_ornekleme_orani = rx_ornekleme_orani_textbox.Text;
        }

        private void rx_bant_genisligi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_rx_bant_genisligi = rx_bant_genisligi_textbox.Text;
        }

        private void rx_anten_kazanci_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_rx_anten_kazanci = rx_anten_kazanci_textbox.Text;
        }

        private void rx_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.kanal_rx_zaman_asimi = rx_zaman_asimi_textbox.Text;
        }

        private void rx_biastee_textbox_CheckedChanged(object sender, EventArgs e)
        {
            if (rx_biastee_checkbox.Checked)
            {
                c_tekrarlayici.kanal_rx_biastee = "Aktif";               
            }
            else
            {
                c_tekrarlayici.kanal_rx_biastee = "Kapali";          
            }
            rx_biastee_checkbox.Text = c_tekrarlayici.kanal_rx_biastee;
        }

        private void vap_tampon_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rxtx_tampon_sayisi = vap_tampon_sayisi_textbox.Text;
        }

        private void vap_tampon_boyutu_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rxtx_tampon_boyutu = vap_tampon_boyutu_textbox.Text;
        }

        private void vap_veri_transfer_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rxtx_veri_transfer_sayisi = vap_veri_transfer_sayisi_textbox.Text;
        }

        private void vap_zaman_asimi_textbox_TextChanged(object sender, EventArgs e)
        {
            c_tekrarlayici.rxtx_zaman_asimi = vap_zaman_asimi_textbox.Text;
        }

        private void tx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tx_kanal_combobox.SelectedIndex ==0)
            {
                c_tekrarlayici.kanal_tx_kanal = "TX1"; // sadece 1 veya 2 yap
            }
            else if(tx_kanal_combobox.SelectedIndex == 1)
            {
                c_tekrarlayici.kanal_tx_kanal = "TX2";
            }
        }

        private void rx_kanal_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rx_kanal_combobox.SelectedIndex == 0)
            {
                c_tekrarlayici.kanal_rx_kanal = "RX1";
            }
            else if (rx_kanal_combobox.SelectedIndex == 1)
            {
                c_tekrarlayici.kanal_rx_kanal = "RX2";
            }
        }

     
    }
}
