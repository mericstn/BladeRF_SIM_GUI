using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bladeRF_GUI_v1.HelpersForms
{
   
    public partial class F_Yardimci : Form
    {
        private int current_step = 0;
        private int total_step = 4;
        public C_SimulasyonYardimci sim_cfg;

        private UC_EfemerisSec uc_EfemerisSec;
        private UC_HareketDosyaSec uc_HareketDosyaSec;
        private UC_CihazYapilandir uc_CihazYapilandir;
        private UC_YuklemeEkrani uc_YuklemeEkrani;
       

        public F_Yardimci()
        {
            
            InitializeComponent();
            sim_cfg = new C_SimulasyonYardimci();

            yardimci_prog_bar.Minimum = 0;
            yardimci_prog_bar.Maximum = 100;

            

            gps_cikti_klasor_label.Text         = sim_cfg.gps_cikti_klasor_yolu;   
            gps_cli_label.Text                  = sim_cfg.gps_cli_dosya_yolu;
            galileo_cikti_klasor_label.Text     = sim_cfg.galileo_cikti_klasor_yolu;
            galileo_cli_label.Text              = sim_cfg.galileo_cli_dosya_yolu;
            bladerf_cli_dosya_yolu_label.Text   = sim_cfg.bladerf_cli_dosya_yolu;

            uc_EfemerisSec      = new UC_EfemerisSec(sim_cfg);
            uc_HareketDosyaSec  = new UC_HareketDosyaSec(sim_cfg);
            uc_YuklemeEkrani    = new UC_YuklemeEkrani(sim_cfg);
            uc_CihazYapilandir  = new UC_CihazYapilandir(sim_cfg);

        }

        private void ShowStep(int step)
        {
            helper_main_panel.Controls.Clear();

            switch (step)
            {
                case 1:
                    baslik.Text = $"Adım 1: Efemeris verilerini seçiniz.";
                    geri_button.Enabled = true;
                    step_button.Text = "Sonraki Adım";
                    uc_EfemerisSec.Update();
                    helper_main_panel.Controls.Add(uc_EfemerisSec);
                    break;
                case 2:
                    baslik.Text = "Adım 2: Kullanıcı hareketini tanımlayınız.";
                    step_button.Text = "Sonraki Adım";
                    helper_main_panel.Controls.Add(uc_HareketDosyaSec);
                    break;
                case 3:
                    baslik.Text = "Adım 3: Simulasyon parametrelerini işleyin ve dosya oluşturun.";
                    step_button.Text = "Sonraki Adım";
                    uc_YuklemeEkrani.guncelle(); //  digeleri icin de yapilabilir
                    helper_main_panel.Controls.Add(uc_YuklemeEkrani);
                    break;
                case 4:
                    baslik.Text = "Adım 4: Cihazı yapılandırın ve simulasyonu kontrol edin.";
                    step_button.Text = "Bitir";
                    uc_CihazYapilandir.guncelle();
                    helper_main_panel.Controls.Add(uc_CihazYapilandir);
                    break;
                case 5:
                    durum_label.Text = "Tamam";
                    baslik.Text = "Tüm adımlar tamamlandı!";
                    step_button.Text = "Kapat";
                    break;
                default:
                    durum_label.Text = "Hata";
                    baslik.Text = "Bilinmeyen Hata!";
                    step_button.Text = "Kapat";
                    geri_button.Enabled = false;
                    break;
            }
        }

        private void Step_button_Click(object sender, EventArgs e)
        {
            if (current_step <= total_step && current_step >= 0) // sayi statik case +1
            {
                current_step++;
                yardimci_prog_bar.Value = ((current_step) * 100) / (total_step+1);
                durum_label.Text = $"{current_step} / {total_step}";
                ShowStep(current_step);
            }
            else
            {
                current_step = 0;
                MessageBox.Show("Tüm adımlar tamamlandı !");
                this.Close();
            }
        }


        private void Cikis_button_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show($"Emin Misiniz ? ", "Çıkış İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sonuc == DialogResult.Yes)
            {
                current_step = 0;
                this.Close();
            }
                
        }

        private void Geri_button_Click(object sender, EventArgs e)
        {
            if (current_step <= total_step+1 && current_step>1)
            {
                current_step--;
                yardimci_prog_bar.Value = ((current_step) * 100) / (total_step + 1);
                durum_label.Text = $"{current_step} / {total_step}";
                ShowStep(current_step);
            }

        }

        private void Gps_binary_klasor_sec_button_Click(object sender, EventArgs e)
        {
            sim_cfg.gps_cikti_klasor_yolu = sim_cfg.klasor_secici();
        }

        private void Galileo_binary_klasor_sec_button_Click(object sender, EventArgs e)
        {
            sim_cfg.galileo_cikti_klasor_yolu = sim_cfg.klasor_secici();
        }

        private void Gps_cli_sec_button_Click(object sender, EventArgs e)
        {
            sim_cfg.gps_cli_dosya_yolu = sim_cfg.dosya_secici();
        }

        private void Galileo_cli_sec_button_Click(object sender, EventArgs e)
        {
            sim_cfg.galileo_cli_dosya_yolu = sim_cfg.dosya_secici();
        }

        private void Bladerf_cli_dosya_sec_button_Click(object sender, EventArgs e)
        {
            sim_cfg.bladerf_cli_dosya_yolu = sim_cfg.dosya_secici();
        }
    }
}
