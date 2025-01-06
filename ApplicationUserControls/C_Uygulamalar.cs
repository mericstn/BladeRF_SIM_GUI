using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bladeRF_GUI_v1.ApplicationUserControls
{
    public class C_Uygulamalar
    {

        public string cihaz_model           { get; set; } = "BladeRF v2.0";
        public string prog_sure             { get; set; } = "120";
        // struct tanimlanabilir !!!
        /*-------------------------TX KANAL---------------------------------------*/
        public string kanal_tx_frekans          { get; set; } = "1575420000";
        public string kanal_tx_ornekleme_orani  { get; set; } = "12000000";
        public string kanal_tx_bant_genisligi   { get; set; } = "50000000";
        public string kanal_tx_anten_kazanci    { get; set; } = "45";
        public string kanal_tx_zaman_asimi      { get; set; } = "500";
        public string kanal_tx_biastee          { get; set; } = "Kapali";
        public string kanal_tx_kanal            { get; set; } = "TX1";
   

        /*-------------------------RX KANAL---------------------------------------*/
        public string kanal_rx_frekans          { get; set; } = "1575420000";
        public string kanal_rx_ornekleme_orani  { get; set; } = "12000000";
        public string kanal_rx_bant_genisligi   { get; set; } = "50000000";
        public string kanal_rx_anten_kazanci    { get; set; } = "45";
        public string kanal_rx_zaman_asimi      { get; set; } = "500";
        public string kanal_rx_biastee          { get; set; } = "Kapali";
        public string kanal_rx_kanal            { get; set; } = "RX2";
   

        /*-------------------------RXTX MOD---------------------------------------*/
        public string rxtx_tampon_sayisi                { get; set; } = "32";
        public string rxtx_ornek_uzunlugu               { get; set; } = "32768";
        public string rxtx_tampon_boyutu                { get; set; } = "32768";
        public string rxtx_veri_transfer_sayisi         { get; set; } = "16";
        public string rxtx_zaman_asimi                  { get; set; } = "1000";
        public string rxtx_ornek_alma_gonderme_sayisi   { get; set; } = "100000";



        /*-------------------------TX MOD---------------------------------------*/
        public string tx_okunacak_dosya_adi           { get; set; } = "yazma.bin";
        public string tx_tampon_sayisi                { get; set; } = "32";
        public string tx_ornek_uzunlugu               { get; set; } = "32768";
        public string tx_tampon_boyutu                { get; set; } = "32768";
        public string tx_veri_transfer_sayisi         { get; set; } = "16";
        public string tx_zaman_asimi                  { get; set; } = "1000";
        public string tx_ornek_alma_gonderme_sayisi   { get; set; } = "100000";
        /*-------------------------RX MOD---------------------------------------*/
        public string rx_yazilacak_dosya_adi          { get; set; } = "okuma.bin";
        public string rx_tampon_sayisi                { get; set; } = "32";
        public string rx_ornek_uzunlugu               { get; set; } = "32768";
        public string rx_tampon_boyutu                { get; set; } = "32768";
        public string rx_veri_transfer_sayisi         { get; set; } = "16";
        public string rx_zaman_asimi                  { get; set; } = "1000";
        public string rx_ornek_alma_gonderme_sayisi   { get; set; } = "100000";




        private StringBuilder parametreler = new StringBuilder();
        private int           mevcut_satir = 1;

        public void satir_ekle(string parametreAdi, string parametreDegeri)
        {
            parametreler.AppendLine($"{parametreAdi},{parametreDegeri}");
            this.mevcut_satir++; 
        }

        public bool cihaz_parametrelerini_kur(string MOD,string parametreler_csv_dosya_yolu)
        {
            satir_ekle("prog_cihaz_versiyon"                , this.cihaz_model);
            satir_ekle("prog_mod"                           , MOD);
            satir_ekle("prog_sure"                          , this.prog_sure);

            satir_ekle("kanal_tx_kanal_adi"                 , "TX1");
            satir_ekle("kanal_tx_kanal"                     , this.kanal_tx_kanal);
            satir_ekle("kanal_tx_frekans"                   , this.kanal_tx_frekans);
            satir_ekle("kanal_tx_ornekleme_orani"           , this.kanal_tx_ornekleme_orani);
            satir_ekle("kanal_tx_bant_genisligi"            , this.kanal_tx_bant_genisligi);
            satir_ekle("kanal_tx_kazanc"                    , this.kanal_tx_anten_kazanci);
            satir_ekle("kanal_tx_zaman_asimi"               , this.kanal_tx_zaman_asimi);
            satir_ekle("kanal_tx_bias_tee"                  , this.kanal_tx_biastee);

            satir_ekle("kanal_rx_kanal_adi"                 , "RX2");
            satir_ekle("kanal_rx_kanal"                     , this.kanal_rx_kanal);
            satir_ekle("kanal_rx_frekans"                   , this.kanal_tx_frekans);
            satir_ekle("kanal_rx_ornekleme_orani"           , this.kanal_rx_ornekleme_orani);
            satir_ekle("kanal_rx_bant_genisligi"            , this.kanal_rx_bant_genisligi);
            satir_ekle("kanal_rx_kazanc"                    , this.kanal_rx_anten_kazanci);
            satir_ekle("kanal_rx_zaman_asimi"               , this.kanal_rx_zaman_asimi);
            satir_ekle("kanal_rx_bias_tee"                  , this.kanal_rx_biastee);
                    
            satir_ekle("rxtx_ornek_uzunlugu"                , this.rxtx_ornek_uzunlugu);
            satir_ekle("rxtx_tampon_boyutu"                 , this.rxtx_tampon_boyutu);
            satir_ekle("rxtx_tampon_sayisi"                 , this.rxtx_tampon_sayisi);
            satir_ekle("rxtx_veri_transfer_sayisi"          , this.rxtx_veri_transfer_sayisi);
            satir_ekle("rxtx_zaman_asimi"                   , this.rxtx_zaman_asimi);
            satir_ekle("rxtx_ornek_alma_gonderme_sayisi"    , this.rxtx_ornek_alma_gonderme_sayisi);

            satir_ekle("tx_dosya_adi"                       , this.kanal_tx_frekans);
            // todo : eklenecek
            // todo : sadece int veya string olan ifadelerin kontrolü eklenebilir.
            try
            {
                File.WriteAllText(parametreler_csv_dosya_yolu, parametreler.ToString());
                parametreler.Clear();
            }
            catch (Exception ex)
            {
                parametreler.Clear();
                return false;
                
            }
                      
            return true;
        }

        
    }
}
