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
using System.Diagnostics;

namespace bladeRF_GUI_v1.HelpersForms
{
    public partial class UC_HareketDosyaSec : UserControl
    {
    
        private C_SimulasyonYardimci _sim_cfg;
        public UC_HareketDosyaSec(C_SimulasyonYardimci sim_cfg)
        {
            InitializeComponent();
            _sim_cfg = sim_cfg;       
        }

        private void Kullanici_hareket_dosyasi_sec_button_Click(object sender, EventArgs e)
        {
            if (neu_checkbox.Checked)
            {
                _sim_cfg.sim_llh = llh_textbox.Text;
                _sim_cfg.sim_statik_konum_modu = true;
                kullanici_hareket_dosyasi_sec_button.Enabled = false;
            }
            if (nmea_checkbox.Checked)
            {
                _sim_cfg.sim_statik_konum_modu = false;
                _sim_cfg.sim_kullanici_hareketi_dosya_yolu = _sim_cfg.dosya_secici();
                kullanici_hareket_dosya_yolu_label.Text = _sim_cfg.sim_kullanici_hareketi_dosya_yolu;
            } 
        }

        private void Google_button_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_google_earth, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_google_earth,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }

        private void Satgen_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.sim_satgen,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Nmea_info_button_Click(object sender, EventArgs e)
        {
            F_BilgilendirmeKutucugu bilgiFormu = new F_BilgilendirmeKutucugu("NMEA Oluşturma Adımları", "buraya yaz"," buraya yaz");
            bilgiFormu.ShowDialog();
        }

        private void Nmea_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (nmea_checkbox.Checked)
            {
                kullanici_hareket_dosya_yolu_label.Visible      = true;
                kullanici_hareket_dosyasi_sec_button.Enabled    = true;
                kullanici_hareket_dosyasi_sec_button.Text       = "Seç";
                llh_textbox.Enabled                             = false;
                _sim_cfg.sim_statik_konum_modu                  = false;
            }
            else
            {
                _sim_cfg.sim_statik_konum_modu = true;
            }

            if (neu_checkbox.Checked && nmea_checkbox.Checked)
            {
                MessageBox.Show($"Yalnızca birini seç ! ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kullanici_hareket_dosyasi_sec_button.Enabled    = false;
                kullanici_hareket_dosya_yolu_label.Visible      = true;
              
            }
                
        }

        private void Neu_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (neu_checkbox.Checked)
            {
                kullanici_hareket_dosya_yolu_label.Visible = false;
                kullanici_hareket_dosyasi_sec_button.Enabled = true;
                kullanici_hareket_dosyasi_sec_button.Text = "Onayla";
                llh_textbox.Enabled = true;
                _sim_cfg.sim_statik_konum_modu = true;
            }

            if (neu_checkbox.Checked && nmea_checkbox.Checked)
            {
                MessageBox.Show($"Yalnızca birini seç ! ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kullanici_hareket_dosyasi_sec_button.Enabled = false;
                kullanici_hareket_dosya_yolu_label.Visible = true;
            }
        }

        private void Nmeagen_git_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_nmeagen,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Llh_textbox_TextChanged(object sender, EventArgs e)
        {
            kullanici_hareket_dosyasi_sec_button.Enabled = true;
        }
    }
}
