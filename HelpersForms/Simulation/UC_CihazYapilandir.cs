using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bladeRF_GUI_v1.HelpersForms
{
    public partial class UC_CihazYapilandir : UserControl
    {
        private C_SimulasyonYardimci _sim_cfg;
        private Process process = new Process();
        public UC_CihazYapilandir(C_SimulasyonYardimci sim_cfg)
        {
            InitializeComponent();
         
            _sim_cfg = sim_cfg;
            cihaz_model_combobox.SelectedIndex = 1;
            guncelle();

        }
        public void guncelle()
        {

            // To Do : Cihazı kullan sekmesi tam detaylı basit bir arayüzde yapılacak. Bu yardımcının amacına uymadığı için buraya koyulmayacaktır.
            //if (Directory.Exists(_sim_cfg.galileo_cikti_klasor_yolu))
            //{
            //    string[] files = Directory.GetFiles(_sim_cfg.galileo_cikti_klasor_yolu); // Dosyaları al.
            //    foreach (string file in files)
            //    {
            //        calisacak_dosya_adi_combobox.Items.Add(Path.GetFileName(file)); // Sadece dosya adını ekle.
            //    }
            //}

            // -----simdilik -----
            if (_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
            {
                calistirilacak_dosya_adi_textbox.Text = _sim_cfg.sim_csv_cikti_dosya_adi;
            }
            else if (_sim_cfg.gps_aktif && !_sim_cfg.galileo_aktif)
            {
                calistirilacak_dosya_adi_textbox.Text = _sim_cfg.gps_cikti_dosya_adi;
            }
            else if (!_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
            {
                calistirilacak_dosya_adi_textbox.Text = _sim_cfg.galileo_cikti_dosya_adi;
            }
        }
        private async void Cihaz_ac_button_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    // BladeRF komutunu çalıştır ve çıktıları işle
                    _sim_cfg.bladerf_komut_isleyicisi_dinamik("open", "-e", (output) =>
                    {
                        // Çıktıları GUI'ye eklemek için thread-safe şekilde yazdırıyoruz
                        this.Invoke((MethodInvoker)(() =>
                        {
                            cikti_yaz("open", output);
                        }));
                    });

                });
            }
            catch (Exception ex)
            {
                // Hata durumunu kullanıcıya bildirin
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Cihaz_kur_picbox_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; 

            StringBuilder commandBuilder = new StringBuilder();

            commandBuilder.Append("open;");
            commandBuilder.Append($"set frequency {ParseValueWithUnit(_sim_cfg.bladerf_frekans)};");
            commandBuilder.Append($"set samplerate {ParseValueWithUnit(_sim_cfg.bladerf_ornekleme_frekansi)};");
            commandBuilder.Append($"set bandwidth {ParseValueWithUnit(_sim_cfg.bladerf_bant_genisligi)};");

           
            if (cihaz_model_combobox.SelectedIndex == 1) // bladeRF v2
            {
                if (_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
                {
                    commandBuilder.Append($"set gain tx1 {_sim_cfg.bladerf_anten_kazanci};");
                    commandBuilder.Append($"set gain tx2 {_sim_cfg.bladerf_anten_kazanci};");
                    string format;                  
                    if (Path.GetExtension(_sim_cfg.sim_csv_cikti_dosya_adi).ToLower() == ".bin")
                    {
                        format = "bin";
                    }
                    else if (Path.GetExtension(_sim_cfg.sim_csv_cikti_dosya_adi).ToLower() == ".csv")
                    {
                        format = "csv";
                    }
                    else
                    {      
                        MessageBox.Show("Hatalı dosya formatı! Yalnızca .bin veya .csv uzantıları destekleniyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Komut oluşturma //  cift destek in to do
                    commandBuilder.Append($"tx config file={_sim_cfg.galileo_cikti_klasor_yolu}\\{_sim_cfg.sim_csv_cikti_dosya_adi} format={format} repeat={_sim_cfg.bladerf_tekrar} channel=1,2;");
                   
                }
                else if (_sim_cfg.gps_aktif && !_sim_cfg.galileo_aktif)
                {
                    commandBuilder.Append($"set gain tx1 {_sim_cfg.bladerf_anten_kazanci};");
                    commandBuilder.Append($"tx config file={_sim_cfg.gps_cikti_klasor_yolu}\\{_sim_cfg.gps_cikti_dosya_adi} format=bin repeat={_sim_cfg.bladerf_tekrar} channel=1;");
                }
                else if (!_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
                {

                    commandBuilder.Append($"set gain tx1 {_sim_cfg.bladerf_anten_kazanci};");
                    commandBuilder.Append($"tx config file={_sim_cfg.galileo_cikti_klasor_yolu}\\{_sim_cfg.galileo_cikti_dosya_adi} format=bin repeat={_sim_cfg.bladerf_tekrar} channel=1;");
                }
            }


            else // bladeRF v1
            {
                if (_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
                {
                    MessageBox.Show("Geçersiz cihaz modeli seçildi! 2 uydu yayını için 2 kanallı bir cihaz gerekmektedir!\n Tek kanalda varsayılan TX1 çıkışı kullanılır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_sim_cfg.gps_aktif && !_sim_cfg.galileo_aktif)
                {
                    commandBuilder.Append($"set txvga1 {_sim_cfg.bladerf_anten_kazanci};");
                    commandBuilder.Append($"tx config file={_sim_cfg.gps_cikti_klasor_yolu}\\{_sim_cfg.gps_cikti_dosya_adi} format=bin;");
                }
                else if (!_sim_cfg.gps_aktif && _sim_cfg.galileo_aktif)
                {
                    commandBuilder.Append($"set txvga1 {_sim_cfg.bladerf_anten_kazanci};");
                    commandBuilder.Append($"tx config file={_sim_cfg.galileo_cikti_klasor_yolu}\\{_sim_cfg.galileo_cikti_dosya_adi} format=bin;");
                }
            }
            commandBuilder.Append($"tx wait;");
            commandBuilder.Append($"tx start;");
            commandBuilder.Append($"tx wait;");

            string allCommands = commandBuilder.ToString();

            Console.WriteLine(allCommands);

            var (result, arguments) = await _sim_cfg.CLI_isleyici_statik(allCommands, "", "",process);
            cikti_yaz(arguments, result);

            cihaz_bilgisi_richtextbox.SelectionStart = cihaz_bilgisi_richtextbox.Text.Length;
            cihaz_bilgisi_richtextbox.ScrollToCaret();
            Cursor = Cursors.Default;
        }




        private void cikti_yaz(string argumanlar, string cikti)
        {
            cihaz_bilgisi_richtextbox.SelectionColor = Color.Red;
            cihaz_bilgisi_richtextbox.AppendText(argumanlar + Environment.NewLine);

            cihaz_bilgisi_richtextbox.SelectionColor = Color.Black;
            cihaz_bilgisi_richtextbox.AppendText(cikti + Environment.NewLine);
        }

        private static string ParseValueWithUnit(string input)
        {
            char unit = input.Last();

            if (char.IsDigit(unit) || unit == '-' || unit == '.')
            {
                return input;
            }

            double value = double.Parse(input.Substring(0, input.Length - 1).Trim());

            switch (unit)
            {
                case 'M':
                    value *= 1_000_000;
                    break;
                case 'k':
                    value *= 1_000;
                    break;
                case 'G':
                    value *= 1_000_000_000;
                    break;
                case 'T':
                    value *= 1_000_000_000_000;
                    break;
                default:
                    break;
            }

            return value.ToString();
        }

        private void Frequency_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_frekans = frequency_textbox.Text;
        }

        private void Samplerate_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_ornekleme_frekansi = samplerate_textbox.Text;
        }

        private void Bandwidth_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_bant_genisligi = bandwidth_textbox.Text;
        }

        private void Tx_gain_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_anten_kazanci = tx_gain_textbox.Text;
        }

        private void bladerf_tekrar_sayisi_textbox_TextChanged(object sender, EventArgs e)
        {
            _sim_cfg.bladerf_tekrar = bladerf_tekrar_sayisi_textbox.Text;
        }
    }
}
