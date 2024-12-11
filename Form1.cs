using System;
using System.Drawing;
using System.Windows.Forms;
using bladeRF_GUI_v1.UserControls;



namespace bladeRF_GUI_v1
{
    public partial class Form1 : Form
    {
        private Ayarlar         ayarlar;
        private UC_CLI          uc_cli;
        private UC_Yardimcilar  uc_yardimcilar;
        private UC_Programlar   uc_programlar;
        private UC_Ayarlar      uc_ayarlar;
            

        public Form1()
        {
            InitializeComponent();
            ayarlar         = new Ayarlar(); 
            uc_cli          = new UC_CLI(ayarlar);
            uc_yardimcilar  = new UC_Yardimcilar(ayarlar);
            uc_programlar   = new UC_Programlar(ayarlar);
            uc_ayarlar      = new UC_Ayarlar(ayarlar);
        }
       
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(userControl);
            userControl.BringToFront();
        }
     

        private void Komut_istemcileri_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_cli);
            UpdateButtonColors(komut_istemcileri_button);
        }


        private void UpdateButtonColors(Button activeButton)
        {
            komut_istemcileri_button.BackColor = Color.MidnightBlue;
            yardimcilar_button.BackColor       = Color.MidnightBlue;
            programlar_button.BackColor        = Color.MidnightBlue;
            ayarlar_button.BackColor           = Color.MidnightBlue;
            activeButton.BackColor             = Color.DarkBlue;
            
        }

        private void Yardimcilar_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_yardimcilar);
            UpdateButtonColors(yardimcilar_button);
        }

        private void Programlar_button_Click(object sender, EventArgs e)
        {
            AddUserControl(uc_programlar);
            UpdateButtonColors(programlar_button);
        }

        private void Ayarlar_button_Click(object sender, EventArgs e)
        {

            AddUserControl(uc_ayarlar);
            UpdateButtonColors(ayarlar_button);
        }
    }
}
