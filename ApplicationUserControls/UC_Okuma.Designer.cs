namespace bladeRF_GUI_v1.ApplicationUserControls
{
    partial class UC_Okuma
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
            this.cihaz_model_combobox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.vap_tampon_sayisi_textbox = new System.Windows.Forms.TextBox();
            this.vap_tampon_boyutu_textbox = new System.Windows.Forms.TextBox();
            this.vap_veri_transfer_sayisi_textbox = new System.Windows.Forms.TextBox();
            this.vap_zaman_asimi_textbox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rx_kanal_combobox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rx_yazilacak_dosya_adi_textbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.durdur_picbox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.cikti_richtextbox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.baslat_picbox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label30 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rx_frekans_textbox = new System.Windows.Forms.TextBox();
            this.rx_ornekleme_orani_textbox = new System.Windows.Forms.TextBox();
            this.rx_bant_genisligi_textbox = new System.Windows.Forms.TextBox();
            this.rx_anten_kazanci_textbox = new System.Windows.Forms.TextBox();
            this.rx_zaman_asimi_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.rx_biastee_checkbox = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durdur_picbox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baslat_picbox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cihaz_model_combobox
            // 
            this.cihaz_model_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cihaz_model_combobox.FormattingEnabled = true;
            this.cihaz_model_combobox.Items.AddRange(new object[] {
            "BladeRF v1.0",
            "BladeRF v2.0"});
            this.cihaz_model_combobox.Location = new System.Drawing.Point(277, 17);
            this.cihaz_model_combobox.Name = "cihaz_model_combobox";
            this.cihaz_model_combobox.Size = new System.Drawing.Size(104, 21);
            this.cihaz_model_combobox.TabIndex = 13;
            this.cihaz_model_combobox.SelectedIndexChanged += new System.EventHandler(this.cihaz_model_combobox_SelectedIndexChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel6.Controls.Add(this.label22, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.label23, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label24, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label25, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.vap_tampon_sayisi_textbox, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.vap_tampon_boyutu_textbox, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.vap_veri_transfer_sayisi_textbox, 2, 2);
            this.tableLayoutPanel6.Controls.Add(this.vap_zaman_asimi_textbox, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.label26, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label27, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label28, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label29, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label38, 2, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(488, 275);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(151, 184);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 17);
            this.label22.TabIndex = 13;
            this.label22.Text = ":";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.Location = new System.Drawing.Point(151, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 17);
            this.label23.TabIndex = 12;
            this.label23.Text = ":";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label24.Location = new System.Drawing.Point(151, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 17);
            this.label24.TabIndex = 11;
            this.label24.Text = ":";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label25.Location = new System.Drawing.Point(151, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(13, 17);
            this.label25.TabIndex = 10;
            this.label25.Text = ":";
            // 
            // vap_tampon_sayisi_textbox
            // 
            this.vap_tampon_sayisi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vap_tampon_sayisi_textbox.Location = new System.Drawing.Point(244, 17);
            this.vap_tampon_sayisi_textbox.Name = "vap_tampon_sayisi_textbox";
            this.vap_tampon_sayisi_textbox.Size = new System.Drawing.Size(169, 20);
            this.vap_tampon_sayisi_textbox.TabIndex = 0;
            this.vap_tampon_sayisi_textbox.TextChanged += new System.EventHandler(this.vap_tampon_sayisi_textbox_TextChanged);
            // 
            // vap_tampon_boyutu_textbox
            // 
            this.vap_tampon_boyutu_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vap_tampon_boyutu_textbox.Location = new System.Drawing.Point(244, 72);
            this.vap_tampon_boyutu_textbox.Name = "vap_tampon_boyutu_textbox";
            this.vap_tampon_boyutu_textbox.Size = new System.Drawing.Size(169, 20);
            this.vap_tampon_boyutu_textbox.TabIndex = 1;
            this.vap_tampon_boyutu_textbox.TextChanged += new System.EventHandler(this.vap_tampon_boyutu_textbox_TextChanged);
            // 
            // vap_veri_transfer_sayisi_textbox
            // 
            this.vap_veri_transfer_sayisi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vap_veri_transfer_sayisi_textbox.Location = new System.Drawing.Point(244, 127);
            this.vap_veri_transfer_sayisi_textbox.Name = "vap_veri_transfer_sayisi_textbox";
            this.vap_veri_transfer_sayisi_textbox.Size = new System.Drawing.Size(169, 20);
            this.vap_veri_transfer_sayisi_textbox.TabIndex = 2;
            this.vap_veri_transfer_sayisi_textbox.TextChanged += new System.EventHandler(this.vap_veri_transfer_sayisi_textbox_TextChanged);
            // 
            // vap_zaman_asimi_textbox
            // 
            this.vap_zaman_asimi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vap_zaman_asimi_textbox.Location = new System.Drawing.Point(244, 182);
            this.vap_zaman_asimi_textbox.Name = "vap_zaman_asimi_textbox";
            this.vap_zaman_asimi_textbox.Size = new System.Drawing.Size(169, 20);
            this.vap_zaman_asimi_textbox.TabIndex = 3;
            this.vap_zaman_asimi_textbox.TextChanged += new System.EventHandler(this.vap_zaman_asimi_textbox_TextChanged);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 13);
            this.label26.TabIndex = 5;
            this.label26.Text = "Tampon Sayısı";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(82, 13);
            this.label27.TabIndex = 6;
            this.label27.Text = "Tampon Boyutu";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 131);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 13);
            this.label28.TabIndex = 7;
            this.label28.Text = "Veri Transfer Sayısı";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 186);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(67, 13);
            this.label29.TabIndex = 8;
            this.label29.Text = "Zaman Aşımı";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(503, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 294);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seçenekler";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.rx_kanal_combobox, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label14, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rx_yazilacak_dosya_adi_textbox, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cihaz_model_combobox, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 275);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // rx_kanal_combobox
            // 
            this.rx_kanal_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_kanal_combobox.FormattingEnabled = true;
            this.rx_kanal_combobox.Items.AddRange(new object[] {
            "RX1",
            "RX2"});
            this.rx_kanal_combobox.Location = new System.Drawing.Point(277, 127);
            this.rx_kanal_combobox.Name = "rx_kanal_combobox";
            this.rx_kanal_combobox.Size = new System.Drawing.Size(104, 21);
            this.rx_kanal_combobox.TabIndex = 14;
            this.rx_kanal_combobox.SelectedIndexChanged += new System.EventHandler(this.rx_kanal_combobox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(151, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = ":";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(151, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = ":";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(151, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = ":";
            // 
            // rx_yazilacak_dosya_adi_textbox
            // 
            this.rx_yazilacak_dosya_adi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_yazilacak_dosya_adi_textbox.Location = new System.Drawing.Point(244, 72);
            this.rx_yazilacak_dosya_adi_textbox.Name = "rx_yazilacak_dosya_adi_textbox";
            this.rx_yazilacak_dosya_adi_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_yazilacak_dosya_adi_textbox.TabIndex = 1;
            this.rx_yazilacak_dosya_adi_textbox.TextChanged += new System.EventHandler(this.rx_yazilacak_dosya_adi_textbox_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Cihaz Model";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Yazılacak Veri Dosyası (.bin)";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Kanal";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 294);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Veri Aktarım Parametreleri";
            // 
            // durdur_picbox
            // 
            this.durdur_picbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.durdur_picbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.durdur_picbox.Image = global::bladeRF_GUI_v1.Properties.Resources.pause;
            this.durdur_picbox.Location = new System.Drawing.Point(247, 3);
            this.durdur_picbox.Name = "durdur_picbox";
            this.durdur_picbox.Size = new System.Drawing.Size(238, 47);
            this.durdur_picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.durdur_picbox.TabIndex = 1;
            this.durdur_picbox.TabStop = false;
            this.durdur_picbox.Click += new System.EventHandler(this.durdur_picbox_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.cikti_richtextbox, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(503, 303);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(494, 294);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // cikti_richtextbox
            // 
            this.cikti_richtextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cikti_richtextbox.Location = new System.Drawing.Point(3, 3);
            this.cikti_richtextbox.Name = "cikti_richtextbox";
            this.cikti_richtextbox.ReadOnly = true;
            this.cikti_richtextbox.Size = new System.Drawing.Size(488, 229);
            this.cikti_richtextbox.TabIndex = 0;
            this.cikti_richtextbox.Text = "";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.durdur_picbox, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.baslat_picbox, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 238);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(488, 53);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // baslat_picbox
            // 
            this.baslat_picbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baslat_picbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baslat_picbox.Image = global::bladeRF_GUI_v1.Properties.Resources.start_tri;
            this.baslat_picbox.Location = new System.Drawing.Point(3, 3);
            this.baslat_picbox.Name = "baslat_picbox";
            this.baslat_picbox.Size = new System.Drawing.Size(238, 47);
            this.baslat_picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.baslat_picbox.TabIndex = 0;
            this.baslat_picbox.TabStop = false;
            this.baslat_picbox.Click += new System.EventHandler(this.baslat_picbox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RX";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.label30, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label10, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rx_frekans_textbox, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rx_ornekleme_orani_textbox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.rx_bant_genisligi_textbox, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.rx_anten_kazanci_textbox, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.rx_zaman_asimi_textbox, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label21, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.rx_biastee_checkbox, 2, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(488, 275);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 243);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 17;
            this.label30.Text = "Bias Tee";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(151, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(151, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(151, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(151, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(151, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = ":";
            // 
            // rx_frekans_textbox
            // 
            this.rx_frekans_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_frekans_textbox.Location = new System.Drawing.Point(244, 12);
            this.rx_frekans_textbox.Name = "rx_frekans_textbox";
            this.rx_frekans_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_frekans_textbox.TabIndex = 0;
            this.rx_frekans_textbox.TextChanged += new System.EventHandler(this.rx_frekans_textbox_TextChanged);
            // 
            // rx_ornekleme_orani_textbox
            // 
            this.rx_ornekleme_orani_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_ornekleme_orani_textbox.Location = new System.Drawing.Point(244, 57);
            this.rx_ornekleme_orani_textbox.Name = "rx_ornekleme_orani_textbox";
            this.rx_ornekleme_orani_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_ornekleme_orani_textbox.TabIndex = 1;
            this.rx_ornekleme_orani_textbox.TextChanged += new System.EventHandler(this.rx_ornekleme_orani_textbox_TextChanged);
            // 
            // rx_bant_genisligi_textbox
            // 
            this.rx_bant_genisligi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_bant_genisligi_textbox.Location = new System.Drawing.Point(244, 102);
            this.rx_bant_genisligi_textbox.Name = "rx_bant_genisligi_textbox";
            this.rx_bant_genisligi_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_bant_genisligi_textbox.TabIndex = 2;
            this.rx_bant_genisligi_textbox.TextChanged += new System.EventHandler(this.rx_bant_genisligi_textbox_TextChanged);
            // 
            // rx_anten_kazanci_textbox
            // 
            this.rx_anten_kazanci_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_anten_kazanci_textbox.Location = new System.Drawing.Point(244, 147);
            this.rx_anten_kazanci_textbox.Name = "rx_anten_kazanci_textbox";
            this.rx_anten_kazanci_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_anten_kazanci_textbox.TabIndex = 3;
            this.rx_anten_kazanci_textbox.TextChanged += new System.EventHandler(this.rx_anten_kazanci_textbox_TextChanged);
            // 
            // rx_zaman_asimi_textbox
            // 
            this.rx_zaman_asimi_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_zaman_asimi_textbox.Location = new System.Drawing.Point(244, 192);
            this.rx_zaman_asimi_textbox.Name = "rx_zaman_asimi_textbox";
            this.rx_zaman_asimi_textbox.Size = new System.Drawing.Size(169, 20);
            this.rx_zaman_asimi_textbox.TabIndex = 4;
            this.rx_zaman_asimi_textbox.TextChanged += new System.EventHandler(this.rx_zaman_asimi_textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Frekans";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Örnekleme Oranı";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bant Genişliği";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Anten Kazancı";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Zaman Aşımı";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(151, 241);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 17);
            this.label21.TabIndex = 16;
            this.label21.Text = ":";
            // 
            // rx_biastee_checkbox
            // 
            this.rx_biastee_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rx_biastee_checkbox.AutoSize = true;
            this.rx_biastee_checkbox.Location = new System.Drawing.Point(304, 241);
            this.rx_biastee_checkbox.Name = "rx_biastee_checkbox";
            this.rx_biastee_checkbox.Size = new System.Drawing.Size(49, 17);
            this.rx_biastee_checkbox.TabIndex = 18;
            this.rx_biastee_checkbox.Text = "Pasif";
            this.rx_biastee_checkbox.UseVisualStyleBackColor = true;
            this.rx_biastee_checkbox.CheckedChanged += new System.EventHandler(this.rx_biastee_checkbox_CheckedChanged);
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(173, 241);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(196, 13);
            this.label38.TabIndex = 15;
            this.label38.Text = "Sadece BladeRF v2.0 için test edilmiştir.";
            // 
            // UC_Okuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Okuma";
            this.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.durdur_picbox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baslat_picbox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cihaz_model_combobox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox vap_tampon_sayisi_textbox;
        private System.Windows.Forms.TextBox vap_tampon_boyutu_textbox;
        private System.Windows.Forms.TextBox vap_veri_transfer_sayisi_textbox;
        private System.Windows.Forms.TextBox vap_zaman_asimi_textbox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox rx_kanal_combobox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox rx_yazilacak_dosya_adi_textbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox durdur_picbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RichTextBox cikti_richtextbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.PictureBox baslat_picbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rx_frekans_textbox;
        private System.Windows.Forms.TextBox rx_ornekleme_orani_textbox;
        private System.Windows.Forms.TextBox rx_bant_genisligi_textbox;
        private System.Windows.Forms.TextBox rx_anten_kazanci_textbox;
        private System.Windows.Forms.TextBox rx_zaman_asimi_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox rx_biastee_checkbox;
        private System.Windows.Forms.Label label38;
    }
}
