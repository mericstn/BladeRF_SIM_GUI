using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bladeRF_GUI_v1.UserInfo
{
    public partial class F_BilgilendirmeKutucugu : Form
    {
        public ProgressBar progressBar;
        public RichTextBox richTextBox;
        // bilgiendirme metinlerini buraya taşı
        public F_BilgilendirmeKutucugu(string baslik, string metin,string ana_metin)
        {
            InitializeComponent();

            // Başlık ayarı
            this.bilgilendirme_baslik_label.Text = baslik;

            // Dinamik metin kutusu oluşturma
           /* richTextBox = new RichTextBox()
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                Text = metin
            };
            this.Controls.Add(richTextBox);*/

            // Progress bar ekleme
            progressBar = new ProgressBar()
            {
                Dock = DockStyle.Bottom,
                Minimum = 0,
                Maximum = 100,
                Value = 0
            };
            this.Controls.Add(progressBar);

            bilgilendirme_metni_richtextbox.Text = ana_metin;

        }

        // RichTextBox'a dinamik olarak metin ekleme fonksiyonu
        public void AppendTextToRichTextBox(string text)
        {
            bilgilendirme_metni_richtextbox.AppendText(text + Environment.NewLine);
            bilgilendirme_metni_richtextbox.ScrollToCaret();
        }

        // ProgressBar'ı güncelleme fonksiyonu
        public void UpdateProgressBar(int value)
        {
            progressBar.Value = Math.Min(value, 100); // Maksimum değeri 100 ile sınırla
        }
        public void goster_kapat_button_Click()
        {
            kapat_button.Show();
        }
        private void kapat_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void sakla_kapat_button_Click()
        {
            kapat_button.Hide();
        }


    }
}
