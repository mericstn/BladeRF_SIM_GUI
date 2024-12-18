using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bladeRF_GUI_v1.ApplicationUserControls
{
    public class C_Uygulamalar
    {

        public string cihaz_model           { get; set; } = "BladeRFv2.0";
        // struct tanimlanabilir !!!
        /*-------------------------TX---------------------------------------*/
        public string tx_frekans            { get; set; } = "1575420000";
        public string tx_ornekleme_orani    { get; set; } = "12000000";
        public string tx_bant_genisligi     { get; set; } = "50000000";
        public string tx_anten_kazanci      { get; set; } = "45";
        public string tx_zaman_asimi        { get; set; } = "500";
        public string tx_biastee            { get; set; } = "Kapali";
        public string tx_kanal              { get; set; } = "TX1";
        public string tx_okunacak_dosya_adi     { get; set; } = "yazma.bin";

        /*-------------------------RX---------------------------------------*/
        public string rx_frekans            { get; set; } = "1575420000";
        public string rx_ornekleme_orani    { get; set; } = "12000000";
        public string rx_bant_genisligi     { get; set; } = "50000000";
        public string rx_anten_kazanci      { get; set; } = "45";
        public string rx_zaman_asimi        { get; set; } = "500";
        public string rx_biastee            { get; set; } = "Kapali";
        public string rx_kanal              { get; set; } = "RX2";
        public string rx_yazilacak_dosya_adi    { get; set; } = "okuma.bin";

        /*-------------------------VAP---------------------------------------*/
        public string vap_tampon_sayisi         { get; set; } = "32";
        public string vap_tampon_boyutu         { get; set; } = "32768";
        public string vap_veri_transfer_sayisi  { get; set; } = "16";
        public string vap_zaman_asimi           { get; set; } = "1000";

    }
}
