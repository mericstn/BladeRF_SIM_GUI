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
using bladeRF_GUI_v1.Classes;

namespace bladeRF_GUI_v1.UserControls
{
    public partial class UC_CLI : UserControl
    {
        private Ayarlar _ayarlar;
        private C_CLI _cli;
        public UC_CLI(Ayarlar ayarlar)
        {

            _ayarlar = ayarlar;
            _cli = new C_CLI(_ayarlar);
            InitializeComponent();

        }

        private async void Cmd_gonder_button_Click(object sender, EventArgs e)
        {
            cmd_gonder_button.Enabled = false;
            var (result, arguments) = await _cli.CLI_isleyici_statik(cmd_komut_girdi_richtextbox.Text, "CMD");

            cmd_richtextbox.SelectionColor = Color.MidnightBlue;
            cmd_richtextbox.AppendText("CMD$ " + arguments + Environment.NewLine);
            cmd_richtextbox.SelectionColor = Color.Black;

            cmd_richtextbox.AppendText(result);
            cmd_richtextbox.SelectionStart = bladerf_richtextbox.Text.Length;

            cmd_richtextbox.ScrollToCaret();

            cmd_gonder_button.Enabled = true;
        }
        private void Cmd_temizle_button_Click(object sender, EventArgs e)
        {
            cmd_richtextbox.Clear();
        }

        private async void Bladerf_gonder_button_Click(object sender, EventArgs e)
        {
            bladerf_gonder_button.Enabled = false;
            var (result, arguments) = await _cli.CLI_isleyici_statik(bladerf_komut_girdi_richtextbox.Text, "BladeRF");

            bladerf_richtextbox.SelectionColor = Color.MidnightBlue;
            bladerf_richtextbox.AppendText("BladeRF-CLI$ " + arguments + Environment.NewLine);
            bladerf_richtextbox.SelectionColor = Color.Black;

            bladerf_richtextbox.AppendText(result);
            bladerf_richtextbox.SelectionStart = bladerf_richtextbox.Text.Length;

            bladerf_richtextbox.ScrollToCaret();
            bladerf_gonder_button.Enabled = true;
        }
        private void Bladerf_temizle_button_Click(object sender, EventArgs e)
        {
            bladerf_richtextbox.Clear();
        }

        private async void Galileo_gonder_button_Click(object sender, EventArgs e)
        {
            galileo_gonder_button.Enabled = false;

            var (result, arguments) = await _cli.CLI_isleyici_statik(galileo_komut_girdi_richtextbox.Text, "Galileo");

            galileo_richtextbox.SelectionColor = Color.MidnightBlue;
            galileo_richtextbox.AppendText("GAL_SIM$ " + arguments + Environment.NewLine);
            galileo_richtextbox.SelectionColor = Color.Black;

            galileo_richtextbox.AppendText(result);
            galileo_richtextbox.SelectionStart = bladerf_richtextbox.Text.Length;

            galileo_richtextbox.ScrollToCaret();

            galileo_gonder_button.Enabled = true;
        }
        private void Galileo_temizle_button_Click(object sender, EventArgs e)
        {
            galileo_richtextbox.Clear();
        }

        private async void Gps_gonder_button_Click(object sender, EventArgs e)
        {
            gps_gonder_button.Enabled = false;

            var (result, arguments) = await _cli.CLI_isleyici_statik(gps_komut_girdi_richtextbox.Text, "GPS");
     
            gps_richtextbox.SelectionColor = Color.MidnightBlue;
            gps_richtextbox.AppendText("GAL_SIM$ " + arguments + Environment.NewLine);
            gps_richtextbox.SelectionColor = Color.Black;

            gps_richtextbox.AppendText(result);
            gps_richtextbox.SelectionStart = bladerf_richtextbox.Text.Length;

            gps_richtextbox.ScrollToCaret();

            gps_gonder_button.Enabled = true;
          
        }
        private void Gps_temizle_button_Click(object sender, EventArgs e)
        {
            gps_richtextbox.Clear();
        }
       
    }
}


