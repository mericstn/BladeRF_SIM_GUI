using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bladeRF_GUI_v1.UserControls
{
    public partial class UC_Ayarlar : UserControl
    {
        private Ayarlar _ayarlar;
        public UC_Ayarlar(Ayarlar ayarlar)
        {
            _ayarlar = ayarlar;
            InitializeComponent();
            satgen_label.Text        = _ayarlar.program_satgen;
            sdrconsole_label.Text    = _ayarlar.program_sdr_console;
            ezusb_label.Text         = _ayarlar.program_ez_usb;
            gpif2_label.Text         = _ayarlar.program_gpif2;
            gnuradio_label.Text      = _ayarlar.program_gnu_radio;
            gpssim_label.Text        = _ayarlar.gps_cli_dosya_yolu;
            galileosim_label.Text    = _ayarlar.galileo_cli_dosya_yolu;
            bladerf_label.Text       = _ayarlar.bladerf_cli_dosya_yolu;
            cmd_label.Text           = _ayarlar.prog_cmd_dosya_yolu;

        }

        private void Satgen_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.program_satgen = _ayarlar.dosya_secici();
        }

        private void Sdrconsole_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.program_sdr_console = _ayarlar.dosya_secici();
        }

        private void Ezusb_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.program_ez_usb = _ayarlar.dosya_secici();
        }

        private void Gpif2_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.program_gpif2 = _ayarlar.dosya_secici();
        }

        private void Gnuradio_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.program_gnu_radio = _ayarlar.dosya_secici();
        }

        private void Gpssim_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.gps_cli_dosya_yolu = _ayarlar.dosya_secici();
        }

        private void Galileo_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.galileo_cli_dosya_yolu = _ayarlar.dosya_secici();
        }

        private void Bladerf_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.bladerf_cli_dosya_yolu = _ayarlar.dosya_secici();
        }

        private void Cmd_sec_button_Click(object sender, EventArgs e)
        {
            _ayarlar.prog_cmd_dosya_yolu = _ayarlar.dosya_secici();
        }
    }
}
