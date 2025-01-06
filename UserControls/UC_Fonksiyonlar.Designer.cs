namespace bladeRF_GUI_v1.UserControls
{
    partial class UC_Fonksiyonlar
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.okuma_button = new System.Windows.Forms.Button();
            this.tekrarlayici_button = new System.Windows.Forms.Button();
            this.yazma_button = new System.Windows.Forms.Button();
            this.func_panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.okuma_button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tekrarlayici_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.yazma_button, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // okuma_button
            // 
            this.okuma_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.okuma_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okuma_button.Enabled = false;
            this.okuma_button.Location = new System.Drawing.Point(3, 123);
            this.okuma_button.Name = "okuma_button";
            this.okuma_button.Size = new System.Drawing.Size(194, 54);
            this.okuma_button.TabIndex = 2;
            this.okuma_button.Text = "Okuma (RX)";
            this.okuma_button.UseVisualStyleBackColor = false;
            this.okuma_button.Click += new System.EventHandler(this.okuma_button_Click);
            // 
            // tekrarlayici_button
            // 
            this.tekrarlayici_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.tekrarlayici_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tekrarlayici_button.Location = new System.Drawing.Point(3, 63);
            this.tekrarlayici_button.Name = "tekrarlayici_button";
            this.tekrarlayici_button.Size = new System.Drawing.Size(194, 54);
            this.tekrarlayici_button.TabIndex = 1;
            this.tekrarlayici_button.Text = "Tekrarlayıcı (Repeater)";
            this.tekrarlayici_button.UseVisualStyleBackColor = false;
            this.tekrarlayici_button.Click += new System.EventHandler(this.tekrarlayici_button_Click);
            // 
            // yazma_button
            // 
            this.yazma_button.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.yazma_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yazma_button.Enabled = false;
            this.yazma_button.Location = new System.Drawing.Point(3, 3);
            this.yazma_button.Name = "yazma_button";
            this.yazma_button.Size = new System.Drawing.Size(194, 54);
            this.yazma_button.TabIndex = 0;
            this.yazma_button.Text = "Yazma (TX)";
            this.yazma_button.UseVisualStyleBackColor = false;
            this.yazma_button.Click += new System.EventHandler(this.yazma_button_Click);
            // 
            // func_panel
            // 
            this.func_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.func_panel.Location = new System.Drawing.Point(200, 0);
            this.func_panel.Name = "func_panel";
            this.func_panel.Size = new System.Drawing.Size(1000, 600);
            this.func_panel.TabIndex = 1;
            // 
            // UC_Fonksiyonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.func_panel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Fonksiyonlar";
            this.Size = new System.Drawing.Size(1200, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button tekrarlayici_button;
        private System.Windows.Forms.Button yazma_button;
        private System.Windows.Forms.Panel func_panel;
        private System.Windows.Forms.Button okuma_button;
    }
}
