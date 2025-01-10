using bladeRF_GUI_v1.UserControls;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

// chat_gpt ile olusturulmustur !!!
namespace bladeRF_GUI_v1.ApplicationUserControls
{
    public partial class UC_Interaktif_Tekrarlayici : UserControl
    {
        private C_Ayarlar c_ayarlar;
        private Process cliProcess;

        public UC_Interaktif_Tekrarlayici(C_Ayarlar _ayarlar)
        {
            c_ayarlar = _ayarlar;
            InitializeComponent();
        }
      
        private void baslat_button_Click(object sender, EventArgs e)
        {
            if (cliProcess != null && !cliProcess.HasExited)
            {
                MessageBox.Show("CLI zaten çalışıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cliProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = $"{c_ayarlar.prog_cmd_dosya_yolu}",
                        Arguments = $"/k {c_ayarlar.repeater_interaktif_cli_dosya_yolu}",  
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = false  
                    }
                };

                cliProcess.Start();
                MessageBox.Show("CLI başlatıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CLI başlatılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tx_arttir_button_Click(object sender, EventArgs e)
        {
            SendCommandToCLI("2"); // TX Gain artırma
        }

        private void tx_azalt_button_Click(object sender, EventArgs e)
        {
            SendCommandToCLI("1"); // TX Gain azaltma
        }

        private void rx_arttir_button_Click(object sender, EventArgs e)
        {
            SendCommandToCLI("4"); // RX Gain artırma
        }

        private void rx_azalt_button_Click(object sender, EventArgs e)
        {
            SendCommandToCLI("3"); // RX Gain azaltma
        }

        private void yardim_button_Click(object sender, EventArgs e)
        {
            SendCommandToCLI("h"); // Yardım komutu
        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            try
            {
                SendCommandToCLI("q"); // CLI çıkış komutu

                if (cliProcess != null && !cliProcess.HasExited)
                {
                    cliProcess.Kill();
                    cliProcess.Dispose();
                    cliProcess = null;
                }

                MessageBox.Show("CLI kapatıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CLI kapatılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendCommandToCLI(string command)
        {
            if (cliProcess == null || cliProcess.HasExited)
            {
                MessageBox.Show("CLI çalışmıyor. Önce CLI'yi başlatın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cliProcess.StandardInput.WriteLine(command);
                cliProcess.StandardInput.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Komut gönderilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
