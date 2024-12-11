using bladeRF_GUI_v1.HelpersForms.SetupDevice;
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
   
    public partial class F_KurulumYardimcisi : Form
    {
        private int current_step = 0;
        private int total_step = 2;
        public C_SimulasyonYardimci sim_cfg;
        private UC_FPGA uc_fpga;
        private UC_Firmware uc_fw;

        public F_KurulumYardimcisi()
        {
            
            InitializeComponent();
            sim_cfg = new C_SimulasyonYardimci();

            uc_fpga = new UC_FPGA(sim_cfg);
            uc_fw   = new UC_Firmware(sim_cfg);

            yardimci_prog_bar.Minimum = 0;
            yardimci_prog_bar.Maximum = 100;


        }

        private void ShowStep(int step)
        {
            helper_main_panel.Controls.Clear();

            switch (step)
            {
                case 1:
                    baslik.Text = $"Adım 1: FPGA Image Yükle";
                    geri_button.Enabled = true;
                    step_button.Text = "Sonraki Adım";
                    helper_main_panel.Controls.Add(uc_fpga);
                    break;
                case 2:
                    baslik.Text = "Adım 2: Cihaz Yazılım Güncelle";
                    step_button.Text = "Sonraki Adım";
                    helper_main_panel.Controls.Add(uc_fw);
                    break;
                case 3:
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

       
    }
}
