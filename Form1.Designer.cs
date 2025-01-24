namespace NtfuLedenCheck
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new System.Windows.Forms.Label();
            LidNummer = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            PostCode = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            GeboorteDatum = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            DisplayResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)DisplayResult).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(15, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 21);
            label1.TabIndex = 0;
            label1.Text = "Lidnummer";
            // 
            // LidNummer
            // 
            LidNummer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LidNummer.Location = new System.Drawing.Point(15, 35);
            LidNummer.MaxLength = 6;
            LidNummer.Name = "LidNummer";
            LidNummer.Size = new System.Drawing.Size(150, 29);
            LidNummer.TabIndex = 1;
            LidNummer.KeyUp += textBox_KeyUp;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(15, 170);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 40);
            button1.TabIndex = 4;
            button1.Text = "Controleer Lid";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PostCode
            // 
            PostCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PostCode.Location = new System.Drawing.Point(200, 35);
            PostCode.MaxLength = 6;
            PostCode.Name = "PostCode";
            PostCode.Size = new System.Drawing.Size(150, 29);
            PostCode.TabIndex = 2;
            PostCode.KeyUp += textBox_KeyUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(200, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 21);
            label2.TabIndex = 7;
            label2.Text = "Postcode";
            // 
            // GeboorteDatum
            // 
            GeboorteDatum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GeboorteDatum.Location = new System.Drawing.Point(15, 110);
            GeboorteDatum.MaxLength = 10;
            GeboorteDatum.Name = "GeboorteDatum";
            GeboorteDatum.Size = new System.Drawing.Size(150, 29);
            GeboorteDatum.TabIndex = 3;
            GeboorteDatum.KeyUp += textBox_KeyUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(15, 85);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(131, 21);
            label3.TabIndex = 9;
            label3.Text = "Geboortedatum";
            // 
            // DisplayResult
            // 
            DisplayResult.BackColor = System.Drawing.Color.Blue;
            DisplayResult.Location = new System.Drawing.Point(200, 110);
            DisplayResult.Name = "DisplayResult";
            DisplayResult.Size = new System.Drawing.Size(150, 100);
            DisplayResult.TabIndex = 11;
            DisplayResult.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(364, 226);
            Controls.Add(DisplayResult);
            Controls.Add(GeboorteDatum);
            Controls.Add(label3);
            Controls.Add(PostCode);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(LidNummer);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "NTFU LedenCheck";
            ((System.ComponentModel.ISupportInitialize)DisplayResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LidNummer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PostCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GeboorteDatum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox DisplayResult;
    }
}
