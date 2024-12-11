namespace bladeRF_GUI_v1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ust_panel = new System.Windows.Forms.Panel();
            this.ana_baslik_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_alt = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.komut_istemcileri_button = new System.Windows.Forms.Button();
            this.yardimcilar_button = new System.Windows.Forms.Button();
            this.ayarlar_button = new System.Windows.Forms.Button();
            this.programlar_button = new System.Windows.Forms.Button();
            this.panel_container = new System.Windows.Forms.Panel();
            this.ust_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_alt.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ust_panel
            // 
            this.ust_panel.BackColor = System.Drawing.Color.DarkBlue;
            this.ust_panel.Controls.Add(this.ana_baslik_label);
            this.ust_panel.Controls.Add(this.pictureBox1);
            this.ust_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ust_panel.Location = new System.Drawing.Point(0, 0);
            this.ust_panel.Name = "ust_panel";
            this.ust_panel.Size = new System.Drawing.Size(1284, 60);
            this.ust_panel.TabIndex = 0;
            // 
            // ana_baslik_label
            // 
            this.ana_baslik_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ana_baslik_label.AutoSize = true;
            this.ana_baslik_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ana_baslik_label.ForeColor = System.Drawing.SystemColors.Control;
            this.ana_baslik_label.Location = new System.Drawing.Point(70, 13);
            this.ana_baslik_label.Name = "ana_baslik_label";
            this.ana_baslik_label.Size = new System.Drawing.Size(188, 33);
            this.ana_baslik_label.TabIndex = 1;
            this.ana_baslik_label.Text = "BladeRF GUI";
            this.ana_baslik_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_alt
            // 
            this.panel_alt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel_alt.Controls.Add(this.tableLayoutPanel1);
            this.panel_alt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_alt.Location = new System.Drawing.Point(0, 60);
            this.panel_alt.Name = "panel_alt";
            this.panel_alt.Size = new System.Drawing.Size(1284, 50);
            this.panel_alt.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.komut_istemcileri_button, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.yardimcilar_button, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ayarlar_button, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.programlar_button, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // komut_istemcileri_button
            // 
            this.komut_istemcileri_button.BackColor = System.Drawing.Color.MidnightBlue;
            this.komut_istemcileri_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.komut_istemcileri_button.ForeColor = System.Drawing.SystemColors.Control;
            this.komut_istemcileri_button.Location = new System.Drawing.Point(3, 3);
            this.komut_istemcileri_button.Name = "komut_istemcileri_button";
            this.komut_istemcileri_button.Size = new System.Drawing.Size(289, 44);
            this.komut_istemcileri_button.TabIndex = 1;
            this.komut_istemcileri_button.Text = "Komut İstemcileri";
            this.komut_istemcileri_button.UseVisualStyleBackColor = false;
            this.komut_istemcileri_button.Click += new System.EventHandler(this.Komut_istemcileri_button_Click);
            // 
            // yardimcilar_button
            // 
            this.yardimcilar_button.BackColor = System.Drawing.Color.MidnightBlue;
            this.yardimcilar_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yardimcilar_button.ForeColor = System.Drawing.SystemColors.Control;
            this.yardimcilar_button.Location = new System.Drawing.Point(645, 3);
            this.yardimcilar_button.Name = "yardimcilar_button";
            this.yardimcilar_button.Size = new System.Drawing.Size(289, 44);
            this.yardimcilar_button.TabIndex = 2;
            this.yardimcilar_button.Text = "Yardımcılar";
            this.yardimcilar_button.UseVisualStyleBackColor = false;
            this.yardimcilar_button.Click += new System.EventHandler(this.Yardimcilar_button_Click);
            // 
            // ayarlar_button
            // 
            this.ayarlar_button.BackColor = System.Drawing.Color.MidnightBlue;
            this.ayarlar_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ayarlar_button.ForeColor = System.Drawing.SystemColors.Control;
            this.ayarlar_button.Location = new System.Drawing.Point(966, 3);
            this.ayarlar_button.Name = "ayarlar_button";
            this.ayarlar_button.Size = new System.Drawing.Size(289, 44);
            this.ayarlar_button.TabIndex = 4;
            this.ayarlar_button.Text = "Ayarlar";
            this.ayarlar_button.UseVisualStyleBackColor = false;
            this.ayarlar_button.Click += new System.EventHandler(this.Ayarlar_button_Click);
            // 
            // programlar_button
            // 
            this.programlar_button.BackColor = System.Drawing.Color.MidnightBlue;
            this.programlar_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.programlar_button.ForeColor = System.Drawing.SystemColors.Control;
            this.programlar_button.Location = new System.Drawing.Point(324, 3);
            this.programlar_button.Name = "programlar_button";
            this.programlar_button.Size = new System.Drawing.Size(289, 44);
            this.programlar_button.TabIndex = 3;
            this.programlar_button.Text = "Programlar";
            this.programlar_button.UseVisualStyleBackColor = false;
            this.programlar_button.Click += new System.EventHandler(this.Programlar_button_Click);
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.Location = new System.Drawing.Point(0, 110);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(1284, 751);
            this.panel_container.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.panel_alt);
            this.Controls.Add(this.ust_panel);
            this.Name = "Form1";
            this.Text = "BladeRF Simulasyon Arayüzü";
            this.ust_panel.ResumeLayout(false);
            this.ust_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_alt.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ust_panel;
        private System.Windows.Forms.Label ana_baslik_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_alt;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button komut_istemcileri_button;
        private System.Windows.Forms.Button yardimcilar_button;
        private System.Windows.Forms.Button programlar_button;
        private System.Windows.Forms.Button ayarlar_button;
    }
}

