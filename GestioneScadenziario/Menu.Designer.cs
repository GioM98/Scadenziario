namespace GestioneScadenziario
{
    partial class Menu
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEsportaScadenziario = new System.Windows.Forms.Button();
            this.daData = new System.Windows.Forms.DateTimePicker();
            this.aData = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnEsportaScadenziario
            // 
            this.btnEsportaScadenziario.Location = new System.Drawing.Point(175, 186);
            this.btnEsportaScadenziario.Name = "btnEsportaScadenziario";
            this.btnEsportaScadenziario.Size = new System.Drawing.Size(175, 61);
            this.btnEsportaScadenziario.TabIndex = 0;
            this.btnEsportaScadenziario.Text = "Esporta Scadenziario";
            this.btnEsportaScadenziario.UseVisualStyleBackColor = true;
            this.btnEsportaScadenziario.Click += new System.EventHandler(this.btnEsportaScadenziario_Click);
            // 
            // daData
            // 
            this.daData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.daData.Location = new System.Drawing.Point(34, 50);
            this.daData.Name = "daData";
            this.daData.Size = new System.Drawing.Size(101, 20);
            this.daData.TabIndex = 1;
            // 
            // aData
            // 
            this.aData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.aData.Location = new System.Drawing.Point(376, 50);
            this.aData.Name = "aData";
            this.aData.Size = new System.Drawing.Size(100, 20);
            this.aData.TabIndex = 2;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 348);
            this.Controls.Add(this.aData);
            this.Controls.Add(this.daData);
            this.Controls.Add(this.btnEsportaScadenziario);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEsportaScadenziario;
        private System.Windows.Forms.DateTimePicker daData;
        private System.Windows.Forms.DateTimePicker aData;
    }
}

