namespace RC6_1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            this.EncryptButton = new System.Windows.Forms.Button();
            this.TextBoxCrypted = new System.Windows.Forms.TextBox();
            this.LabelCryptedText = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.LabelKey = new System.Windows.Forms.Label();
            this.TextBoxKey = new System.Windows.Forms.TextBox();
            this.LabelOpenText = new System.Windows.Forms.Label();
            this.TextBoxOpenText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EncryptButton
            // 
            this.EncryptButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EncryptButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncryptButton.Location = new System.Drawing.Point(205, 552);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(154, 48);
            this.EncryptButton.TabIndex = 2;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = false;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // TextBoxCrypted
            // 
            this.TextBoxCrypted.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxCrypted.Location = new System.Drawing.Point(33, 397);
            this.TextBoxCrypted.Multiline = true;
            this.TextBoxCrypted.Name = "TextBoxCrypted";
            this.TextBoxCrypted.Size = new System.Drawing.Size(775, 126);
            this.TextBoxCrypted.TabIndex = 6;
            // 
            // LabelCryptedText
            // 
            this.LabelCryptedText.AutoSize = true;
            this.LabelCryptedText.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCryptedText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelCryptedText.Location = new System.Drawing.Point(33, 368);
            this.LabelCryptedText.Name = "LabelCryptedText";
            this.LabelCryptedText.Size = new System.Drawing.Size(142, 26);
            this.LabelCryptedText.TabIndex = 7;
            this.LabelCryptedText.Text = "Crypted text";
            // 
            // DecryptButton
            // 
            this.DecryptButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecryptButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecryptButton.Location = new System.Drawing.Point(490, 552);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(154, 48);
            this.DecryptButton.TabIndex = 8;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = false;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // LabelKey
            // 
            this.LabelKey.AutoSize = true;
            this.LabelKey.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelKey.Location = new System.Drawing.Point(33, 19);
            this.LabelKey.Name = "LabelKey";
            this.LabelKey.Size = new System.Drawing.Size(54, 26);
            this.LabelKey.TabIndex = 4;
            this.LabelKey.Text = "Key";
            // 
            // TextBoxKey
            // 
            this.TextBoxKey.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxKey.Location = new System.Drawing.Point(33, 48);
            this.TextBoxKey.Multiline = true;
            this.TextBoxKey.Name = "TextBoxKey";
            this.TextBoxKey.Size = new System.Drawing.Size(775, 126);
            this.TextBoxKey.TabIndex = 5;
            this.TextBoxKey.Tag = "";
            // 
            // LabelOpenText
            // 
            this.LabelOpenText.AutoSize = true;
            this.LabelOpenText.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelOpenText.Location = new System.Drawing.Point(33, 186);
            this.LabelOpenText.Name = "LabelOpenText";
            this.LabelOpenText.Size = new System.Drawing.Size(118, 26);
            this.LabelOpenText.TabIndex = 9;
            this.LabelOpenText.Text = "Open Text";
            // 
            // TextBoxOpenText
            // 
            this.TextBoxOpenText.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxOpenText.Location = new System.Drawing.Point(33, 215);
            this.TextBoxOpenText.Multiline = true;
            this.TextBoxOpenText.Name = "TextBoxOpenText";
            this.TextBoxOpenText.Size = new System.Drawing.Size(775, 126);
            this.TextBoxOpenText.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 612);
            this.Controls.Add(this.TextBoxOpenText);
            this.Controls.Add(this.LabelOpenText);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.LabelCryptedText);
            this.Controls.Add(this.TextBoxCrypted);
            this.Controls.Add(this.TextBoxKey);
            this.Controls.Add(this.LabelKey);
            this.Controls.Add(this.EncryptButton);
            this.Name = "MainWindow";
            this.Text = "RC6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button EncryptButton;
        public System.Windows.Forms.TextBox TextBoxCrypted;
        public System.Windows.Forms.Label LabelCryptedText;
        public System.Windows.Forms.Button DecryptButton;
        public System.Windows.Forms.Label LabelKey;
        public System.Windows.Forms.TextBox TextBoxKey;
        public System.Windows.Forms.Label LabelOpenText;
        public System.Windows.Forms.TextBox TextBoxOpenText;
    }
}

