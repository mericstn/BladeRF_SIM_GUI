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

namespace bladeRF_GUI_v1.HelpersForms.SetupDevice
{
    public partial class UC_FPGA : UserControl
    {
        private C_SimulasyonYardimci _sim_cfg;
        public UC_FPGA(C_SimulasyonYardimci sim_cfg)
        {
            _sim_cfg = sim_cfg;
            InitializeComponent();
            image_dosya_yolu.Text = _sim_cfg.bladerf_fpga_dosya_yolu;
        }

        private void Kalici_yukle_button_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show($"Dosya:\n{_sim_cfg.bladerf_fpga_dosya_yolu}", "Bu dosya ile cihazın güncellenmesini onaylıyor musunuz ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.Yes)
            {
                var (result, arguments) = _sim_cfg.bladerf_komut_isleyicisi(_sim_cfg.bladerf_fpga_dosya_yolu,"--flash-fpga");
                MessageBox.Show($"Komut:\n{arguments}\n\nSonuç:\n{result}", "bladeRF Komut Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Tek_sefer_yukle_button_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show($"Dosya:\n{_sim_cfg.bladerf_fpga_dosya_yolu}", "Bu dosya ile cihazın güncellenmesini onaylıyor musunuz ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.Yes)
            {
                var (result, arguments) = _sim_cfg.bladerf_komut_isleyicisi(_sim_cfg.bladerf_fpga_dosya_yolu,"--load-fpga");
                MessageBox.Show($"Komut:\n{arguments}\n\nSonuç:\n{result}", "bladeRF Komut Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Bilgi_button_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_sim_cfg.prog_gps_efemeris_bilgi_yolu, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _sim_cfg.bladerf_fpga_bilgi,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Geçersiz URL!");
            }
        }

        private void İmage_sec_button_Click(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_fpga_dosya_yolu = _sim_cfg.dosya_secici();
            image_dosya_yolu.Text = _sim_cfg.bladerf_fpga_dosya_yolu;
        }
    }
}
