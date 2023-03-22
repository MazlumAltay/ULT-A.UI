namespace ULTİA
{
    partial class Listeleme
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
            this.components = new System.ComponentModel.Container();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.btnListele = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ChKayitNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChUrunTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChGuncelFiyat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChMarka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ultiaDataSet = new ULTİA.UltiaDataSet();
            this.ultiaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblIsim = new System.Windows.Forms.Label();
            this.BtnVarlik = new System.Windows.Forms.Button();
            this.btnRaporListele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultiaDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.Location = new System.Drawing.Point(295, 59);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(135, 23);
            this.btnYeniKayit.TabIndex = 1;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.UseVisualStyleBackColor = true;
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(148, 59);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(130, 23);
            this.btnListele.TabIndex = 2;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChKayitNo,
            this.ChUrunTipi,
            this.ChGuncelFiyat,
            this.ChMarka,
            this.ChModel});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(418, 341);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ChKayitNo
            // 
            this.ChKayitNo.Text = "Kayıt Numarası";
            this.ChKayitNo.Width = 92;
            // 
            // ChUrunTipi
            // 
            this.ChUrunTipi.Text = "Ürün Tipi";
            this.ChUrunTipi.Width = 78;
            // 
            // ChGuncelFiyat
            // 
            this.ChGuncelFiyat.Text = "Güncel Fiyat";
            this.ChGuncelFiyat.Width = 106;
            // 
            // ChMarka
            // 
            this.ChMarka.Text = "Marka";
            this.ChMarka.Width = 75;
            // 
            // ChModel
            // 
            this.ChModel.Text = "Model";
            this.ChModel.Width = 532;
            // 
            // ultiaDataSet
            // 
            this.ultiaDataSet.DataSetName = "UltiaDataSet";
            this.ultiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultiaDataSetBindingSource
            // 
            this.ultiaDataSetBindingSource.DataSource = this.ultiaDataSet;
            this.ultiaDataSetBindingSource.Position = 0;
            // 
            // lblIsim
            // 
            this.lblIsim.AutoSize = true;
            this.lblIsim.Location = new System.Drawing.Point(385, 21);
            this.lblIsim.Name = "lblIsim";
            this.lblIsim.Size = new System.Drawing.Size(35, 13);
            this.lblIsim.TabIndex = 4;
            this.lblIsim.Text = "label1";
            // 
            // BtnVarlik
            // 
            this.BtnVarlik.Location = new System.Drawing.Point(12, 59);
            this.BtnVarlik.Name = "BtnVarlik";
            this.BtnVarlik.Size = new System.Drawing.Size(117, 23);
            this.BtnVarlik.TabIndex = 5;
            this.BtnVarlik.Text = "Ekip";
            this.BtnVarlik.UseVisualStyleBackColor = true;
            this.BtnVarlik.Click += new System.EventHandler(this.BtnVarlik_Click);
            // 
            // btnRaporListele
            // 
            this.btnRaporListele.Location = new System.Drawing.Point(13, 30);
            this.btnRaporListele.Name = "btnRaporListele";
            this.btnRaporListele.Size = new System.Drawing.Size(116, 23);
            this.btnRaporListele.TabIndex = 6;
            this.btnRaporListele.Text = "Rapor Listele";
            this.btnRaporListele.UseVisualStyleBackColor = true;
            this.btnRaporListele.Click += new System.EventHandler(this.btnRaporListele_Click);
            // 
            // Listeleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 450);
            this.Controls.Add(this.btnRaporListele);
            this.Controls.Add(this.BtnVarlik);
            this.Controls.Add(this.lblIsim);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.btnYeniKayit);
            this.Name = "Listeleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listeleme";
            this.Load += new System.EventHandler(this.Listeleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultiaDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnYeniKayit;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ChKayitNo;
        private System.Windows.Forms.ColumnHeader ChUrunTipi;
        private System.Windows.Forms.ColumnHeader ChGuncelFiyat;
        private System.Windows.Forms.ColumnHeader ChMarka;
        private System.Windows.Forms.ColumnHeader ChModel;
        private System.Windows.Forms.BindingSource ultiaDataSetBindingSource;
        private UltiaDataSet ultiaDataSet;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.Button BtnVarlik;
        private System.Windows.Forms.Button btnRaporListele;
    }
}