namespace bladeRF_GUI_v1.UserInfo
{
    partial class F_BilgilendirmeKutucugu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_BilgilendirmeKutucugu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kapat_button = new System.Windows.Forms.Button();
            this.bilgilendirme_baslik_label = new System.Windows.Forms.Label();
            this.bilgilendirme_metni_richtextbox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 643);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bilgilendirme_baslik_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bilgilendirme_metni_richtextbox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 643);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.kapat_button, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 581);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 59);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kapat_button
            // 
            this.kapat_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kapat_button.Location = new System.Drawing.Point(400, 3);
            this.kapat_button.Name = "kapat_button";
            this.kapat_button.Size = new System.Drawing.Size(391, 53);
            this.kapat_button.TabIndex = 0;
            this.kapat_button.Text = "Tamam";
            this.kapat_button.UseVisualStyleBackColor = true;
            this.kapat_button.Click += new System.EventHandler(this.kapat_button_Click);
            // 
            // bilgilendirme_baslik_label
            // 
            this.bilgilendirme_baslik_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bilgilendirme_baslik_label.AutoSize = true;
            this.bilgilendirme_baslik_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bilgilendirme_baslik_label.Location = new System.Drawing.Point(367, 20);
            this.bilgilendirme_baslik_label.Name = "bilgilendirme_baslik_label";
            this.bilgilendirme_baslik_label.Size = new System.Drawing.Size(66, 24);
            this.bilgilendirme_baslik_label.TabIndex = 1;
            this.bilgilendirme_baslik_label.Text = "label1";
            // 
            // bilgilendirme_metni_richtextbox
            // 
            this.bilgilendirme_metni_richtextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bilgilendirme_metni_richtextbox.Location = new System.Drawing.Point(3, 67);
            this.bilgilendirme_metni_richtextbox.Name = "bilgilendirme_metni_richtextbox";
            this.bilgilendirme_metni_richtextbox.ReadOnly = true;
            this.bilgilendirme_metni_richtextbox.Size = new System.Drawing.Size(794, 508);
            this.bilgilendirme_metni_richtextbox.TabIndex = 2;
            this.bilgilendirme_metni_richtextbox.Text = resources.GetString("bilgilendirme_metni_richtextbox.Text");
            // 
            // bilgilendirme_kutucugu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 643);
            this.Controls.Add(this.panel1);
            this.Name = "bilgilendirme_kutucugu";
            this.Text = "Bilgilendirme Kutucuğu";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button kapat_button;
        private System.Windows.Forms.Label bilgilendirme_baslik_label;
        private System.Windows.Forms.RichTextBox bilgilendirme_metni_richtextbox;
    }
}