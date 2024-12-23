using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bladeRF_GUI_v1.ApplicationUserControls;
using bladeRF_GUI_v1.Classes;
namespace bladeRF_GUI_v1.UserControls
{
    public partial class UC_Fonksiyonlar : UserControl
    {
        private UC_Okuma            uc_okuma;
        private UC_Yazma            uc_yazma;
        private UC_Tekrarlayici     uc_tekrarlayici;
        private C_Ayarlar           c_ayarlar;

        public UC_Fonksiyonlar(C_Ayarlar _ayarlar)
        {
            
            InitializeComponent();
            c_ayarlar           = _ayarlar;
            uc_okuma            = new UC_Okuma(); // todo ayarlar eklenecek
            uc_yazma            = new UC_Yazma(); // todo ayarlar eklenecek
            uc_tekrarlayici     = new UC_Tekrarlayici(c_ayarlar);
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            func_panel.Controls.Clear();
            func_panel.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void UpdateButtonColors(Button activeButton)
        {
            yazma_button.BackColor              = Color.LightGoldenrodYellow;
            okuma_button.BackColor              = Color.LightGoldenrodYellow;
            tekrarlayici_button.BackColor       = Color.LightGoldenrodYellow;
            activeButton.BackColor              = Color.IndianRed;

        }


        private void tekrarlayici_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_tekrarlayici);
            UpdateButtonColors(tekrarlayici_button);
        }

        private void yazma_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_yazma);
            UpdateButtonColors(yazma_button);
        }

        private void okuma_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_okuma);
            UpdateButtonColors(okuma_button);
        }
    }
}
