namespace bladeRF_GUI_v1.UserControls
{
    partial class UC_Programlar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.program_sdr_console_button = new System.Windows.Forms.Button();
            this.program_satgen_nmea_button = new System.Windows.Forms.Button();
            this.program_ez_usb_button = new System.Windows.Forms.Button();
            this.program_gpif2_button = new System.Windows.Forms.Button();
            this.program_gnu_radio = new System.Windows.Forms.Button();
            this.site_nmeagen_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.program_bladerf_cli_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.program_sdr_console_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.program_satgen_nmea_button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.program_ez_usb_button, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.program_gpif2_button, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.program_gnu_radio, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.site_nmeagen_button, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.program_bladerf_cli_button, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // program_sdr_console_button
            // 
            this.program_sdr_console_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_sdr_console_button.Location = new System.Drawing.Point(64, 101);
            this.program_sdr_console_button.Name = "program_sdr_console_button";
            this.program_sdr_console_button.Size = new System.Drawing.Size(172, 23);
            this.program_sdr_console_button.TabIndex = 0;
            this.program_sdr_console_button.Text = "SDR Console";
            this.program_sdr_console_button.UseVisualStyleBackColor = true;
            this.program_sdr_console_button.Click += new System.EventHandler(this.Program_sdr_console_button_Click);
            // 
            // program_satgen_nmea_button
            // 
            this.program_satgen_nmea_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_satgen_nmea_button.Location = new System.Drawing.Point(64, 176);
            this.program_satgen_nmea_button.Name = "program_satgen_nmea_button";
            this.program_satgen_nmea_button.Size = new System.Drawing.Size(172, 23);
            this.program_satgen_nmea_button.TabIndex = 1;
            this.program_satgen_nmea_button.Text = "SatGenNMEA";
            this.program_satgen_nmea_button.UseVisualStyleBackColor = true;
            this.program_satgen_nmea_button.Click += new System.EventHandler(this.Program_satgen_nmea_button_Click);
            // 
            // program_ez_usb_button
            // 
            this.program_ez_usb_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_ez_usb_button.Location = new System.Drawing.Point(64, 251);
            this.program_ez_usb_button.Name = "program_ez_usb_button";
            this.program_ez_usb_button.Size = new System.Drawing.Size(172, 23);
            this.program_ez_usb_button.TabIndex = 2;
            this.program_ez_usb_button.Text = "EZ USB Suite";
            this.program_ez_usb_button.UseVisualStyleBackColor = true;
            this.program_ez_usb_button.Click += new System.EventHandler(this.Program_ez_usb_button_Click);
            // 
            // program_gpif2_button
            // 
            this.program_gpif2_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_gpif2_button.Location = new System.Drawing.Point(64, 326);
            this.program_gpif2_button.Name = "program_gpif2_button";
            this.program_gpif2_button.Size = new System.Drawing.Size(172, 23);
            this.program_gpif2_button.TabIndex = 3;
            this.program_gpif2_button.Text = "GPIF II Designer";
            this.program_gpif2_button.UseVisualStyleBackColor = true;
            this.program_gpif2_button.Click += new System.EventHandler(this.Program_gpif2_button_Click);
            // 
            // program_gnu_radio
            // 
            this.program_gnu_radio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_gnu_radio.Location = new System.Drawing.Point(64, 401);
            this.program_gnu_radio.Name = "program_gnu_radio";
            this.program_gnu_radio.Size = new System.Drawing.Size(172, 23);
            this.program_gnu_radio.TabIndex = 4;
            this.program_gnu_radio.Text = "GNU Radio Companion";
            this.program_gnu_radio.UseVisualStyleBackColor = true;
            this.program_gnu_radio.Click += new System.EventHandler(this.Program_gnu_radio_Click);
            // 
            // site_nmeagen_button
            // 
            this.site_nmeagen_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.site_nmeagen_button.Location = new System.Drawing.Point(664, 101);
            this.site_nmeagen_button.Name = "site_nmeagen_button";
            this.site_nmeagen_button.Size = new System.Drawing.Size(172, 23);
            this.site_nmeagen_button.TabIndex = 5;
            this.site_nmeagen_button.Text = "NMEAgen.com";
            this.site_nmeagen_button.UseVisualStyleBackColor = true;
            this.site_nmeagen_button.Click += new System.EventHandler(this.Site_nmeagen_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Programlar";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Online Bağlantılar";
            // 
            // program_bladerf_cli_button
            // 
            this.program_bladerf_cli_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.program_bladerf_cli_button.Location = new System.Drawing.Point(64, 476);
            this.program_bladerf_cli_button.Name = "program_bladerf_cli_button";
            this.program_bladerf_cli_button.Size = new System.Drawing.Size(172, 23);
            this.program_bladerf_cli_button.TabIndex = 8;
            this.program_bladerf_cli_button.Text = "BladeRF CLI";
            this.program_bladerf_cli_button.UseVisualStyleBackColor = true;
            this.program_bladerf_cli_button.Click += new System.EventHandler(this.Program_bladerf_cli_button_ClickAsync);
            // 
            // UC_Programlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Programlar";
            this.Size = new System.Drawing.Size(1200, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button program_sdr_console_button;
        private System.Windows.Forms.Button program_satgen_nmea_button;
        private System.Windows.Forms.Button program_ez_usb_button;
        private System.Windows.Forms.Button program_gpif2_button;
        private System.Windows.Forms.Button program_gnu_radio;
        private System.Windows.Forms.Button site_nmeagen_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button program_bladerf_cli_button;
    }
}
