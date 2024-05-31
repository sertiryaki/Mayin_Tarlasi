namespace Mayin_Tarlasi03
{
    partial class Mayin_Tarlasi03
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.flag = new System.Windows.Forms.TextBox();
            this.txtSkor = new System.Windows.Forms.TextBox();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.btnOyna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flag
            // 
            this.flag.Location = new System.Drawing.Point(121, 44);
            this.flag.Name = "flag";
            this.flag.Size = new System.Drawing.Size(34, 20);
            this.flag.TabIndex = 1;
            this.flag.Text = "30";
            // 
            // txtSkor
            // 
            this.txtSkor.Location = new System.Drawing.Point(323, 44);
            this.txtSkor.Name = "txtSkor";
            this.txtSkor.Size = new System.Drawing.Size(76, 20);
            this.txtSkor.TabIndex = 2;
            // 
            // pnlPanel
            // 
            this.pnlPanel.Location = new System.Drawing.Point(25, 87);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(639, 351);
            this.pnlPanel.TabIndex = 3;
            // 
            // btnOyna
            // 
            this.btnOyna.Location = new System.Drawing.Point(180, 41);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(113, 23);
            this.btnOyna.TabIndex = 0;
            this.btnOyna.Text = "Yeniden Oyna";
            this.btnOyna.UseVisualStyleBackColor = true;
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);
            // 
            // Mayin_Tarlasi03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPanel);
            this.Controls.Add(this.txtSkor);
            this.Controls.Add(this.flag);
            this.Controls.Add(this.btnOyna);
            this.Name = "Mayin_Tarlasi03";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOyna;
        private System.Windows.Forms.TextBox flag;
        private System.Windows.Forms.TextBox txtSkor;
        private System.Windows.Forms.Panel pnlPanel;
    }
}

