using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bladeRF_GUI_v1.HelpersForms;

namespace bladeRF_GUI_v1.UserControls
{
    public partial class UC_Yardimcilar : UserControl
    {
        private F_Yardimci yardimci;
        private F_KurulumYardimcisi kurulum_yardimci;
        private C_Ayarlar _ayarlar;
        public UC_Yardimcilar(C_Ayarlar ayarlar)
        {
            _ayarlar = ayarlar;
            InitializeComponent();
           
        }
        private void Yardimci_button_Click(object sender, EventArgs e)
        {
            yardimci = new F_Yardimci();
            yardimci.Show();
        }

        private void Cihaz_kurulum_button_Click(object sender, EventArgs e)
        {
            kurulum_yardimci = new F_KurulumYardimcisi();
            kurulum_yardimci.Show();
        }
    }
}
