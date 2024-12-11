namespace bladeRF_GUI_v1.HelpersForms
{
    partial class F_Yardimci
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header_panel = new System.Windows.Forms.Panel();
            this.geri_button = new System.Windows.Forms.Button();
            this.cikis_button = new System.Windows.Forms.Button();
            this.step_button = new System.Windows.Forms.Button();
            this.baslik = new System.Windows.Forms.Label();
            this.helper_main_panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.bladerf_cli_dosya_sec_button = new System.Windows.Forms.Button();
            this.bladerf_cli_dosya_yolu_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gps_binary_klasor_sec_button = new System.Windows.Forms.Button();
            this.gps_cikti_klasor_label = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.galileo_binary_klasor_sec_button = new System.Windows.Forms.Button();
            this.galileo_cikti_klasor_label = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gps_cli_sec_button = new System.Windows.Forms.Button();
            this.galileo_cli_sec_button = new System.Windows.Forms.Button();
            this.gps_cli_label = new System.Windows.Forms.Label();
            this.galileo_cli_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.durum_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yardimci_prog_bar = new System.Windows.Forms.ProgressBar();
            this.header_panel.SuspendLayout();
            this.helper_main_panel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_panel
            // 
            this.header_panel.Controls.Add(this.geri_button);
            this.header_panel.Controls.Add(this.cikis_button);
            this.header_panel.Controls.Add(this.step_button);
            this.header_panel.Controls.Add(this.baslik);
            this.header_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_panel.Location = new System.Drawing.Point(0, 0);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(1318, 50);
            this.header_panel.TabIndex = 0;
            // 
            // geri_button
            // 
            this.geri_button.Enabled = false;
            this.geri_button.Location = new System.Drawing.Point(1060, 16);
            this.geri_button.Name = "geri_button";
            this.geri_button.Size = new System.Drawing.Size(75, 23);
            this.geri_button.TabIndex = 2;
            this.geri_button.Text = "Geri";
            this.geri_button.UseVisualStyleBackColor = true;
            this.geri_button.Click += new System.EventHandler(this.Geri_button_Click);
            // 
            // cikis_button
            // 
            this.cikis_button.Location = new System.Drawing.Point(31, 16);
            this.cikis_button.Name = "cikis_button";
            this.cikis_button.Size = new System.Drawing.Size(75, 23);
            this.cikis_button.TabIndex = 1;
            this.cikis_button.Text = "Çıkış";
            this.cikis_button.UseVisualStyleBackColor = true;
            this.cikis_button.Click += new System.EventHandler(this.Cikis_button_Click);
            // 
            // step_button
            // 
            this.step_button.Location = new System.Drawing.Point(1198, 16);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(75, 23);
            this.step_button.TabIndex = 0;
            this.step_button.Text = "Başla";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.Step_button_Click);
            // 
            // baslik
            // 
            this.baslik.AutoSize = true;
            this.baslik.Location = new System.Drawing.Point(527, 21);
            this.baslik.Name = "baslik";
            this.baslik.Size = new System.Drawing.Size(47, 13);
            this.baslik.TabIndex = 0;
            this.baslik.Text = "Yardımcı";
            // 
            // helper_main_panel
            // 
            this.helper_main_panel.Controls.Add(this.tableLayoutPanel2);
            this.helper_main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helper_main_panel.Location = new System.Drawing.Point(0, 50);
            this.helper_main_panel.Name = "helper_main_panel";
            this.helper_main_panel.Size = new System.Drawing.Size(1145, 555);
            this.helper_main_panel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label19, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.bladerf_cli_dosya_sec_button, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.bladerf_cli_dosya_yolu_label, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gps_binary_klasor_sec_button, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.gps_cikti_klasor_label, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.galileo_binary_klasor_sec_button, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.galileo_cikti_klasor_label, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label27, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.gps_cli_sec_button, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.galileo_cli_sec_button, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.gps_cli_label, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.galileo_cli_label, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1145, 555);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(57, 508);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(115, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "bladerf CLI Dosya Yolu";
            // 
            // bladerf_cli_dosya_sec_button
            // 
            this.bladerf_cli_dosya_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bladerf_cli_dosya_sec_button.Location = new System.Drawing.Point(260, 503);
            this.bladerf_cli_dosya_sec_button.Name = "bladerf_cli_dosya_sec_button";
            this.bladerf_cli_dosya_sec_button.Size = new System.Drawing.Size(52, 23);
            this.bladerf_cli_dosya_sec_button.TabIndex = 35;
            this.bladerf_cli_dosya_sec_button.Text = "Seç";
            this.bladerf_cli_dosya_sec_button.UseVisualStyleBackColor = true;
            this.bladerf_cli_dosya_sec_button.Click += new System.EventHandler(this.Bladerf_cli_dosya_sec_button_Click);
            // 
            // bladerf_cli_dosya_yolu_label
            // 
            this.bladerf_cli_dosya_yolu_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bladerf_cli_dosya_yolu_label.AutoSize = true;
            this.bladerf_cli_dosya_yolu_label.Location = new System.Drawing.Point(346, 508);
            this.bladerf_cli_dosya_yolu_label.Name = "bladerf_cli_dosya_yolu_label";
            this.bladerf_cli_dosya_yolu_label.Size = new System.Drawing.Size(77, 13);
            this.bladerf_cli_dosya_yolu_label.TabIndex = 36;
            this.bladerf_cli_dosya_yolu_label.Text = "Proje Exec-CLI";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "GPS Binary Veri Çıktı Klasörü";
            // 
            // gps_binary_klasor_sec_button
            // 
            this.gps_binary_klasor_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gps_binary_klasor_sec_button.Location = new System.Drawing.Point(260, 107);
            this.gps_binary_klasor_sec_button.Name = "gps_binary_klasor_sec_button";
            this.gps_binary_klasor_sec_button.Size = new System.Drawing.Size(52, 23);
            this.gps_binary_klasor_sec_button.TabIndex = 18;
            this.gps_binary_klasor_sec_button.Text = "Seç";
            this.gps_binary_klasor_sec_button.UseVisualStyleBackColor = true;
            this.gps_binary_klasor_sec_button.Click += new System.EventHandler(this.Gps_binary_klasor_sec_button_Click);
            // 
            // gps_cikti_klasor_label
            // 
            this.gps_cikti_klasor_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gps_cikti_klasor_label.AutoSize = true;
            this.gps_cikti_klasor_label.Location = new System.Drawing.Point(346, 112);
            this.gps_cikti_klasor_label.Name = "gps_cikti_klasor_label";
            this.gps_cikti_klasor_label.Size = new System.Drawing.Size(28, 13);
            this.gps_cikti_klasor_label.TabIndex = 17;
            this.gps_cikti_klasor_label.Text = "Aktif";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 191);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Galileo Binary Veri Çıktı Klasörü";
            // 
            // galileo_binary_klasor_sec_button
            // 
            this.galileo_binary_klasor_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.galileo_binary_klasor_sec_button.Location = new System.Drawing.Point(260, 186);
            this.galileo_binary_klasor_sec_button.Name = "galileo_binary_klasor_sec_button";
            this.galileo_binary_klasor_sec_button.Size = new System.Drawing.Size(52, 23);
            this.galileo_binary_klasor_sec_button.TabIndex = 21;
            this.galileo_binary_klasor_sec_button.Text = "Seç";
            this.galileo_binary_klasor_sec_button.UseVisualStyleBackColor = true;
            this.galileo_binary_klasor_sec_button.Click += new System.EventHandler(this.Galileo_binary_klasor_sec_button_Click);
            // 
            // galileo_cikti_klasor_label
            // 
            this.galileo_cikti_klasor_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.galileo_cikti_klasor_label.AutoSize = true;
            this.galileo_cikti_klasor_label.Location = new System.Drawing.Point(346, 191);
            this.galileo_cikti_klasor_label.Name = "galileo_cikti_klasor_label";
            this.galileo_cikti_klasor_label.Size = new System.Drawing.Size(28, 13);
            this.galileo_cikti_klasor_label.TabIndex = 20;
            this.galileo_cikti_klasor_label.Text = "Aktif";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(77, 270);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(75, 13);
            this.label27.TabIndex = 28;
            this.label27.Text = "GPS Exec-CLI";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Galileo Exec-CLI";
            // 
            // gps_cli_sec_button
            // 
            this.gps_cli_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gps_cli_sec_button.Location = new System.Drawing.Point(260, 265);
            this.gps_cli_sec_button.Name = "gps_cli_sec_button";
            this.gps_cli_sec_button.Size = new System.Drawing.Size(52, 23);
            this.gps_cli_sec_button.TabIndex = 29;
            this.gps_cli_sec_button.Text = "Seç";
            this.gps_cli_sec_button.UseVisualStyleBackColor = true;
            this.gps_cli_sec_button.Click += new System.EventHandler(this.Gps_cli_sec_button_Click);
            // 
            // galileo_cli_sec_button
            // 
            this.galileo_cli_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.galileo_cli_sec_button.Location = new System.Drawing.Point(262, 344);
            this.galileo_cli_sec_button.Name = "galileo_cli_sec_button";
            this.galileo_cli_sec_button.Size = new System.Drawing.Size(48, 23);
            this.galileo_cli_sec_button.TabIndex = 32;
            this.galileo_cli_sec_button.Text = "Seç";
            this.galileo_cli_sec_button.UseVisualStyleBackColor = true;
            this.galileo_cli_sec_button.Click += new System.EventHandler(this.Galileo_cli_sec_button_Click);
            // 
            // gps_cli_label
            // 
            this.gps_cli_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gps_cli_label.AutoSize = true;
            this.gps_cli_label.Location = new System.Drawing.Point(346, 270);
            this.gps_cli_label.Name = "gps_cli_label";
            this.gps_cli_label.Size = new System.Drawing.Size(28, 13);
            this.gps_cli_label.TabIndex = 30;
            this.gps_cli_label.Text = "Aktif";
            // 
            // galileo_cli_label
            // 
            this.galileo_cli_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.galileo_cli_label.AutoSize = true;
            this.galileo_cli_label.Location = new System.Drawing.Point(346, 349);
            this.galileo_cli_label.Name = "galileo_cli_label";
            this.galileo_cli_label.Size = new System.Drawing.Size(28, 13);
            this.galileo_cli_label.TabIndex = 33;
            this.galileo_cli_label.Text = "Aktif";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(640, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 26);
            this.label3.TabIndex = 37;
            this.label3.Text = "Varsayılan Ayarlar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1145, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 596);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.durum_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 596);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // durum_label
            // 
            this.durum_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.durum_label.AutoSize = true;
            this.durum_label.Location = new System.Drawing.Point(67, 574);
            this.durum_label.Name = "durum_label";
            this.durum_label.Size = new System.Drawing.Size(38, 13);
            this.durum_label.TabIndex = 0;
            this.durum_label.Text = "Durum";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::bladeRF_GUI_v1.Properties.Resources.satellite;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 560);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.yardimci_prog_bar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1145, 41);
            this.panel2.TabIndex = 0;
            // 
            // yardimci_prog_bar
            // 
            this.yardimci_prog_bar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yardimci_prog_bar.Location = new System.Drawing.Point(0, 0);
            this.yardimci_prog_bar.Margin = new System.Windows.Forms.Padding(8);
            this.yardimci_prog_bar.Name = "yardimci_prog_bar";
            this.yardimci_prog_bar.Size = new System.Drawing.Size(1145, 41);
            this.yardimci_prog_bar.TabIndex = 0;
            // 
            // F_Yardimci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1318, 646);
            this.Controls.Add(this.helper_main_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header_panel);
            this.Name = "F_Yardimci";
            this.Text = "Simulasyon Yardımcısı";
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            this.helper_main_panel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header_panel;
        private System.Windows.Forms.Label baslik;
        private System.Windows.Forms.Panel helper_main_panel;
        private System.Windows.Forms.Button step_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar yardimci_prog_bar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label durum_label;
        private System.Windows.Forms.Button cikis_button;
        private System.Windows.Forms.Button geri_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label gps_cikti_klasor_label;
        private System.Windows.Forms.Button gps_binary_klasor_sec_button;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label galileo_cikti_klasor_label;
        private System.Windows.Forms.Button galileo_binary_klasor_sec_button;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button gps_cli_sec_button;
        private System.Windows.Forms.Label gps_cli_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button galileo_cli_sec_button;
        private System.Windows.Forms.Label galileo_cli_label;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button bladerf_cli_dosya_sec_button;
        private System.Windows.Forms.Label bladerf_cli_dosya_yolu_label;
        private System.Windows.Forms.Label label3;
    }
}