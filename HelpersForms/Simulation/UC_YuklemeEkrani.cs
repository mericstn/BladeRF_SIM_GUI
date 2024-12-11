using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bladeRF_GUI_v1.UserInfo;

namespace bladeRF_GUI_v1.HelpersForms
{
    public partial class UC_YuklemeEkrani : UserControl
    {
        private C_SimulasyonYardimci _sim_cfg;



        public UC_YuklemeEkrani(C_SimulasyonYardimci sim_cfg)
        {
            InitializeComponent();

            _sim_cfg = sim_cfg;

            guncelle();


        }


        public void guncelle()
        {


            gps_aktif_label.Text                    = _sim_cfg.gps_aktif ? "Aktif" : "Pasif";
            gps_efemeris_yolu_label.Text            = _sim_cfg.gps_rinex2_dosya_yolu;
            gps_hareket_tipi_label.Text             = _sim_cfg.sim_statik_konum_modu ? "Statik" : "Dinamik";
            gps_kullanici_dosya_yolu_label.Text     = _sim_cfg.sim_kullanici_hareketi_dosya_yolu;
            gps_statik_konum_label.Text             = _sim_cfg.sim_llh;
            gps_binary_cikti_isim_textbox.Text      = _sim_cfg.gps_cikti_dosya_adi;
            gps_simulasyon_suresi_textbox.Text      = _sim_cfg.sim_simulasyon_suresi;
            gps_ornekleme_frekansi_textbox.Text     = _sim_cfg.bladerf_ornekleme_frekansi;
            gps_iyonosferik_gecikme_label.Text      = _sim_cfg.gps_iyonosferik_gecikme ? "Aktif" : "Pasif";

            galileo_aktif_label.Text                = _sim_cfg.galileo_aktif ? "Aktif" : "Pasif";
            galileo_efemeris_yolu_label.Text        = _sim_cfg.galileo_vector_dosya_yolu;
            galileo_hareket_tipi_label.Text         = _sim_cfg.sim_statik_konum_modu ? "Statik" : "Dinamik";
            galileo_kullanici_dosya_yolu_label.Text = _sim_cfg.sim_kullanici_hareketi_dosya_yolu;
            galileo_statik_konum_label.Text         = _sim_cfg.sim_llh;
            galileo_binary_cikti_isim_textbox.Text  = _sim_cfg.galileo_cikti_dosya_adi;
            galileo_simulasyon_suresi_textbox.Text  = _sim_cfg.sim_simulasyon_suresi;
            galileo_ornekleme_frekansi_textbox.Text = _sim_cfg.bladerf_ornekleme_frekansi;
            galileo_iyonosferik_gecikme_label.Text  = _sim_cfg.galileo_iyonosferik_gecikme ? "Aktif" : "Pasif";

            if(_sim_cfg.gps_aktif &&  _sim_cfg.galileo_aktif)
            {
                llabel.Enabled = true;
                ikili_cikti_dosya_adi_textbox.Enabled = true;
            }
            else
            {
                llabel.Enabled = false;
                ikili_cikti_dosya_adi_textbox.Enabled = false;
            }

        }
        private async void Sim_olustur_button_Click(object sender, EventArgs e)
        {
            if(_sim_cfg.gps_aktif)
            {
                string gps_komut = _sim_cfg.Gps_komut_olustur();

                /*-----------------GPS-SIM ile Binary Dosyanın Oluşturulması------------------------*/

                F_BilgilendirmeKutucugu bilgiFormu = new F_BilgilendirmeKutucugu("GPS Simulasyon Dosyası Oluşturuluyor", gps_komut, gps_komut);
                bilgiFormu.Show();
                bilgiFormu.sakla_kapat_button_Click();

                try
                {
                    await Task.Run(() =>
                    {
                        int totalOutputs = 100;
                        int currentOutputCount = 0;
                        _sim_cfg.gps_cli_isleyici_dinamik(gps_komut, (output) =>
                        {
                            bilgiFormu.Invoke(new Action(() =>
                            {
                                bilgiFormu.AppendTextToRichTextBox(output);
                                currentOutputCount++;

                                int progressPercentage = (currentOutputCount * 100) / totalOutputs;
                                bilgiFormu.UpdateProgressBar(progressPercentage);
                            }));
                        });
                    });
                    bilgiFormu.goster_kapat_button_Click();
                }
                catch (Exception ex)
                {
                    bilgiFormu.Close();
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(_sim_cfg.galileo_aktif)
            {
                string galileo_komut = _sim_cfg.Galileo_komut_olustur();

                /*-----------------Galileo-SIM ile Binary Dosyanın Oluşturulması------------------------*/

                F_BilgilendirmeKutucugu bilgiFormu = new F_BilgilendirmeKutucugu("Galileo Simulasyon Dosyası Oluşturuluyor", galileo_komut, galileo_komut);
                bilgiFormu.Show();
                bilgiFormu.sakla_kapat_button_Click();

                try
                {
                    await Task.Run(() =>
                    {
                        int totalOutputs = 100;
                        int currentOutputCount = 0;
                        _sim_cfg.galileo_cli_isleyici_dinamik(galileo_komut, (output) =>
                        {
                            bilgiFormu.Invoke(new Action(() =>
                            {
                                bilgiFormu.AppendTextToRichTextBox(output);
                                currentOutputCount++;

                                int progressPercentage = (currentOutputCount * 100) / totalOutputs;
                                bilgiFormu.UpdateProgressBar(progressPercentage);
                            }));
                        });
                    });
                    bilgiFormu.goster_kapat_button_Click();
                }
                catch (Exception ex)
                {
                    bilgiFormu.Close();
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (_sim_cfg.galileo_aktif && _sim_cfg.gps_aktif) // python kodu calistirilir
            {
                // kod csv tablosu oluşturur

                string python_komut = _sim_cfg.python_komut_olustur();

                /*-----------------Binary Dosyaların CSV olarak Birleştirilmesi ------------------------*/

                F_BilgilendirmeKutucugu bilgiFormu = new F_BilgilendirmeKutucugu(" Simulasyon Dosyaları Birleştiriliyor ", python_komut, python_komut);
                bilgiFormu.Show();
                bilgiFormu.sakla_kapat_button_Click();

                try
                {
                    await Task.Run(() =>
                    {
                        int totalOutputs = 100;
                        int currentOutputCount = 0;
                        _sim_cfg.cmd_cli_isleyici(python_komut, (output) =>
                        {
                            bilgiFormu.Invoke(new Action(() =>
                            {
                                bilgiFormu.AppendTextToRichTextBox(output);
                                currentOutputCount++;

                                int progressPercentage = (currentOutputCount * 100) / totalOutputs;
                                bilgiFormu.UpdateProgressBar(progressPercentage);
                            }));
                        });
                    });
                    bilgiFormu.goster_kapat_button_Click();
                }
                catch (Exception ex)
                {
                    bilgiFormu.Close();
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }


        private void İnfo_picbox_Click(object sender, EventArgs e)
        {

        }
        //17.145302,42.145369,13.1453
        private void Komut_bilgi_button_Click(object sender, EventArgs e)
        {
            if (_sim_cfg.gps_aktif)
            {
                F_BilgilendirmeKutucugu bilgiFormu = new F_BilgilendirmeKutucugu("GPS Simulasyon Komutu", "", _sim_cfg.Gps_komut_olustur());
                bilgiFormu.Show();
                bilgiFormu.sakla_kapat_button_Click();
            }
            if (_sim_cfg.galileo_aktif)
            {
                F_BilgilendirmeKutucugu bilgiFormu2 = new F_BilgilendirmeKutucugu("Galileo Simulasyon Komutu", "", _sim_cfg.Galileo_komut_olustur());
                bilgiFormu2.Show();
                bilgiFormu2.sakla_kapat_button_Click();
            }
            if (_sim_cfg.galileo_aktif && _sim_cfg.gps_aktif)
            {
                F_BilgilendirmeKutucugu bilgiFormu3 = new F_BilgilendirmeKutucugu("Python Birleştirme Komutu", "",_sim_cfg.python_komut_olustur());
                bilgiFormu3.Show();
                bilgiFormu3.sakla_kapat_button_Click();
            }
        }

        private void Gps_binary_cikti_isim_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.gps_cikti_dosya_adi = gps_binary_cikti_isim_textbox.Text;
        }



        private void Gps_simulasyon_suresi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.sim_simulasyon_suresi = gps_simulasyon_suresi_textbox.Text;
        }


        private void Galileo_binary_cikti_isim_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.galileo_cikti_dosya_adi = galileo_binary_cikti_isim_textbox.Text;
        }

        private void Galileo_simulasyon_suresi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.sim_simulasyon_suresi = galileo_simulasyon_suresi_textbox.Text;
        }

        private void Galileo_ornekleme_frekansi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.sim_ornekleme_frekansi = galileo_ornekleme_frekansi_textbox.Text;
        }

        private void Gps_ornekleme_frekansi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.sim_ornekleme_frekansi = gps_ornekleme_frekansi_textbox.Text; // ornekleme frekansları ayırılabilir !!!!!!!
        }

        private void Gps_iyonosferik_gecikme_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (gps_iyonosferik_gecikme_checkbox.Checked)
            {
                _sim_cfg.gps_iyonosferik_gecikme = true;
            }
            else
            {
                _sim_cfg.gps_iyonosferik_gecikme = false;
            }
        }

        private void Galileo_iyonosferik_gecikme_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (galileo_iyonosferik_gecikme_checkbox.Checked)
            {
                _sim_cfg.galileo_iyonosferik_gecikme = true;
            }
            else
            {
                _sim_cfg.galileo_iyonosferik_gecikme = false;
            }
        }

        private void ikili_cikti_dosya_adi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.sim_csv_cikti_dosya_adi = ikili_cikti_dosya_adi_textbox.Text;
        }
    }
}
