namespace EncryptedDecryptedAlgo
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
            this.txtText = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtASCII = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTernary = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPolyEncryptedFormat = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(41, 44);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(876, 104);
            this.txtText.TabIndex = 0;
            this.txtText.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Text to be encrypted";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Arabolical", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnEncrypt.Location = new System.Drawing.Point(293, 166);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(148, 36);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Start Encryption";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtASCII
            // 
            this.txtASCII.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtASCII.Location = new System.Drawing.Point(230, 221);
            this.txtASCII.Name = "txtASCII";
            this.txtASCII.Size = new System.Drawing.Size(687, 54);
            this.txtASCII.TabIndex = 3;
            this.txtASCII.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(100, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "ASCII Encrypted";
            // 
            // txtTernary
            // 
            this.txtTernary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTernary.Location = new System.Drawing.Point(230, 294);
            this.txtTernary.Name = "txtTernary";
            this.txtTernary.Size = new System.Drawing.Size(687, 54);
            this.txtTernary.TabIndex = 5;
            this.txtTernary.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ternary Encrypted Format";
            // 
            // txtPolyEncryptedFormat
            // 
            this.txtPolyEncryptedFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolyEncryptedFormat.Location = new System.Drawing.Point(230, 366);
            this.txtPolyEncryptedFormat.Name = "txtPolyEncryptedFormat";
            this.txtPolyEncryptedFormat.Size = new System.Drawing.Size(687, 76);
            this.txtPolyEncryptedFormat.TabIndex = 7;
            this.txtPolyEncryptedFormat.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arabolical", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(502, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "Polynomial Encrypted Format";
            // 
            // txtDecrypted
            // 
            this.txtDecrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecrypted.Location = new System.Drawing.Point(230, 524);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.Name = "txtDecrypted";
            this.txtDecrypted.Size = new System.Drawing.Size(687, 51);
            this.txtDecrypted.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 535);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 22);
            this.label9.TabIndex = 11;
            this.label9.Text = "Decrypted Text";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Huxtable", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(438, 470);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(948, 614);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDecrypted);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPolyEncryptedFormat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTernary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtASCII);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption and Decryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

private System.Windows.Forms.RichTextBox txtText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.RichTextBox txtASCII;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtTernary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtPolyEncryptedFormat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
    }
}

