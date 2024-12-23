using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bladeRF_GUI_v1.Classes
{
    class C_CLI
    {
        private C_Ayarlar _ayarlar;
        public C_CLI(C_Ayarlar ayarlar)
        {
            _ayarlar = ayarlar;
        }

        public async Task<(string result, string arguments)> CLI_isleyici_statik(string komut, string istemci)
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = _ayarlar.prog_cmd_dosya_yolu;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                // Komutları ayarlıyoruz
                switch (istemci)
                {
                    case ("CMD"):
                        process.StartInfo.Arguments = $"/c {komut}";
                        break;
                    case ("BladeRF"):
                        process.StartInfo.Arguments = $"/c {_ayarlar.bladerf_cli_dosya_yolu}  -e {komut}";
                        break;
                    case ("Program"):
                        process.StartInfo.CreateNoWindow = false;
                        process.StartInfo.Arguments = $"/c {_ayarlar.bladerf_cli_dosya_yolu} -i ";
                        break;
                    case ("GPS"):
                        process.StartInfo.Arguments = $"/c {_ayarlar.gps_cli_dosya_yolu} {komut}";
                        break;
                    case ("Galileo"):
                        process.StartInfo.Arguments = $"/c {_ayarlar.galileo_cli_dosya_yolu} {komut}";
                        break;
                    case ("Repeater"):
                        process.StartInfo.Arguments = $"/c {_ayarlar.repeater_cli_dosya_yolu} {komut}";
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Starting process: " + process.StartInfo.FileName);
                Console.WriteLine("Arguments: " + process.StartInfo.Arguments);
       
                process.Start();

                string output = "";
                string error = "";

     
                Task outputTask = Task.Run(() => { output = process.StandardOutput.ReadToEnd(); });
                Task errorTask = Task.Run(() => { error = process.StandardError.ReadToEnd(); });
      
                await Task.WhenAll(outputTask, errorTask);  
              
                string result = string.IsNullOrEmpty(output) ? error : output;

                return (result, process.StartInfo.Arguments);
            }
            catch (Exception ex)
            {
                return ($"Hata: {ex.Message}", $"{istemci} {komut}");
            }
        }

    }
}
