using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace bladeRF_GUI_v1
{
    public class Ayarlar
    {
        public string program_dizini;

        /*-------------- Program Dizinleri----------------------*/
        public string program_satgen            { get; set; }
        public string program_sdr_console       { get; set; }
        public string program_ez_usb            { get; set; }
        public string program_gpif2             { get; set; }
        public string program_gnu_radio         { get; set; }
        public string program_gnu_radio_python  { get; set; }
        public string program_gnu_radio_cwp     { get; set; }
        public string site_nmea_gen             { get; set; } = "https://nmeagen.org/";


        // digerleri gelecek....

        /*-------------- CLI Dizinleri----------------------*/
        public string gps_cli_dosya_yolu        { get; set; }
        public string galileo_cli_dosya_yolu    { get; set; }
        public string bladerf_cli_dosya_yolu    { get; set; }
        public string repeater_cli_dosya_yolu    { get; set; }
        public string prog_cmd_dosya_yolu       { get; set; } = @"C:\Windows\system32\cmd.exe"; // C dizini icin Statik 

        public Ayarlar()
        {
            program_dizini   = AppDomain.CurrentDomain.BaseDirectory; // C:\Users\PC_3740\Desktop\GYT_MericSetan_GuzDonemi_Staj\Calismalar\Blade_RF\bladerf_gui_vers\bladeRF_GUI_v1\bin\Debug\

            program_satgen = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "SatgenNMEA", "SatGenNMEA.exe"));
           
            
            program_sdr_console = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "SDR_radio", "SDR Console.exe"));
            program_ez_usb = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "ez","Eclipse", "ezUsbSuite.exe"));
            program_gpif2 = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "ez","GPIFII Designer", "bin","cygraphicaltool.exe"));
            program_gnu_radio = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "radioconda", "Scripts", "gnuradio-companion.exe"));
            program_gnu_radio_python = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "radioconda", "python.exe"));
            program_gnu_radio_cwp = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "radioconda", "cwp.py"));

            gps_cli_dosya_yolu      = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "SimpleCode", "x64", "Release", "SimpleCode.exe"));
            galileo_cli_dosya_yolu  = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "gal_osnma_sim", "x64", "Debug", "gal_osnma_sim.exe"));
            bladerf_cli_dosya_yolu  = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "bladeRF", "x64", "bladeRF-cli.exe"));


            repeater_cli_dosya_yolu = Path.GetFullPath(Path.Combine(program_dizini, "..", "..", "Programs", "bladeRF", "x64", "bladeRF-cli.exe")); // duzenlenecek



        }
        public string dosya_secici()
        {

            OpenFileDialog openFileDialog   = new OpenFileDialog();
            openFileDialog.Title            = "Bir Dosya Seçin";

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
                folderBrowserDialog.Description           = "Bir Klasör Seçin";
                folderBrowserDialog.ShowNewFolderButton   = true; 

                
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderBrowserDialog.SelectedPath; 
                }
            }

            return "Hatalı dizin!";
        }


    }
}
