using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bladeRF_GUI_v1.HelpersForms
{
    public class C_SimulasyonYardimci
    {

        /*-------------- Dizinler----------------------*/

        public string program_dizini;

        public string sim_satgen { get; set;}
        // digerleri gelecek....

        public string gps_rinex2_dosya_yolu             { get; set; }
        public string gps_cikti_klasor_yolu             { get; set; }
        public string gps_cli_dosya_yolu                { get; set; }

        public string galileo_vector_dosya_yolu         { get; set; }
        public string galileo_cikti_klasor_yolu         { get; set; }
        public string galileo_cli_dosya_yolu            { get; set; }

        public string sim_csv_cikti_dosya_adi           { get; set; } = "gpsgal.bin"; // csv kaldırıldı

        public string bladerf_cli_dosya_yolu            { get; set; }
        public string bladerf_script_dosya_yolu         { get; set; }
        public string bladerf_fpga_dosya_yolu           { get; set; }
        public string bladerf_firmware_dosya_yolu       { get; set; }

        public string prog_cmd_dosya_yolu               { get; set; } = @"C:\Windows\system32\cmd.exe";
        public string prog_python_script_dosya_yolu     { get; set; }

        public C_SimulasyonYardimci()
        {
            program_dizini                  = AppDomain.CurrentDomain.BaseDirectory; // C:\Users\PC_3740\Desktop\GYT_MericSetan_GuzDonemi_Staj\Calismalar\Blade_RF\bladerf_gui_vers\bladeRF_GUI_v1\bin\Debug\

            sim_satgen                      = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "SatgenNMEA", "SatGenNMEA.exe"));

            gps_rinex2_dosya_yolu           = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Inputs", "GPSBroadcasts","brdc3480.20n"));
            gps_cikti_klasor_yolu           = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Outputs"));
            gps_cli_dosya_yolu              = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "SimpleCode", "x64", "Release", "SimpleCode.exe"));

            galileo_vector_dosya_yolu       = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Inputs", "GalileoBroadcasts","13_DEC_2020_GST_09_00_01_fixed.csv"));
            galileo_cikti_klasor_yolu       = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Outputs"));
            galileo_cli_dosya_yolu          = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "gal_osnma_sim_dinamik", "x64", "Debug", "gal_osnma_sim_dinamik.exe"));

            bladerf_cli_dosya_yolu          = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "bladeRF", "x64", "bladeRF-cli.exe"));
            bladerf_script_dosya_yolu       = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Outputs", "command.script"));
            bladerf_firmware_dosya_yolu     = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Inputs", "BladeRF", "bladeRF_fw_latest.img"));
            bladerf_fpga_dosya_yolu         = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Inputs", "BladeRF", "hostedxA4-latest.rbf"));

            prog_python_script_dosya_yolu   = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "PythonScripts", "combine_binbin.py"));

        }
        /*-------------- Simulasyon----------------------*/
        public string   sim_kullanici_hareketi_dosya_yolu   { get; set; } 
        public string   sim_llh                             { get; set; } = "";
        public string   sim_simulasyon_suresi               { get; set; } = "100";
        public string   sim_ornekleme_frekansi              { get; set; } = "2.6M";
        public bool     sim_statik_konum_modu               { get; set; } = true;
       
        /*-------------- GPS----------------------*/
        public bool gps_aktif                   { get; set; }
        public bool gps_iyonosferik_gecikme     { get; set; }
        public string gps_cikti_dosya_adi       { get; set; } = "gpssim.bin";

        /*-------------- Galileo----------------------*/
        public bool   galileo_aktif                   { get; set; }
        public bool   galileo_iyonosferik_gecikme     { get; set; }
        public string galileo_cikti_dosya_adi         { get; set; } = "galsim.bin";
        /*------------BladeRF-----------------------*/
     
        public string bladerf_anten_kazanci         { get; set; } = "-25";
        public string bladerf_ornekleme_frekansi    { get; set; } = "2.6M";
        public string bladerf_bant_genisligi        { get; set; } = "5.2M";
        public string bladerf_frekans               { get; set; } = "1575420000";
        public string bladerf_tekrar               { get; set; } = "1";
        public string bladerf_fpga_bilgi            { get; set; } = "https://www.nuand.com/fpga_images/";
        public string bladerf_fw_bilgi              { get; set; } = "https://www.nuand.com/fx3_images/";
        /*------------Porgram-------------------*/
        public string prog_gps_efemeris_bilgi_yolu          { get; set; } = "http://walter.bislins.ch/bloge/index.asp?page=Understanding+GPS%2FGNSS+RINEX+Files+and+Relevant+Parameters";
        public string prog_gps_efemeris_indirme_yolu        { get; set; } = "https://urs.earthdata.nasa.gov/oauth/authorize?client_id=gDQnv1IO0j9O2xXdwS8KMQ&response_type=code&redirect_uri=https%3A%2F%2Fcddis.nasa.gov%2Fproxyauth&state=aHR0cDovL2NkZGlzLm5hc2EuZ292L2FyY2hpdmUvZ3BzL2RhdGEvZGFpbHkvMjAyMS8xNzEvMjFuLw";
        public string prog_galileo_efemeris_bilgi_yolu      { get; set; } = "https://www.gsc-europa.eu/gsc-products/galileo-rinex-navigation-parameters";
        public string prog_galileo_efemeris_indirme_yolu    { get; set; } = "https://github.com/Algafix/OSNMA/blob/master/tests/icd_test_vectors/reformat_test_vectors.py"; // henüz yok
        public string prog_google_earth { get; set; } = "https://earth.google.com/web/@40.84970929,28.90104147,-24.43085017a,337734.06304982d,35y,14.87951678h,1.18511282t,0r/data=CgRCAggBQgIIAEoNCP___________wEQAA";
        public string prog_nmeagen { get; set; } = "https://nmeagen.org/";


        public string Gps_komut_olustur()
        {

            string gps_komut = "";
            string iyono     = this.gps_iyonosferik_gecikme ? "1" : "0";

            if (this.sim_statik_konum_modu)
                gps_komut = $"-e {this.gps_rinex2_dosya_yolu} -l {this.sim_llh} -o {this.gps_cikti_klasor_yolu}\\{this.gps_cikti_dosya_adi} -d {this.sim_simulasyon_suresi} -i {iyono} -s {ParseValueWithUnit(this.sim_ornekleme_frekansi)} ";
            else
                gps_komut = $"-e {this.gps_rinex2_dosya_yolu} -u {this.sim_kullanici_hareketi_dosya_yolu} -o {this.gps_cikti_klasor_yolu}\\{this.gps_cikti_dosya_adi} -d {this.sim_simulasyon_suresi} -i {iyono} -s {ParseValueWithUnit(this.sim_ornekleme_frekansi)} ";

            return gps_komut; 
        }


        public string Galileo_komut_olustur()
        {

            string galileo_komut = "";
            string iyono         = this.galileo_iyonosferik_gecikme ? "1" : "0";


            /*-------------------- galileo simulasyonunda statik konum modu var yalnızca. İleride ekmele yapılacak.*/
            if (this.sim_statik_konum_modu)
                galileo_komut = $"-v {this.galileo_vector_dosya_yolu} -l {this.sim_llh} -o {this.galileo_cikti_klasor_yolu}\\{this.galileo_cikti_dosya_adi} -d {this.sim_simulasyon_suresi} -i {iyono} -s {ParseValueWithUnit(this.sim_ornekleme_frekansi)} ";
            else
                galileo_komut = $"-v {this.galileo_vector_dosya_yolu} -g {this.sim_kullanici_hareketi_dosya_yolu} -o {this.galileo_cikti_klasor_yolu}\\{this.galileo_cikti_dosya_adi} -d {this.sim_simulasyon_suresi} -i {iyono} -s {ParseValueWithUnit(this.sim_ornekleme_frekansi)} ";

            return galileo_komut;
        }

        public string python_komut_olustur()
        {

            string python_komut = "";

            python_komut = $" python {this.prog_python_script_dosya_yolu} {this.galileo_cikti_klasor_yolu}\\{this.galileo_cikti_dosya_adi} {this.gps_cikti_klasor_yolu}\\{this.gps_cikti_dosya_adi} {this.galileo_cikti_klasor_yolu}\\{this.sim_csv_cikti_dosya_adi}"; 
            return python_komut;
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

        public void cmd_cli_isleyici(string komut, Action<string> outputHandler)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = this.prog_cmd_dosya_yolu;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = $"/c {komut}";

                process.OutputDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);
                process.ErrorDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                outputHandler?.Invoke($"Hata: {ex.Message}");
            }
        }

        public void gps_cli_isleyici_dinamik(string sdrsim_komut, Action<string> outputHandler)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = this.prog_cmd_dosya_yolu;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = $"/c {this.gps_cli_dosya_yolu} {sdrsim_komut}";

                process.OutputDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);
                process.ErrorDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                outputHandler?.Invoke($"Hata: {ex.Message}");
            }
        }

        public void galileo_cli_isleyici_dinamik(string sdrsim_komut, Action<string> outputHandler)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = this.prog_cmd_dosya_yolu;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = $"/c {this.galileo_cli_dosya_yolu} {sdrsim_komut}";

                process.OutputDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);
                process.ErrorDataReceived += (sender, args) => outputHandler?.Invoke(args.Data);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                outputHandler?.Invoke($"Hata: {ex.Message}");
            }
        }

        public async Task<(string result, string arguments)> CLI_isleyici_statik(string komut, string istemci,string komut_ayar, Process process )
        {
            try
            {
              
                process.StartInfo.FileName = this.bladerf_cli_dosya_yolu;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = $"-e  \"{komut}\"";
                

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


        public (string result, string arguments) bladerf_komut_isleyicisi(string bladerf_komut, string komut_ayar)
        {

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = this.bladerf_cli_dosya_yolu;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = $"{komut_ayar} {bladerf_komut}";

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();
                string result = string.IsNullOrEmpty(output) ? error : output;

                return (result, process.StartInfo.Arguments);


            }
            catch (Exception ex)
            {
                return ($"Hata: {ex.Message}", $"{komut_ayar} {bladerf_komut}");
            }
        }
        public void bladerf_komut_isleyicisi_dinamik(string bladerf_komut, string komut_ayar, Action<string> outputHandler)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo =
            {
                FileName = this.bladerf_cli_dosya_yolu,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                Arguments = $"{komut_ayar} {bladerf_komut}"
            }
                };  
                process.OutputDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(args.Data))
                        outputHandler?.Invoke(args.Data);
                };

                process.ErrorDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(args.Data))
                        outputHandler?.Invoke(args.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                outputHandler?.Invoke($"Hata: {ex.Message}");
            }
        }






        public string dosya_secici()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Bir Dosya Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return "Hatalı dosya !";

        }
        public string klasor_secici()
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Bir Klasör Seçin";
                folderBrowserDialog.ShowNewFolderButton = true;


                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderBrowserDialog.SelectedPath;
                }
            }

            return "Hatalı dizin!";
        }




    }



}

/*
 SimpleCode.exe

Secenekler:
  -e<gps_nav> GPS ephemeris verileri icin RINEX navigasyon dosyasi(gerekli)
  -u<kullanici_hareketi> ECEF x, y, z formatinda kullanici hareket dosyasi(dinamik mod)
  -g<nmea_gga> NMEA GGA akisi(dinamik mod)
  -c<konum> ECEF X,Y,Z cinsinden(statik mod) ornegin 3967283.15,1022538.18,4872414.48
  -l<konum> Enlem, Boylam, Yukseklik (statik mod) ornegin 30.286502,120.032669,100
  -L<wnslf, dn, dtslf> Kullanici leap gelecekteki olay icin GPS hafta numarasi, gun numarasi, bir sonraki leap saniye ornegin 2347,3,19
  -t<tarih, saat> Senaryo baslangic zamani YYYY/MM/DD,hh:mm:ss
  -T<tarih, saat> TOC ve TOE'yi senaryo baslangic zamani ile gecersiz kil
  -d<sure> Sure[sn] (dinamik mod max: 300, statik mod max: 86400)
  -o<cikis> I/Q ornekleme veri dosyasi(varsayilan: gpssim.bin ; stdout icin - kullanin)
  -s<frekans> Ornekleme frekansi[Hz] (varsayilan: 2600000)
  -b<iq_bits> I/Q veri formati[1 / 8 / 16] (varsayilan: 16)
  -i Uzay araci senaryosu icin iyonosfer gecikmesini devre disi birak
  -p[sabit_guc] Yolda kayiplari devre disi birak ve guc seviyesini sabit tut
  -v Simule edilen kanallar hakkinda ayrintilari goster */



/*
Usage:
-v <testvector>       Test vector file.
-l <location>         Lat,Lon,Alt (default. 48.8435155,2.4297700,60).
-o <output>           I/Q sampling data file (default: osnma.bin).
-s <frequency>        Sampling frequency [Hz] (default: 2600000).
-b <iq_bits>          I/Q data format [8/16] (default: 8).
-d <duration>         Scenario duration [s] (default : 0 -> whole scenario duration).
-h                    Help.

Example:
./gal-osnma-sim -l 48.8435155,2.4297700,60 -t ./tv/configuration_A/13_DEC_2020_GST_09_00_01_fixed.csv -k
*/