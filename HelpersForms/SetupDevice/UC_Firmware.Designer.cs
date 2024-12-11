namespace bladeRF_GUI_v1.HelpersForms.SetupDevice
{
    partial class UC_Firmware
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
            this.fw_sec_button = new System.Windows.Forms.Button();
            this.fw_yukle_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fw_dosya_yolu_label = new System.Windows.Forms.Label();
            this.bilgi_button = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.fw_yukle_button, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.fw_sec_button, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fw_dosya_yolu_label, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bilgi_button, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fw_sec_button
            // 
            this.fw_sec_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fw_sec_button.Location = new System.Drawing.Point(412, 78);
            this.fw_sec_button.Name = "fw_sec_button";
            this.fw_sec_button.Size = new System.Drawing.Size(75, 23);
            this.fw_sec_button.TabIndex = 0;
            this.fw_sec_button.Text = "Seç";
            this.fw_sec_button.UseVisualStyleBackColor = true;
            this.fw_sec_button.Click += new System.EventHandler(this.Fw_sec_button_Click);
            // 
            // fw_yukle_button
            // 
            this.fw_yukle_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fw_yukle_button.Location = new System.Drawing.Point(712, 438);
            this.fw_yukle_button.Name = "fw_yukle_button";
            this.fw_yukle_button.Size = new System.Drawing.Size(75, 23);
            this.fw_yukle_button.TabIndex = 1;
            this.fw_yukle_button.Text = "Yükle";
            this.fw_yukle_button.UseVisualStyleBackColor = true;
            this.fw_yukle_button.Click += new System.EventHandler(this.Fw_yukle_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cihaza yüklenecek yazılım Image\'ini seçiniz.";
            // 
            // fw_dosya_yolu_label
            // 
            this.fw_dosya_yolu_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fw_dosya_yolu_label.AutoSize = true;
            this.fw_dosya_yolu_label.Location = new System.Drawing.Point(732, 83);
            this.fw_dosya_yolu_label.Name = "fw_dosya_yolu_label";
            this.fw_dosya_yolu_label.Size = new System.Drawing.Size(35, 13);
            this.fw_dosya_yolu_label.TabIndex = 3;
            this.fw_dosya_yolu_label.Text = "label2";
            // 
            // bilgi_button
            // 
            this.bilgi_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bilgi_button.Location = new System.Drawing.Point(112, 138);
            this.bilgi_button.Name = "bilgi_button";
            this.bilgi_button.Size = new System.Drawing.Size(75, 23);
            this.bilgi_button.TabIndex = 4;
            this.bilgi_button.Text = "Bilgi";
            this.bilgi_button.UseVisualStyleBackColor = true;
            this.bilgi_button.Click += new System.EventHandler(this.Bilgi_button_Click);
            // 
            // UC_Firmware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Firmware";
            this.Size = new System.Drawing.Size(1200, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button fw_yukle_button;
        private System.Windows.Forms.Button fw_sec_button;
        private System.Windows.Forms.Label fw_dosya_yolu_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bilgi_button;
    }
}
