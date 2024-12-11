using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace bladeRF_GUI_v1.HelpersForms
{
    public partial class UC_EfemerisSec : UserControl
    {
        private C_SimulasyonYardimci _sim_cfg;
       
        public UC_EfemerisSec(C_SimulasyonYardimci sim_cfg)
        {
            InitializeComponent();
            _sim_cfg = sim_cfg;
       
            gps_rinex_dosya_yolu_label.Text = _sim_cfg.gps_rinex2_dosya_yolu;
            galileo_vector_dosya_yolu_label.Text = _sim_cfg.galileo_vector_dosya_yolu;
           
        }

        private void Gps_rinex_dosya_sec_button_Click(object sender, EventArgs e)
        {
            _sim_cfg.gps_rinex2_dosya_yolu = _sim_cfg.dosya_secici();
            gps_rinex_dosya_yolu_label.Text = _sim_cfg.gps_rinex2_dosya_yolu;
        }

        private void Galileo_vector_dosya_sec_button_Click(object sender, EventArgs e)
        {
            _sim_cfg.galileo_vector_dosya_yolu = _sim_cfg.dosya_secici();
            galileo_vector_dosya_yolu_label.Text = _sim_cfg.galileo_vector_dosya_yolu;
        }

        private void Gps_indir_button_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_gps_efemeris_indirme_yolu, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_gps_efemeris_indirme_yolu,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }

        private void Galileo_indir_button_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_galileo_efemeris_indirme_yolu, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_galileo_efemeris_indirme_yolu,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }

        private void Gps_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (gps_checkbox.Checked)
            {
                gps_rinex_dosya_sec_button.Enabled = true;
                _sim_cfg.gps_aktif                 = true;
            }
            else
            {
                gps_rinex_dosya_sec_button.Enabled = false;
                _sim_cfg.gps_aktif                 = false;
            }

            if(gps_checkbox.Checked && galileo_checkbox.Checked)
                MessageBox.Show($"İki uydu için 2 Kanallı bir cihaz gerekmektedir! \n- BladeRF 2.0 ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Galileo_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (galileo_checkbox.Checked)
            {
                galileo_vector_dosya_sec_button.Enabled = true;
                _sim_cfg.galileo_aktif                  = true;
            }
            else
            {
                galileo_vector_dosya_sec_button.Enabled = false;
                _sim_cfg.galileo_aktif                  = false;
            }


            if (gps_checkbox.Checked && galileo_checkbox.Checked)
                MessageBox.Show($"İki uydu için 2 Kanallı bir cihaz gerekmektedir! \n- BladeRF 2.0 ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Gps_info_button_Click_1(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_gps_efemeris_bilgi_yolu, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_gps_efemeris_bilgi_yolu,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }

        private void Galileo_info_button_Click_1(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_galileo_efemeris_bilgi_yolu, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.prog_galileo_efemeris_bilgi_yolu,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }
    }
}
