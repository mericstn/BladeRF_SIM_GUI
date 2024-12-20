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
using System.IO;

namespace bladeRF_GUI_v1.UserControls
{
    public partial class UC_Programlar : UserControl
    {
        private Ayarlar _ayarlar;
        
        public UC_Programlar(Ayarlar ayarlar)
        {
            _ayarlar = ayarlar;

            InitializeComponent();

        }

        private void Program_sdr_console_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _ayarlar.program_sdr_console,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Program_satgen_nmea_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _ayarlar.program_satgen,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Program_ez_usb_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _ayarlar.program_ez_usb,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Program_gpif2_button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _ayarlar.program_gpif2,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private async void Program_gnu_radio_Click(object sender, EventArgs e)
        {
            try
            {
                // Process'i oluştur
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = _ayarlar.program_gnu_radio_python, // python.exe'nin yolu
                        Arguments = $"{_ayarlar.program_gnu_radio_cwp} {Path.GetDirectoryName(_ayarlar.program_gnu_radio_python)} {_ayarlar.program_gnu_radio}", // cwp.py ile gnuradio-companion çalıştırma
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = false // Konsolu görmek için false
                    }
                };

                // Process'i başlat
                process.Start();

                // Standart çıktıyı ve hatayı asenkron olarak oku
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                // Process'in tamamlanmasını bekle
                process.WaitForExit();

                // Çıktıları ekrana veya uygun yere yazdır
                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Çıktı:");
                    Console.WriteLine(output);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Hata:");
                    Console.WriteLine(error);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunu yakala ve bildir
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                MessageBox.Show($"Program çalıştırılamadı:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Program_bladerf_cli_button_ClickAsync(object sender, EventArgs e)
        {
            try 
            {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = _ayarlar.bladerf_cli_dosya_yolu,
                    Arguments = "-i",

                    UseShellExecute = false,
                    CreateNoWindow = false // Konsol penceresi gösterimi
                }
            };

            process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program çalıştırılamadı: {ex.Message}");
            }
        }

        private void Site_nmeagen_button_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(_ayarlar.site_nmea_gen, UriKind.Absolute))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = _ayarlar.site_nmea_gen,
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
