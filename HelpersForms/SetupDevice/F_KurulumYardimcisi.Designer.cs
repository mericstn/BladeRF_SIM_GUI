namespace bladeRF_GUI_v1.HelpersForms
{
    partial class F_KurulumYardimcisi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.durum_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yardimci_prog_bar = new System.Windows.Forms.ProgressBar();
            this.header_panel.SuspendLayout();
            this.helper_main_panel.SuspendLayout();
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
            this.pictureBox1.Image = global::bladeRF_GUI_v1.Properties.Resources.setupdevice;
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
            // F_KurulumYardimcisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 646);
            this.Controls.Add(this.helper_main_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header_panel);
            this.Name = "F_KurulumYardimcisi";
            this.Text = "Kurulum Yardımcısı";
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            this.helper_main_panel.ResumeLayout(false);
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
    }
}